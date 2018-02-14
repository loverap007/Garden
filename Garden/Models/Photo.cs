using System.ComponentModel.DataAnnotations;

namespace Garden.Models
{
    public class Photo : AModel
    {
        public string FileName { get; set; }

        public string MimeType { get; set; }

        public string PathToFile { get; set; }
    }
}
