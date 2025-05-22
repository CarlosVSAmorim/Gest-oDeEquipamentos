using System;

namespace GestãoDeEquipamentos
{
    public class ChamadoManutencao : EntidadeBase
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Equipamento Equipamento { get; set; }
        public DateTime DataAbertura { get; set; }

        public int DiasAberto => (DateTime.Now - DataAbertura).Days;

        public ChamadoManutencao(string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
        {
            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentException("O título do chamado não pode ser vazio.");
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("A descrição do chamado não pode ser vazia.");
            if (equipamento == null)
                throw new ArgumentException("O equipamento associado ao chamado não pode ser nulo.");

            Titulo = titulo;
            Descricao = descricao;
            Equipamento = equipamento;
            DataAbertura = dataAbertura;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Título: {Titulo}, Equipamento: {Equipamento.Nome}, Abertura: {DataAbertura:dd/MM/yyyy}, Dias aberto: {DiasAberto}";
        }
    }
}