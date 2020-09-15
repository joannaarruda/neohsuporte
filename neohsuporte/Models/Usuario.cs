using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace neohsuporte.Models
{
    public class Usuario : Entity
    {
        public Guid HospitalId { get; set; }
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [DisplayName("Nome do Usuário/ Desenvolvedor")]
        public string Nome { get; set; }
       
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [DisplayName("E-mail")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [DisplayName("Telefone para contato")]
        public string Telefone { get; set; }
        public string CargoOcupacao { get; set; }
        
        [DisplayName("Ativo?")]
        public bool SnAtivo { get; set; }
        public DateTime DataCadastro { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
        [DisplayName("Perfil do Usuário")]
        public TipoUsuario TipoUsuario { get; set; }

        /* EF Relations */

        public IEnumerable<Hospital> Hospitais { get; set; }
        public IEnumerable<PedidoSuporte> PedidoSuportes { get; set; }

        public static bool ValidaCPF(string Cpf)

        {

            string valor = Cpf.Replace(".", "");
            valor = valor.Replace("-", "");



            if (valor.Length != 11)
                return false;
            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;



            if (igual || valor == "12345678909")

                return false;
            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)

                numeros[i] = int.Parse(

                  valor[i].ToString());
               int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];
            int resultado = soma % 11;
            
            if (resultado == 1 || resultado == 0)

            {

                if (numeros[9] != 0)

                    return false;

            }

            else if (numeros[9] != 11 - resultado)

                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += (11 - i) * numeros[i];
            resultado = soma % 11;



            if (resultado == 1 || resultado == 0)

            {

                if (numeros[10] != 0)

                    return false;

            }

            else

                if (numeros[10] != 11 - resultado)

                return false;
            return true;

        }
    }


}
