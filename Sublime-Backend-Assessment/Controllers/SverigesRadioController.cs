using System;
using System.Linq;
using System.Web.Mvc;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using Sublime_Backend_Assessment.Models.SverigesRadio;
using Sublime_Backend_Assessment.Repository;
using Sublime_Backend_Assessment.Utility;
using Sublime_Backend_Assessment.Models.SverigesRadio.BaseModels;

namespace Sublime_Backend_Assessment.Controllers
{
    /// <summary>
    /// Handle All requests to SverigesRadioApi
    /// </summary>
    public class SverigesRadioController : Controller
    {
        #region Constructor

        private ISverigesRadioRepository _sverigesRadioRepository;

        public SverigesRadioController()
        {
            this._sverigesRadioRepository = new SverigesRadioRepository();
        }
        #endregion


        #region Api method call

        /// <summary>
        /// List all programs belonging to the category "Humor"
        /// </summary>
        public async Task<ActionResult> ProgramsByCategory()
        {
            var presenter = new List<ProgramGroupedPresenter>();
            var categories = await _sverigesRadioRepository.FetchCategoriesAsync();

            if (categories != null && categories.Count > 0)
            {
                int categoryId = categories.FirstOrDefault(ff => ff.Name.ToLower() == "humor").Id;
                string filter = "size=100&programcategoryid=" + categoryId;
                var programsWapper = await _sverigesRadioRepository.FetchProgramsAsync(filter);
                presenter = programsWapper.CastTo().ToList();
            }
            return View("Programme", presenter);
        }

        /// <summary>
        /// List only programs that have podcasts
        /// </summary>
        public async Task<ActionResult> ProgramsPodcasts()
        {
            string filter = "size=50&filter=program.haspod&filterValue=true";
            var programsWapper = await _sverigesRadioRepository.FetchProgramsAsync(filter,true);
            var presenter = programsWapper.CastTo().ToList();
            return View("Programme", presenter);
        }

        /// <summary>
        /// List only programs that are not archived
        /// </summary>
        public async Task<ActionResult> ProgramsNotArchived()
        {
            string filter = "size=100&filter=program.haspod&filterValue=true";
            var programsWapper = await _sverigesRadioRepository.FetchProgramsAsync(filter);
            var presenter = programsWapper.CastTo().ToList();
            return View("Programme", presenter);
        }
        #endregion       
    }
}
