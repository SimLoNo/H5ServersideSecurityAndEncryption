using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H5ServersideMonday.Components.Models
{
    public class CprEntry
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string User { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Cpr { get; set; }
    }
}
