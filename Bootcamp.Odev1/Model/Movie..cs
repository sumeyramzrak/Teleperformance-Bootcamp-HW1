using System.ComponentModel.DataAnnotations;

namespace Bootcamp.Odev1
{
    public class Movie
    {
        [Required(ErrorMessage = "Bu alan bo� b�rak�lamaz!")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu alan bo� b�rak�lamaz!")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public DateTime Year { get; set; }
    }
}