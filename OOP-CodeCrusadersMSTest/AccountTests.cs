using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP___Projekt_i_grupp___Code_Crusades__SUT23_;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using test;

namespace OOP_CodeCrusadersMSTest
{
    [TestClass]
    public class AccountsTests
    {
        [TestMethod]
        [Description("Verifies that the account summary includes all accounts and their balances for a user with multiple accounts.")]
        public void GetAccountSummaryTests()
        {
            // Arrange
            var user = new User("username", "password", true);
            user.Accounts.Add(new Accounts("Checking", 1000.00m, "USD"));
            user.Accounts.Add(new Accounts("Savings", 5000.00m, "USD"));
            UserContext.CurrentUser = user;

            // Act
            var summary = Accounts.GetAccountSummary(user);

            // Assert
            summary.Should().Contain("\tDina konton & saldo:");
            summary.Should().Contain("\tChecking: 1000.00 USD");
            summary.Should().Contain("\tSavings: 5000.00 USD");
        }

        [TestMethod]
        [Description("Verifies that the account summary correctly displays a single account and its balance.")]
        public void TestGetAccountSummary_SingleAccount()
        {
            // Arrange
            var user = new User("username", "password", true);
            user.Accounts.Add(new Accounts("Checking", 1000.00m, "USD"));
            UserContext.CurrentUser = user;

            // Act
            var summary = Accounts.GetAccountSummary(user);

            // Assert
            summary.Should().Contain("\tDina konton & saldo:");
            summary.Should().Contain("\tChecking: 1000.00 USD");
        }

        [TestMethod]
        [Description("Verifies that the account summary correctly displays an account with a zero balance.")]
        public void TestGetAccountSummary_ZeroBalance()
        {
            // Arrange
            var user = new User("username", "password", true);
            user.Accounts.Add(new Accounts("Checking", 0.00m, "USD"));
            UserContext.CurrentUser = user;

            // Act
            var summary = Accounts.GetAccountSummary(user);

            // Assert
            summary.Should().Contain("\tDina konton & saldo:");
            summary.Should().Contain("\tChecking: 0.00 USD");
        }

        [TestMethod]
        [Description("Verifies that the account summary correctly displays an account with a negative balance.")]
        //Bör Felhanteras!
        public void TestGetAccountSummary_NegativeBalance()
        {
            // Arrange
            var user = new User("username", "password", true);
            user.Accounts.Add(new Accounts("Checking", -100.75m, "USD"));
            UserContext.CurrentUser = user;

            // Act
            var summary = Accounts.GetAccountSummary(user);

            // Assert
            summary.Should().Contain("\tDina konton & saldo:");
            summary.Should().Contain("\tChecking: -100.75 USD");
        }

        [TestMethod]
        [Description("Verifies that the account summary correctly displays accounts with different currencies.")]
        public void TestGetAccountSummary_DifferentCurrencies()
        {
            // Arrange
            var user = new User("username", "password", true);
            user.Accounts.Add(new Accounts("Checking", 1000.00m, "USD"));
            user.Accounts.Add(new Accounts("Savings", 5000.00m, "EUR"));
            user.Accounts.Add(new Accounts("Investment", 2000.00m, "GBP"));
            UserContext.CurrentUser = user;

            // Act
            var summary = Accounts.GetAccountSummary(user);

            // Assert
            summary.Should().Contain("\tDina konton & saldo:");
            summary.Should().Contain("\tChecking: 1000.00 USD");
            summary.Should().Contain("\tSavings: 5000.00 EUR");
            summary.Should().Contain("\tInvestment: 2000.00 GBP");
        }

        [TestMethod]
        [Description("Verifies that the account summary correctly handles a user with no accounts.")]
        public void TestGetAccountSummary_NoAccounts()
        {
            // Arrange
            var user = new User("username", "password", true);
            UserContext.CurrentUser = user;

            // Act
            var summary = Accounts.GetAccountSummary(user);

            // Assert
            summary.Should().Contain("\tDina konton & saldo:");
            summary.Should().NotContain("\tChecking:");
            summary.Should().NotContain("\tSavings:");
        }
    }
}
