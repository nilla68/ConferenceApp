using Xunit;

namespace ConferenceApp.UnitTests;

public class ParticipantTests
{
    [Fact]
    public void CreateParticipant()
    {
        // Arrange
        var firstName = "Anna";
        var lastName = "Andersson";
        var email = "anna@andersson.se";
        var specialRequest = "Vegan";

        // Act
        var participant = new Participant(firstName, lastName, email, specialRequest);

        // Assert
        Assert.Equal(firstName, participant.FirstName);
        Assert.Equal(lastName, participant.LastName);
        Assert.Equal(email, participant.Email);
        Assert.Equal(specialRequest, participant.SpecialRequest);
    }
}
