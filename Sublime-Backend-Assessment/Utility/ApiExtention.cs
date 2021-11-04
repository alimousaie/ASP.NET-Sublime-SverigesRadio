using Newtonsoft.Json;
using Sublime_Backend_Assessment.Models.SverigesRadio;
using Sublime_Backend_Assessment.Models.SverigesRadio.BaseModels;
using System.Collections.Generic;
using System.Linq;

namespace Sublime_Backend_Assessment.Utility
{
    public static class ApiExtention
    {
        public static string QueryParamFormatter(this string filter)
        {
            string filterUrl = string.IsNullOrEmpty(filter) ? "" : "&" + filter.Trim();
            return filterUrl;
        }

        public static T CastTo<T>(this string response)
        {
            T resolved = JsonConvert.DeserializeObject<T>(response);
            return resolved;
        }

        public static IEnumerable<ProgramGroupedPresenter> CastTo(this ProgramsWrapper programsWrapper)
        {
            IEnumerable<ProgramGroupedPresenter> result;
            List<Program> programList = programsWrapper.Programs;
            result = programList.OrderBy(p => p.Channel.Name)
                .ThenBy(p => p.Name)
                .GroupBy(p => p.Channel.Name)
                .Select(g => new ProgramGroupedPresenter { Name = g.Key, Programs = g.ToList() });

            return result;
        }
    }
}