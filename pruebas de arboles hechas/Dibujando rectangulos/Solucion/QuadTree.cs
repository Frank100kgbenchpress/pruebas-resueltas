namespace QUadTreeSolution
{
    public class QuadTreeNode
    {
        public int X { get; }
        public int Y { get; }
        public int Ancho { get; }
        public int Largo { get; }
        public Color Color { get; set; }
        public QuadTreeNode[] Hijos { get; set; }
        public QuadTreeNode(int x, int y, int ancho, int largo, Color color) => (X,Y ,Ancho , Largo , Color , Hijos ) = (x,y,ancho,largo,color,null);
    }   
}