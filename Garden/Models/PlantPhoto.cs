namespace Garden.Models
{
    public class PlantPhoto : AModel
    {
        public string PathToPhoto { get; set; }

        public int? PlantId { get; set; }
        public Plant Plant { get; set; }
    }
}
