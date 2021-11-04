using Sublime_Backend_Assessment.Models.BaseModels.SverigesRadio;
using System.Collections.Generic;

namespace Sublime_Backend_Assessment.Models.SverigesRadio
{
    public class ProgramCategoryWrapper : ResponseWrapper
    {
        public List<ProgramCategory> Programcategories { get; set; }
    }
}