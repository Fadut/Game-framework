using Game_framework;
using System.Diagnostics;

// World x,y created from config
World gameWorld = new World();
Logger.Instance.AddTraceListener(new ConsoleTraceListener());

Console.WriteLine("MaxX: " + gameWorld.MaxX);
Console.WriteLine("MaxY: " + gameWorld.MaxY);

Creature dragon = new Creature(8, 5, 22, "Dragon");
Creature goblin = new Creature(9, 11, 23, "Goblin");

gameWorld.AddCreature(dragon);
gameWorld.AddCreature(goblin);

WorldObject rock = new WorldObject(2, 3, false, 41, "Rock");
WorldObject tree = new WorldObject(2, 4, false, 42, "Tree");

gameWorld.AddWorldObject(rock);
gameWorld.AddWorldObject(tree);


//gameWorld.RemoveCreature(new Creature(7, 8, 23, "Goblin"));  

Console.WriteLine("All creatures in this world:");
foreach (Creature creature in gameWorld.GetCreatures())
{
    creature.EquipWeapon(
        new AttackItem(creature.X, creature.Y, true, 11, 0, "Dookie Destroyer", 12)
    );

    Console.WriteLine("--> " + creature.ToString());
}

/*
 * Three linq expressions below
 */

// Sum all damage of creatures and print to console
Console.WriteLine("total damage {0}, and faton is {1}", gameWorld.GetCreatures().Sum(creature => creature.GetTotalDamage()), "cool" );

// Find a specific creature with a damage over a certain threshold
gameWorld.GetCreatures().Find(creature => creature.GetTotalDamage() > 10);

// Sum all damage of creatures with aggregate function and print to console
int totalWorldCreatureDamage = gameWorld.GetCreatures().Aggregate(0, (total, creature) => { 
    return total + creature.GetTotalDamage();
} );
Console.WriteLine($"Total damage in the world {totalWorldCreatureDamage}");



Console.WriteLine("1st method: All objects in this world:");
gameWorld.GetWorldObjects();

Console.WriteLine("2nd method: All objects in this world:");
gameWorld.PrintWorldObjects();

Logger.Instance.RemoveTraceListener(new ConsoleTraceListener());

Console.ReadLine();