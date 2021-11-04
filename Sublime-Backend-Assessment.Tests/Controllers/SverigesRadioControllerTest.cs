using System;
using System.Threading;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sublime_Backend_Assessment.Controllers;

namespace Sublime_Backend_Assessment.Tests.Controllers
{
    [TestClass]
    public class SverigesRadioControllerTest
    {
        [TestMethod]
        public void ProgramsByCategory()
        {
            SverigesRadioController controller = new SverigesRadioController();
            var result = controller.ProgramsPodcasts().Result;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ProgramsPodcasts()
        {
            SverigesRadioController controller = new SverigesRadioController();
            var result = controller.ProgramsPodcasts().Result;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ProgramsNotArchived()
        {
            SverigesRadioController controller = new SverigesRadioController();
            var result = controller.ProgramsNotArchived().Result;
            Assert.IsNotNull(result);
        }
    }
}
