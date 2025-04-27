using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SysMedicalAPI.Models;

public partial class Medicamento
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [StringLength(255)]
    public string? Descripcion { get; set; }

    [StringLength(100)]
    public string? DosisRecomendada { get; set; }

    [InverseProperty("Medicamento")]
    public virtual ICollection<Receta> Receta { get; set; } = new List<Receta>();
}
