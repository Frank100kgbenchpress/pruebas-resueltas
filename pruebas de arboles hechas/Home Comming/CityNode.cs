namespace HomeComming
{
    public class CityNode
    {
        List<(int, CityNode)> roads;
        CityNode? teleport;

        public CityNode(CityNode? teleport = null, List<(int, CityNode)>? roads = null)
        {
            this.roads = (roads is null) ? new() : roads;
            this.teleport = teleport;
        }

        public (int, CityNode)[] Roads()=> roads.ToArray();
        
        public (bool, CityNode?) HasTeleport() => (teleport != null, teleport);
        
    }
}
