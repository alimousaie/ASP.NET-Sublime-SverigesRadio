using Sublime_Backend_Assessment.Models.BaseModels.SverigesRadio;
using Sublime_Backend_Assessment.Models.SverigesRadio.BaseModels;
using System.Collections.Generic;

namespace Sublime_Backend_Assessment.Models.SverigesRadio
{
    public class PodcastsWrapper: ResponseWrapper
    {
        public List<Podcast> Podfiles { get; set; }
    }
}