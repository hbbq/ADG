using System;
using NUnit.Framework;
using Moq;
using Shouldly;

namespace ADG.Lib.Tests
{
    
    [TestFixture]
    public class TourRepository
    {

        private Mock<Connectors.IApiConnector> _apiConnectorMock;
        private Mock<Mappers.IApiMapper> _apiMapperMock;
        private Repositories.TourRepository _tourRepository;

        [SetUp]
        public void Setup()
        {

            _apiConnectorMock = new Mock<Connectors.IApiConnector>();
            _apiConnectorMock.Setup(o => o.GetTourResults()).Returns(
                @"[{""player"":""player1"",""class"":""Open"",""course"":""thecourse"",""date"":""20170101"",""score"":""60""}," +
                @"{""player"":""player2"",""class"":""Open"",""course"":""thecourse"",""date"":""20070220"",""score"":""70""}]");

            _apiMapperMock = new Mock<Mappers.IApiMapper>();
            _apiMapperMock.Setup(o => o.ResultsFromJArray(It.IsAny<Newtonsoft.Json.Linq.JArray>())).Returns(
                new System.Collections.Generic.List<Models.Result> {
                    new Models.Result { Player = "player1", Class = "Open", Course = "thecourse", Date = new DateTime(2017,1,1), Score = 60 },
                    new Models.Result { Player = "player2", Class = "Open", Course = "thecourse", Date = new DateTime(2017,2,20), Score = 70 },
                });

            _tourRepository = new Repositories.TourRepository(_apiConnectorMock.Object, _apiMapperMock.Object);

        }

        [Test]
        public void TourRepository_GetResults_ShouldNotBeNull()
        {
            _tourRepository.GetTourResults().ShouldNotBeNull();
        }

        [Test]
        public void TourRepository_GetResults_ShouldCallApiOnce()
        {
            _tourRepository.GetTourResults();
            _apiConnectorMock.Verify(o => o.GetTourResults(), Times.Once);
        }

        [Test]
        public void TourRepository_GetResults_ShouldReturnTwoObjects()
        {
            _tourRepository.GetTourResults().Count.ShouldBe(2);
        }

        [Test]
        public void TourRepository_GetResults_ShouldUseMapper()
        {
            _tourRepository.GetTourResults();
            _apiMapperMock.Verify(o => o.ResultsFromJArray(It.IsAny<Newtonsoft.Json.Linq.JArray>()), Times.AtLeastOnce);
        }

    }

}
