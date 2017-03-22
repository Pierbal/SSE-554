using System;

namespace Project1_SSE554
{
    public class GameType
    {
        public GameType()
        { }

        public int setGameType(string type)
        {
            int num = 10;

            if (type == "Endless-RPS")
                num = 0;
            else if (type == "FirstToTwo-RPS")
                num = 1;
            else if (type == "GuessTheNumber")
                num = 2;
            else if (type == "GuessTheTVShow")
                num = 3;
            return num;
        }

        public int[] numberRangeChosen(string type)
        {
            int[] numberRange = new int[2];
            string[] range = (type).Split('-');
            for(int i=0; i<range.Length; i++)
            {
                numberRange[i] = Int32.Parse(range[i]);
            }
            return numberRange;
        }
    }
}
