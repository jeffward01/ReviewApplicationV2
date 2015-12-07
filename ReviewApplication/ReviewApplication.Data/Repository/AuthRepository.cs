using Microsoft.AspNet.Identity;
using ReviewApplication.API.Models;
using ReviewApplication.CORE.Infrastructure;
using ReviewApplication.CORE.Repository;
using ReviewApplication.CORE.Models;
using ReviewApplication.CORE.Domain;
using ReviewApplication.Data.Infrastructure;
using ReviewApplication.CORE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReviewApplication.DATA.Infrastructure;

namespace ReviewApplication.Data.Repository
{
    public class AuthRepository : IAuthRepository, IDisposable
    {
        
        private readonly IDatabaseFactory _databaseFactory;
        private UserManager<User, int> _userManager;
        private readonly IUserStore<User, int> _userStore;

        private ReviewApplicationDbContext _dataContext;
        protected ReviewApplicationDbContext DataContext
        {
            get
            {
                return _dataContext ?? (_dataContext = _databaseFactory.GetDataContext());
            }
        }

        public AuthRepository(IDatabaseFactory databaseFactory, IUserStore<User, int> userStore)
        {
            _userStore = userStore;
            _databaseFactory = databaseFactory;
            _userManager = new UserManager<User, int>(userStore);
        }

        public async Task<IdentityResult> RegisterUser(RegistrationModel registrationModel)
        {
            User user = new User
            {
                UserName = registrationModel.UserName
            };

            var result = await _userManager.CreateAsync(user, registrationModel.Password);

            return result;
        }

        public async Task<User> FindUser(string userName, string password)
        {
            return await _userManager.FindAsync(userName, password);

        }

        public void Dispose()
        {
            _userManager.Dispose();

        }
    }

}
