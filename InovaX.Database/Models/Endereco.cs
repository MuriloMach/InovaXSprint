﻿using System.ComponentModel.DataAnnotations;

public class Endereco
{
    
    public int IdEndereco { get; set; }
    public string CEP { get; set; }
    public string Rua { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Estado { get; set; }
    public string Numero { get; set; }
    public string Cidade { get; set; }
}
