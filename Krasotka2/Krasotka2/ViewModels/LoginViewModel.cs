using Krasotka2.Entities;
using Krasotka2.Entities.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krasotka2.ViewModels
{
    public class LoginViewModel:ViewModelBase
    {
        private List<User> _users;
        private string _login;
        private string _password;

        public string Password
        {
            get { return _password; }
            set { Set(ref _password, value, nameof(Password)); }
        }

        public string Login
        {
            get { return _login; }
            set { Set(ref _login, value, nameof(Login)); }
        }
        public LoginViewModel()
        {
            using(ApplicationDbContext context = new())
            {
                _users = context.Users
                    .Include(r => r.RoleNavigation)
                    .ToList();
            }
        }        
        //проверяет имеется ли пользователь в бд
        public User Sign()
        {
            if(_users.Any(l=>l.Login==Login && l.Password == Password))
            {   
                        //возвращает пользователя       
                return _users.FirstOrDefault(l => l.Login == Login && l.Password == Password);
            }
            else return null;
        }
    }
}
