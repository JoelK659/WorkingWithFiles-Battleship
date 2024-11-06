using System.IO;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Web;

namespace WorkingWithFiles_Battleship
{
    public partial class Battleship : Form
    {
        public int row;
        public int col;
        public char[,] point = { { 'o', 'o', 'o', 'o', 'x', 'x', 'o', 'o', 'o', 'o' },
                                 { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                 { 'x', 'o', 'o', 'o', 'o', 'o', 'o', 'x', 'o', 'o' },
                                 { 'x', 'o', 'o', 'o', 'o', 'o', 'o', 'x', 'o', 'o' },
                                 { 'x', 'o', 'o', 'o', 'o', 'o', 'o', 'x', 'o', 'o' },
                                 { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                 { 'x', 'x', 'x', 'x', 'o', 'o', 'o', 'o', 'o', 'o' },
                                 { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' },
                                 { 'o', 'o', 'o', 'o', 'x', 'x', 'x', 'x', 'x', 'o' },
                                 { 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o' }};
        public char test;
        public string updatedBoard;
        public int charTracker;
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
                test = point[row - 1, col - 1];

                if (point[row - 1, col - 1] == 'x')
                {
                    MessageBox.Show("Direct Hit!");
                    point[row - 1, col - 1] = 'H';
                    FileStream newBoard = File.Create("BattleshipBoard.txt");
                    foreach(char i in point)
                    {
                        updatedBoard += i;
                        charTracker++;
                        if(charTracker == 10)
                        {
                            updatedBoard += "\r\n";
                            charTracker = 0;
                        }
                    }
                    byte[] writeToNew = new UTF8Encoding(true).GetBytes(updatedBoard);
                    newBoard.Write(writeToNew, 0, writeToNew.Length);
                    newBoard.Close();

                }
                else
                {
                    MessageBox.Show("Miss!");
                    point[row - 1, col - 1] = 'M';
                    FileStream newBoard = File.Create("BattleshipBoard.txt");
                    foreach (char i in point)
                    {
                        updatedBoard += i;
                        charTracker++;
                        if (charTracker == 10)
                        {
                            updatedBoard += "\r\n";
                            charTracker = 0;
                        }
                    }
                    byte[] writeToNew = new UTF8Encoding(true).GetBytes(updatedBoard);
                    newBoard.Write(writeToNew, 0, writeToNew.Length);
                    newBoard.Close()

                }


            }


        }


    }
}
