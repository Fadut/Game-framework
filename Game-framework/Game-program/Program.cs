using Game_framework;

World world = new World(10, 10);

Creature player = new Creature(0, 0, 1);
Creature enemy1 = new Creature(6, 6, 21);

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
