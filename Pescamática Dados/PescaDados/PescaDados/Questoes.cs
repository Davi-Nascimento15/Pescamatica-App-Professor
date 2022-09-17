using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PescaDados
{
    class Questoes
    {
        private string pergunta;
        private int alternativa1;
        private int alternativa2;
        private int alternativa3;
        private int alternativa4;
        private int alternativa5;
        private int alternativa6;
        private int alternativa7;
        private int reposta;

        public string Pergunta { get => pergunta; set => pergunta = value; }
        public int Alternativa1 { get => alternativa1; set => alternativa1 = value; }
        public int Alternativa2 { get => alternativa2; set => alternativa2 = value; }
        public int Alternativa3 { get => alternativa3; set => alternativa3 = value; }
        public int Alternativa4 { get => alternativa4; set => alternativa4 = value; }
        public int Alternativa5 { get => alternativa5; set => alternativa5 = value; }
        public int Alternativa6 { get => alternativa6; set => alternativa6 = value; }
        public int Alternativa7 { get => alternativa7; set => alternativa7 = value; }
        public int Reposta { get => reposta; set => reposta = value; }
    }
}
