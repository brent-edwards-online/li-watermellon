using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Web.Mvc;
using Watermellons.Controllers;
using Watermellons.EntityFramework;
using Watermellons.Services;

namespace Watermellons.Tests.Controllers
{
    [TestClass]
    public class WatermellonControllerTest
    {
        private WatermellonController _controller;
        private ICompetitionEntryService _competitionEntryService;
        private IEmailService _emailService;
        private IMessageFormatter _messageFormatter;

        [TestInitialize]
        public void Initialize()
        {
            _competitionEntryService = Substitute.For<ICompetitionEntryService>();
            _emailService = Substitute.For<IEmailService>();
            _messageFormatter = Substitute.For<IMessageFormatter>();
            _controller = new WatermellonController(_competitionEntryService, _emailService, _messageFormatter);
        }

        [TestMethod]
        [TestCategory("Test Watermellon Controller")]
        public void CanCreateAControllerCompetitionEntry()
        {
            ViewResult actual = _controller.CompetitionEntry() as ViewResult;
            Assert.IsNotNull(actual);
            Assert.IsNull(actual.Model);
        }

        [TestMethod]
        [TestCategory("Test Watermellon Controller")]
        public void EmptyEntryReturnsInvalidModelState()
        {
            CompetitionEntry entry = new CompetitionEntry();
            ViewResult actual = _controller.CompetitionEntry(entry) as ViewResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual(false, actual.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        [TestCategory("Test Watermellon Controller")]
        public void CompleteEntryRedirectsToThankyou()
        {
            CompetitionEntry entry = new CompetitionEntry();
            var errorMessage = "";
            var competitionEntryService = Substitute.For<ICompetitionEntryService>();
            var emailService = Substitute.For<IEmailService>();
            var messageFormatter = Substitute.For<IMessageFormatter>();
            var controller = new WatermellonController(competitionEntryService, emailService, messageFormatter);
            competitionEntryService.InsertCompetitionEntry(Arg.Any<CompetitionEntry>(), out errorMessage)
                .Returns(x =>
                {
                    x[1] = "";
                    return true;
                });
            controller.ModelState.Clear();

            var actual = controller.CompetitionEntry(entry) as RedirectToRouteResult;
            Assert.IsNotNull(actual);
            Assert.AreEqual("Thankyou", actual.RouteValues["action"]);
        }

        [TestMethod]
        [TestCategory("Test Watermellon Controller")]
        public void InvalidEntryReturnsToCompetitionEntryView()
        {
            CompetitionEntry entry = new CompetitionEntry();
            var errorMessage = "";
            _competitionEntryService.InsertCompetitionEntry(Arg.Any<CompetitionEntry>(), out errorMessage).Returns(true);
            _controller.ModelState.AddModelError("Model Error", "Model Error");

            ViewResult actual = _controller.CompetitionEntry(entry) as ViewResult;
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Model);
            Assert.AreEqual("CompetitionEntry", actual.ViewName);
        }
    }
}
