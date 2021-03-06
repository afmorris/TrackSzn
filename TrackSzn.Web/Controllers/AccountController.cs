﻿using System;
using System.Configuration;
using System.IdentityModel.Services;
using System.Web;
using System.Web.Mvc;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using ServiceStack.Mvc;

namespace TrackSzn.Web.Controllers
{
    [RoutePrefix("account")]
    public class AccountController : ServiceStackController
    {
        [Route("login")]
        public ActionResult Login(string returnUrl)
        {
            var client = new AuthenticationApiClient(new Uri($"https://{ConfigurationManager.AppSettings["auth0:Domain"]}"));

            var request = this.Request;
            var redirectUri = new UriBuilder(request.Url.Scheme, request.Url.Host, this.Request.Url.IsDefaultPort ? -1 : request.Url.Port, "LoginCallback.ashx");

            var authorizeUrlBuilder = client.BuildAuthorizationUrl()
                .WithClient(ConfigurationManager.AppSettings["auth0:ClientId"])
                .WithRedirectUrl(redirectUri.ToString())
                .WithResponseType(AuthorizationResponseType.Code)
                .WithScope("openid profile")
                // adding this audience will cause Auth0 to use the OIDC-Conformant pipeline
                // you don't need it if your client is flagged as OIDC-Conformant (Advance Settings | OAuth)
                .WithAudience($"https://{ConfigurationManager.AppSettings["auth0:Domain"]}/userinfo");

            if (!string.IsNullOrEmpty(returnUrl))
            {
                var state = "ru=" + HttpUtility.UrlEncode(returnUrl);
                authorizeUrlBuilder.WithState(state);
            }

            return new RedirectResult(authorizeUrlBuilder.Build().ToString());
        }

        [Route("logout")]
        public ActionResult Logout()
        {
            FederatedAuthentication.SessionAuthenticationModule.SignOut();

            // Redirect to Auth0's logout endpoint.
            // After terminating the user's session, Auth0 will redirect to the 
            // returnTo URL, which you will have to add to the list of allowed logout URLs for the client.
            var returnTo = Url.Action("Index", "Home", null, Request.Url.Scheme);
            return Redirect($"https://{ConfigurationManager.AppSettings["auth0:Domain"]}/v2/logout?returnTo={Server.UrlEncode(returnTo)}&client_id={ConfigurationManager.AppSettings["auth0:ClientId"]}");
        }
    }
}