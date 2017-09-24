using System.IO;
using System.Linq;
using Scotia.Sudoku.Utils;

namespace Scotia.Sudoku.IO
{
    /// <summary>
    /// Main file parsing logic, reads solution from a path and produces a string array with the content
    /// skips empty lines and has error handling logic for missing files
    /// </summary>
    class FileParser
    {
        #region Fields

        private readonly string _fileName;

        #endregion Fields


        #region Public Methods

        public FileParser(string fileName)
        {
            Guard.FileExists(fileName, string.Format("missing file name: {0}", fileName));
            _fileName = fileName;
        }

        public string[] LoadContent()
        {
            //Reading the entire file in one go since it is expected to be small, for a more robust approach 
            //I could have read/verified format one line at a time: https://msdn.microsoft.com/en-CA/library/aa287535(v=vs.71).aspx

            //Load the file content skipping empty lines to make it more resilient (if this wasn't the desired behavior we can remove 
            //the where lambda and update SolutionLoader to check & fail if empty lines are missing)
            return File.ReadLines(_fileName)
                .Where(line => !string.IsNullOrEmpty(line))
                .ToArray();
        }

        #endregion Public Methods
    }
}
