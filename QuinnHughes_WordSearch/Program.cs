namespace QuinnHughes_WordSearch
{
    using System.IO;
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteToFile();
            StartWS();
        }
        private static void WriteToFile()
        {
            string wordsFilePath = "words.txt";
            string[] allWords =
            {
          "FairyTailCharacters",
          "Natsu",
          "Lucy",
          "Gray",
          "Jellal",
          "Wendy",
          "Juvia",
          "Gajeel",
          "Mirajane",
          "Happy",
          "Loki",
          "Erza",
          "Laxus",
          "Cana",
          "Sting",
          "Rogue",
          "",
          "Zodiacs",
          "Aries",
          "Taurus",
          "Gemini",
          "Cancer",
          "Leo",
          "Virgo",
          "Libra",
          "Scorpio",
          "Sagittarius",
          "Capricorn",
          "Aquarius",
          "Pisces",
          "Ophiuchus",
          "Orion",
          "Cetus",
          "",
          "RomanceAnime",
          "Clannad",
          "Toradora",
          "Horimiya",
          "Nisekoi",
          "Orange",
          "MaidSama",
          "KamisamaKiss",
          "OHSHC",
          "FruitsBasket",
          "SpecialA",
          "Anohana",
          "ReLife",
          "Chihayafuru",
          "Tonikawa",
          "SkipBeat",
          "",
          "OHSHCCharacters",
          "Tamaki",
          "Haruhi",
          "Kyoya",
          "Hikaru",
          "Kaoru",
          "Honey",
          "Mori",
          "Renge",
          "Nekozawa",
          "Ranka",
          "Kasanoda",
          "Yasuchika",
          "Satoshi",
          "Eclair",
          "Mei",
          "",
          "GenshinCharacters",
          "Raiden",
          "Zhongli",
          "Nahida",
          "Xiao",
          "Kazuha",
          "Childe",
          "Fischl",
          "Arlecchino",
          "Wanderer",
          "Capitano",
          "Alhaitham",
          "Yelan",
          "Neuvillette",
          "Furina",
          "Cyno",
          "",
          "ShadesOfGreen",
          "Emerald",
          "Jade",
          "Mint",
          "Olive",
          "Forest",
          "Lime",
          "Teal",
          "Chartreuse",
          "Sage",
          "Moss",
          "Fern",
          "Pine",
          "Seafoam",
          "Shamrock",
          "Cypress",
          "",
          "VastayanChampions",
          "Ahri",
          "Rakan",
          "Xayah",
          "Wukong",
          "Nidalee",
          "Neeko",
          "Sett",
          "Nami",
          "Rengar",
          "Aurora",
          "Yuumi",
          "Lillia",
          "Kayn",
          "Alune",
          "Lest",
          "",
          "Yordle Champions",
          "Teemo",
          "Tristana",
          "Veigar",
          "Lulu",
          "Heimerdinger",
          "Poppy",
          "Corki",
          "Rumble",
          "Kennen",
          "Ziggs",
          "Fizz",
          "Amumu",
          "Kled",
          "Norra",
          "Vex",
          "",
          "GreekGods",
          "Zeus",
          "Hera",
          "Poseidon",
          "Demeter",
          "Athena",
          "Apollo",
          "Artemis",
          "Ares",
          "Aphrodite",
          "Hermes",
          "Hades",
          "Hestia",
          "Dionysus",
          "Persephone",
          "Nyx",
          "",
          "WordsForLove",
          "Affection",
          "Adoration",
          "Devotion",
          "Passion",
          "Fondness",
          "Amour",
          "Romance",
          "Desire",
          "Yearning",
          "Sentiment",
          "Tenderness",
          "Infatuation",
          "Worship",
          "Attraction",
          "Endearment",
      };
            File.WriteAllLines(wordsFilePath, allWords);
        }
        static void StartWS()
        {
            string[] allWords = File.ReadAllLines("words.txt");


            //Select Category
            string[] categoryNames = { allWords[0], allWords[17], allWords[34], allWords[51], allWords[68], allWords[85], allWords[102], allWords[119], allWords[136], allWords[153] };
            bool isValidInput = false;
            int chosenCategoryInt = 0;
            string[] categoryWords = new string[15];
            string[] selectedWords = new string[8];
            Random rand = new Random();

            Console.WriteLine("Choose a category by typing its name exactly:");
            for (int i = 0; i < categoryNames.Length; i++)
            {
                Console.WriteLine(categoryNames[i]);
            }

            while (!isValidInput) 
            {
                string? playerInput = Console.ReadLine();
                if (categoryNames.Contains(playerInput))
                {

                    chosenCategoryInt = Array.IndexOf(categoryNames, playerInput); //In the array categoryNames, finds the Index number of playerInput
                    //should remove
                    Console.WriteLine("You selected category: " + categoryNames[chosenCategoryInt]);
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }

            //Select 8 words from category, no repeats
            for (int i = 0; i < categoryWords.Length; i++)
            {
                categoryWords[i] = allWords[(chosenCategoryInt * (categoryWords.Length+2)) + 1 + i];
                //changing the amount of words in category will also increase here. The +2 comes from the category title and the "" space
            }
            
            for (int i = 0; i < selectedWords.Length; i++)
            {
                string possibleWord;
                possibleWord = categoryWords[rand.Next(0, 14)];
                foreach (string word in selectedWords)
                {
                    if (selectedWords.Contains(possibleWord))
                    {
                        i--;
                        break;
                    }
                    else
                    {
                        selectedWords[i] = possibleWord;
                        Console.WriteLine(selectedWords[i]);
                        break;
                    }
                }
            }

            //output 20x20 grid of "."
            Console.WriteLine("Word Search *naked edition*:");

            //string[,]??
                //substrings??
        }
    }
}
