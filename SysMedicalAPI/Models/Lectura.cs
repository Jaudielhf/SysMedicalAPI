using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysMedicalAPI.Models;

public partial class Lectura
{
    [Key]
    public int Id { get; set; }

    public int UsuarioId { get; set; }

    public int DispositivoId { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Temperatura { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Peso { get; set; }

    [Column(TypeName = "decimal(5, 2)")]
    public decimal? Estatura { get; set; }

    public int? Pulso { get; set; }

    [StringLength(500)]
    public string? FotoUrl { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaLectura { get; set; }

    [ForeignKey("DispositivoId")]
    [InverseProperty("Lecturas")]
    public virtual Dispositivo Dispositivo { get; set; } = null!;

    [ForeignKey("UsuarioId")]
    [InverseProperty("Lecturas")]
    public virtual Usuario Usuario { get; set; } = null!;
}
