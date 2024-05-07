using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public partial class Produtores
{

    public Produtores()
    {
        Propriedades = new HashSet<Propriedade>();
        Entrada = new HashSet<Entrada>();
        Saida = new HashSet<Saida>();
    }

    public int ProdutorId { get; set; }

    public string NomeProdutor { get; set; }

    public string? CpfProdutor { get; set; }

    public string? RgProdutor { get; set; }

    public string? TelefoneProdutor { get; set; }

    public string? EnderecoProdutor { get; set; }

    public string? CidadeProdutor { get; set; }

    public string? UfProdutor { get; set; }

    public string? EmailProdutor { get; set; }

    public string? CepProdutor { get; set; }
    

    public virtual ICollection<Entrada> Entrada { get; set; }
    
    public virtual ICollection<Propriedade> Propriedades { get; set; }

    public virtual ICollection<Saida> Saida { get; set; }
}
