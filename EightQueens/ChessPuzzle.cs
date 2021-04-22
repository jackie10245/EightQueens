using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    class ChessPuzzle
    {
        private string[,] chessBoard;
        private int queenIndex;
        private int[] colNum;
        private List<string[,]> solutions;

        public ChessPuzzle()
        {
            this.chessBoard = new string[Constants.CHESSBOARD_SIZE, Constants.CHESSBOARD_SIZE];
            this.queenIndex = 0;
            this.ColNum = new int[Constants.QUEEN_COUNT] { 0,0,0,0,0,0,0,0};
            this.solutions = new List<string[,]>();
        }

        public int QueenIndex
        {
            get
            {
                return queenIndex;
            }

            set
            {
                queenIndex = value;
            }
        }

        public int[] ColNum
        {
            get
            {
                return colNum;
            }

            set
            {
                colNum = value;
            }
        }

        public string[,] getChessBoard()
        {
            return this.chessBoard;
        }


        public void drawChessBoard()
        {
            for (int i = 0; i < Constants.QUEEN_COUNT; i++)
            {
                this.chessBoard[i, this.ColNum[i]] = "Q";
            }
        }

        public void resetChessBoard()
        {
            this.chessBoard = new string[Constants.CHESSBOARD_SIZE, Constants.CHESSBOARD_SIZE];
        }

        public bool checkPosValid()
        {
            for (int i = 0; i < queenIndex; i++)
            {
                int rowDiff = Math.Abs(queenIndex - i);
                int colDiff = Math.Abs(ColNum[queenIndex] - ColNum[i]);

                if (colDiff == 0) // two queens in same col
                    return false;

                if (rowDiff == colDiff) // two queens in same slash / backslash
                    return false;
            }

            return true;
        }

        public void findSolutions()
        {
            while (queenIndex >= 0)
            {
                if (colNum[Constants.FIRST_QUEEN_INDEX] >= Constants.CHESSBOARD_SIZE)
                {
                    break;
                }

                while (colNum[queenIndex] < Constants.CHESSBOARD_SIZE && !checkPosValid())
                {
                    colNum[queenIndex]++;
                }

                if (colNum[queenIndex] >= Constants.CHESSBOARD_SIZE) // over column index limit
                {
                    queenIndex--;
                    colNum[queenIndex]++;
                }
                else
                {

                    if (queenIndex == Constants.CHESSBOARD_SIZE - 1)
                    {
                        drawChessBoard();

                        solutions.Add(getChessBoard());
                        resetChessBoard();
                        colNum[queenIndex]++;
                    }
                    else
                    {
                        queenIndex++;
                        colNum[queenIndex] = 0; // reinitialize for next queen
                    }
                }
            }
        }

        public void printSolutions()
        {
            int solutionNumber = 0;

            foreach (string[,] solution in solutions)
            {
                solutionNumber++;
                Console.WriteLine("//Solution " + solutionNumber);

                for (int i = 0; i < 8; i++)
                {
                    string line = String.Empty;
                    for (int j = 0; j < 8; j++)
                    {

                        if (String.IsNullOrEmpty(solution[i, j]))
                            solution[i, j] = ".";

                        line = line + solution[i, j] + " ";
                    }
                    Console.WriteLine(line);
                }
            }

        }

    }
}
