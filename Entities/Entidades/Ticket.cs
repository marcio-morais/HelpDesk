using Entities.Notificacoes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entidades
{
    [Table("Tickets")]
    public class Ticket : Notifies
    {
        [Key]
        [Column("IdTicket")]
        public int IdTicket { get; set; }

        [Column("Assunto")]
        public string Assunto { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("Prioridade")]
        public string Prioridade { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        [Column("Categoria")]
        public string Categoria { get; set; }

        [Column("NomeCliente")]
        public string NomeCliente { get; set; }

        [Column("EmailCliente")]
        public string EmailCliente { get; set; }

        [Column("DataCriacao")]
        public DateTime DataCriacao { get; set; }

        [Column("DataAtualizacao")]
        public DateTime? DataAtualizacao { get; set; }

        [Column("IdResponsavel")]
        public string IdResponsavel { get; set; }

        [Column("IdDepartamento")]
        public int? IdDepartamento { get; set; }

        //[ForeignKey("IdResponsavel")]
        //public ApplicationUser Responsavel { get; set; }

        //[ForeignKey("IdDepartamento")]
        //public Departamento Departamento { get; set; }

        //public virtual ICollection<Comentario> Comentarios { get; set; }

        //public virtual ICollection<Anexo> Anexos { get; set; }
    }
}