using Sublime_Backend_Assessment.Models.SverigesRadio.BaseModels;
using System.Collections.Generic;

namespace Sublime_Backend_Assessment.Models.SverigesRadio
{
    public class ProgramGroupedPresenter
    {
        public string Name { get; set; }
        public List<Program> Programs { get; set; }
    }
}