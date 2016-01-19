using System.ComponentModel.DataAnnotations;

namespace MVC5Template.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "ユーザー名を入れてください")]
        [Display(Name = "ユーザー名")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "パスワードを入れてください")]
        [Display(Name = "パスワード")]
        public string Password { get; set; }
    }
}
