﻿using System.ComponentModel.DataAnnotations;

namespace consultaCep_backend.Entities
{
    public class EnderecoEntite
    {
        [Key]
        public int Id { get; set; }
        public string? Cep { get; set; } = string.Empty;
        public string? Logradouro { get; set; } = string.Empty;
        public string? Complemento { get; set; } = string.Empty;
        public string? Bairro { get; set; } = string.Empty;
        public string? Localidade { get; set; } = string.Empty;
        public string? Uf { get; set; } = string.Empty;
        public long? Unidade { get; set; }
        public int? Ibge { get; set; }
        public string? Gia{ get; set; } = string.Empty;
    }
}
