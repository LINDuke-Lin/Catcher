using Catcher.Model.Caches;
using Catcher.Model.Entities;
using System.Collections.Generic;

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
    public List<MyUser> Load()
    {
        List<MyUser> res = new();
        res = _dbContext.MyUsers.ToList();
        return res;
    }
}