using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sublime_Backend_Assessment.Repository;

namespace Sublime_Backend_Assessment.Tests.Repository
{
    [TestClass]
    public class SverigesRadioRepositoryTest
    {
        SverigesRadioRepository sverigesRadioRepository;

        [TestInitialize]
        public void Init()
        {
            sverigesRadioRepository = new SverigesRadioRepository();
        }

        #region Podcast Test

        [TestMethod]
        public void FetchPodcasts()
        {
            var result = sverigesRadioRepository.FetchPodcastsAsync("programid=1123&size=2").Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Copyright);
            Assert.IsNotNull(result.Podfiles);
            Assert.IsNotNull(result.Pagination);
            Assert.AreEqual(2, result.Podfiles.Count);
        }

        #endregion


        #region Programme Test

        [TestMethod]
        public void FetchProgramsWithoutFilter()
        {
            var result = sverigesRadioRepository.FetchProgramsAsync().Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Copyright);
            Assert.IsNotNull(result.Programs);
            Assert.IsNotNull(result.Pagination);
            Assert.AreEqual(10, result.Programs.Count);
        }

        [TestMethod]
        public void FetchProgramsWithFilter()
        {
            var result = sverigesRadioRepository.FetchProgramsAsync("filter=program.haspod&filterValue=true").Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Copyright);
            Assert.IsNotNull(result.Programs);
            Assert.IsNotNull(result.Pagination);
            Assert.AreEqual(10, result.Programs.Count);

            int count = result.Programs.Count(program => program.Haspod);
            Assert.AreEqual(10, result.Programs.Count);
        }

        #endregion


        #region Category Test

        [TestMethod]
        public void FetchCategories()
        {
            var result = sverigesRadioRepository.FetchCategoriesAsync().Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(15, result.Count);
        }

        #endregion
    }
}
