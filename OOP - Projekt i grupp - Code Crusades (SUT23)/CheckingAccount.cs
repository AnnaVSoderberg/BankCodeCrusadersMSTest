using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    public class CheckingAccount : Accounts
    {
        public CheckingAccount(string name, decimal balance, string currency) : base(name, balance, currency)
        {}
        public static void CreateAccount()
        {
            Console.Write("\n\tVad vill du döpa ditt konto till: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                name = "Checking Account";                                  //Default name if the user doesnt add anything
            }
            
            decimal insert = 0;
            bool validInput = false;
            do
            {
                Console.Write("\n\tHur mycket vill du sätta in: ");
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out insert) && insert > 0)                             // The user has to add atleast 1.  
                {
                    validInput = true;
                }
                else if (insert < 0)
                {
                    Console.WriteLine("\n\tBeloppet du matar in måste vara större än 0.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("\n\tOgiltig inmatning, var god försök igen.");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (!validInput);
            List<string> currencyOpt = new List<string> { "\tSEK", "\tUSD" };
            Console.WriteLine("\n\tVilken valuta vill du ha?" +
                "\n\tTryck Enter för att göra ditt val.");
            Console.ReadKey();
            int menuSelected = Menu.startMenuArrow(currencyOpt);

            string currency = null;
            switch (menuSelected)
            {
                case 0:
                    currency = "SEK";
                    break;
                case 1:
                    currency = "USD";
                    break;
            }

            Console.WriteLine($"\n\tDitt nya konto: \"{name}\" med beloppet: {Math.Round(insert, 2 )} {currency} har skapats.");
            UserContext.CurrentUser.Accounts.Add(new CheckingAccount(name, insert, currency));
            
            Console.ReadKey();
        }
    }
}
