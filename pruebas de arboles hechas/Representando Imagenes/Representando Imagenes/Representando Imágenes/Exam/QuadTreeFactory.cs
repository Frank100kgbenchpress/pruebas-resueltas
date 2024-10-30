namespace Exam
{
    public static class QuadTreeFactory
    {
        public static IQuadtree Create(int size) => new QuadTree(size);
    }
    public class QuadTree : IQuadtree
    {
        int Size {get;}
        int RealSize;
        int MidSize;
        int Pow;
        public QuadNodeColor Color{get;set;}
        public QuadTree(int size) => (Size,RealSize,Pow,MidSize,Color,TopLeft,TopRight,BottomLeft,BottomRight ) = (size,size*size,(int)Math.Round(Math.Log2(size)),(int)Math.Pow(2, Pow - 1),QuadNodeColor.White,null,null,null,null);
        public IQuadtree TopLeft {get;set;}

        public IQuadtree TopRight {get;set;}

        public IQuadtree BottomLeft {get;set;}

        public IQuadtree BottomRight {get;set;}

        public void DrawPixel(int x , int y , bool isBlack)
        {
            if(Color == QuadNodeColor.Black && isBlack) return;
            if(Color == QuadNodeColor.White && !isBlack) return;
            if(Pow == 0)
            {
                Color = isBlack ? QuadNodeColor.Black : QuadNodeColor.White;
                return;
            }
            else
            {
                (IQuadtree, int, int) toPaint = GetZoneAndIndexToPaint(x, y);
                toPaint.Item1.DrawPixel(toPaint.Item2, toPaint.Item3, isBlack);
                UpdateTree();
                return;
            }

        }
        (IQuadtree, int, int) GetZoneAndIndexToPaint(int x, int y)
        {
            (IQuadtree, int, int) toReturn = (null, 0, 0);
            if(TopLeft == null)
            {
                TopLeft = new QuadTree(MidSize);
                TopRight = new QuadTree(MidSize);
                BottomRight = new QuadTree(MidSize);
                BottomLeft = new QuadTree(MidSize);
            }
            if(x < MidSize && y < MidSize)    toReturn = (TopLeft,x,y);
            
            else if(x < MidSize && y >= MidSize)    toReturn = (BottomLeft,x,y-MidSize);
            
            else if(x >= MidSize && y < MidSize)    toReturn = (TopRight,x-MidSize,y);
            
            else if(x >= MidSize && y >= MidSize)    toReturn = (BottomRight,x-MidSize,y-MidSize);
            
            return toReturn;
        }
        void UpdateTree()
        {
            List<IQuadtree> children = [TopLeft, TopRight, BottomLeft, BottomRight];
            int black = 0, white = 0;
            foreach(IQuadtree child in children)
            {
                if(child.Color == QuadNodeColor.Black) black++;
                if(child.Color == QuadNodeColor.White) white++;
            }
            if(black == 4 || white == 4)
            {
                Reduce();
                Color = (black == 4) ? QuadNodeColor.Black : QuadNodeColor.White;
            }
        }
        void Reduce()
        {
            TopLeft = null;
            TopRight = null;
            BottomLeft = null;
            BottomRight = null;
        }
        public int CountPixels()
        {
            if(Color == QuadNodeColor.Black) return RealSize;
            if(Color == QuadNodeColor.Gray)
            {
                int count = 0;
                count += TopLeft.CountPixels();
                count += TopRight.CountPixels();
                count += BottomLeft.CountPixels();
                count += BottomRight.CountPixels();
                return count;
            }
            return 0;
        }        
    }
}
