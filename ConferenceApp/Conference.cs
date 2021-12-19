namespace ConferenceApp;

/// <summary>
/// Handles participants and a discount code for a conference.
/// </summary>
public class Conference
{
    // List of participants for the conference.
    List<Participant> participants = new List<Participant>();

    // Discount code for the conference created by using a Guid.
    Guid discountCode = Guid.NewGuid();

    /// <summary>
    /// All conference participants.
    /// </summary>        
    public List<Participant> Participants
    {
        get
        {
            return participants;
        }
    }

    /// <summary>
    /// Add new participant to the conference.
    /// </summary>
    /// <param name="participant">Participant to add to the conference</param>
    public void AddParticipant(Participant participant)
    {
        participants.Add(participant);
    }

    /// <summary>
    /// Remove participant from the conference.
    /// </summary>
    /// <param name="index">The index of the participant to remove in the Participants list.</param>
    public void RemoveParticipant(int index)
    {
        participants.RemoveAt(index);
    }

    /// <summary>
    /// Save the conference to a comma separated text file.
    /// </summary>
    /// <param name="filePath">The path where the file will be saved.</param>
    /// <returns>The full path of the saved file.</returns>
    public string Save(string filePath)
    {
        FileInfo file = new FileInfo(filePath);
        Directory.CreateDirectory(file.DirectoryName);

        File.WriteAllLines(filePath, participants.Select(participant => $"{participant.FirstName},{participant.LastName},{participant.Email},{participant.SpecialRequest}"));

        return file.FullName;
    }

    /// <summary>
    /// Load a conference from a comma separated text file.
    /// </summary>
    /// <param name="filePath">The path to the file for conference data.</param>
    /// <returns>The loaded conference.</returns>
    public Conference Load(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var conference = new Conference();

        foreach (var line in lines)
        {
            var data = line.Split(',');
            var participant = new Participant(data[0], data[1], data[2], data[3]);
            conference.AddParticipant(participant);
        }

        return conference;
    }

    /// <summary>
    /// Get the discount code for the conference.
    /// </summary>
    /// <returns>The discount code for the conference</returns>
    public string GetDiscountCode()
    {
        return discountCode.ToString();
    }
}