using System.IO;
using System.Text;

namespace WorkingWithFiles_Battleship
{
    public partial class Battleship : Form
    {
        public int row;
        public int col;
        public char[,] point = new char[10, 10];
        public Battleship()
        {
            InitializeComponent();

        }
        private void Battleship_Load(object sender, EventArgs e)
        {
            FileStream board = File.Create("BattleshipBoard.txt");
            byte[] myInfo = new UTF8Encoding(true).GetBytes("ooooxxoooo\r\noooooooooo\r\nxooooooxoo\r\nxooooooxoo\r\n" +
                "xooooooxoo\r\noooooooooo\r\nxxxxoooooo\r\noooooooooo\r\nooooxxxxxo\r\noooooooooo");
            board.Write(myInfo, 0, myInfo.Length);
            board.Close();
            StreamReader stream = new StreamReader("BattleshipBoard.txt");
            for (int i = 0; i < point.GetLength(0); i++)
            {
                for (int j = 0; j < point.GetLength(1); j++)
                {
                    point[i, j] = (char)stream.Read();
                }

            }
            stream.Close();
        }

        private void SendBomb_Click(object sender, EventArgs e)
        {
            try
            {
                row = Convert.ToInt32(RowBox.Text);
                col = Convert.ToInt32(RowBox.Text);
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

                StreamReader sr = new StreamReader("BattleshipBoard.txt");
                string seaRow;
                if (point[row, col] == 'x')
                {
                    MessageBox.Show("Direct Hit!");
                    StreamReader stream = new StreamReader("C:\\Users\\joelj\\source\\repos\\WorkingWithFiles-Battleship\\WorkingWithFiles-Battleship\\BattleshipBoard.txt");
                    FileStream newBoard = File.Create("C:\\Users\\joelj\\source\\repos\\WorkingWithFiles-Battleship\\WorkingWithFiles-Battleship\\BattleshipBoard.txt");
                    for (int i = 0; i < point.GetLength(0); i++)
                    {
                        for (int j = 0; j < point.GetLength(1); j++)
                        {
                            point[i, j] = (char)stream.Read();
                        }

                    }
                }


            }


        }

        
    }
}
