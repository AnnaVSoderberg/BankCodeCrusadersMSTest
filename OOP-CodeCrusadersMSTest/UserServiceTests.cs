using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOP___Projekt_i_grupp___Code_Crusades__SUT23_;
using System.Collections.Generic;

namespace OOP_CodeCrusadersMSTest
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        [Description("CreateUser should properly initialize user properties.")]
        public void CreateUser_ShouldInitializeProperties()
        {
            // Arrange
            string expectedUsername = "TestUser";
            string expectedPin = "1234";
            bool expectedRole = false;
            var userService = new UserService();

            // Act
            User newUser = userService.CreateUser(expectedUsername, expectedPin, expectedRole);

            // Assert
            Assert.AreEqual(expectedUsername, newUser.Username);
            Assert.AreEqual(expectedPin, newUser.Pin);
            Assert.AreEqual(expectedRole, newUser.Role);
            Assert.IsNotNull(newUser.Accounts);
            Assert.IsNotNull(newUser.Loans);
            Assert.IsNotNull(newUser.TransferLogs);
        }

        [TestMethod]
        [Description("CreateUser should throw ArgumentException when username is empty.")]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUser_ShouldThrowException_WhenUsernameIsEmpty()
        {
            // Arrange
            var userService = new UserService();

            // Act
            userService.CreateUser("", "1234");

            // Assert - Expects exception
        }

        [TestMethod]
        [Description("CreateUser should throw ArgumentException when username is null.")]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUser_ShouldThrowException_WhenUsernameIsNull()
        {
            // Arrange
            var userService = new UserService();

            // Act
            userService.CreateUser(null, "1234");

            // Assert - Expects exception
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [Description("CreateUser should throw ArgumentException when PIN is empty.")]
        public void CreateUser_ShouldThrowException_WhenPinIsEmpty()
        {
            // Arrange
            var userService = new UserService();

            // Act
            userService.CreateUser("TestUser", "");

            // Assert - Expects exception
        }

        [TestMethod]
        [Description("CreateUser should throw ArgumentException when PIN is null.")]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUser_ShouldThrowException_WhenPinIsNull()
        {
            // Arrange
            var userService = new UserService();

            // Act
            userService.CreateUser("TestUser", null);

            // Assert - Expects exception
        }

 
        [TestMethod]
        [Description("AddUserToList should add the user to the provided user list.")]
        public void AddUserToList_ShouldAddUserToList()
        {
            // Arrange
            var userService = new UserService();
            var userList = new List<User>();
            var newUser = new User("TestUser", "1234", false);

            // Act
            userService.AddUserToList(newUser, userList);

            // Assert
            Assert.AreEqual(1, userList.Count);
            Assert.AreSame(newUser, userList[0]);
        }
    }
}
