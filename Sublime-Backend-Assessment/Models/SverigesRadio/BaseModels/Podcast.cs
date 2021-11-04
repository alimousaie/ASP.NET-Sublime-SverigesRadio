using Sublime_Backend_Assessment.Models.BaseModels.SverigesRadio;
using Sublime_Backend_Assessment.Utility;

namespace Sublime_Backend_Assessment.Models.SverigesRadio.BaseModels
{
    public class Podcast
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long Filesizeinbytes { get; set; }
        public Channel Program { get; set; }
        public string Availablefromutc { get; set; }

        private string _duration;
        public string Duration
        {
            get => _duration.DurationFormater();
            set { _duration = value; }
        }

        private string _publishdateutc;
        public string Publishdateutc
        {
            get => _publishdateutc.DateParser().DateFormater();
            set { _publishdateutc = value; }
        }
        public string Url { get; set; }
        public string Statkey { get; set; }
    }
}