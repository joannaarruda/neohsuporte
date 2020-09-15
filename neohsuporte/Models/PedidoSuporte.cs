using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace neohsuporte.Models
{
    public class PedidoSuporte : Entity
    {
        public Guid UsuarioId { get; set; }
        public Guid HospitalId { get; set; }
        public DateTime DataPedido { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [DisplayName("Tipo do Chamado")]
        public TipoChamado TipoChamado { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Título")]
        public string TituloChamado { get; set; }

        [DisplayName("Imagem")]
        public string Imagem { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [StringLength(5000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Observação do Pedido")]
        public string ObservacaoChamado { get; set; }

        [DisplayName("Status do Pedido")]
        public StatusPedido StatusPedido { get; set; }
        public DateTime DataConclusao { get; set; }

        /* EF Relations */

        public Usuario Usuario { get; set; }
        public Hospital Hospital { get; set; }
    }
}
