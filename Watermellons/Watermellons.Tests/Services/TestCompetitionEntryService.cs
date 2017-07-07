using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Watermellons.Services;
using NSubstitute;
using Watermellons.Repository;
using Watermellons.EntityFramework;
using System.Collections.Generic;

namespace Watermellons.Tests.Services
{
    [TestClass]
    public class TestCompetitionEntryService
    {
        ICompetitionEntryService _service;
        ICompetitionEntryRepository _repo;
        IUnitOfWork _unit;

        [TestInitialize]
        public void Initialise()
        {
            _repo = Substitute.For<ICompetitionEntryRepository>();
            _unit = Substitute.For<IUnitOfWork>();
            _service = new CompetitionEntryService(_repo, _unit);
        }

        [TestMethod]
        [TestCategory("Test Competition Entry Service")]
        public void LessThan100WordsReturnsFalse()
        {
            string errorMessage;
            var entry = new CompetitionEntry();
            entry.FavouriteWatermellonPlace = "This is a free online calculator which counts the number of words or units in a text";
            var actual = _service.InsertCompetitionEntry(entry, out errorMessage);
            Assert.AreEqual(true, actual);
            Assert.AreEqual("", errorMessage);
        }

        [TestMethod]
        [TestCategory("Test Competition Entry Service")]
        public void GreaterThan100WordsReturnsFalse()
        {
            string errorMessage;
            var entry = new CompetitionEntry();
            entry.FavouriteWatermellonPlace = "This is a free online calculator which counts the number of words or units in a text. Authors writing your book, pupils working on your essay, self-employed word smiths, teachers, translators, professors, or simply curious individuals: please feel free to use this tool to count the number of words in your document. It will also be useful for database, grammatical research, translation breakdowns, dictionary creation, commercial writing, etc.This is a free online calculator which counts the number of words or units in a text. It will also be useful for database, grammatical research, translation breakdowns, dictionary creation, commercial writing, etc. 101";
            var actual = _service.InsertCompetitionEntry(entry, out errorMessage);
            Assert.AreEqual(false, actual);
            Assert.AreEqual("Too many words entered", errorMessage);
        }

        [TestMethod]
        [TestCategory("Test Competition Entry Service")]
        public void OneHundredWordsReturnsTrue()
        {
            string errorMessage;
            var entry = new CompetitionEntry();
            entry.FavouriteWatermellonPlace = "This is a free online calculator which counts the number of words or units in a text. Authors writing your book, pupils working on your essay, self-employed word smiths, teachers, translators, professors, or simply curious individuals: please feel free to use this tool to count the number of words in your document. It will also be useful for database, grammatical research, translation breakdowns, dictionary creation, commercial writing, etc.This is a free online calculator which counts the number of words or units in a text. It will also be useful for database, grammatical research, translation breakdowns, dictionary creation, commercial writing, etc.";
            var actual = _service.InsertCompetitionEntry(entry, out errorMessage);
            Assert.AreEqual(true, actual);
            Assert.AreEqual("", errorMessage);
        }

        [TestMethod]
        [TestCategory("Test Competition Entry Service")]
        public void ExceptionReturnsFalse()
        {
            string errorMessage;
            var entry = new CompetitionEntry();
            _repo.When(r => r.Insert(Arg.Any<CompetitionEntry>()))
                .Do(r => { throw new Exception("Exception Thrown"); });
                        
            var actual = _service.InsertCompetitionEntry(entry, out errorMessage);
            Assert.AreEqual(false, actual);
            Assert.AreEqual("Exception Thrown", errorMessage);
        }


        [TestMethod]
        [TestCategory("Test Competition Entry Service")]
        public void ExistingEmailReturnsTrue()
        {
            IList<CompetitionEntry> fakeData = new List<CompetitionEntry>();
            var entry = new CompetitionEntry();
            entry.Email = "bob@smith.com";
            fakeData.Add(entry);
            _repo.GetAll().Returns(fakeData);
            
            var actual = _service.EntryAlreadyExists("bob@smith.com");
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        [TestCategory("Test Competition Entry Service")]
        public void NonExistingEmailReturnsFalse()
        {
            IList<CompetitionEntry> fakeData = new List<CompetitionEntry>();
            var entry = new CompetitionEntry();
            entry.Email = "bob@smith.com";
            fakeData.Add(entry);
            _repo.GetAll().Returns(fakeData);

            var actual = _service.EntryAlreadyExists("bobby@smith.com");
            Assert.AreEqual(false, actual);
        }

    }
}
