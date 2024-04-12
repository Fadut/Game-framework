using System.Xml;

namespace Game_framework
{
    public class World
    {
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        private List<Creature> _creatures;
        private List<WorldObject> _worldObjects;
        private const string _configFilePath = @"C:\\Users\\Faton\\source\\repos\\Game-framework\\Game-framework\\Game-framework\config.xml"; // Default config file path

        // manual input ctor
        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            _creatures = new List<Creature>();
            _worldObjects = new List<WorldObject>();
        }

        // constructor for reading config file
        public World()
        {
            LoadConfiguration(_configFilePath);
            _creatures = new List<Creature>();
            _worldObjects = new List<WorldObject>();
        }

        public void AddCreature(Creature creature)
        {
            _creatures.Add(creature);
            Logger.Instance.LogInformation($"Creature added: {creature.Name}");
        }

        public void RemoveCreature(Creature creature)
        {
            _creatures.Remove(creature);
            Logger.Instance.LogInformation($"Creature removed: {creature.Name}");
        }

        public void AddWorldObject(WorldObject worldObject)
        {
            _worldObjects.Add(worldObject);
            Logger.Instance.LogInformation($"World object added: {worldObject.Name}");
        }

        public void RemoveWorldObject(WorldObject worldObject)
        {
            _worldObjects.Remove(worldObject);
            Logger.Instance.LogInformation($"World object removed: {worldObject.Name}");
        }

        public IEnumerable<Creature> GetCreatures()
        {
            return _creatures;
        }

        private void LoadConfiguration(string configFilePath)
        {
            try
            {
                if (!File.Exists(configFilePath))
                {
                    throw new FileNotFoundException("Config file not found", configFilePath);
                }

                XmlDocument doc = new XmlDocument();
                doc.Load(configFilePath);

                XmlNode worldNode = doc.SelectSingleNode("//Configuration/WorldSettings");
                if (worldNode != null)
                {
                    XmlNode maxXNode = worldNode.SelectSingleNode("MaxX");
                    XmlNode maxYNode = worldNode.SelectSingleNode("MaxY");

                    if (maxXNode != null && maxYNode != null)
                    {
                        MaxX = int.Parse(maxXNode.InnerText);
                        MaxY = int.Parse(maxYNode.InnerText);
                    }
                    else
                    {
                        throw new Exception("MaxX or MaxY not found in configuration file.");
                    }
                }
                else
                {
                    throw new Exception("WorldSettings node not found in configuration file.");
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.LogError("An error occurred while loading configuration. " + ex.Message);
                // Console.WriteLine("An error occurred while loading configuration: " + ex.Message);
            }
        }
    }
}
