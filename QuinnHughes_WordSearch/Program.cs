namespace QuinnHughes_WordSearch
{
    using System;
    using System.IO;

    internal class Program
    {
        static void Main(string[] args)
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

            //declarations
            //Player guess
            string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string[] cosmeticBoard = GenerateAestheticBoard(blankBoard, rand, Alphabet);
            int guessedWordIndex;
            int guessedX;
            int guessedY;
            string[] directions = { "up", "down", "forwards", "backwards" };
            int guessedDirection;
            //win condition
            bool isValidGuess = false;
            string[] wordsUnguessed = selectedWords;
            int numberOfWordsGuessed = 0;
            

            //gameplay loop
            while (numberOfWordsGuessed < 8)
            {
                foreach (string line in cosmeticBoard)
                {
                    Console.WriteLine(line);
                }

                //prompt player
                guessedWordIndex = PlayerInputIndex(wordsUnguessed);
                Console.WriteLine("What column (horizontal position) is the beginning letter of the word?");
                guessedX = PlayerInputInt(1, blankBoard[1].Length);
                Console.WriteLine("What Row (Vertical position) is the beginning letter of the word?");
                guessedY = PlayerInputInt(1, blankBoard[1].Length);
                Console.WriteLine("What direction does the word flow from the first letter to the last?");
                guessedDirection = PlayerInputIndex(directions);

                //Output guess and verify
                Console.WriteLine( "Word: "+ wordsUnguessed[guessedWordIndex] + " at " + "(" + guessedX + ", " + guessedY + ")" + " going: " + directions[guessedDirection]);
                isValidGuess = GuessVerification(blankBoard, wordsUnguessed[guessedWordIndex], guessedX, guessedY, guessedDirection);
                
                //if guess correct, update array
                if (isValidGuess)
                {
                    Console.WriteLine("You guessed right!");
                    numberOfWordsGuessed++;
                    string[] placeholderArray = new string[selectedWords.Length - numberOfWordsGuessed];
                    int x = 0;
                    for (int i = 0; i < wordsUnguessed.Length; i++)
                    {
                        if (guessedWordIndex == i)
                        {
                            continue;
                        }
                        else
                        {
                            placeholderArray[x] = wordsUnguessed[i];
                            x++;
                        }
                    }
                    wordsUnguessed = placeholderArray;
                }
            }
            Console.WriteLine("You found all the words! Game Over.");
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
        /// <summary>
        /// Parses a player's input within a controlled range.
        /// </summary>
        /// <param name="rangeMin">Inclusive bottom bound</param>
        /// <param name="rangeMax">Inclusive top bound</param>
        /// <returns>Int within range</returns>
        static int PlayerInputInt(int rangeMin, int rangeMax)
        {
            int parsedInt = 0;
            bool isValidInput = false;
            while (!isValidInput)
            {
                if (int.TryParse(Console.ReadLine(), out int playerInput)) //If parse success, move onto range check
                {
                    if ((playerInput >= rangeMin) && (playerInput <= rangeMax))
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
        /// <summary>
        /// Validates the guess of a word's location.
        /// </summary>
        /// <param name="board">Word Search board</param>
        /// <param name="word">Guessed word</param>
        /// <param name="x">Guessed X or column location</param>
        /// <param name="y">Guessed Y or row location</param>
        /// <param name="direction">Guessed direction 0-3 </param>
        /// <returns>Bool if a guess was correct (true) or not (false) </returns>
        static bool GuessVerification(string[] board, string word, int x, int y, int direction)
        {
            bool isValid = false;
            int guessedLetters = 0;
            switch (direction)
            {
                case 0: //up
                    for (int i = 0; i < word.Length; i++)
                    {
                        if ((y) < word.Length)
                        {
                            Console.WriteLine("Out of bounds.");
                            break;
                        }
                        if (word.Substring(i, 1) == (board[y - 1 - i].Substring(x - 1, 1)).ToUpper()) //y and x both need -1 since arrays start at 0 not 1
                        {
                            guessedLetters++;
                            if (guessedLetters == word.Length)
                            {
                                isValid = true;
                                break;
                            }
                        }
                    }
                    break;
                case 1://down
                    for (int i = 0; i < word.Length; i++)
                    {
                        if ((20 - y) < word.Length)
                        {
                            Console.WriteLine("Out of bounds.");
                            break;
                        }
                        if (word.Substring(i, 1) == (board[y - 1 + i].Substring(x - 1, 1)).ToUpper())
                        {
                            guessedLetters++;
                            if (guessedLetters == word.Length)
                            {
                                isValid = true;
                                break;
                            }
                        }
                    }
                    break;
                case 2: //forwards
                    for (int i = 0; i < word.Length; i++)
                    {
                        if ((20 - x) < word.Length) //This is fine
                        {
                            Console.WriteLine("Out of bounds.");
                            break;
                        }
                        if (word.Substring(i, 1) == (board[y - 1].Substring(x - 1 + i, 1)).ToUpper())
                        {
                            guessedLetters++;
                            if (guessedLetters == word.Length)
                            {
                                isValid = true;
                                break;
                            }
                        }
                    }
                    break;
                case 3: //Backwards
                    for (int i = 0; i < word.Length; i++)
                    {
                        if ((x) < word.Length)
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
                    }
                    break;
            }
            return isValid;
        }
        /// <summary>
        /// Generates a visually easy to read crossword board
        /// </summary>
        /// <param name="board">Source board with words and "."</param>
        /// <param name="rand">random</param>
        /// <param name="Alphabet">string with the alphabet</param>
        /// <returns>String[] with each string being a row</returns>
        static string[] GenerateAestheticBoard(string[] board, Random rand, string Alphabet) //need to draw once then recall.
        {
            string[] newBoard = new string[21];
            newBoard[0] = "0  1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16 17 18 19 20";
            int x = 1;
            foreach (string line in board)
            {
                if (x < 10) { newBoard[x] = x + "  "; }
                else { newBoard[x] = x + " "; }

                char[] lineArray = line.ToCharArray();
                for (int i = 0; i < lineArray.Length; i++)
                {
                    if (lineArray[i] == '.')
                    {
                        lineArray[i] = Alphabet[rand.Next(0, 26)];
                    }
                    else
                    {
                        lineArray[i] = char.ToUpper(lineArray[i]);
                    }
                    newBoard[x] = newBoard[x] + lineArray[i] + "  ";
                }
                x++;
            }
            return newBoard;

        }
    }
}


