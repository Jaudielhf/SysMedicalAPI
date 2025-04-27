using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysMedicalAPI.Models;

public partial class Dispositivo
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(50)]
    public string? Tipo { get; set; }

    [StringLength(255)]
    public string? Descripcion { get; set; }

    public int? UsuarioAsignado { get; set; }

    [InverseProperty("Dispositivo")]
    public virtual ICollection<Lectura> Lecturas { get; set; } = new List<Lectura>();

    [ForeignKey("UsuarioAsignado")]
    [InverseProperty("Dispositivos")]
    public virtual Usuario? UsuarioAsignadoNavigation { get; set; }
}
