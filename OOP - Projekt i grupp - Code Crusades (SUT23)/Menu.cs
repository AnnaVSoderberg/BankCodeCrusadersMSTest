using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    internal class Menu
    {
        public static void startMenuForUser()
        {
            bool IsAdmin = UserContext.CurrentUser.Role;
            List<string> Menulist = new List<string>();
            var userService = new UserService();
            var createUser = new CreateUser(userService);

            if (IsAdmin == true)
            {
                Menulist.Add("\tSkapa ny användare");
                Menulist.Add("\tsätt valutakurs");
                Menulist.Add("\tLogga ut");
                Menulist.Add("\tAvsluta");
                while (true)
                {
                    int menuSelected = startMenuArrow(Menulist);
                    switch (menuSelected)
                    {
                        case 0:
                            createUser.AddUser();
                            break;
                        case 1:
                            ExchangeRate.SetExchangeRate();
                            break;
                        case 2:
                            Console.WriteLine("\n\tDu loggas ut" +
                                "\n\tTryck Enter...");
                            Console.ReadKey();
                            User.Login();
                            break;
                        case 3:
                            Console.WriteLine("\n\tProgrammet avslutas" +
                                "\n\tTryck Enter för att avsluta programmet...");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                    }
                }
            }
            else
            {
                Menulist.Add("\tSe konton");
                Menulist.Add("\tÖverföring");
                Menulist.Add("\tÖverföring till annan användare");
                Menulist.Add("\tÖppna nytt sparkonto");
                Menulist.Add("\tÖppna nytt konto");
                Menulist.Add("\tÖverföringshistorik");
                Menulist.Add("\tLåneförfrågan");
                Menulist.Add("\tLogga ut");
                Menulist.Add("\tAvsluta");
                while (true)
                {
                    int menuSelected = startMenuArrow(Menulist);

                    switch (menuSelected)
                    {
                        case 0:
                            Accounts.PrintAcc(Console.ReadKey);
                            break;
                        case 1:
                            Transfer.TransferMoney();
                            break;
                        case 2:
                            TransferUser.TransferToUser();                            
                            break;
                        case 3:
                            SavingsAccount.CreateSavingsAccount();
                            break;
                        case 4:
                            CheckingAccount.CreateAccount();
                            break;
                        case 5:
                            UserContext.CurrentUser.PrintTransferHistory();
                            break;
                        case 6:
                            var userContext = UserContext.CurrentUser; // Assuming UserContext is static
                            Func<string> readLine = Console.ReadLine;
                            Action<string> writeLine = Console.WriteLine;
                            Action clear = Console.Clear;
                            RequestLoan.Loan(UserContext.CurrentUser, readLine, writeLine, clear);
                            break;
                        case 7:
                            Console.WriteLine("\n\tDu loggas ut" +
                                "\n\tTryck Enter...");
                            Console.ReadKey();
                            User.Login();
                            break;
                        case 8:
                            Console.WriteLine("\n\tProgrammet avslutas" +
                                "\n\tTryck Enter för att avsluta programmet...");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
        public static int startMenuArrow(List<string> MenuList)
        {
            int menuSelected = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n\tGör ditt val med piltangenterna och tryck Enter för att välja:\n");
                for (int i = 0; i < MenuList.Count; i++)
                {
                    if (menuSelected == i)
                    {
                        Console.WriteLine("-->" + MenuList[i]);
                    }
                    else
                    {
                        Console.WriteLine(MenuList[i]);
                    }
                }
                var keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.DownArrow && menuSelected != MenuList.Count - 1)
                {
                    menuSelected++;
                }
                else if (keyPressed.Key == ConsoleKey.UpArrow && menuSelected >= 1)
                {
                    menuSelected--;
                }
                else if (keyPressed.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    return menuSelected;
                }
            }
        }
    }
}
