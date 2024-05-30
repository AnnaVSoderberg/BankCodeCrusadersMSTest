Jag har valt att skapa tester för:

UserService - skriv ut konton

   Att korreta värden sparas vid skapandet av en ny användare

   Att det inte går att skapa ny användare när UserName eller pin aningen är tomt eller Null
   
   Att ny användare korrekt läggs till i listan av användare

RequestLoan

   Att räntan beräknas korrekt
   
   Att det går att ta ett lån och att detta läggs in på kundens konto
   
   Att det inte går att ta ett lån över 5*ditt kapital
   
   att uppdaterad ränta slår igenom korrekt

Account

   Att korrekt information skrivs ut för inga konton, ett konto och flera konton
   
   Att summan på kontot skrivs ut för negativa värde, positiva värden och noll värde
   
   Att olika valutor skrivs ut korrekt



UserService

   Ensuring that correct values are saved when creating a new user.
   
   Verifying that a new user cannot be created when the username or pin is either empty or null.
   
   Confirming that a new user is correctly added to the list of users.

RequestLoan

   Ensuring that the interest is calculated correctly.
   
   Verifying that a loan can be taken out and that it is deposited into the customer's account.
   
   Confirming that a loan cannot be taken out for an amount greater than 5 times the user's capital.
   
   Ensuring that the updated interest rate is applied correctly.

Account

   Ensuring that the correct information is displayed for no accounts, a single account, and multiple accounts.
   
   Verifying that the account balance is displayed correctly for negative values, positive values, and zero balance.
   
   Confirming that different currencies are displayed correctly.


   
The Code-crusader bank is a group project for school. The program is coded in C# in .NET. It's a program that resembles a simple bank system.
There are seventeen different classes in our program.

These are all of our classes:
Our program has seventeen different classes;

Accounts:
This is a base/parent class where the users can create new bank accounts.

Checking accounts:
This is a subclass from 'Accounts'. It contains a method that create new accounts.

Create user:
A class where the admin can create new users for the program.

ExchangeRate:
A class where the admin can change the ExchangeRate

Loan:
A class for creating new loans.

Logo:
Shows the bank-logo.

Menu:
A class that writes out the menues. There's one seperate menu for the user and one for the admin.

PrintAccounts:
This class print the bank-accounts for the users.

Program:
Just calls the method StartBank()

RequestLoan:
In this class you request and execute bank-loans.

SavingAccounts:
This is also a subclass based on 'Accounts'. Here the user can open new Saving accounts.

Start:
This is a class that contains the already existing users and their bank-accounts.

Transfer:
In this class you manage the transfers between different accounts.

TransferLog:
A class for creating TransferLogs to save the transferhistory.

TransferUser:
Here you can transfer money to different users.

Users:
A class for creating new users.

UserContext:
This is a class that contains two static Users, one CurrentUsers and one TargetUser.


Starting the application: 

The first step when you start the program is the loginscreen: 
Here the user can choose wether to log in as an admin or a user! 
The user has 3 chances to log in to the application if its wrong the third time the application will close. 

If you log in as a user you get transported to the usermenu wich has the following choices: 

1. View Accounts

   Prints out all the current accounts for the logged in user
3. Transfer

   Lets the user transfer money between its own accounts
4. Transfer to another user

   Lets the user transfer money to another user that has accounts in the bank
6. Open a savingsaccount

   Lets the user open up a savings account, and gets the opportunity to choose the currency,

   And gets interestrate on the money they put in.
8. Open a checking account

    Lets the user open up a checking account, and gets the opportunity to choose the currency
10. Transfer history

     Shows all the logged transfers the user has made.
12. Loan request

    Lets the user request a loan thats not exceeds the amount of the users balance * five. 
14. Log out

    Logs out, and returns to the start page.
16. Exit the program

    Shuts down the program.

If you log in as an Admin you get transported to the AdminMenu wich has the following choices: 

1. Create new user

   Lets the Admin create a new user with unique username and password
3. Set exchangerates

   Lets the admin set the exchangerates for the current currencies
5. Log out

   Logs out, and returns to the start page.
7. Exit the program

   Shuts down the program.

Link to our UML diagram
   
   https://lucid.app/lucidchart/0d1aeb14-297a-4446-b6f1-fcdba2e0a0c2/edit?viewport_loc=-1849%2C-1508%2C4992%2C2319%2CHWEp-vi-RSFO&invitationId=inv_91ced300-da0e-4d9a-b4f3-0d6fb5ca0b66

Link to our Scrum board wich we made in Trello

https://trello.com/b/WPAKfdAF/projekt-oop
