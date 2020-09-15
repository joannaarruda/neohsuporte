using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace neohsuporte.Models
{
    public class AtenderPedido : Entity
    {

       
        public Guid UsuarioId { get; set; }
        public Guid PedidoSuporte { get; set; }

        [DisplayName("Observação do Atendimento do Pedido")]
        public string ObservacaoAtend { get; set; }
        public DateTime DataConclusao { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [DisplayName("Status do Pedido")]
        public StatusPedido StatusPedido { get; set; }

        /* EF Relation */
        public Usuario Usuario { get; set; }


    }
}
