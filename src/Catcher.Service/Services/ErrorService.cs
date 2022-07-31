using Catcher.Model.Repositorys;

namespace Catcher.Service.Services
{

    public interface IErrorService
    {
        void Create();
    }
    public class ErrorService: IErrorService
    {
        private readonly IErrorReopsitory _errorRepo;

        public ErrorService(IErrorReopsitory errorRepo)
        {
            _errorRepo = errorRepo;
        }

        public void Create()
        {
            _errorRepo.Create();
        }
    }
}
