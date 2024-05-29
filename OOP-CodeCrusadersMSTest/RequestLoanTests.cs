using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP___Projekt_i_grupp___Code_Crusades__SUT23_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using test;

namespace OOP_CodeCrusadersMSTest
{
    [TestClass]
    public class RequestLoanTests
    {
        [TestMethod] //OK
        public void CalculateInterest_ShouldReturnCorrectInterest()
        {
            // Arrange
            decimal loanAmount = 1000m;
            decimal expectedInterest = loanAmount * RequestLoan.InterestRate;

            // Act
            decimal actualInterest = RequestLoan.CalculateInterest(loanAmount);

            // Assert
            Assert.AreEqual(expectedInterest, actualInterest);
        }

        [TestMethod]
        public void Loan_ValidLoanRequest_ShouldAddLoanToUser()
        {
            // Arrange
            var user = new User("username", "password", true)
            {
                Accounts = new List<Accounts>
        {
            new Accounts("Savings", 1000m, "USD")
        }
            };
            decimal expectedLoanAmount = 2000m;
            // Add inputs to simulate the entire process
            Queue<string> inputs = new Queue<string>(new[] { "2000", "0", "", "" });
            bool isCleared = false;
            List<string> outputLines = new List<string>();

            Func<string> mockReadLine = () => inputs.Dequeue();
            Action<string> mockWriteLine = outputLines.Add;
            Action mockClear = () => isCleared = true;

            // Act
            RequestLoan.Loan(user, mockReadLine, mockWriteLine, mockClear);

            // Assert
            Assert.AreEqual(1, user.Loans.Count);
            Assert.AreEqual(expectedLoanAmount, user.Loans[0].Amount);
            Assert.IsTrue(isCleared);
        }


        [TestMethod]
        public void Loan_ExceedingMaximumLoan_ShouldNotAddExceedingLoanButAddValidLoan()
        {
            // Arrange
            var user = new User("username", "password", true)
            {
                Accounts = new List<Accounts>
                {
                    new Accounts("Savings", 1000m, "USD")
                }
            };

            decimal totalCapital = user.Accounts.Sum(account => account.Balance);
            decimal maxLoan = totalCapital * 5;

            // Provide inputs to simulate the loan process
            var inputs = new Queue<string>(new[]
            {
                (maxLoan + 1).ToString(), // Exceeding max loan input
                "500", // Valid loan input after exceeding
                "0" // Valid account selection input
            });

            Func<string> readLine = () => inputs.Count > 0 ? inputs.Dequeue() : "";
            var outputs = new List<string>();
            Action<string> writeLine = (output) => outputs.Add(output);
            Action clear = () => { /* Do nothing for now */ };

            // Act
            RequestLoan.Loan(user, readLine, writeLine, clear);

            // Assert
            foreach (var output in outputs)
            {
                Console.WriteLine(output); // Debugging output
            }

            // Since we should eventually add a valid loan, check that the valid loan was added
            Assert.AreEqual(1, user.Loans.Count, "Loan should be added when a valid loan amount is provided.");
            Assert.AreEqual(500, user.Loans[0].Amount, "The amount of the loan should be 500.");

            // Optionally, verify that the writeLine was called with the correct message when the loan amount exceeded
            bool exceededMaxLoanMessageDisplayed = outputs.Any(o => o.Contains($"Du kan maximalt låna {maxLoan:0.00}."));
            Assert.IsTrue(exceededMaxLoanMessageDisplayed, "The correct message should be displayed when the loan exceeds the maximum allowed.");
        }



        [TestMethod]
        public void DepositLoan_ShouldDepositAmountIntoSelectedAccount()
        {
            // Arrange
            var user = new User("username", "password", true)
            {
                Accounts = new List<Accounts>
            {
                new Accounts("Savings", 1000m, "USD"),
                new Accounts("Checking", 500m, "USD")
            }
            };
            decimal loanAmount = 2000m;
            Queue<string> inputs = new Queue<string>(new[] { "0", "" }); // Simulate account selection and Enter key press
            List<string> outputLines = new List<string>();
            bool isCleared = false;

            Func<string> mockReadLine = () => inputs.Dequeue();
            Action<string> mockWriteLine = outputLines.Add;
            Action mockClear = () => isCleared = true;
            int selectedIndex = 0; // Select the first account for testing

            // Act
            RequestLoan.DepositLoan(user, loanAmount, mockReadLine, mockWriteLine, mockClear, selectedIndex);

            // Assert
            Assert.AreEqual(3000m, user.Accounts[0].Balance); // Check that the loan amount was added to the first account
            Assert.IsTrue(isCleared);
        } 

        [TestMethod] //OK
        public void UpdateInterest_ValidInput_ShouldUpdateInterestRate()
        {
            // Arrange
            string userInput = "10";
            List<string> outputLines = new List<string>();

            Func<string> mockReadLine = () => userInput;
            Action<string> mockWriteLine = outputLines.Add;

            // Act
            RequestLoan.UpdateInterest(mockReadLine, mockWriteLine);

            // Assert
            Assert.AreEqual(0.10m, RequestLoan.InterestRate);
            Assert.IsTrue(outputLines.Any(line => line.Contains("Räntesatsen har uppdaterats till"))); // Check that the update message was printed
        }

        [TestMethod] //OK
        public void UpdateInterest_InvalidInput_ShouldNotUpdateInterestRate()
        {
            // Arrange
            string userInput = "invalid";
            decimal originalInterestRate = RequestLoan.InterestRate;
            List<string> outputLines = new List<string>();

            Func<string> mockReadLine = () => userInput;
            Action<string> mockWriteLine = outputLines.Add;

            // Act
            RequestLoan.UpdateInterest(mockReadLine, mockWriteLine);

            // Assert
            Assert.AreEqual(originalInterestRate, RequestLoan.InterestRate);
            Assert.IsTrue(outputLines.Any(line => line.Contains("Felaktig inmatning"))); // Check that the error message was printed
        }
    }
}