using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M4Trader.ordenes.services.Entities
{ 
    public class LoginModel
    {
        public string JavascriptToRun { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(64)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "*")]
        public string Password { get; set; }

        public bool NeedNewPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }

        public string Msg { get; set; }

        public string LoginState { get; set; }

        public string SecurityToken { get; set; }

        public string TokenGuid { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public LoginModel()
        {
            UserName = "";
            Password = "";
            Msg = "";
            LoginState = "";
            NeedNewPassword = false;
            SecurityToken = "";
        }

        public LoginModel(string username, string password, string msg, string loginState, bool needNewPass, string securityToken)
        {
            UserName = username;
            Password = password;
            Msg = msg;
            LoginState = loginState;
            NeedNewPassword = needNewPass;
            SecurityToken = securityToken;
        }
    } 
}
