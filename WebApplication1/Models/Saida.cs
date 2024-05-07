using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public partial class Saida
{
    public int SaidaId { get; set; }

    public int DestinoProdutorId { get; set; }

    public int DestinoPropriedadeId { get; set; }

    public int DestinoEmpresaId { get; set; }

    public int EntradaId { get; set; }

    public DateTime? DataSaida { get; set; }

    public decimal? QtdSacas { get; set; }

    public int? TipoSaida { get; set; }

    public decimal? PrecoSaida { get; set; }

    public decimal? CustoSaida { get; set; }

    public string? NfeSaida { get; set; }

    public string? EmbalagemSaida { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual Empresa? DestinoEmpresa { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual Produtores? DestinoProdutor { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual Propriedade? DestinoPropriedade { get; set; }

    [JsonIgnore]
    [IgnoreDataMember]
    public virtual Entrada? Entrada { get; set; } 
}
