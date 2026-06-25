// #1 the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string animalSuggestedDonation = "";

// #2 variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";

// #3 array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];
// #4 create sample data ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 45 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            animalSuggestedDonation = "$50";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "gus";
            animalSuggestedDonation = "$50";
            break;

        case 2:
            animalSpecies = "dog";
            animalID = "d3";
            animalAge = "1";
            animalPhysicalDescription = "small white female beagle mix weighing about 20 pounds. not housebroken.";
            animalPersonalityDescription = "friendly and playful, loves attention and short walks.";
            animalNickname = "snow";
            animalSuggestedDonation = "$25";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c1";
            animalAge = "4";
            animalPhysicalDescription = "small gray female tabby with bright green eyes.";
            animalPersonalityDescription = "quiet and affectionate, enjoys sunny windowsills.";
            animalNickname = "misty";
            animalSuggestedDonation = "$20";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
                animalSuggestedDonation = "";
            break;
    }
    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
            ourAnimals[i, 6] = "Suggested donation: " + animalSuggestedDonation;
}
// #5 display the top-level menu options
do
{
    // NOTE: the Console.Clear method is throwing an exception in debug sessions
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    // use switch-case to process the selected menu option
    switch (menuSelection)
    {
        case "1":
            // list all pet info
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("\n\rPress the Enter key to continue");
            readResult = Console.ReadLine();
            break;

        case "2":
            Console.Write("Enter a dog characteristic to search for: ");
            readResult = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(readResult))
            {
                string searchTerm = readResult.Trim().ToLower();
                bool foundDog = false;

                Console.WriteLine();
                for (int i = 0; i < maxPets; i++)
                {
                    string species = ourAnimals[i, 1].Replace("Species: ", "").Trim().ToLower();
                    string physicalDescription = ourAnimals[i, 4].Replace("Physical description: ", "").Trim().ToLower();
                    string personalityDescription = ourAnimals[i, 5].Replace("Personality: ", "").Trim().ToLower();

                    if (species == "dog" &&
                        (physicalDescription.Contains(searchTerm) || personalityDescription.Contains(searchTerm)))
                    {
                        foundDog = true;
                        DisplayAnimalRecord(ourAnimals, i);
                    }
                }

                if (!foundDog)
                {
                    Console.WriteLine($"\nNo dogs found with the characteristic '{readResult.Trim()}'.");
                }
            }

            Console.WriteLine("\nPress the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "exit");

static void DisplayAnimalRecord(string[,] ourAnimals, int animalIndex)
{
    Console.WriteLine();
    for (int i = 0; i < 7; i++)
    {
        Console.WriteLine(ourAnimals[animalIndex, i]);
    }
}