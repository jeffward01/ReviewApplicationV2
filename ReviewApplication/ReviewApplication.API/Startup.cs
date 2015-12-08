using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using ReviewApplication.Core.Communication;
using ReviewApplication.Core.Domain;
using ReviewApplication.Core.Infrastructure;
using ReviewApplication.Core.Repository;
using ReviewApplication.Data.Infrastructure;
using ReviewApplication.Data.Repository;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using SimpleInjector.Integration.WebApi;
using System.Web.Http;

[assembly: OwinStartup(typeof(ReviewApplication.API.Startup))]
namespace ReviewApplication.API
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Container container = ConfigureSimpleInjector(app);

            HttpConfiguration config = new HttpConfiguration
            {
                DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container)
            };

            WebApiConfig.Register(config);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(config);
        }

        //Register Container for classes that use dependecy Injection
        private Container ConfigureSimpleInjector(IAppBuilder app)
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            container.Register<IUserStore<User, int>, UserStore>(Lifestyle.Scoped);

            container.Register<IDatabaseFactory, DatabaseFactory>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>();

            container.Register<IAuthRepository, AuthRepository>();
            container.Register<ICommentRepository, CommentRepository>();
            container.Register<IUserRepository, UserRepository>();
            container.Register<ICompanyProfileRepository, CompanyProfileRepository>();
            container.Register<IInsuranceAgentProfileRepository, InsuranceAgentProfileRepository>();
            container.Register<ILeadProductRepository, LeadProductRepository>();
            container.Register<ILeadTransactionRepository, LeadTransactionRepository>();
            container.Register<IReviewPostRepository, ReviewPostRepository>();
            container.Register<IIndustryRepository, IndustryRepository>();
            container.Register<IExternalLoginRepository, ExternalLoginRepository>();
            container.Register<ISmsClient, TwilioSmsClient>();


            app.Use(async (context, next) => {
                    using (container.BeginExecutionContextScope())
                    {
                        await next();
                    }
                });

            container.Verify();

            return container;
        }



        /*
        public void ConfigureOAuth(IAppBuilder app)
        {
            //Configure OAuth for our Application
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                Provider = new SimpleAuthorizationServerProvider()
            };

            //Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
            */
        
    }
}
