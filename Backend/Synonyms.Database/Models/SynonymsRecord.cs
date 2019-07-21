using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Synonyms.Database.Models
{
    public class SynonymsRecord
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Term { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR(MAX)")]
        public string Synonyms { get; set; }
    }
}