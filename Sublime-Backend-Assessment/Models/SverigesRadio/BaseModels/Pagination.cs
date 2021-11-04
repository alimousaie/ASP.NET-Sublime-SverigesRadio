namespace Sublime_Backend_Assessment.Models.BaseModels.SverigesRadio
{
    public class Pagination
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public int TotalHits { get; set; }
        public int Totalpages { get; set; }
        public string Nextpage { get; set; }
    }
}