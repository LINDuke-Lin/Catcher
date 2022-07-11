using Catcher.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catcher.Model.Repositorys
{
    public interface ITestEFRepository
    {
        void Create();
        IEnumerable<MyUser> GetUser();
    }
    public class TestEFRepository: ITestEFRepository
    {
        private readonly CatcherDB db;
        public TestEFRepository(CatcherDB dbContext)
        {
            db = dbContext;
        }


        public void Create()
        {
            db.MyUsers.Add(new MyUser
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                Password = "1234",
            });
            db.SaveChanges();
        }

        public IEnumerable<MyUser> GetUser()
        {
            return db.MyUsers;
        }
    }
}
