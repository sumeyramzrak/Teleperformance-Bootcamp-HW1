using System.ComponentModel.DataAnnotations;

namespace Bootcamp.Odev1
{
    public class Movie
    {
        [Required(ErrorMessage = "Bu alan boþ býrakýlamaz!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan boþ býrakýlamaz!")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public DateTime Year { get; set; }
    }
}