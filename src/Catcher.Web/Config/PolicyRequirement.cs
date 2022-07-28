using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Catcher.Web.Config
{

    /// <summary>
    /// 許可權承載實體
    /// </summary>
    public class PolicyRequirement : IAuthorizationRequirement
    {
        /// <summary>
        /// 使用者許可權集合
        /// </summary>
        public List<UserPermission> UserPermissions { get; private set; }
        /// <summary>
        /// 無許可權action
        /// </summary>
        public string DeniedAction { get; set; }
        /// <summary>
        /// 構造
        /// </summary>
        public PolicyRequirement()
        {
            //沒有許可權則跳轉到這個路由
            DeniedAction = new PathString("/Home/Index");
            ////使用者有許可權訪問的路由配置,當然可以從資料庫獲取
            //UserPermissions = new List<UserPermission> {
            //                  new UserPermission {  Url="/api/values3", UserName="admin"},
            //              };
        }
    }

    /// <summary>
    /// 使用者許可權承載實體
    /// </summary>
    public class UserPermission
    {
        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 請求Url
        /// </summary>
        public string Url { get; set; }
    }
}
