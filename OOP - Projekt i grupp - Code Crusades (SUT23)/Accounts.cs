using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    public class Accounts
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }

        public Accounts(string name, decimal balance, string currency)
        {
            Name = name;
            Balance = balance;
            Currency = currency;
        }

        public static string GetAccountSummary(User user)
        {
            var output = new StringWriter();
            output.WriteLine("\n\tDina konton & saldo:");

            foreach (var account in user.Accounts)
            {
                string formattedBalance = account.Balance.ToString("F2", CultureInfo.InvariantCulture);
                output.WriteLine($"\n\t{account.Name}: {formattedBalance} {account.Currency}");
            }

            return output.ToString();
        }

        public static void PrintAcc(Func<ConsoleKeyInfo> readKey)
        {
            var summary = GetAccountSummary(UserContext.CurrentUser);
            Console.WriteLine(summary);
            readKey();
        }
    }
}
