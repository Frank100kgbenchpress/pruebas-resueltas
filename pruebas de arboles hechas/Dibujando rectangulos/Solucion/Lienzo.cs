namespace QUadTreeSolution
{
    public class Lienzo : ILienzo
    {
        QuadTreeNode root;
        public int Resolucion => root.Ancho * root.Largo;
        public Lienzo(int N)
        {
            int size = (int)Math.Pow(2, N);
            root = new QuadTreeNode(0, 0, size, size, Color.Blanco);
        }
        public int CantidadDeNodosBlancos => CountNodesByColor(root, Color.Blanco);
        public int CantidadDeNodosNegros => CountNodesByColor(root, Color.Negro);
        public int CantidadDeNodosGrises => CountNodesByColor(root, Color.Gris);
        public void Dibuja(int fila, int columna, int ancho, int alto) => DibujaRectangulo(root, fila, columna, ancho, alto);
        public bool EstaPintado(int fila, int columna) => EstaPintadoRecursivo(root, fila, columna);
        void DibujaRectangulo(QuadTreeNode nodo, int fila, int columna, int ancho, int alto)
        {
            if (nodo.Color == Color.Negro)    return;
            if (RectanguloCubreNodo(nodo, fila, columna, ancho, alto))
            {
                nodo.Color = Color.Negro;
                nodo.Hijos = null;
                return;
            }
            if (nodo.Color == Color.Blanco)    SubdividirNodo(nodo);
            foreach (var hijo in nodo.Hijos)
            {
                if (RectanguloIntersecaNodo(hijo, fila, columna, ancho, alto))    DibujaRectangulo(hijo, fila, columna, ancho, alto);
            }

            if (TodosLosHijosSonNegros(nodo))
            {
                nodo.Color = Color.Negro;
                nodo.Hijos = null;
            }
            else nodo.Color = Color.Gris;
        }
        bool EstaPintadoRecursivo(QuadTreeNode nodo, int fila, int columna)
        {
            if (nodo.Color == Color.Negro)    return true;
            
            if (nodo.Color == Color.Blanco || nodo.Hijos == null)    return false;
            foreach (var hijo in nodo.Hijos)
            {
                if (PuntoDentroDelNodo(hijo, fila, columna))    return EstaPintadoRecursivo(hijo, fila, columna);   
            }
            return false;
        }
        void SubdividirNodo(QuadTreeNode nodo)
        {
            int midWidth = nodo.Ancho / 2;
            int midHeight = nodo.Largo / 2;
            nodo.Hijos = new QuadTreeNode[4];
            nodo.Hijos[0] = new QuadTreeNode(nodo.X, nodo.Y, midWidth, midHeight, Color.Blanco); // Top-left
            nodo.Hijos[1] = new QuadTreeNode(nodo.X, nodo.Y + midHeight, midWidth, midHeight, Color.Blanco); // Bottom-left
            nodo.Hijos[2] = new QuadTreeNode(nodo.X + midWidth, nodo.Y, midWidth, midHeight, Color.Blanco); // Top-right
            nodo.Hijos[3] = new QuadTreeNode(nodo.X + midWidth, nodo.Y + midHeight, midWidth, midHeight, Color.Blanco); // Bottom-right
        }

        bool RectanguloCubreNodo(QuadTreeNode nodo, int fila, int columna, int ancho, int alto)
        {
            return fila <= nodo.X && columna <= nodo.Y && 
                (fila + alto) >= (nodo.X + nodo.Largo) && 
                (columna + ancho) >= (nodo.Y + nodo.Ancho);
        }
        bool RectanguloIntersecaNodo(QuadTreeNode nodo, int fila, int columna, int ancho, int alto)
        {
            return !(fila + alto <= nodo.X || nodo.X + nodo.Largo <= fila ||
                    columna + ancho <= nodo.Y || nodo.Y + nodo.Ancho <= columna);
        }

        private bool TodosLosHijosSonNegros(QuadTreeNode nodo)
        {
            return nodo.Hijos != null && nodo.Hijos.All(hijo => hijo.Color == Color.Negro);
        }

        private bool PuntoDentroDelNodo(QuadTreeNode nodo, int fila, int columna)
        {
            return fila >= nodo.X && fila < nodo.X + nodo.Largo &&
                columna >= nodo.Y && columna < nodo.Y + nodo.Ancho;
        }

        int CountNodesByColor(QuadTreeNode nodo, Color color)
        {
            if (nodo.Hijos == null)        return nodo.Color == color && color != Color.Gris ? 1 : 0;
            int count = nodo.Color == color && color == Color.Gris ? 1 : 0;
            return count + nodo.Hijos.Sum(hijo => CountNodesByColor(hijo, color));
        }
    }
}