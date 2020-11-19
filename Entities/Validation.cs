using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
   public class Validation
    {

        public  string NomePropriedade { get; set; }

        public  string Mensagem { get; set; }

        public static bool ValidaPropriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {   
                return false;
            }

            return true;

        }
    }
}
