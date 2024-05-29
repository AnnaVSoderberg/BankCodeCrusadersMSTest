using OOP___Projekt_i_grupp___Code_Crusades__SUT23_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class UserContext
    {
        public static User CurrentUser { get; set; }
        public static User TargetUser { get; set; }
    }
}
