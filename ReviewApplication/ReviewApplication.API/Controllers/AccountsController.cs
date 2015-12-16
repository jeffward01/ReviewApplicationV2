using Microsoft.AspNet.Identity;
using ReviewApplication.API.Models;
using ReviewApplication.Core.Communication;
using ReviewApplication.Core.Infrastructure;
using ReviewApplication.Core.Models;
using ReviewApplication.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;

namespace ReviewApplication.API.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountsController : ApiController
    {
        private IAuthRepository _authRepository = null;
        private ISmsClient _smsClient;

        public AccountsController(IAuthRepository authRepository, ISmsClient smsClient)
        {
            _authRepository = authRepository;
            _smsClient = smsClient;
        }




        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegistrationModel registration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _authRepository.RegisterUser(registration);

            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            //Insert Registration Logic here

           // _smsClient.SendText("9092247557", "9098108106", "Your account has been created");

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _authRepository.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
