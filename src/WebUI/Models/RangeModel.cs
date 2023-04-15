using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class RangeModel
    {
        [Required]
        [MinLength(8)]
        [MaxLength(8)]
        public string FromDate { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(8)]
        public string ToDate { get; set; }
    }
}
