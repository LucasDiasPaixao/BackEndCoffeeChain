using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public partial class Entrada
{
    public Entrada()
    {
        Saida = new HashSet<Saida>();
    }
    [Key]
    public int EntradaId { get; set; }

    public int ProdutorId { get; set; }

    public int PropriedadeId { get; set; }

    public int EmpresaId { get; set; }

    public int ArmazemId { get; set; }

    public DateTime DataEntrada { get; set; }

    public string CodigoLote { get; set; } = null!;

    public decimal QtdSacas { get; set; }

    public decimal PrecoLote { get; set; }

    public decimal? CustoEntrada { get; set; }

    public string? NfeEntrada { get; set; }

    public int? TipoEntrada { get; set; }

    public string? Safra { get; set; }

    public string? TipoCafe { get; set; }

    public string? LocalArmazenado { get; set; }

    public string? EmbalagemArmazenado { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual Armazem? Armazem { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual Empresa? Empresa { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual Produtores? Produtor { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual Propriedade? Propriedade { get; set; }

    public virtual ICollection<Saida> Saida { get; set; }
}
