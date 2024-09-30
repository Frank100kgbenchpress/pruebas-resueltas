using System.ComponentModel;
using FoodRebellion;


public class Exam
{
    public static IRankings CreateRankings(INode root)        => new Ranking(root);
    public class Ranking : IRankings
    {
        public INode Root { get; set; }

        public Ranking(INode root) =>    Root = root;
        

        public INode Find(Func<INode, bool> query)    => Find(query,Root);
        INode Find(Func<INode, bool> query, INode actualNode)
        {
            if(actualNode is null) throw new Exception ("No hay nodo padrino");
            if(query(actualNode)) return actualNode;
            return Find(query, actualNode?.Left) ?? Find(query, actualNode?.Right);
        }

        public IEnumerable<INode> GetByLevel(int level)
        {
            if(level <= 0) throw new Exception  ("no se puede acceder a ese nivel");
            List<INode> result = new();
            GetByLevel(Root,1,level,result);
            if(result.Count == 0) throw new Exception("Hasta ahi no llegamos padrino");
            return result;
        }

        void GetByLevel(INode actualNode, int actualLevel, int level, List<INode> result)
        {
            if(actualNode is null) return;
            if(actualLevel == level)
            {
                result.Add(actualNode);
                return;
            } 
            if(actualLevel < level)
            {
                GetByLevel(actualNode.Left!,actualLevel+1,level,result);
                GetByLevel(actualNode.Right!,actualLevel+1,level,result);
            }  

        }

        public void Insert(INode node)
        {
            var aux = Find(node => (node.Left is null && node.Right is not null) || (node.Right is null && node.Left is not null));
            node.Parent = aux;
            if(aux.Left is null) aux.Left = node;
            else if(aux.Right is null) aux.Right = node;
            ReOrder(node,node.Parent);
        }

        void ReOrder(INode insertedNode, INode actualNode)
        {
            if(actualNode is null)
            {
                Root = insertedNode;
                return;
            }
            if(insertedNode.Tastiness > actualNode.Tastiness)
            {
                insertedNode.Parent = actualNode.Parent;
                actualNode.Parent = insertedNode;
                if(HaveParent(insertedNode) && insertedNode.Parent.Left is not null && insertedNode.Parent.Left == actualNode)
                    insertedNode.Parent.Left = insertedNode;
                else if (HaveParent(insertedNode) && insertedNode.Parent.Right is not null && insertedNode.Parent.Right == actualNode )
                    insertedNode.Parent.Right = insertedNode;
                var L = insertedNode.Left;
                var R = insertedNode.Right;
                if(actualNode.Left != insertedNode)
                {
                    insertedNode.Left = actualNode.Left;
                    insertedNode.Left.Parent = insertedNode;
                    insertedNode.Right = actualNode;                     
                }
                if(actualNode.Right != insertedNode)
                {
                    insertedNode.Right = actualNode.Right;
                    insertedNode.Left.Parent = insertedNode;
                    insertedNode.Right = actualNode;
                }
                actualNode.Left = L;
                actualNode.Right = R;
                if(actualNode.Left is not null) actualNode.Left.Parent = actualNode;
                if(actualNode.Right is not null) actualNode.Right.Parent = actualNode;
                ReOrder(insertedNode,insertedNode.Parent);
            }
        }
        bool HaveParent(INode node) => node.Parent is not null;
        
        public void Remove(string name)
        {
            INode node = Find(node => node.Name == name);
            if(node is null) throw new Exception ( " eso no aparece ni en centros espirituales");
            if(node == Root) Root = node.Tasty;
            if(LeafAndLeftParent(node))
            {
                node.Parent!.Left = null;
                return;
            } 
            if(LeafAndRightParent(node))
            {
                node.Parent!.Right = null;
                return;
            } 
            node.Tasty.Parent = node.Parent;
            if(node.Tasty.Parent is not null)
            {
                if(node.Tasty.Parent.Left == node) node.Tasty.Parent.Left = node.Tasty;
                else if(node.Tasty.Parent.Right == node) node.Tasty.Parent.Right = node.Tasty;
            }
            Balance(node.Bland,node.Tasty);

        }
        bool Leaf(INode node) => node.Left is null && node.Right is null && node.Parent is not null;
        bool LeafAndLeftParent(INode node) => Leaf(node) &&  node.Parent!.Left == node;
        bool LeafAndRightParent(INode node) => Leaf(node) && node.Parent!.Right == node; 
        void Balance(INode toBalanceNode, INode actualNode)
        {
            if(toBalanceNode == null) return ;
            if(actualNode.Left == null && actualNode.Right == null)
            {
                actualNode.Left = toBalanceNode;
                return;
            }
            var bland = actualNode.Bland;
            var tasty = actualNode.Tasty;
            if(actualNode.Left is not null && actualNode.Left == bland)
            {
                actualNode.Left = toBalanceNode;
                Balance(bland,tasty);
            }
            if(actualNode.Right is not null && actualNode.Right == bland)
            {
                actualNode.Right = toBalanceNode;
                Balance(bland,tasty);
            }
        }
    }

    public class Node : INode
    {
        public string Name { get; set; }

        public int Tastiness { get; set; }

        public INode? Parent { get; set; }
        public INode? Left { get; set; }
        public INode? Right { get; set; }

        public INode Tasty { get; set; }

        public INode Bland { get; set; }

        public Node(string name, int tastiness) => (Name, Tastiness) = (name, tastiness);
        
    }
}