using Catcher.Model.Entities;

namespace Catcher.Model.Repositorys;

public interface IUsersRepository
{
    /// <summary>
    /// load all user data from db
    /// </summary>
    /// <returns></returns>
    List<MyUser> Load();
}

public class UsersRepository:IUsersRepository
{
    private readonly CatcherDb _dbContext;

    public UsersRepository(CatcherDb dbContext)
    {
        this._dbContext = dbContext;
    }
    
    /// <summary>
    /// load all user data from db
    /// </summary>
    /// <returns></returns>
    public List<MyUser> Load()
    {
        return _dbContext.MyUsers.ToList();
    }
}