using System;

namespace GestãoDeEquipamentos
{
    public class Equipamento : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string NumeroSerie { get; set; }
        public DateTime DataFabricacao { get; set; }
        public string Fabricante { get; set; }

        public Equipamento(string nome, decimal preco, string numeroSerie, DateTime dataFabricacao, string fabricante)
        {
            if (string.IsNullOrWhiteSpace(nome) || nome.Length < 6)
                throw new ArgumentException("Nome deve ter pelo menos 6 caracteres.");

            if (preco < 0)
                throw new ArgumentException("Preço não pode ser negativo.");

            if (string.IsNullOrWhiteSpace(numeroSerie))
                throw new ArgumentException("Número de série não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(fabricante))
                throw new ArgumentException("Fabricante não pode ser vazio.");

            Nome = nome;
            Preco = preco;
            NumeroSerie = numeroSerie;
            DataFabricacao = dataFabricacao;
            Fabricante = fabricante;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Nome: {Nome}, Preço: R${Preco:F2}, Fabricante: {Fabricante}, Fabricação: {DataFabricacao:dd/MM/yyyy}";
        }
    }
}