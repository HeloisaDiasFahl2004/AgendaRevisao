using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaRevisao
{
    internal class Pessoa
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime Aniversario { get; set; }

        public Pessoa()
        {

        }
        public Pessoa CadastrarPessoa(string nome, string telefone, string email, DateTime aniversario)
        {
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
            this.Aniversario = aniversario;
            return new Pessoa();

        }
        public override string ToString()
        {
            return "\nNOME: " + this.Nome + "\nTELEFONE: " + this.Telefone + "\nEMAIL: " + this.Email + "\nANIVERSARIO: " + this.Aniversario.ToShortDateString();
        }
    }
}
