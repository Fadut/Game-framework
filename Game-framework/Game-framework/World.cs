using System.Xml;

namespace Game_framework
{
    /// <summary>
    /// Represents the game world. Includes size of 2D game grid in x, y coordinates, and lists of creatures and objects.
    /// </summary>
    public class World
    {
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }
        private List<Creature> _creatures;
        private List<WorldObject> _worldObjects;
        private const string _configFilePath = @"C:\\Users\\Faton\\source\\repos\\Game-framework\\Game-framework\\Game-framework\config.xml"; // Default config file path

        // manual input constructor
        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
            _creatures = new List<Creature>();
            _worldObjects = new List<WorldObject>();
        }

        // constructor reading from config file
        public World()
        {
            LoadConfiguration(_configFilePath);
            _creatures = new List<Creature>();
            _worldObjects = new List<WorldObject>();
        }

        /// <summary>
        /// Adds a new creature to the world. Also logs name of creature added.
        /// </summary>
        /// <param name="creature">The creature to add.</param>
        public void AddCreature(Creature creature)
        {
            _creatures.Add(creature);
            Logger.Instance.LogInformation($"Creature added: {creature.Name}");
        }

        /// <summary>
        /// Removes a creature from the world. Logs name.
        /// </summary>
        /// <param name="creature">The creature to remove.</param>
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

        // for LINQ usage
        public List<Creature> GetCreatures()
        {
            return _creatures;
        }

        // for LINQ usage
        public List<WorldObject> GetWorldObjects()
        {
            return _worldObjects;
        }

        /// <summary>
        /// Gets all world objects in the world.
        /// </summary>
        public void PrintWorldObjects()
        {
            foreach (WorldObject worldObject in _worldObjects)
            {
                Console.WriteLine(worldObject);
            }
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
