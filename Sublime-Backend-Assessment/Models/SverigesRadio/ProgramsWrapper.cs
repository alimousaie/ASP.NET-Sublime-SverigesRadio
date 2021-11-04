using Sublime_Backend_Assessment.Models.BaseModels.SverigesRadio;
using Sublime_Backend_Assessment.Models.SverigesRadio.BaseModels;
using System.Collections.Generic;

namespace Sublime_Backend_Assessment.Models.SverigesRadio
{
    public class ProgramsWrapper: ResponseWrapper
    {
        public List<Program> Programs { get; set; }
    }
}