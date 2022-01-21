using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quizzes.Models
{
    [Keyless]
    public class SubjectView
    {
        [Column("sname")]
        public string? sname { get; set; }
        [Column("sdescrip")]
        public string? sdescrip { get; set; }
        [Column("subname")]
        public string? subname { get; set; }
        [Column("subdesc")]
        public string? subdesc { get; set; }

    }
}
