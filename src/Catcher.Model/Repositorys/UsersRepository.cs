using Catcher.Model.Caches;
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

public class UsersRepository : IUsersRepository
{
    private readonly CatcherDb _dbContext;
    private readonly IRedisDao _redisDao;

    public UsersRepository(CatcherDb dbContext, IRedisDao redisDao)
    {
        _dbContext = dbContext;
        _redisDao = redisDao;
    }

    /// <summary>
    /// load all user data from db
    /// </summary>
    /// <returns></returns>
    public List<MyUser> Load() => _dbContext.MyUsers.ToList();
}