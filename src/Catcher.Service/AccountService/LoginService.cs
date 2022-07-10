using Catcher.Service.Helpers;

namespace Catcher.Service.AccountService
{
    public interface ILoginService
    {
        bool IsValid(string user, string password);
    }

    public class LoginService: ILoginService
    {
        private static List<AspNetUsers> userList = new List<AspNetUsers>()
        {
            new AspNetUsers()
            {
                User ="Admin",
                PasswordHash=""
            }
        };

        public bool IsValid(string user, string password)
        {
            List<AspNetUsers> item = userList.Where(x => x.User.Equals(user)).ToList();
            if (item.Count <= 0) { return false; }
            return HashedHelper.VerifyHashedPassword(item[0].PasswordHash, password);
        }
    }

    public class AspNetUsers
    {
        public string User { get; set; }
        public string PasswordHash { get; set; }
    }
}
