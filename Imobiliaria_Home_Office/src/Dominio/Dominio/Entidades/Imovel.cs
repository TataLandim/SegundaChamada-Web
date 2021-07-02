using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Imovel
    {
        public Imovel(string cidade, string bairro, int qtdDeQuartos, decimal valorDoAluguel)
        {
            Cidade = cidade;
            Bairro = bairro;
            QtdDeQuartos = qtdDeQuartos;
            ValorDoAluguel = valorDoAluguel;
        }

        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public int QtdDeQuartos { get; set; }
        public decimal ValorDoAluguel { get; set; }

        public void AtualizarImovel(string cidade, string bairro, int qtdDeQuartos, decimal valorDoAluguel)
        {
            this.Cidade = cidade;
            this.Bairro = bairro;
            this.QtdDeQuartos = qtdDeQuartos;
            this.ValorDoAluguel = valorDoAluguel;
        }
    }
}
