using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace H5ServersideMonday.Components.Models
{
    public class ToDoList
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "int")]
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Item { get; set; }
    }
}
