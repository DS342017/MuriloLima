using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }
        public string NomeMedicamento { get; set; }
        public string QtdeMedicamento { get; set; }
        public string CodCliente { get; set; }
        public string DataEntrega { get; set; }

    }
}