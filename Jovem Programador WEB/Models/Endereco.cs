﻿namespace Jovem_Programador_WEB.Models
{
    public class Endereco
    {
        public string cep { get; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
    }
}
