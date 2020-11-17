using System;
using System.Collections.Generic;

namespace WebMVCRazor.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        private static List<Cliente> BaseLocal = new List<Cliente>();

        public void Salvar(){
            BaseLocal.Add(this);
        }
        
        public static List<Cliente> Todos(){
            return BaseLocal;
        }

    }
}
