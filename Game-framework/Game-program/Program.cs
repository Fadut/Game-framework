using Game_framework;
using System.Diagnostics;

World world = new World(10, 10);

Creature player = new Creature(0, 0, 1, "Hero");
Creature enemy1 = new Creature(6, 6, 21, "Spider");

world.AddCreature(player);
world.AddCreature(enemy1);

AttackItem sword = new AttackItem(2, 2, true, 10, 1, "Sword", 1);
DefenseItem shield = new DefenseItem(3, 3, true, 10, "Shield", 2);

world.AddWorldObject(sword);
world.AddWorldObject(shield);

player.Loot(sword);
player.Loot(shield);

// Equip weapon - needs logic implemented
// player.EquipWeapon(0);

int damageDealt = player.Hit(enemy1);
Console.WriteLine($"Player dealt {damageDealt} to enemy1");

Console.WriteLine(player.HitPoints);
Console.WriteLine(enemy1.HitPoints);

player.ReceiveHit(15);

enemy1.ReceiveHit(150);
Console.WriteLine($"Player received a hit. Player HP after hit: {player.HitPoints}");

// ABOVE: Is for fast testing purpose, below is more tested



// World x,y created from config
World worldConfig = new World();

Console.WriteLine("MaxX: " + worldConfig.MaxX);
Console.WriteLine("MaxY: " + worldConfig.MaxY);

Logger.Instance.AddTraceListener(new ConsoleTraceListener());

worldConfig.AddCreature(new Creature(7, 7, 22, "Dragon"));
worldConfig.AddCreature(new Creature(7, 8, 23, "Goblin"));


worldConfig.AddWorldObject(new WorldObject(2, 3, false, 41, "Rock"));

Console.WriteLine(player.Name);
Console.WriteLine(enemy1.Name);
Console.WriteLine(player.UniqueId);
Console.WriteLine(enemy1.UniqueId);

worldConfig.RemoveCreature(new Creature(7, 8, 23, "Goblin"));

Console.WriteLine("All creatures in world:");
foreach (Creature creature in worldConfig.GetCreatures())
{
    Console.WriteLine(creature.ToString());
}

Logger.Instance.RemoveTraceListener(new ConsoleTraceListener());

Console.ReadLine();