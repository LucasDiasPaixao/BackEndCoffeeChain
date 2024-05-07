using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public partial class Propriedade
{
    public Propriedade()
    {
        Entrada = new HashSet<Entrada>();
        Saida = new HashSet<Saida>();
    }
    public int PropriedadeId { get; set; }

    public int ProdutorId { get; set; }

    public string NomeFazenda { get; set; } = null!;

    public string? CnpjFazenda { get; set; }

    public string? InscEstadual { get; set; }

    public string? TelefonePropriedade { get; set; }

    public string? EnderecoPropriedade { get; set; }

    public string? CidadePropriedade { get; set; }

    public string? UfPropriedade { get; set; }

    public string? EmailPropriedade { get; set; }

    public string? CepPropriedade { get; set; }

    
    public virtual ICollection<Entrada> Entrada { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual Produtores? Produtor { get; set; }

    
    public virtual ICollection<Saida> Saida { get; set; }

}
