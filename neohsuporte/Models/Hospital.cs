using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace neohsuporte.Models
{
    public class Hospital : Entity
    {
        [Required(ErrorMessage ="O campo {0} é de preenchimento obrigatório")]
        [DisplayName("CNPJ da Unidade")]
        public string CnpjHospital { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nome do Hospital")]
        public string NmHospital { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [DisplayName("Hospital é grupo?")]
        public bool HospitalGrupo { get; set; }
        
        public bool SnAtivo { get; set; }
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        public TipoSistema TipoSistema { get; set; }



        /* EF Relations */

        
        public IEnumerable<PedidoSuporte> PedidoSuportes { get; set; }
    }
}
