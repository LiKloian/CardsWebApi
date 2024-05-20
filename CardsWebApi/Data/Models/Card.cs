using System.ComponentModel.DataAnnotations;

namespace CardsWebApi.Data.Models
{
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string? IbanAccount { get; set; }
        public int HolderId { get; set; }

        [MaxLength(50)]
        public string? HolderLabel { get; set; }
    }
}
