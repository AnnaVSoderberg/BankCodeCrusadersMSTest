namespace OOP___Projekt_i_grupp___Code_Crusades__SUT23_
{
    //public class CreateUser
    //{
    //    public static void AddUser()
    //    {
    //        Console.Write("\n\tAnge Användarnamn: ");
    //        string username = Console.ReadLine();

    //        Console.Write("\n\tAnge pin: ");
    //        string pin = Console.ReadLine();

    //        bool role = false;

    //        User newCustomer = new User(username, pin, role);
    //        newCustomer.Accounts = new List<Accounts>();

    //        Start.CustomerList.Add(newCustomer);

    //        Console.WriteLine($"\n\tAnvändare {username} Skapats!");
    //        Console.ReadKey();
    //    }
    //}

    //    Updated Testcode
    //    

    public class CreateUser
    {
        private readonly UserService _userService;

        public CreateUser(UserService userService)
        {
            _userService = userService;
        }

        public void AddUser()
        {
            Console.Write("\n\tAnge Användarnamn: ");
            string username = Console.ReadLine();

            Console.Write("\n\tAnge pin: ");
            string pin = Console.ReadLine();

            User newCustomer = _userService.CreateUser(username, pin);
            _userService.AddUserToList(newCustomer, Start.CustomerList);

            Console.WriteLine($"\n\tAnvändare {username} Skapats!");
            Console.ReadKey();
        }
    }


    public class UserService
    {
        public User CreateUser(string username, string pin, bool role = false)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null or empty.");

            if (string.IsNullOrWhiteSpace(pin))
                throw new ArgumentException("Pin cannot be null or empty.");

            User newCustomer = new User(username, pin, role);
            newCustomer.Accounts = new List<Accounts>();
            newCustomer.Loans = new List<Loan>();
            newCustomer.TransferLogs = new List<TransferLog>();

            return newCustomer;
        }

        public void AddUserToList(User user, List<User> customerList)
        {
            customerList.Add(user);
        }
    }


}
