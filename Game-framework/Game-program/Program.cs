﻿using Game_framework;
using Game_framework.Decorator;
using Game_framework.Factory;
using System.Diagnostics;

// World x,y created from config file
World gameWorld = World.Instance;

// Prints duplicate, since Add methods in World.cs already calls logger info
// Logger.Instance.AddTraceListener(new ConsoleTraceListener());

Console.WriteLine("Game world created.");
Console.WriteLine("Game world size in x-coordinate is: " + gameWorld.MaxX);
Console.WriteLine("Game world size in y-coordinate is: " + gameWorld.MaxY);
Console.WriteLine();

Creature hero = new Creature(1, 1, 91, "Hero");
Creature zombie = new Creature(8, 5, 22, "Zombie");
Creature goblin = new Creature(9, 11, 23, "Goblin");
Creature spider = new Creature(19, 19, 24, "Spider"); // gets removed 

gameWorld.AddCreature(hero);
gameWorld.AddCreature(zombie);
gameWorld.AddCreature(goblin);

WorldObject rock = new WorldObject(2, 3, false, 41, "Rock");
WorldObject tree = new WorldObject(2, 4, false, 42, "Tree");

gameWorld.AddWorldObject(rock);
gameWorld.AddWorldObject(tree);

gameWorld.RemoveCreature(spider);
Console.WriteLine(); // for spacing

Console.WriteLine("All objects in this world:");
gameWorld.PrintWorldObjects();
Console.WriteLine();

Console.WriteLine("All creatures in this world equip a weapon:");
foreach (Creature creature in gameWorld.GetCreatures())
{
    creature.EquipWeapon(
        new AttackItem(creature.X, creature.Y, true, 17, "melee", "Sword", 12)
    );

    Console.WriteLine("--> " + creature.ToString());
}
Console.WriteLine(); // for spacing

/*
 * Three+ linq expressions below
 */

// Sum all damage of creatures and print to console
Console.WriteLine("Damage sum of all creatures:");
Console.WriteLine("Total damage = {0}", gameWorld.GetCreatures().Sum(creature => creature.GetTotalDamage()));

// Find a specific creature with a damage over a certain threshold
Console.WriteLine();
Console.WriteLine("LINQ find: Creature with > 10 damage.");
// Prints only first occurence, hero in this case. Only for showing linq expression
gameWorld.GetCreatures().Find(creature => creature.GetTotalDamage() > 10);
Console.WriteLine(gameWorld.GetCreatures().Find(creature => creature.GetTotalDamage() > 10));
Console.WriteLine();

// Sum all damage of creatures with aggregate function and print to console
int totalWorldCreatureDamage = gameWorld.GetCreatures().Aggregate(0, (total, creature) => { 
    return total + creature.GetTotalDamage();
} );
Console.WriteLine($"Total damage in the world = {totalWorldCreatureDamage}");
Console.WriteLine();

// LINQ Find by name
Console.WriteLine(gameWorld.FindCreatureByName("Hero"));
Console.WriteLine();

// LINQ find best weapon
Console.WriteLine("Strongest Weapon:");
Console.WriteLine(gameWorld.FindMostEffectiveWeapon());
Console.WriteLine();

Console.WriteLine($"Hero current damage is: {hero.GetTotalDamage()}");
Console.WriteLine($"Zombie health: {zombie.HitPoints}");
hero.Hit(zombie);
hero.Hit(zombie);
hero.Hit(zombie);
hero.Hit(zombie);
hero.Hit(zombie);
hero.Hit(zombie);
hero.Hit(zombie);
hero.Hit(zombie);
Console.WriteLine($"Zombie health {zombie.HitPoints}");
Console.WriteLine();

// check for singleton pattern
World sameWorld = World.Instance;
Console.WriteLine($"Is gameWorld the same instance as sameWorld? {gameWorld == sameWorld}");

// factory pattern
IWeaponFactory swordFactory = new SwordFactory();
Weapon randomSword = swordFactory.CreateWeapon();
Console.WriteLine($"Random Sword: {randomSword}");

Logger.Instance.RemoveTraceListener(new ConsoleTraceListener());
Console.ReadLine();