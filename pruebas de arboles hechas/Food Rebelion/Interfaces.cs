namespace FoodRebellion
{
    public interface INode
    {
        public string Name { get; }
        public int Tastiness { get; }

        public INode? Parent { get; set; }
        public INode? Left { get; set; }
        public INode? Right { get; set; }

        public INode Tasty { get; }
        public INode Bland { get; }
    }
    public interface IRankings
    {
        public INode Root { get; }

        public void Remove(string name);

        public void Insert(INode node);

        public INode Find(Func<INode, bool> query);

        public IEnumerable<INode> GetByLevel(int level);
    }

}