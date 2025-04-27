using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysMedicalAPI.Models;

public partial class Usuario
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(100)]
    public string Apellido { get; set; } = null!;

    public DateOnly? FechaNacimiento { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? Genero { get; set; }

    [StringLength(50)]
    public string? TipoUsuario { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? FechaRegistro { get; set; }

    [InverseProperty("Usuario")]
    public virtual ICollection<Diagnostico> Diagnosticos { get; set; } = new List<Diagnostico>();

    [InverseProperty("UsuarioAsignadoNavigation")]
    public virtual ICollection<Dispositivo> Dispositivos { get; set; } = new List<Dispositivo>();

    [InverseProperty("Usuario")]
    public virtual ICollection<HistorialMedico> HistorialMedicos { get; set; } = new List<HistorialMedico>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Lectura> Lecturas { get; set; } = new List<Lectura>();

    [InverseProperty("Usuario")]
    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
