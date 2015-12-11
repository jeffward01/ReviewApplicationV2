using AutoMapper;
using ReviewApplication.Core.Domain;
using ReviewApplication.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ReviewApplication.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Enable cross origin requests to API
            var cors = new EnableCorsAttribute(
                origins: "*",
                headers: "*",
                methods: "*"
            );
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Remove XML format inorder to return JSON
            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

            SetupAutomapper();

        }


        private static void SetupAutomapper()
        {   
            Mapper.CreateMap<Comment, CommentModel>();
            Mapper.CreateMap<Company, CompanyProfileModel>();
            Mapper.CreateMap<InsuranceAgent, InsuranceAgentProfileModel>();
            Mapper.CreateMap<LeadProduct, LeadProductModel>();
            Mapper.CreateMap<LeadTransaction, LeadTransactionModel>();
            Mapper.CreateMap<ReviewPost, ReviewPostModel>();
            Mapper.CreateMap<User, UserModel>();
            
        }
    }
}
