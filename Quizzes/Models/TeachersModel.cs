using System.ComponentModel.DataAnnotations.Schema;

namespace Quizzes.Models
{
    [Keyless]
    public class TeachersModel
    {
        [Column("id")]
        public string? id { get; set; }
        [Column("fname")]
        public string? fname { get; set; }
        [Column("mname")]
        public string? mname { get; set; }
        [Column("lname")]
        public string? lname { get; set; }
        [Column("descrip")]
        public string? descrip { get; set; }
        [Column("position")]
        public string? position { get; set; }
    }
}
