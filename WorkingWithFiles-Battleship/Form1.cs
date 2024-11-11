using System.IO;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Web;

//Programmer: Joel Klein
//NOTE: The Battleship Board array is in the Boards class. If you'd like to play the game without looking at the ship placements, 
//please review the class after playing. Thanks.
namespace WorkingWithFiles_Battleship
{
    public partial class Battleship : Form {

        //Keeps track of the current character while using the Read method of StreamReader.
        public char currentChar;
        
        //Integers that keep track of the row/column guessed and the number of tries/ship segments that have been found.
        public int row;
        public int col;
        public int tries;
        public int shipSegmentsFound;
        public int charTracker;

        //A string that keep track of the board throughout the game, documenting your Hits and Misses.
        public string updatedBoard;

        //Booleans that keep track of when the player wins, or when they've guessed a duplicate set of coordinates.
        public bool playerWon;
        public bool dupeGuess;

        //An array of strings that store the player's guesses for later comparison.
        public string[] guesses = new string[30];

        //An instance of the Boards class that creates the Battleship Board
        //and your board.
        Boards accessBoard = new Boards();
        public Battleship()
        {
            InitializeComponent();
            //Creates text files in the bin that write out the ships in "BattleshipBoard.txt" and write out just O's in "YourBoard.txt".
            FileStream board = File.Create("BattleshipBoard.txt");
            byte[] myInfo = new UTF8Encoding(true).GetBytes("ooooxxoooo\r\noooooooooo\r\nxooooooxoo\r\nxooooooxoo\r\n" +
                "xooooooxoo\r\noooooooooo\r\nxxxxoooooo\r\noooooooooo\r\nooooxxxxxo\r\noooooooooo");
            board.Write(myInfo, 0, myInfo.Length);
            board.Close();
            FileStream yourboard = File.Create("YourBoard.txt");
            byte[] yourInfo = new UTF8Encoding(true).GetBytes("oooooooooo\r\noooooooooo\r\noooooooooo\r\noooooooooo\r\n" +
                "oooooooooo\r\noooooooooo\r\noooooooooo\r\noooooooooo\r\noooooooooo\r\noooooooooo");
            yourboard.Write(yourInfo, 0, yourInfo.Length);
            yourboard.Close();

            //Displays the number of tries and number of ships hit on their respective text boxes
            //(Should be 0)
            NumofTries.Text = tries.ToString();
            NumofShipsHit.Text = shipSegmentsFound.ToString();


        }


        /// <summary>
        /// Writes each character in the board array into the updatedBoard string.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public char[,] UpdateBoard(ref char[,] board)
        {
            updatedBoard = null;
            foreach (char i in board)
            {
                updatedBoard += i;
                charTracker++;
                if (charTracker == 10)
                {
                    updatedBoard += "\r\n";
                    charTracker = 0;
                }
            }
            return board;
        }
        /// <summary>
        /// Converts the row and column values typed into integers uses them as indexes for the board array
        /// to then check if the indexes match with an x in the array. If it does, a ship has been hit and the text files will replace the x in that spot with an H.
        /// If it doesn't, no ship has been hit and the text files will replace the o in that spot with an M.
        /// Will also check for duplicate entries and makes the player retry in the event one is entered. At the very end the ship count will be checked via
        /// the Battleship Board text file, and will end the game if the player successfully found all the ships. If not all the ships have been found
        /// and the player has used their 30 guesses, the game will end in failure. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendBomb_Click(object sender, EventArgs e)
        {

            try
            {
                row = Convert.ToInt32(RowBox.Text);
                col = Convert.ToInt32(ColBox.Text);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Please enter a number 1-10 into each box");
            }
            if (row > 10 | row < 1 | col > 10 | col < 1)
            {
                MessageBox.Show("Please enter a number 1-10 into each box");
            }
            else
            {
                foreach (string i in guesses)
                {
                    if (i == row.ToString() + col.ToString())
                    {
                        MessageBox.Show("You've already guessed these coordinates. Try another point.");
                        dupeGuess = true;
                    }

                }

                if (dupeGuess == false)
                {
                    guesses[tries] = row.ToString() + col.ToString();
                    tries += 1;
                    NumofTries.Text = tries.ToString();
                    if (accessBoard.solutionsBoard[row - 1, col - 1] == 'x' & dupeGuess == false)
                    {
                        shipSegmentsFound += 1;
                        NumofShipsHit.Text = shipSegmentsFound.ToString();
                        MessageBox.Show("Direct Hit!");
                        accessBoard.solutionsBoard[row - 1, col - 1] = 'H';
                        accessBoard.playerBoard[row - 1, col - 1] = 'H';
                        currentChar = accessBoard.playerBoard[0, 4];
                        FileStream newBoard = File.Create("BattleshipBoard.txt");
                        UpdateBoard(ref accessBoard.solutionsBoard);
                        byte[] writeToNew = new UTF8Encoding(true).GetBytes(updatedBoard);
                        newBoard.Write(writeToNew, 0, writeToNew.Length);
                        newBoard.Close();
                        FileStream yourNewBoard = File.Create("YourBoard.txt");
                        UpdateBoard(ref accessBoard.playerBoard);
                        byte[] writeToYourNew = new UTF8Encoding(true).GetBytes(updatedBoard);
                        yourNewBoard.Write(writeToYourNew, 0, writeToYourNew.Length);
                        yourNewBoard.Close();

                    }
                    else
                    {

                        MessageBox.Show("Miss!");
                        accessBoard.solutionsBoard[row - 1, col - 1] = 'M';
                        accessBoard.playerBoard[row - 1, col - 1] = 'M';
                        FileStream newBoard = File.Create("BattleshipBoard.txt");
                        UpdateBoard(ref accessBoard.solutionsBoard);
                        byte[] writeToNew = new UTF8Encoding(true).GetBytes(updatedBoard);
                        newBoard.Write(writeToNew, 0, writeToNew.Length);
                        newBoard.Close();
                        FileStream yourNewBoard = File.Create("YourBoard.txt");
                        UpdateBoard(ref accessBoard.playerBoard);
                        byte[] writeToYourNew = new UTF8Encoding(true).GetBytes(updatedBoard);
                        yourNewBoard.Write(writeToYourNew, 0, writeToYourNew.Length);
                        yourNewBoard.Close();


                    }
                    StreamReader sr = new StreamReader("BattleshipBoard.txt");
                    currentChar = (char)sr.Read();
                    while (sr.Read() != -1)
                    {
                        
                        if (currentChar == 'x')
                        {
                            playerWon = false;
                            break;
                        }
                        else
                        {
                            currentChar = (char)sr.Read();
                        }

                    }
                    if(sr.Read() == -1)
                    {
                        playerWon = true;
                    }
                    sr.Close();
                    if (playerWon == true)
                    {
                        MessageBox.Show("Congratulations, you found all the ships! Reload the application to play again (although the board will stay the same :( )");
                        SendBomb.Enabled = false;
                    }

                    if (tries == 30 & playerWon == false)
                    {
                        SendBomb.Enabled = false;
                        MessageBox.Show("You failed to find the ships in 30 tries. Reload the application to try again!");
                    }
                    
                }
                dupeGuess = false;
            }
        }
    }
}
