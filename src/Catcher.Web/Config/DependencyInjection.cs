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
        }
    }
}
