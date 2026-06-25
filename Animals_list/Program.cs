using System.Text;

const int StartingCapacity = 4;
const string DataFileName = "animals.txt";

string[] ourAnimals = new string[StartingCapacity];
int animalCount = LoadAnimals(DataFileName, ref ourAnimals);

Console.WriteLine("Current animal records:\n");
DisplayAnimals(ourAnimals, animalCount);

while (true)
{
	Console.WriteLine();
	Console.WriteLine("Choose an option:");
	Console.WriteLine("1 - Add a new animal");
	Console.WriteLine("2 - Save records and exit");
	Console.Write("Selection: ");

	string? selection = Console.ReadLine();

	if (selection == "1")
	{
		if (animalCount >= ourAnimals.Length)
		{
			Array.Resize(ref ourAnimals, ourAnimals.Length + StartingCapacity);
		}

		ourAnimals[animalCount] = ReadAnimalRecord(animalCount + 1);
		animalCount += 1;

		Console.WriteLine("Animal added.\n");
		DisplayAnimals(ourAnimals, animalCount);
	}
	else if (selection == "2")
	{
		SaveAnimals(DataFileName, ourAnimals, animalCount);
		Console.WriteLine($"Records saved to '{DataFileName}'.");
		break;
	}
	else
	{
		Console.WriteLine("Please enter 1 or 2.");
	}
}

static int LoadAnimals(string fileName, ref string[] ourAnimals)
{
	if (!File.Exists(fileName))
	{
		return 0;
	}

	string[] lines = File.ReadAllLines(fileName);

	if (lines.Length > ourAnimals.Length)
	{
		Array.Resize(ref ourAnimals, lines.Length);
	}

	int count = 0;
	foreach (string line in lines)
	{
		if (string.IsNullOrWhiteSpace(line))
		{
			continue;
		}

		ourAnimals[count] = line.Trim();
		count += 1;
	}

	return count;
}

static void SaveAnimals(string fileName, string[] ourAnimals, int animalCount)
{
	var records = new List<string>(animalCount);

	for (int index = 0; index < animalCount; index++)
	{
		if (!string.IsNullOrWhiteSpace(ourAnimals[index]))
		{
			records.Add(ourAnimals[index]);
		}
	}

	File.WriteAllLines(fileName, records, Encoding.UTF8);
}

static void DisplayAnimals(string[] ourAnimals, int animalCount)
{
	if (animalCount == 0)
	{
		Console.WriteLine("No animal records found.");
		return;
	}

	for (int index = 0; index < animalCount; index++)
	{
		Console.WriteLine($"{index + 1}. {ourAnimals[index]}");
	}
}

static string ReadAnimalRecord(int animalNumber)
{
	Console.WriteLine($"Enter data for animal {animalNumber}.");
	Console.Write("ID: ");
	string id = ReadRequiredValue();

	Console.Write("Species: ");
	string species = ReadRequiredValue();

	Console.Write("Age: ");
	string age = ReadRequiredValue();

	Console.Write("Nickname: ");
	string nickname = ReadRequiredValue();

	Console.Write("Description: ");
	string description = ReadRequiredValue();

	return string.Join("|", id, species, age, nickname, description);
}

static string ReadRequiredValue()
{
	while (true)
	{
		string? value = Console.ReadLine();

		if (!string.IsNullOrWhiteSpace(value))
		{
			return value.Trim();
		}

		Console.Write("Value is required. Try again: ");
	}
}
