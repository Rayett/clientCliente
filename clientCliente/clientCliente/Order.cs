using System;
using System.Collections.Generic;
using System.Text;

namespace clientCliente
{
    class Order
    {
        public string tipo;
        public float costo;
        public string citta = null;
        public string stato = null;
        public int peso;
        public string dataAcq;
        public int FKPortoStart = -1;
        public int FKViaggioCamion = -1;
        public float tempoSt = -1;
        public string data = null;
    }
}
