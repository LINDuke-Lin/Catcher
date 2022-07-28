using Catcher.Model.Repositorys;
using Catcher.Service.Helpers;

namespace Catcher.Service.AccountService
{
    public interface ILoginService
    {
        bool IsValid(string user, string password);
    }

    public class LoginService : ILoginService
    {
        private readonly IUsersRepository _userRepo;

        public LoginService(IUsersRepository userRepo)
        {
            this._userRepo = userRepo;
        }

        /// <summary>
        /// check the user and password is valid
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValid(string user, string password)
        {
            try
            {
                var item = _userRepo.Load();
                if (item.Count <= 0) return false;
                return HashedHelper.VerifyHashedPassword(item[0].Password, password);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
