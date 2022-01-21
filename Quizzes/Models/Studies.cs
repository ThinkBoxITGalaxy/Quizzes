using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Studies
    {
    [Key]
    [Column("id")]
    public int id { get; set; }
    [Column("sname")]
    public string? sname { get; set; }
    [Column("sdescrip")]
    public string? sdescrip { get; set; }
}
