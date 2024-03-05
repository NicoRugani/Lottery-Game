using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LotteryNumbers
{
    public partial class Form1 : Form
    {
        int money = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int[] playerNumbers = new int[5];
            int[] powerBallNumbers = new int[5];
            string pNums = "";
            string winningNums = "";
            string moneySpent = "";

            money -= 2;
            moneySpent = moneySpent + " " + money.ToString();


            HashSet<int> generatedNumbers = new HashSet<int>();

            for (int i = 0; i < 5; i++)
            {
                int playerNum = random.Next(1, 60);

                // Ensure playerNum is unique
                while (generatedNumbers.Contains(playerNum))
                {
                    playerNum = random.Next(1, 60);
                }

                playerNumbers[i] = playerNum;
                generatedNumbers.Add(playerNum);

                int powerBallNum = random.Next(1, 60);

                // Ensure powerBallNum is unique
                while (generatedNumbers.Contains(powerBallNum))
                {
                    powerBallNum = random.Next(1, 60);
                }

                powerBallNumbers[i] = powerBallNum;
                generatedNumbers.Add(powerBallNum);
            }

            Array.Sort(playerNumbers);
            Array.Sort(powerBallNumbers);

            for (int i = 0; i < playerNumbers.Length; i++)
            {
                pNums = pNums + " " + playerNumbers[i].ToString() + " ";
                winningNums = winningNums + " " + powerBallNumbers[i].ToString() + " ";
            }


            txtPlayerNum.Text = pNums;
            txtWinningNums.Text = winningNums;

            if (playerNumbers == powerBallNumbers)
            {
                label3.Text = "You Win!";
                money += 1000000;
            }
            else
            {
                label3.Text = "You Lose";
            }

            label4.Text = "Money spent: $" + moneySpent;

        }
        

        
    }
}
