using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ElectronicsDbApi.Models
{
    [Table("part")]
    public class Part
    {
        [Key]
        [Column("part_id")]
        public int Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("amount")]
        public int Amount { get; set; }

        [Column("description")]
        public string Description { get; set; }

    }
}
