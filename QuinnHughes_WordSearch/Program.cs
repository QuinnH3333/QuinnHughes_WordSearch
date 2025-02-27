namespace QuinnHughes_WordSearch
{
    using System;
    using System.IO;
    using System.Reflection.Metadata;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    internal class Program
    {
        static void Main(string[] args)
        {
            WriteToFile();
            PlayWordSearch();
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
          "YordleChampions",
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
        /// <summary>
        /// Reads words.txt and generates a 20x20 word search with 8 words from the player's selected category. 
        /// </summary>
        static void PlayWordSearch()
        {
            string[] allWords = File.ReadAllLines("words.txt");


            //Declarations for categories and word selection
            Random rand = new Random();
            int selectedCategoryIndex = 0;
            string[] categoryWords = new string[15];
            string[] selectedWords = new string[8];
            //changing the amount of words in category will also change the location of the category title.
            //The +2 comes from the category title and the "" space. Repeated elsewhere.
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
            selectedCategoryIndex = PlayerInputIndex(categoryNames);

            //Select 8 words from category, no repeats
            for (int i = 0; i < categoryWords.Length; i++)
            {
                categoryWords[i] = allWords[(selectedCategoryIndex * (categoryWords.Length + 2)) + 1 + i];
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

            //output 20x20 grid of "." then write the 8 words, cardinal directions
            Console.WriteLine("Word Search *now with dots!*");
            //Declarations for assigning word placements
            int randomY = 0;
            int randomX = 0;
            int wordLength = 0;
            int spacesOpen = 0;
            bool wordCanFit = false;
            int randomPrintDirection;
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
            };

            //Place all 8 selected words on the board using 1 of 4 random directions
            foreach (string word in selectedWords)
            {
                string selectedWordForward = word;
                string selectedWordBackward = ReverseWord(word);

                randomPrintDirection = rand.Next(0, 4); //max is exclusive true range is min to max-1

                switch (randomPrintDirection)
                {
                    case 0:
                        Horizontal(randomY, randomX, blankBoard, selectedWordForward, wordLength, spacesOpen, wordCanFit, rand);
                        break;
                    case 1:
                        Horizontal(randomY, randomX, blankBoard, selectedWordBackward, wordLength, spacesOpen, wordCanFit, rand);
                        break;
                    case 2:
                        Vertical(randomY, randomX, blankBoard, selectedWordForward, wordLength, spacesOpen, wordCanFit, rand);
                        break;
                    case 3:
                        Vertical(randomY, randomX, blankBoard, selectedWordBackward, wordLength, spacesOpen, wordCanFit, rand);
                        break;
                }
            }
            //Draw board
            for (int i = 0; i < blankBoard.Length; i++)
            {
                if (i < 11) { Console.WriteLine(i + 1 + "  " + blankBoard[i]); }
                else { Console.WriteLine(i + 1 + " " + blankBoard[i]); }

            }


            //Player guess
            //declarations
            int guessedWordIndex = PlayerInputIndex(selectedWords);
            int guessedX;
            int guessedY;
            string[] directions = { "up", "down", "forwards", "backwards" };
            int guessedDirection;
            bool validGuess = false;

            while (validGuess == false)
            {
                Console.WriteLine("What column (horizontal position) is the beginning of the word?");
                guessedX = PlayerInputInt(0, blankBoard[1].Length);
                Console.WriteLine("What Row (Vertical position) is the beginning of the word?");
                guessedY = PlayerInputInt(0, blankBoard[1].Length);

                guessedDirection = PlayerInputIndex(directions);

                Console.WriteLine(selectedWords[guessedWordIndex] + " " + directions[guessedDirection] + " at " + "(" + guessedX + ", " + guessedY + ")");
                validGuess = GuessWord(blankBoard, selectedWords[guessedWordIndex], guessedX, guessedY, guessedDirection);
                Console.WriteLine("You're right?  " + validGuess);
            }
        }
        /// <summary>
        /// Loops attempting to place a word horizontally without overwriting characters other than ".", exits loop when placing succeeds. 
        /// </summary>
        /// <param name="randomY">The selected string in the board string array</param>
        /// <param name="randomX">The selected starting character in the selected string</param>
        /// <param name="blankBoard">The string array for the board</param>
        /// <param name="wordDirectional">Selected word to be placed, can be forwards or backwards</param>
        /// <param name="selectedWordLength">Length of selected word</param>
        /// <param name="spacesOpen">Number of characters in the selected string checked that were "."</param>
        /// <param name="wordCanFit">If the word can fit in the spaces chosen or not</param>
        /// <param name="rand">random</param>
        static void Horizontal(int randomY, int randomX, string[] blankBoard, string wordDirectional, int selectedWordLength, int spacesOpen, bool wordCanFit, Random rand)
        {
            while (true)
            {
                randomY = rand.Next(0, blankBoard.Length);
                randomX = rand.Next(0, 20);
                selectedWordLength = wordDirectional.Length;

                spacesOpen = 0;
                wordCanFit = false;
                if ((20 - randomX) < selectedWordLength)
                {
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
                    blankBoard[randomY] =
                        blankBoard[randomY].Substring(0, randomX)
                        + wordDirectional
                        + blankBoard[randomY].Substring(randomX + selectedWordLength);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        /// <summary>
        /// Loops attempting to place a word vertically without overwriting characters other than ".", exits loop when placing succeeds. 
        /// </summary>
        /// <param name="randomY">The selected string in the board string array</param>
        /// <param name="randomX">The selected starting character in the selected string</param>
        /// <param name="blankBoard">The string array for the board</param>
        /// <param name="wordDirectional">Selected word to be placed, can be forwards or backwards</param>
        /// <param name="selectedWordLength">Length of selected word</param>
        /// <param name="spacesOpen">Number of characters in the selected string checked that were "."</param>
        /// <param name="wordCanFit">If the word can fit in the spaces chosen or not</param>
        /// <param name="rand">random</param>
        static void Vertical(int randomY, int randomX, string[] blankBoard, string wordDirectional, int selectedWordLength, int spacesOpen, bool wordCanFit, Random rand)
        {
            while (true)
            {
                randomY = rand.Next(0, blankBoard.Length);
                randomX = rand.Next(0, 20);
                selectedWordLength = wordDirectional.Length;


                spacesOpen = 0;
                wordCanFit = false;
                if ((20 - randomY) < selectedWordLength)
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < selectedWordLength; j++) //for how ever many letter in your word 
                    {
                        if (blankBoard[randomY + j].Substring(randomX, 1) == ".") //if the char is a "."
                        {
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
                    for (int j = 0; j < selectedWordLength; j++)
                    {
                        blankBoard[randomY + j] =
                            blankBoard[randomY + j].Substring(0, randomX)
                            + wordDirectional[j]
                            + blankBoard[randomY + j].Substring(randomX + 1);
                    }
                    break;
                }
                else
                {
                    continue;
                }

            }
        }
        /// <summary>
        /// Reverses the input word and returns it as a string.
        /// </summary>
        /// <param name="word"> Input to be reversed </param>
        /// <returns> the reversed word as a string</returns>
        static string ReverseWord(string word)
        {
            string reversedWord = "";
            for (int i = word.Length; i > 0; i--)
            {
                reversedWord = reversedWord + word[i - 1];
            }
            return reversedWord;
        }
        /// <summary>
        /// Outputs options of string array, Finds the Index of a player's input in a string array. 
        /// Loops until an input matches, not case or null sensitive
        /// </summary>
        /// <param name="array">string array with the options of the</param>
        /// <returns>Index of the input given by the player</returns>
        static int PlayerInputIndex(string[] array)
        {
            Console.WriteLine("Please type one of these options:");
            int i = 0;
            foreach (string word in array)
            {

                Console.WriteLine(word);
                array[i] = word.ToUpper();
                i++;
            }

            int InputIndexNumber = 0;
            bool isValidInput = false;
            while (!isValidInput)
            {
                string? playerInput = Console.ReadLine().ToUpper();

                if (array.Contains(playerInput))
                {
                    InputIndexNumber = Array.IndexOf(array, playerInput); //In the array categoryNames, finds the Index number of playerInput
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }
            return InputIndexNumber;
        }

        static int PlayerInputInt(int rangeMin, int rangeMax)
        {
            int parsedInt = 0;
            bool isValidInput = false;
            while (!isValidInput)
            {
                if (int.TryParse(Console.ReadLine(), out int playerInput)) //If parse success, move onto range check
                {
                    if ((playerInput > rangeMin) && (playerInput <= rangeMax))
                    {
                        parsedInt = playerInput;
                        isValidInput = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Number out of bounds. Pick between 1-20");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                }
            }

            return parsedInt;
        }
        static bool GuessWord(string[] board, string word, int x, int y, int direction)
        {
            //string[] directions = { "up", "down", "forwards", "backwards" }
            bool isValid = false;
            int guessedLetters = 0;
            switch (direction)
            {
                //case 0:
                //    for (int i = 0; i < word.Length; i++)
                //    {
                //        if (word.Substring(i, 1) == board[y+i].Substring(x, 1))
                //        {
                //            guessedLetters++;
                //            if (guessedLetters == word.Length)
                //            {
                //                isValid = true;
                //                break;
                //            }
                //        }
                //    }
                //    break;
                //    case 1:
                //    for (int i = 0; i < word.Length; i++)
                //    {
                //        if (word.Substring(i, 1) == board[y-1].Substring(x, 1))
                //        {
                //            guessedLetters++;
                //            if (guessedLetters == word.Length)
                //            {
                //                isValid = true;
                //                break;
                //            }
                //        }
                //    }
                //    break;
                case 2: //forwards
                    for (int i = 0; i < word.Length; i++)
                    {
                        if ((20 - x) < word.Length)
                        {
                            Console.WriteLine("Out of bounds.");
                            break;
                        }
                        if (word.Substring(i, 1) == (board[y - 1].Substring(x - 1 + i, 1)).ToUpper()) //y and x both need -1 since arrays start at 0 not 1
                        {

                            guessedLetters++;
                            if (guessedLetters == word.Length)
                            {
                                isValid = true;
                                break;
                            }
                        }
                        //Console.WriteLine((word.Substring(i, 1)) + " vs " + (board[y - 1].Substring(x - 1 + i, 1))); //Remove Debug
                    }
                    break;
                case 3: //Backwards
                    for (int i = 0; i < word.Length; i++)
                    {
                        if ((20 + x) > word.Length)
                        {
                            Console.WriteLine("Out of bounds.");
                            break;
                        }
                        if (word.Substring(i, 1) == (board[y - 1].Substring(x - 1 - i, 1)).ToUpper())
                        {
                            guessedLetters++;
                            if (guessedLetters == word.Length)
                            {
                                isValid = true;
                                break;
                            }
                        }
                        //Console.WriteLine((word.Substring(i, 1)) + " vs " + board[y - 1].Substring(x - 1 - i, 1)); //Remove Debug
                    }
                    break;
            }

            return isValid;
        }
    }
}


