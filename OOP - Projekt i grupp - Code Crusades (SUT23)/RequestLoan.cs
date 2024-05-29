using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    public class RequestLoan
    {
        public static decimal InterestRate = 0.05m; // A decimal to control the interest rate
        public static void Loan(User user, Func<string> readLine, Action<string> writeLine, Action clear)
        {
            decimal totalCapital = user.Accounts.Sum(account => account.Balance);
            decimal maxLoan = totalCapital * 5;
            writeLine($"\n\tDu kan maximalt låna {maxLoan:0.00}" +
                $"\n\tAnge önskat belopp: ");

            while (true)
            {
                if (decimal.TryParse(readLine(), out decimal loanInput) && loanInput > 0)
                {
                    if (loanInput <= maxLoan)
                    {
                        decimal interest = CalculateInterest(loanInput);
                        clear();
                        writeLine($"\n\tRäntesatsen ligger på {InterestRate * 100}%. Det innebär att räntan för lånet är {interest}");
                        Loan newLoan = new Loan(loanInput, InterestRate);
                        user.AddLoan(newLoan);

                        // Prompt user to select an account
                        writeLine("\n\tVälj konto för insättning:");
                        for (int i = 0; i < user.Accounts.Count; i++)
                        {
                            writeLine($"\t{i}: {user.Accounts[i].Name} - Saldo: {user.Accounts[i].Balance:0.00} {user.Accounts[i].Currency}");
                        }
                        writeLine("\tAnge kontonummer: ");

                        // Validate account selection
                        while (true)
                        {
                            var input = readLine();
                            if (int.TryParse(input, out int selectedIndex) && selectedIndex >= 0 && selectedIndex < user.Accounts.Count)
                            {
                                DepositLoan(user, loanInput, readLine, writeLine, clear, selectedIndex);
                                break; // Exit loop after successful deposit
                            }
                            else
                            {
                                writeLine("\n\tFel inmatning, försök igen.");
                            }
                        }

                        break; // Exit the loop after successful loan processing
                    }
                    else
                    {
                        writeLine($"\n\tDu kan maximalt låna {maxLoan:0.00}.");
                    }
                }
                else
                {
                    writeLine("\n\tFel inmatning, försök igen.");
                }
            }
        }
        public static decimal CalculateInterest(decimal loanAmount)
        {
            return loanAmount * InterestRate;
        }

        public static void DepositLoan(User user, decimal loanAmount, Func<string> readLine, Action<string> writeLine, Action clear, int selectedIndex)
        {
            writeLine("\n\tPå vilket konto vill du sätta in pengarna?\n");

            writeLine("\n\tDina konton & saldo:");
            foreach (var account in user.Accounts)
            {
                writeLine($"\n\t{account.Name}: {account.Balance:0.00} {account.Currency}");
            }

            writeLine(" ");
            writeLine("\n\tTryck Enter för att välja konton");
            readLine();

            var chosenAccount = user.Accounts[selectedIndex];
            chosenAccount.Balance += loanAmount;

            clear();
            writeLine($"\n\t{loanAmount:0.00} {chosenAccount.Currency} sattes in på {chosenAccount.Name}.");
            writeLine($"\n\tNytt saldo: {Math.Round(chosenAccount.Balance, 2)}");
            readLine();

            string logDetails = $"\n\tFrån : \t\tBank(Lån)\n" +
                $"\tTill : \t\t{chosenAccount.Name}\n" +
                $"\tÖverfört : \t{chosenAccount.Balance:0.00} {chosenAccount.Currency}\n" +
                $"\tDatum : \t{DateTime.Now}\n\n";

            TransferLog transferLog = new TransferLog(logDetails);
            user.LogTransfer(transferLog);

            clear();
            // Comment out the menu call for testing
            //Menu.startMenuForUser();
        }

        public static void UpdateInterest(Func<string> readLine, Action<string> writeLine)
        {
            writeLine("\n\tAnge den nya räntesatsen (som en procent, t.ex. 5 för 5%):");
            if (decimal.TryParse(readLine(), out decimal input) && input >= 0 && input <= 100)
            {
                InterestRate = input / 100;
                writeLine($"\n\tRäntesatsen har uppdaterats till {InterestRate * 100}%.");
            }
            else
            {
                writeLine("\n\tFelaktig inmatning, ange ett värde mellan 0 och 100.");
            }
        }
    }
}
