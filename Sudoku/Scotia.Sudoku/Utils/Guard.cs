using System;
using System.IO;

namespace Scotia.Sudoku.Utils
{
    /// <summary>
    /// A helper class to cleanly do precondition checks
    /// </summary>
    public static class Guard
    {
        public static void IsNotNull(object value, string argumentName, string errorMessage)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName, errorMessage);
            }
        }

        public static void IsTrue(bool condition, string errorMessage)
        {
            if (!condition)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public static void IsFalse(bool condition, string errorMessage)
        {
            if (condition)
            {
                throw new ArgumentException(errorMessage);
            }
        }

        public static void FileExists(string fileName, string errorMessage)
        {
            if (!File.Exists(fileName))
            {
                throw new FileLoadException(errorMessage);
            }
        }
    }
}
