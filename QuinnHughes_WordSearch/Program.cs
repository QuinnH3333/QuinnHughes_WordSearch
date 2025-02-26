namespace QuinnHughes_WordSearch
{
    using System;
    using System.IO;
    using System.Reflection.Metadata;

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
            bool isValidInput = false;
            int chosenCategoryInt = 0;
            string[] categoryWords = new string[15];
            string[] selectedWords = new string[8];
            //changing the amount of words in category will also change the location of the category title. The +2 comes from the category title and the "" space. Repeated elsewhere.
            string[] categoryNames =
                {
                allWords[0],
                allWords[1 * (categoryWords.Length + 2)],
                allWords[2 * (categoryWords.Length + 2)],
                allWords[3 * (categoryWords.Length + 2)],
                allWords[4 * (categoryWords.Length + 2)],
                allWords[5 * (categoryWords.Length + 2)],
                allWords[6 * (categoryWords.Length + 2)],
                allWords[7 * (categoryWords.Length + 2)],
                allWords[8 * (categoryWords.Length + 2)],
                allWords[9 * (categoryWords.Length + 2)]
            };

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
                categoryWords[i] = allWords[(chosenCategoryInt * (categoryWords.Length + 2)) + 1 + i];

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
                        break;
                    }
                }
            }

            //output 20x20 grid of "."
            Console.WriteLine("Word Search *now with dots!*");
            //substrings??
            string[] blankBoard =
            {
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
                "....................",
            };

            int randomY = 0;
            int randomX = 0;
            int wordLength = 0;
            int spacesOpen = 0;
            bool wordCanFit = false;
            int randomPrintDirection;

            foreach (string word in selectedWords)
            {
                string selectedWordForward = word;
                string selectedWordBackward = ReverseWord(word);

                randomPrintDirection = rand.Next(0, 2); //max is exclusive 

                switch (randomPrintDirection)
                {
                    case 0:
                        Horizontal(randomY, randomX, blankBoard, selectedWordForward, wordLength, spacesOpen, wordCanFit, rand);
                        break;
                    case 1:
                        Horizontal(randomY, randomX, blankBoard, selectedWordBackward, wordLength, spacesOpen, wordCanFit, rand);
                        break;
                }
            }
            for (int i = 0; i < blankBoard.Length; i++)
            {
                Console.WriteLine(blankBoard[i]);
            }

        }
        static void Horizontal(int randomY, int randomX, string[] blankBoard, string wordDirectional, int selectedWordLength, int spacesOpen, bool wordCanFit, Random rand)
        {
            for (int i = 0; i <= 0; i++)
            {
                randomY = rand.Next(0, blankBoard.Length);
                randomX = rand.Next(0, 20);
                selectedWordLength = wordDirectional.Length;


                spacesOpen = 0;
                wordCanFit = false;
                if ((20 - randomX) < selectedWordLength)
                {
                    i--;
                    continue;
                }
                else
                {
                    for (int j = 0; j < selectedWordLength; j++) //for how ever many letter in your word 
                    {
                        if (blankBoard[randomY].Substring(randomX + j, 1) == ".") //if the char is a "."
                        {
                            //move to next char
                            spacesOpen++;
                        }
                        if (spacesOpen == selectedWordLength)
                        {
                            wordCanFit = true;
                            break;
                        }
                    }
                }

                if (wordCanFit == true)
                {
                    blankBoard[randomY] = blankBoard[randomY].Substring(0, randomX) + wordDirectional + blankBoard[randomY].Substring(randomX + selectedWordLength);
                    continue;
                }
                else
                {
                    i--;
                }
            }
        }
        static string ReverseWord(string word)
        {
            string reversedWord = "";
            for (int i = word.Length; i > 0; i--)
            {
                reversedWord = reversedWord + word[i - 1];
            }
            return reversedWord;
        }

    }
}


