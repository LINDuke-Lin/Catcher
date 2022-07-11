using Catcher.Model.Repositorys;
using Catcher.Service.Helpers;

namespace Catcher.Service.AccountService
{
    public interface ILoginService
    {
        bool IsValid(string user, string password);
    }

    public class LoginService: ILoginService
    {
        private readonly ITestEFRepository testEFRepo;

        public LoginService(ITestEFRepository testEFRepo)
        {
            this.testEFRepo = testEFRepo;
        }

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
            testEFRepo.Create();
            var myUser = testEFRepo.GetUser().ToList();

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
