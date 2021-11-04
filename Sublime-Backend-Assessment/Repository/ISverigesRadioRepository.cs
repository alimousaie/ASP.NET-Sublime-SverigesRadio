using Sublime_Backend_Assessment.Models.BaseModels.SverigesRadio;
using Sublime_Backend_Assessment.Models.SverigesRadio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Sublime_Backend_Assessment.Repository
{
    public interface ISverigesRadioRepository //: IDisposable
    {
        Task<PodcastsWrapper> FetchPodcastsAsync(string filter);

        Task<ProgramsWrapper> FetchProgramsAsync(string filter = "",bool fillPodcastList=false);

        Task<List<ProgramCategory>> FetchCategoriesAsync(string filter = "");
    }
}