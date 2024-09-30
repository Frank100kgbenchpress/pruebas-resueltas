using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weboo.Examen.Interfaces;

namespace Weboo.Examen
{
    public class Lienzo : ILienzo
    {
        public Lienzo(int N)
        {
            throw new NotImplementedException();
        }

        public int Resolucion
        {
            get { throw new NotImplementedException(); }
        }

        public int CantidadDeNodosBlancos
        {
            get { throw new NotImplementedException(); }
        }

        public int CantidadDeNodosNegros
        {
            get { throw new NotImplementedException(); }
        }

        public int CantidadDeNodosGrises
        {
            get { throw new NotImplementedException(); }
        }

        public void Dibuja(int fila, int columna, int ancho, int alto)
        {
            throw new NotImplementedException();
        }

        public bool EstaPintado(int fila, int columna)
        {
            throw new NotImplementedException();
        }
    }
}
