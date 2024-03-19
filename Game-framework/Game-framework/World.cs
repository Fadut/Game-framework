namespace Game_framework
{
    public class World
    {
        public int MaxX { get; private set; }
        public int MaxY { get; private set;}
        private List<Creature> _creatures;
        private List<WorldObject> _worldObjects;

        public World(int maxX, int maxY )
        {
            MaxX = maxX;
            MaxY = maxY;
            _creatures = new List<Creature>();
            _worldObjects = new List<WorldObject>();
        }

        public void AddCreature(Creature creature)
        {
            _creatures.Add(creature);
        }

        public void RemoveCreature(Creature creature)
        {
            _creatures.Remove(creature);
        }

        public void AddWorldObject(WorldObject worldObject)
        {
            _worldObjects.Add(worldObject);
        }

        public void RemoveWorldObject(WorldObject worldObject)
        {
            _worldObjects.Remove(worldObject);
        }
    }
}
