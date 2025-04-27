using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysMedicalAPI.Models;

[Table("HistorialMedico")]
public partial class HistorialMedico
{
    [Key]
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    [StringLength(255)]
    public string? Evento { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaEvento { get; set; }

    [ForeignKey("UsuarioId")]
    [InverseProperty("HistorialMedicos")]
    public virtual Usuario Usuario { get; set; } = null!;
}
