using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AulaBackT9
{
    public class PessoaFisica : Pessoa
    {
        public string? cpf {get; set;}
        public DateTime dataNascimento {get; set;}
        public override double PagarImposto(float rendimento){

            if (rendimento <= 1500)
            {
                return 0;

            }else if(rendimento > 1500 && rendimento <= 5000)
            {
                return rendimento * .03;

            }else{
                return (rendimento/100) * 5;
            }


        }

        public bool ValidarDataNascimento(DateTime dataNascimento){

            DateTime dataAtual = DateTime.Today;

            double idade = (dataAtual - dataNascimento).TotalDays / 365;

            if (idade >= 18){

                return true;

            }else{

                return false;

            }
        }
    }
}