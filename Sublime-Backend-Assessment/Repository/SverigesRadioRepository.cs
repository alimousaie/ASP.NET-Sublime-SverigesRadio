using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Sublime_Backend_Assessment.Models.SverigesRadio;
using System.Collections.Generic;
using Sublime_Backend_Assessment.Models.BaseModels.SverigesRadio;
using Sublime_Backend_Assessment.Utility;
using Sublime_Backend_Assessment.Models.SverigesRadio.BaseModels;
using System.Linq;

namespace Sublime_Backend_Assessment.Repository
{
    /// <summary>
    /// Handle All requests to SverigesRadioApi
    /// </summary>
    public class SverigesRadioRepository : ISverigesRadioRepository
    {
        #region api client
        private static readonly string BaseUrl = "http://api.sr.se/api/v2/";

        /// <summary>
        /// Manage all get request with this method
        /// </summary>
        private async Task<string> FetchDataAsync(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var MediaType = new MediaTypeWithQualityHeaderValue("application/json");
                httpClient.BaseAddress = new Uri(BaseUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(MediaType);

                return await httpClient.GetStringAsync(url);
            }
        }
        #endregion


        #region Implementation of ISverigesRadioRepository interface

        /// <summary>
        /// Fetch list of podcasts based on filter parameters
        /// <param name="filter">filters</param>
        /// <example>
        /// programid=3117
        /// </example>
        /// </summary> 
        public async Task<PodcastsWrapper> FetchPodcastsAsync(string filter)
        {
            string url = "podfiles?format=json";
            url += filter.QueryParamFormatter();
            string podcastResponse = await FetchDataAsync(url);
            var podcasts = podcastResponse.CastTo<PodcastsWrapper>();
            return podcasts;
        }

        /// <summary>
        /// Fetch list of programs based on filter parameters
        /// <param name="filter">filters</param>
        /// <example>
        /// filter=program.hasondemand&filterValue=false
        /// channelid=164&programcategoryid=14 
        /// </example>
        /// </summary> 
        public async Task<ProgramsWrapper> FetchProgramsAsync(string filter = "", bool fillPodcastList = false)
        {
            string url = "programs/index?format=json";
            url += filter.QueryParamFormatter();
            string podcastResponse = await FetchDataAsync(url);

            var programsWrapper = podcastResponse.CastTo<ProgramsWrapper>();

            if (fillPodcastList)
            {
                var podfiles = await FetchPodfilesAsync(programsWrapper.Programs);

                foreach (var program in programsWrapper.Programs)
                {
                    program.Podcasts = podfiles[program.Id];
                }
            }

            return programsWrapper;
        }

        /// <summary>
        /// Fetch list of all categories
        /// </summary>
        public async Task<List<ProgramCategory>> FetchCategoriesAsync(string filter = "")
        {
            string url = "programcategories?format=json&pagination=false";
            url += filter.QueryParamFormatter();
            string podcastResponse = await FetchDataAsync(url);

            var wrapper = podcastResponse.CastTo<ProgramCategoryWrapper>();

            if (wrapper != null)
            {
                var categories = wrapper.Programcategories;
                return categories;
            }

            return null;
        }
        #endregion


        #region fill podcast for each program
        private async Task<Dictionary<int, List<Podcast>>> FetchPodfilesAsync(List<Program> programs)
        {
            var result = new Dictionary<int, List<Podcast>>();

            await Task.WhenAll(
                programs.Select(async program =>
                {
                    result.Add(program.Id, new List<Podcast>());
                    if (program.Haspod)
                    {
                        var podfiles = await PodcastByProgramAsync(program.Id);
                        if (podfiles != null)
                        {
                            result[program.Id] = podfiles.Podfiles;
                        }
                    }
                })
            );

            return result;
        }

        private async Task<PodcastsWrapper> PodcastByProgramAsync(int id)
        {
            string filter = "&size=3&sort=desc&programid=" + id;
            var data = await FetchPodcastsAsync(filter);
            return data;
        }
        #endregion 
    }
}
