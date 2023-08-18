using ClubMembershipApplication.FieldValidators;
using ClubMembershipApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembershipApplication.Views
{
    public class WelcomeUserView : IView
    {
        User user=null;

        public WelcomeUserView(User user)
        {
            this.user = user;
        }

        public IFieldValidator FieldValidator => null;

        public void RunView()
        {
            Console.Clear();
            CommonOutputText.WriteMainHeading();
            CommonOutputFormat.ChangeFontColor(FontTheme.Success);
            Console.WriteLine($"Hi {user.LastName}!!{Environment.NewLine}Welcome to the Cycling Club");
            CommonOutputFormat.ChangeFontColor(FontTheme.Default);
            Console.ReadKey();
        }
    }
}
