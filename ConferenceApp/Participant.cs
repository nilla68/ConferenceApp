namespace ConferenceApp;

/// <summary>
/// Handles information for a participant.
/// </summary>
public class Participant
{
    /// <summary>
    /// First name of the participant.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Last name of the participant.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// Email address of the participant.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Any special requests. If empty the participant do not have any special requests.
    /// </summary>
    public string? SpecialRequest { get; set; }

    /// <summary>
    /// Create a new participant.
    /// </summary>
    /// <param name="firstName">First name</param>
    /// <param name="lastName">Last name</param>
    /// <param name="email">Email adress</param>
    /// <param name="specialRequest">Special requests</param>
    public Participant(string firstName, string lastName, string email, string? specialRequest)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        SpecialRequest = specialRequest;
    }
}
