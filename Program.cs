using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://www.reddit.com/r/dailyprogrammer/comments/dv0231/20191111_challenge_381_easy_yahtzee_upper_section/

// CHALLENGE: 

// The game of Yahtzee is played by rolling five 6-sided dice, and scoring the results in a number of ways. 
// You are given a Yahtzee dice roll, represented as a sorted list of 5 integers, each of which is between 1 and 6 inclusive. 
// Your task is to find the maximum possible score for this roll in the upper section of the Yahtzee score card. Here's what that means.

//For the purpose of this challenge, the upper section of Yahtzee gives you six possible ways to score a roll. 
//1 times the number of 1's in the roll, 2 times the number of 2's, 3 times the number of 3's, and so on up to 6 times the number of 6's.
//For instance, consider the roll[2, 3, 5, 5, 6]. If you scored this as 1's, the score would be 0, since there are no 1's in the roll. 
//If you scored it as 2's, the score would be 2, since there's one 2 in the roll. Scoring the roll in each of the six ways gives you the six possible scores:

//0 2 3 0 10 6

//BONUS:

//Efficiently handle inputs that are unsorted and much larger, both in the number of dice and in the number of sides per die. (
//For the purpose of this bonus challenge, you want the maximum value of some number k, times the number of times k appears in the input.)

//yahtzee_upper([1654, 1654, 50995, 30864, 1654, 50995, 22747,
//    1654, 1654, 1654, 1654, 1654, 30864, 4868, 1654, 4868, 1654,
//    30864, 4868, 30864]) => 123456

//There's no strict limit on how fast it needs to run. That depends on your language of choice. 
//But for rough comparison, my Python solution on this challenge input, consisting of 100,000 values between 1 and 999,999,999 takes about 0.2 seconds 
//(0.06 seconds not counting input parsing).



namespace Yahtzee_Upper_Section
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CalculateBestYahtzeeUpperScore(new int[] { 2, 3, 5, 5, 6 }));
            Console.WriteLine(CalculateBestYahtzeeUpperScore(new int[] { 1, 1, 1, 1, 3 }));
            Console.WriteLine(CalculateBestYahtzeeUpperScore(new int[] { 1, 1, 1, 3, 3 }));
            Console.WriteLine(CalculateBestYahtzeeUpperScore(new int[] { 1, 2, 3, 4, 5 }));
            Console.WriteLine(CalculateBestYahtzeeUpperScore(new int[] { 6, 6, 6, 6, 6 }));

            Console.WriteLine(CalculateBestYahtzeeUpperScore(new int[] { 1654, 1654, 50995, 30864, 1654, 50995, 22747, 1654, 1654, 1654, 1654, 1654,
                30864, 4868, 1654, 4868, 1654, 30864, 4868, 30864 }));

            int[] fileArray = FromFile("..\\..\\yahtzee-upper-1.txt");

            Console.WriteLine(CalculateBestYahtzeeUpperScore(fileArray));
        }

        private static int[] FromFile(string strFile)
        {
            string[] strText;
            int[] intArray;

            strText = File.ReadAllLines(strFile);

            intArray = new int[strText.Length];

            for (int i = 0; i < strText.Length; i++)
                intArray[i] = Convert.ToInt32(strText[i]);

            return intArray;
        }

        private static int CalculateBestYahtzeeUpperScore(int[] values)
        {
            Dictionary<int, int> dictScores = new Dictionary<int, int>();

            foreach (int value in values)
            {
                if (!dictScores.ContainsKey(value))
                    dictScores[value] = value;
                else
                    dictScores[value] += value;
            }

            return dictScores.Values.Max();
        }
    }
}
