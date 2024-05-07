using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WebApplication1.Models;

public partial class Empresa
{
    public Empresa()
    {
        Armazem = new HashSet<Armazem>();
        Entrada = new HashSet<Entrada>();
        Saida = new HashSet<Saida>();   
    }

    [Key]
    public int EmpresaId { get; set; }

    public string RazaoSocial { get; set; }

    public string NomeFantasia { get; set; }

    public string? CnpjEmpresa { get; set; }

    public string? TelefoneEmpresa { get; set; }

    public string? EnderecoEmpresa { get; set; }

    public string? CidadeEmpresa { get; set; }

    public string? UfEmpresa { get; set; }

    public string? PaisEmpresa { get; set; }

    public string? CepEmpresa { get; set; }

    public string? EmailEmpresa { get; set; }

   
    public virtual ICollection<Armazem> Armazem { get; set; }

    
    public virtual ICollection<Entrada> Entrada { get; set; }

    
    public virtual ICollection<Saida> Saida { get; set; }
}
