﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MvcCoreSeguridadEmpleados.Repositories;

namespace MvcCoreSeguridadEmpleados.Filters
{
    public class AuthorizeEmpleadosAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            string controller = context.RouteData.Values["controller"]!.ToString()!;
            string action = context.RouteData.Values["action"]!.ToString()!;

            //RepositoryHospital repo = context.HttpContext.RequestServices.GetService<RepositoryHospital>();

            ITempDataProvider provider = context.HttpContext.RequestServices.GetService<ITempDataProvider>()!;
            var TempData = provider.LoadTempData(context.HttpContext);

            TempData["controller"] = controller;
            TempData["action"] = action;

            provider.SaveTempData(context.HttpContext, TempData);

            if (user.Identity.IsAuthenticated == false)
            {
                context.Result = this.GetRoute("Managed", "Login");
            }
            else
            {
                if (user.IsInRole("PRESIDENTE") == false
                && user.IsInRole("DIRECTOR") == false
                && user.IsInRole("ANALISTA") == false)
                {
                    context.Result = this.GetRoute("Managed", "ErrorAcceso");
                }
            }
        }

        private RedirectToRouteResult GetRoute(string controller, string action)
        {
            RouteValueDictionary route = new(
                new
                {
                    controller,
                    action
                }
            );
            return new RedirectToRouteResult(route);
        }
    }
}
