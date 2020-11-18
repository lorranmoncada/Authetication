using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
   public class Validation
    {

        public Validation()
        {
            LstNotifies = new List<Validation>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Validation> LstNotifies;

        public bool ValidaPropriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor) || string.IsNullOrWhiteSpace(nomePropriedade))
            {
                LstNotifies.Add(new Validation { Mensagem = "Campo Obrigatório", NomePropriedade = nomePropriedade });

                return false;
            }

            return true;

        }
    }
}
