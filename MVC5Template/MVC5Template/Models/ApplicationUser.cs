using Microsoft.AspNet.Identity;

namespace MVC5Template.Models
{
    /// <summary>
    /// ユーザー情報を管理します
    /// </summary>
    public class ApplicationUser : IUser<string>
    {
        /// <summary>
        /// ユーザーを識別するためのキーです。
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// ユーザーの名前です。
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// ユーザーのパスワードのハッシュ値です。
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Id を使用して ApplicationUser クラスの新しいインスタンスを生成します。
        /// </summary>
        /// <param name="id"></param>
        public ApplicationUser(string id)
        {
            this.Id = id;
        }
    }
}