namespace AdventOfCode2022.DayCode
{
    internal class Day2 : IDayCode
    {
        public void RunDay(string input)
        {
            var roundLines = input.Split('\n');
            var score = 0;
            score = roundLines.Sum(round =>
            {
                var roundVals = round.Split(' ');
                var opponentVal = Enum.Parse(typeof(RockPaperScissorsOpponent), roundVals[0]);
                var playerVal = Enum.Parse(typeof(RockPaperScissors), roundVals[1]);
                var winScore = 0;
                var res = (int)playerVal - (int)opponentVal;
                if (res == 0)
                {
                    winScore = 3;
                }
                else if (res == -2 || res == 1)
                {
                    winScore = 6;
                }
                return (int)playerVal + winScore;
            });

            var realScore = 0;
            realScore = roundLines.Sum(round =>
            {
                var roundVals = round.Split(' ');
                var opponentVal = Enum.Parse(typeof(RockPaperScissorsOpponent), roundVals[0]);
                var winPref = (RockPaperScissorsPlayPreference)Enum.Parse(typeof(RockPaperScissorsPlayPreference), roundVals[1]);
                if (winPref == RockPaperScissorsPlayPreference.Y)
                {
                    return (int)winPref + (int)opponentVal;
                }
                else if (winPref == RockPaperScissorsPlayPreference.X)
                {
                    var playInt = (int)opponentVal - 1;
                    if (playInt == 0) playInt = 3;
                    return (int)winPref + (int)playInt;
                }
                else
                {
                    var playInt = (int)opponentVal + 1;
                    if (playInt == 4) playInt = 1;
                    return (int)winPref + (int)playInt;
                }
            });

            Console.WriteLine($"Score: {score}");
            Console.WriteLine($"True Score: {realScore}");
            Console.ReadLine();
        }
    }

    enum RockPaperScissors
    {
        X = 1,
        Y = 2,
        Z = 3,
    }

    enum RockPaperScissorsPlayPreference
    {
        X = 0,
        Y = 3,
        Z = 6,
    }

    enum RockPaperScissorsOpponent
    {
        A = 1,
        B = 2,
        C = 3,
    }
}
