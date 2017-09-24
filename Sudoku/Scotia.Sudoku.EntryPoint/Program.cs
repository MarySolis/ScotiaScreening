using System;
using System.IO;
using Scotia.Sudoku.IO;
using Scotia.Sudoku.Models;
using Scotia.Sudoku.Utils;

namespace Scotia.Sudoku.EntryPoint
{
    //Entry points, requires a Sudoku solution file as an argument
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Guard.IsNotNull(args, "args", "Solution file must be sent as a parameter");
                Guard.IsTrue(args.Length >= 1, "At least one parameter is required");

                //Although my implementation supports arbitrary board/block sizes, input files don't describe game dimensions so I'm 
                //hard-coding sizes at the entry point
                var input = new SolutionLoader(args[0], new BoardDimensions(9, 9, 3, 3));
                var board = input.GetBoard();

                var verifier = new SolutionVerifier();
                Console.WriteLine(verifier.IsValid(board));
                Console.ReadLine();
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine("File load exception: {0}\r\n{1}", ex.Message, ex.StackTrace);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("{0} \r\n {1}", ex.Message, ex.StackTrace );
            }
            catch
            {
                //Unexpected exception, write to console and exit gracefully, a more realistic implementation would have proper logging that would
                //contain details about the exception by now
                Console.WriteLine("Unexpected exception");
            }
        }
    }
}
