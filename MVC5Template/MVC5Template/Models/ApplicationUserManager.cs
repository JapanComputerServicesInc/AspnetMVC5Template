using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace MVC5Template.Models
{
    /// <summary>
    /// UserStoreを使ったユーザー情報管理を自動化したAPIを提供します。
    /// </summary>
    public class ApplicationUserManager : UserManager<ApplicationUser>  // （1）
    {
        /// <summary>
        /// UserStoreを使用して ApplicationUserManager クラスの新しいインスタンスを生成します。
        /// </summary>
        /// <param name="store"></param>
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        /// <summary>
        /// ApplicationUserManager クラスのインスタンスを作成します。
        /// </summary>
        /// <param name="options"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new ApplicationUserStore());  // （2）
            return manager;
        }
    }
}