using ClubMembershipApplication.Data;
using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    public class UserLoginView : IView
    {
        ILogin _loginUser = null;
        public IFieldValidator FieldValidator => null;
        public UserLoginView(ILogin login) {
        _loginUser = login;
        }

        public void RunView()
        {
            CommonOutputText.WriteMainHeading();

            CommonOutputText.WriteLoginHeading();

            Console.Write("Please enter your email address: ");

            string emailAddress=Console.ReadLine();

            Console.Write("Please enter your password: ");

            string password=Console.ReadLine();

            User user=_loginUser.Login(emailAddress, password);

            if(user != null )
            {
                WelcomeUserView welcomeUserView = new WelcomeUserView(user);
                welcomeUserView.RunView();
            }
            else
            {
                Console.Clear();
                CommonOutputFormat.ChangeFontColor(FontTheme.Danger);
                Console.WriteLine("The credentials provided do not match any of our records");
                CommonOutputFormat.ChangeFontColor(FontTheme.Default);
                Console.ReadKey();
            }
        }
    }
}
