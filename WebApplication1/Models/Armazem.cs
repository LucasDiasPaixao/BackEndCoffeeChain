using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public partial class Armazem
{
    public Armazem() 
    {
        Entrada = new HashSet<Entrada>();
    }

    public int ArmazemId { get; set; }

    public int EmpresaId { get; set; }

    public string? TelefoneArmazem { get; set; }

    public string? EnderecoArmazem { get; set; }

    public string? CidadeArmazem { get; set; }

    public string? UfArmazem { get; set; }

    public string? EmailArmazem { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual Empresa? Empresa { get; set; }

    
    public virtual ICollection<Entrada> Entrada { get; set; }
}

