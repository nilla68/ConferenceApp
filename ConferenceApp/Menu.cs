using System.Text;

namespace ConferenceApp;

/// <summary>
/// Handles user interaction.
/// </summary>
internal static class Menu
{
    /// <summary>
    /// Prints out the main menu and validates the user input. 
    /// </summary>
    public static int PrintMainMenu()
    {
        PrintMenuBanner("Conference & Event Planner");
        Console.WriteLine("1 Register a participant");
        Console.WriteLine("2 Access a discount code for the conference");
        Console.WriteLine("3 List all participants");
        Console.WriteLine("4 Cancel a participant");
        Console.WriteLine("5 Save to file");
        Console.WriteLine("6 Load from file");
        Console.WriteLine("7 Exit program");
        Console.Write("Please enter your option: ");

        // Run until the user enters a valid menu option.
        while (true)
        {
            // Validates user input number range 1-7.
            if (int.TryParse(Console.ReadLine(), out int menuChoice))
            {
                if (menuChoice > 0 && menuChoice < 8)
                {
                    return menuChoice;
                }
            }

            PrintErrorMessage("Please enter a valid menu option: 1-7.");
        }
    }

    /// <summary>
    /// Handles user input values to create a new participant.
    /// </summary>
    /// <returns>The new participant.</returns>
    public static Participant AddParticipant()
    {
        PrintMenuBanner("Add a new participant to the conference");

        string firstName = GetParticipantData("Enter first name: ");
        string lastName = GetParticipantData("Enter last name: ");
        string email = GetParticipantData("Enter email: ");

        Console.Write("Enter special meal requests: ");
        var specialRequest = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine("The following participant has been registered:");
        Console.WriteLine($"First name: {firstName}\nLast name: {lastName}\nEmail: {email}\nSpecial Requests: {specialRequest}");
        ReturnToMainMenu();

        Participant participant = new Participant(firstName, lastName, email, specialRequest);

        return participant;
    }

    /// <summary>
    /// Prints the discount code to the console.
    /// </summary>
    /// <param name="discountCode">The discount code.</param>
    public static void PrintDiscountCode(string discountCode)
    {
        PrintMenuBanner("Conference discount code");
        Console.WriteLine($"Code for 50% meal discount: {discountCode}");
        ReturnToMainMenu();
    }

    /// <summary>
    /// Prints out a list of the participants to the console.
    /// </summary>
    /// <param name="participants">The list of participants.</param>
    public static void PrintAllParticipants(List<Participant> participants)
    {
        PrintMenuBanner("Conference participants");

        if (participants.Count > 0)
        {
            PrintParticipantsToConsole(participants);
        }
        else
        {
            Console.WriteLine("There are no participants registered for this conference.");
        }

        ReturnToMainMenu();
    }

    /// <summary>
    /// Handles cancellation of a praticipant by entering the index postition from a printed list.
    /// </summary>
    /// <param name="participants">The list of participants.</param>
    /// <returns>The index of the participant to be removed.</returns>
    public static int RemoveParticipant(List<Participant> participants)
    {
        PrintMenuBanner("Cancel participant from the conference");

        PrintParticipantsToConsole(participants);
        Console.Write("Enter the participant number to be cancelled: ");

        // Run until the user enters a valid menu option.
        while (true)
        {
            // Validate that a number is entered.
            if (int.TryParse(Console.ReadLine(), out int removeIndex))
            {
                // Subtract by one because the list start with 1.
                removeIndex--;

                // Validates user input number range 1-the number of participants.
                if (removeIndex >= 0 && removeIndex < participants.Count)
                {
                    Console.WriteLine("The following participant has been cancelled: ");
                    Console.WriteLine($"First name: {participants[removeIndex].FirstName}\nLast name: {participants[removeIndex].LastName}\nEmail: {participants[removeIndex].Email}");

                    ReturnToMainMenu();

                    return removeIndex;
                }
            }

            PrintErrorMessage("Please enter a number from the above list.");
        }
    }

    /// <summary>
    /// Get the file path to save the conference.
    /// </summary>
    /// <returns>The file path.</returns>
    public static string GetSavePath()
    {
        PrintMenuBanner("Save conference to file");

        while (true)
        {
            Console.Write("Enter file path: ");
            var filePath = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                return filePath;
            }
            else
            {
                PrintErrorMessage("You have entered an incorrect file path.");
            }
        }
    }

    /// <summary>
    /// Get the file path to load a conference from file.
    /// </summary>
    /// <returns>The file path.</returns>
    public static string GetLoadPath()
    {
        PrintMenuBanner("Load conference from file");

        while (true)
        {
            Console.Write("Enter file path: ");
            var filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                return filePath;
            }

            PrintErrorMessage($"File {filePath} does not exist!");
        }
    }

    /// <summary>
    /// Prints the full path to the file from where the conference was loaded.
    /// </summary>
    /// <param name="path">Relative or absolute path.</param>
    public static void ConfirmLoad(string path)
    {
        var file = new FileInfo(path);

        Console.WriteLine($"Your conference is loaded from file: {file.FullName}");
        ReturnToMainMenu();
    }

    /// <summary>
    /// Prints the full path to the file where the conference was saved. 
    /// </summary>
    /// <param name="path">The full path.</param>
    public static void ConfirmSave(string path)
    {
        Console.WriteLine($"Your conference is saved to file: {path}");
        ReturnToMainMenu();
    }

    /// <summary>
    /// Prints all participants to the console.
    /// </summary>
    /// <param name="participants">List of participants.</param>
    private static void PrintParticipantsToConsole(IEnumerable<Participant> participants)
    {
        int index = 1;
        foreach (Participant participant in participants)
        {
            Console.WriteLine($"{index} Firstname: {participant.FirstName} Last name: {participant.LastName} Email: {participant.Email}");
            index++;
        }
    }

    /// <summary>
    /// Ask the user to confirm before returing to the main menu.
    /// </summary>
    private static void ReturnToMainMenu()
    {
        Console.WriteLine();
        Console.WriteLine("Press enter to return to the main menu.");
        Console.ReadLine();
    }

    /// <summary>
    /// Print a error message to the console in red.
    /// </summary>
    /// <param name="message">The error message.</param>
    private static void PrintErrorMessage(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    /// <summary>
    /// Retrieve data from the user, validates that the data is not an empty string.
    /// </summary>
    /// <param name="message">Describe the data to be retrieved.</param>
    /// <returns>The data.</returns>
    private static string GetParticipantData(string message)
    {
        string? data = string.Empty;
        while (true)
        {
            Console.Write(message);
            data = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(data))
            {
                PrintErrorMessage("You have to enter a value!");
            }
            else
            {
                return data;
            }
        }
    }

    /// <summary>
    /// Prints a menu banner to the console.
    /// </summary>
    /// <param name="text">The text of the menu banner.</param>
    private static void PrintMenuBanner(string text)
    {
        var bannerText = $"**** {text} ****";
        var bannerStars = new StringBuilder();

        for (int i = 0; i < bannerText.Length; i++)
        {
            bannerStars.Append('*');
        }

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(bannerText);
        Console.WriteLine(bannerStars.ToString());
        Console.ResetColor();
    }
}

