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
    public partial class Battleship : Form
    {
        public char test;
        public int row;
        public int col;
        public int tries;
        public int shipSegmentsFound;
        public int charTracker;
        public string updatedBoard;
        public bool playerWon;
        public bool dupeGuess;
        public string[] guesses = new string[17];
        Boards accessBoard = new Boards();
        public Battleship()
        {
            InitializeComponent();
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
            NumofTries.Text = tries.ToString();
            NumofShipsHit.Text = shipSegmentsFound.ToString();
            

        }

        

        public char[,] updateBoard(ref char[,] board)
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
                        test = accessBoard.playerBoard[0, 4];
                        FileStream newBoard = File.Create("BattleshipBoard.txt");
                        updateBoard(ref accessBoard.solutionsBoard);
                        byte[] writeToNew = new UTF8Encoding(true).GetBytes(updatedBoard);
                        newBoard.Write(writeToNew, 0, writeToNew.Length);
                        newBoard.Close();
                        FileStream yourNewBoard = File.Create("YourBoard.txt");
                        updateBoard(ref accessBoard.playerBoard);
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
                        updateBoard(ref accessBoard.solutionsBoard);
                        byte[] writeToNew = new UTF8Encoding(true).GetBytes(updatedBoard);
                        newBoard.Write(writeToNew, 0, writeToNew.Length);
                        newBoard.Close();
                        FileStream yourNewBoard = File.Create("YourBoard.txt");
                        updateBoard(ref accessBoard.playerBoard);
                        byte[] writeToYourNew = new UTF8Encoding(true).GetBytes(updatedBoard);
                        yourNewBoard.Write(writeToYourNew, 0, writeToYourNew.Length);                           
                        yourNewBoard.Close();


                    }
                    if (shipSegmentsFound == 17)
                    {
                        MessageBox.Show("Congratulations, you found all the ships! Click restart to play again (although the board will stay the same :( )");
                        SendBomb.Enabled = false;
                        RestartButton.Visible = true;
                        playerWon = true;
                    }

                    if (tries == 30 & playerWon == false)
                    {
                        SendBomb.Enabled = false;
                        RestartButton.Visible = true;
                        MessageBox.Show("You failed to find the ships in 30 tries. Click Restart to try again!");
                    }
                    dupeGuess = false;
                }

            }
        }


    }
}
