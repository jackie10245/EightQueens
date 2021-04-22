using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueens
{
    public class Program
    {
        static List<string[,]> solutions = new List<string[,]>();

        static void Main(string[] args)
        {
            ChessPuzzle chess = new ChessPuzzle();

            chess.findSolutions();

            chess.printSolutions();

        }

    }
}
