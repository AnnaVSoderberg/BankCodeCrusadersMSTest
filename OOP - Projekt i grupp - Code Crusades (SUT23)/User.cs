using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    public class User
    {


        public string Username { get; set; }
        public string Pin { get; set; }
        public bool Role { get; set; }
        public List<Accounts> Accounts { get; set; }
        public List<Loan> Loans { get; set; }
        public List<TransferLog> TransferLogs { get; set; }

        public User(string username, string pin, bool role)
        {
            Username = username;
            Pin = pin;
            Role = role;
            Accounts = new List<Accounts>();
            Loans = new List<Loan>();
            TransferLogs = new List<TransferLog>();
        }

        public void AddLoan(Loan loan)
        {
            Loans.Add(loan);
        }

        public void LogTransfer(TransferLog log)
        {
            TransferLogs.Add(log);
        }

        public void PrintTransferHistory()
        {

            foreach (var log in TransferLogs)
            {
                Console.WriteLine(log.TransferDetails);
            }

            Console.ReadKey();

        }


        public static void Login()
        {
            Logo.CreateLogo();
            int loginAttempts = 0;

            Console.Clear();
            Console.WriteLine("\n\tVälkommen till Bankomaten!");

            while (loginAttempts < 3)
            {
                Console.Write("\n\tAnge ditt Användar-ID: ");
                string username = Console.ReadLine();

                Console.Write("\n\tAnge din pinkod: ");
                string pin = GetPassword();

                User UserLogin = Start.CustomerList.Find(u => u.Username == username && u.Pin == pin);

                if (UserLogin != null)
                {
                    UserContext.CurrentUser = UserLogin;
                    loginAttempts = 0;
                    Console.WriteLine($"\n" +
                        $"\n\tInloggning lyckades. Välkommen!" +
                        "\n\tTryck \"Enter\" för att Fortsätta ");
                    Console.ReadKey();

                    Menu.startMenuForUser();
                }
                else
                {
                    Console.WriteLine("\n" +
                        "\n\tFelaktigt användarnamn eller pinkod. Försök igen.");
                    loginAttempts++;
                }
            }

            Console.WriteLine("\n\tFör många felaktiga inloggningsförsök. " +
                "\n\tProgrammet avslutas....");
            Console.ReadKey();
            Environment.Exit(0);
        }
        private static string GetPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                    break;

                if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                    Console.Write("\b \b");
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
            } while (true);

            return password;
        }
    }

}