

using DTOs.DTOs;
using FinalProject.Interfaces;
using Social.Interfaces;

namespace FinalProject.Dialogues;

public class MainMenuDialogues (IUserService userService) : IMainMenuDialogues
{
    private readonly IUserService _userService = userService;

    public void ShowMenuOptions()
    {
        var running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine(string.Empty);
            Console.WriteLine("--------- USER MANAGEMENT ---------");
            Console.WriteLine("1. Create New User");
            Console.WriteLine("2. View All Users");
            Console.WriteLine("Q. Quit Application");
            Console.WriteLine("-----------------------------------\n");
            Console.Write("Enter Option: ");
            var option = Console.ReadLine()!.ToLower();

            switch (option)
            {
                case "1":
                    CreateUserOption();
                    break;

                case "2":
                    ViewAllUsersOption();
                    break;

                case "q":
                    running = QuitApplication();
                    break;
            }

        }
    }

    public void CreateUserOption()
    {
        var user = new UserContactForm();

        Console.Clear();
        Console.WriteLine("--------- CREATE NEW USER ---------\n");

        Console.Write("Enter First Name: ");
        user.FirstName = Console.ReadLine()!.Trim();

        Console.Write("Enter Last Name: ");
        user.LastName = Console.ReadLine()!.Trim();

        Console.Write("Enter Email: ");
        user.Email = Console.ReadLine()!.ToLower().Trim();

        Console.Write("Enter Phone Number: ");
        user.PhoneNumber = Console.ReadLine()!.Trim();

        Console.Write("Enter Address: ");
        user.Address = Console.ReadLine()!;

        Console.Write("Enter Postal Number: ");
        user.PostalNumber = Console.ReadLine()!.Trim();

        Console.Write("Enter Municipality: ");
        user.Municipality = Console.ReadLine()!;
        
        _userService.CreateUserProfile(user);

    }

    public void ViewAllUsersOption()
    {
        Console.Clear();
        Console.WriteLine("--------- USERS ---------\n");

        foreach (var user in _userService.GetUserProfiles())
        {
            Console.WriteLine($"{"Id:",-17}{user.Id}");
            Console.WriteLine($"{"Name:",-17}{user.FirstName} {user.LastName}");
            Console.WriteLine($"{"Email:",-17}{user.Email}");
            Console.WriteLine($"{"Phone Number:",-17}{user.PhoneNumber}");
            Console.WriteLine($"{"Address:",-17}{user.Address}");
            Console.WriteLine($"{"Postal Number:",-17}{user.PostalNumber}");
            Console.WriteLine($"{"Municipality:",-17}{user.Municipality}\n\n");
        }
        Console.WriteLine("Press any key to return...");
        Console.ReadKey();
    }

    public bool QuitApplication()
    {
        while ( true ) 
        { 
            Console.Clear();
            Console.Write("Are you sure you want to quit the application? (y/n): ");
            var option = Console.ReadLine()!.ToLower();

            if (option == "y")
            {
                return false;   
            }
            else if (option == "n")
            {
                return true;
            }
            else
            {
                Console.WriteLine("\nPlease enter either 'y' or 'n' to quit or return to the application.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
