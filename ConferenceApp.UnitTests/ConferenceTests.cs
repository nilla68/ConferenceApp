using System;
using Xunit;

namespace ConferenceApp.UnitTests;

public class ConferenceTests
{
    [Fact]
    public void AddParticipantToConference()
    {
        // Arrange
        var expectedParticipantCount = 1;

        var firstName = "Anna";
        var lastName = "Andersson";
        var email = "anna@andersson.se";
        var specialRequest = "Vegan";
        var participant = new Participant(firstName, lastName, email, specialRequest);
        var conference = new Conference();

        // Act
        conference.AddParticipant(participant);

        // Assert
        Assert.Equal(expectedParticipantCount, conference.Participants.Count);
        Assert.Equal(participant, conference.Participants[0]);
    }

    [Fact]
    public void CancelParticipantFromConference()
    {
        // Arrange
        var expectedParticipantCount = 0;

        var firstName = "Anna";
        var lastName = "Andersson";
        var email = "anna@andersson.se";
        var specialRequest = "Vegan";
        var participant = new Participant(firstName, lastName, email, specialRequest);

        var conference = new Conference();
        conference.AddParticipant(participant);

        // Act
        conference.RemoveParticipant(0);

        // Assert
        Assert.Equal(expectedParticipantCount, conference.Participants.Count);
    }

    [Fact]
    public void GetDiscountCode()
    {
        // Arrange
        var conference = new Conference();

        // Act
        var disoucountCode = conference.GetDiscountCode();

        // Assert
        Assert.IsType<Guid>(Guid.Parse(disoucountCode));
    }
}
