

using Catcher.Model.Caches;
using Catcher.Service.Helpers;
using Catcher.Service.Services;

namespace Catcher.Web.Config
{
    public static class DependencyInjection
    {
        /// <summary>
        /// 依賴注入容器
        /// </summary>
        /// <param name="builder"></param>
        public static void Container(WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ILoginService, LoginService>();

            builder.Services.AddTransient<IErrorService, ErrorService>();

            builder.Services.AddTransient<IUsersRepository, UsersRepository>();

            builder.Services.AddTransient<IErrorReopsitory, ErrorReopsitory>();

            builder.Services.AddSingleton<JwtHelpers>();

            builder.Services.AddSingleton<IRedisDao, RedisDao>();
        }
    }
}
