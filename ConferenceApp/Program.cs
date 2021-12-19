using ConferenceApp;

// Create a new conference
Conference conference = new Conference();

// Condition for the loop.
bool isRunning = true;

// Loop is running and prints the meny options until the user exits the program. 
while (isRunning)
{
    // Print the main menu.
    var menuChoice = Menu.PrintMainMenu();

    switch (menuChoice)
    {
        // Add new participant.
        case 1:
            Participant participant = Menu.AddParticipant();
            conference.AddParticipant(participant);
            break;

        // Print discount code for the conference.
        case 2:
            var discountCode = conference.GetDiscountCode();
            Menu.PrintDiscountCode(discountCode);
            break;

        // Print list of participants.
        case 3:
            Menu.PrintAllParticipants(conference.Participants);
            break;

        // Remove a participant.
        case 4:
            var index = Menu.RemoveParticipant(conference.Participants);
            conference.RemoveParticipant(index);
            break;

        // Save the conference.
        case 5:
            var saveFilePath = Menu.GetSavePath();
            var fullPath = conference.Save(saveFilePath);
            Menu.ConfirmSave(fullPath);
            break;

        // Load a conference.
        case 6:
            var loadFilePath = Menu.GetLoadPath();
            conference = conference.Load(loadFilePath);
            Menu.ConfirmLoad(loadFilePath);
            break;

        // Exit the program.
        case 7:
            isRunning = false;
            break;
    }
}