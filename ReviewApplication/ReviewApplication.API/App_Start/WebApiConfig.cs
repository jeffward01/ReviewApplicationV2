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


        public static void SetupAutomapper()
        {   
            Mapper.CreateMap<Comment, CommentModel>();
            Mapper.CreateMap<Company, CompanyModel>();
            Mapper.CreateMap<Industry, IndustryModel>();
            Mapper.CreateMap<CompanyIndustry, CompanyIndustryModel>();
            Mapper.CreateMap<InsuranceAgentIndustry, InsuranceAgentIndustryModel>();
            Mapper.CreateMap<InsuranceAgent, InsuranceAgentModel>();
            Mapper.CreateMap<LeadProduct, LeadProductModel>();
            Mapper.CreateMap<LeadTransaction, LeadTransactionModel>();
            Mapper.CreateMap<ReviewPost, ReviewPostModel>();
            Mapper.CreateMap<ExternalLogin, ExternalLoginModel>();
            Mapper.CreateMap<User, UserModel>();
            
        }
    }
}
