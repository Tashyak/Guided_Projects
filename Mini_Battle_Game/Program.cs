using System;

var random = new Random();

var player = new Fighter("Player", maxHealth: 30, attackPower: 8, healPower: 6);
var monster = new Fighter("Monster", maxHealth: 24, attackPower: 7, healPower: 0);

Console.WriteLine("Turn-Based Combat");
Console.WriteLine("You fight a Monster.");
Console.WriteLine();

while (player.IsAlive && monster.IsAlive)
{
	Console.WriteLine($"{player.Name}: {player.Health}/{player.MaxHealth} HP");
	Console.WriteLine($"{monster.Name}: {monster.Health}/{monster.MaxHealth} HP");
	Console.WriteLine();
	Console.WriteLine("Choose an action:");
	Console.WriteLine("1. Attack");
	Console.WriteLine("2. Heal");
	Console.Write("> ");

	var choice = Console.ReadLine();

	if (choice == "2")
	{
		var healed = player.Heal(random.Next(3, player.HealPower + 1));
		Console.WriteLine($"You recover {healed} health.");
	}
	else
	{
		var damage = player.Attack(random.Next(1, player.AttackPower + 1));
		monster.TakeDamage(damage);
		Console.WriteLine($"You strike the Monster for {damage} damage.");
	}

	if (!monster.IsAlive)
	{
		break;
	}

	var monsterTurn = random.Next(0, 100);
	if (monsterTurn < 20)
	{
		Console.WriteLine("Monster hesitates and misses its turn.");
	}
	else
	{
		var damage = monster.Attack(random.Next(1, monster.AttackPower + 1));
		player.TakeDamage(damage);
		Console.WriteLine($"Monster hits you for {damage} damage.");
	}

	Console.WriteLine();
}

Console.WriteLine(player.IsAlive ? "You won the battle!" : "You were defeated.");

sealed class Fighter
{
	public Fighter(string name, int maxHealth, int attackPower, int healPower)
	{
		Name = name;
		MaxHealth = maxHealth;
		Health = maxHealth;
		AttackPower = attackPower;
		HealPower = healPower;
	}

	public string Name { get; }

	public int MaxHealth { get; }

	public int Health { get; private set; }

	public int AttackPower { get; }

	public int HealPower { get; }

	public bool IsAlive => Health > 0;

	public int Attack(int damage)
	{
		return Math.Max(1, damage);
	}

	public int Heal(int amount)
	{
		var healed = Math.Max(1, amount);
		var actualHealed = Math.Min(MaxHealth - Health, healed);
		Health = Math.Min(MaxHealth, Health + healed);
		return actualHealed;
	}

	public void TakeDamage(int damage)
	{
		Health = Math.Max(0, Health - Math.Max(1, damage));
	}
}
