using Sublime_Backend_Assessment.Models.BaseModels.SverigesRadio;
using System.Collections.Generic;

namespace Sublime_Backend_Assessment.Models.SverigesRadio.BaseModels
{
    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ProgramCategory Programcategory { get; set; }
        public string Broadcastinfo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Programurl { get; set; }
        public string Programslug { get; set; }
        public string Programimage { get; set; }
        public string Programimagetemplate { get; set; }
        public string Programimagewide { get; set; }
        public string Programimagetemplatewide { get; set; }
        public string Socialimage { get; set; }
        public string Socialimagetemplate { get; set; }
        public List<Socialmediaplatform> Socialmediaplatforms { get; set; }
        public Channel Channel { get; set; }
        public bool Archived { get; set; }
        public bool Hasondemand { get; set; }
        public bool Haspod { get; set; }
        public string Responsibleeditor { get; set; }
        public List<Podcast> Podcasts { get; set; }

    }
}