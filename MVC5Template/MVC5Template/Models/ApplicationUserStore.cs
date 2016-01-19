using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;

namespace MVC5Template.Models
{
    /// <summary>
    /// ユーザーの管理用APIを提供します。
    /// </summary>
    public class ApplicationUserStore :
        IUserStore<ApplicationUser>,
        IUserPasswordStore<ApplicationUser>
    {
        public Task CreateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<ApplicationUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ユーザー名を使いユーザーを検索します。
        /// </summary>
        /// <param name="userName">ユーザー名。</param>
        /// <returns>見つかったユーザー情報。見つからない場合はnullを返す。</returns>
        public Task<ApplicationUser> FindByNameAsync(string userName)  // （3）
        {
            // ここで外部サービス等からユーザー情報を取得する
            var hasher = new PasswordHasher();
            var user = new ApplicationUser(Guid.NewGuid().ToString())
            {
                UserName = userName,
                PasswordHash = hasher.HashPassword("123456")
            };
            return Task.FromResult(user);
        }

        /// <summary>
        /// ユーザーのハッシュ処理されたパスワードを取得します。
        /// </summary>
        /// <param name="user">ユーザー情報。</param>
        /// <returns>ユーザーのハッシュ処理されたパスワード。</returns>
        public Task<string> GetPasswordHashAsync(ApplicationUser user)  // （5）
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}