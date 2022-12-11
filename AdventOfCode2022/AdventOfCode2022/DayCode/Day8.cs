using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.DayCode
{
    internal class Day8 : IDayCode
    {
        public void RunDay(string input)
        {
            var lines = input.Split('\n');
            var trees = new int[lines.Length, lines[0].Length];
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    trees[i, j] = int.Parse(lines[i][j].ToString());
                }
            }
            int visibleTrees = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (isVisibleOnHorizontal(trees, i, j) || isVisibleOnVertical(trees, i, j)) visibleTrees++;
                }
            }
            Console.WriteLine($"The amount of trees visible from the outside is {visibleTrees}");

            List<int> viewingScores = new List<int>();
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    viewingScores.Add(calcAllViewingScores(trees, i, j));
                }
            }
            Console.WriteLine($"The best viewing score is {viewingScores.Max()}");
        }

        private bool isVisibleOnHorizontal(int[,] trees, int row, int col)
        {
            bool visibleFront = true;
            for (int i = 0; i < col; i++)
            {
                if (trees[row, i] >= trees[row, col]) visibleFront = false;
            }
            bool visibleAfter = true;
            for (int i = col+1; i < trees.GetLength(0); i++)
            {
                if (trees[row, i] >= trees[row, col]) visibleAfter = false;
            }
            return visibleAfter || visibleFront;
        }

        private bool isVisibleOnVertical(int[,] trees, int row, int col)
        {
            bool visibleFront = true;
            for (int i = 0; i < row; i++)
            {
                if (trees[i, col] >= trees[row, col]) visibleFront = false;
            }
            bool visibleAfter = true;
            for (int i = row+1; i < trees.GetLength(1); i++)
            {
                if (trees[i, col] >= trees[row, col]) visibleAfter = false;
            }
            return visibleAfter || visibleFront;
        }

        private int calcAllViewingScores(int[,] trees, int row, int col)
        {
            return leftViewingScore(trees, row, col) * rightViewingScore(trees, row, col) * upViewingScore(trees, row, col) * downViewingScore(trees, row, col);
        }

        private int leftViewingScore(int[,] trees, int row, int col)
        {
            if (col == 0) return 0;
            int score = 1;
            for (int i = col; i > -1; i--)
            {
                if (trees[row, i] >= trees[row, col]) break;
                score++;
            }
            return score;
        }

        private int rightViewingScore(int[,] trees, int row, int col)
        {
            if (col == trees.GetLength(0)-1) return 0;
            int score = 1;
            for (int i = col+1; i < trees.GetLength(0); i++)
            {
                if (trees[row, i] >= trees[row, col]) break;
                score++;
            }
            return score;
        }

        private int upViewingScore(int[,] trees, int row, int col)
        {
            if (row == 0) return 0;
            int score = 1;
            for (int i = row; i > -1; i--)
            {
                if (trees[i, col] >= trees[row, col]) break;
                score++;
            }
            return score;
        }

        private int downViewingScore(int[,] trees, int row, int col)
        {
            if (row == trees.GetLength(1) - 1) return 0;
            int score = 1;
            for (int i = row + 1; i < trees.GetLength(1); i++)
            {
                if (trees[i, col] >= trees[row, col]) break;
                score++;
            }
            return score;
        }

    }

    //internal class GroveTree {
    //    int row { get; set; }
    //    int col { get; set; }
    //    int height { get; set; }
    //    GroveTree[] allTrees { get; set; }
    //    bool visible { get
    //        {
    //            return 
    //                !allTrees.Where(t => t.row == row).Take(col).Any(x => x.height >= this.height) ||
    //                !allTrees.Where(t => t.row == row).Skip(col).Any(x => x.height >= this.height) ||
    //                !allTrees.Where(t => t.col == col).Take(row).Any(x => x.height >= this.height) ||
    //                !allTrees.Where(t => t.col == col).Skip(row).Any(x => x.height >= this.height)
    //        } 
    //    }
    //}
}
