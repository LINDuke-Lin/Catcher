using Catcher.Model.Entities;

namespace Catcher.Model.Repositorys
{
    public interface IErrorReopsitory
    {
        void Create();
    }

    public class ErrorReopsitory : IErrorReopsitory
    {
        private readonly CatcherDb _dbContext;

        public ErrorReopsitory(CatcherDb dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create()
        {
            var guid = Guid.NewGuid().ToString();


            ErrorTitle errorTitle = new ErrorTitle()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "test log",
                TypeCode = guid,
                ErrorDate = DateTime.Now,
                Memo = "測試用"
            };

            List<ErrorBody> errorBodies = new()
            {
                new ErrorBody()
                {
                    Id= Guid.NewGuid().ToString(),
                    TypeCode=guid,
                    Type="Error",
                    Qty=5
                },
                 new ErrorBody()
                {
                    Id= Guid.NewGuid().ToString(),
                    TypeCode=guid,
                    Type="Info",
                    Qty=50
                },
                  new ErrorBody()
                {
                    Id= Guid.NewGuid().ToString(),
                    TypeCode=guid,
                    Type="Debug",
                    Qty=15
                }
            };


            _dbContext.ErrorTitle.Add(errorTitle);
            errorBodies.ForEach(data =>
            {
                _dbContext.ErrorBody.Add(data);
            });

            _dbContext.SaveChanges();
        }
    }
}
