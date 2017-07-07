using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Watermellons.Services;
using Watermellons.EntityFramework;

namespace Watermellons.Tests.Services
{
    [TestClass]
    public class TestMessageFormatter
    {
        [TestMethod]
        [TestCategory("Test Message Formatter")]
        public void EmptyEntryReturnsCorrectResult()
        {
            IMessageFormatter _formatter = new MessageFormatter();
            CompetitionEntry entry = new CompetitionEntry();

            var actual = _formatter.FormatMessage(entry);
            var expected = "Name: \nEmail: \nGender: Male\nFavourite Place To Eat Watermellon: \nTerms and conditions: Not Accepted\n";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Test Message Formatter")]
        public void CompletedEntryReturnsCorrectResult()
        {
            IMessageFormatter _formatter = new MessageFormatter();
            CompetitionEntry entry = new CompetitionEntry();
            entry.FullName = "Bob Smith";
            entry.Email = "bob@smith.com";
            entry.Gender = false;
            entry.FavouriteWatermellonPlace = "In the bath";
            entry.TermsAndConditionsAccepted = false;

            var actual = _formatter.FormatMessage(entry);
            var expected = "Name: Bob Smith\nEmail: bob@smith.com\nGender: Male\nFavourite Place To Eat Watermellon: In the bath\nTerms and conditions: Not Accepted\n";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Test Message Formatter")]
        public void MaleEntryReturnsCorrectResult()
        {
            IMessageFormatter _formatter = new MessageFormatter();
            CompetitionEntry entry = new CompetitionEntry();
            entry.Gender = false;

            var actual = _formatter.FormatMessage(entry);
            var expected = "Name: \nEmail: \nGender: Male\nFavourite Place To Eat Watermellon: \nTerms and conditions: Not Accepted\n";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Test Message Formatter")]
        public void FemaleEntryReturnsCorrectResult()
        {
            IMessageFormatter _formatter = new MessageFormatter();
            CompetitionEntry entry = new CompetitionEntry();
            entry.Gender = true;

            var actual = _formatter.FormatMessage(entry);
            var expected = "Name: \nEmail: \nGender: Female\nFavourite Place To Eat Watermellon: \nTerms and conditions: Not Accepted\n";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Test Message Formatter")]
        public void NotAcceptedEntryReturnsCorrectResult()
        {
            IMessageFormatter _formatter = new MessageFormatter();
            CompetitionEntry entry = new CompetitionEntry();
            entry.TermsAndConditionsAccepted = false;

            var actual = _formatter.FormatMessage(entry);
            var expected = "Name: \nEmail: \nGender: Male\nFavourite Place To Eat Watermellon: \nTerms and conditions: Not Accepted\n";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [TestCategory("Test Message Formatter")]
        public void AcceptedEntryReturnsCorrectResult()
        {
            IMessageFormatter _formatter = new MessageFormatter();
            CompetitionEntry entry = new CompetitionEntry();
            entry.TermsAndConditionsAccepted = true;

            var actual = _formatter.FormatMessage(entry);
            var expected = "Name: \nEmail: \nGender: Male\nFavourite Place To Eat Watermellon: \nTerms and conditions: Accepted\n";
            Assert.AreEqual(expected, actual);
        }

    }
}
