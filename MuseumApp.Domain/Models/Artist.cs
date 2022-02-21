using System;
namespace MuseumApp.Domain.Models
{
    public class Artist
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string BornLocation { get; set; }
        public string Biography { get; set; }
        public string PictureURL { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
    }
}
