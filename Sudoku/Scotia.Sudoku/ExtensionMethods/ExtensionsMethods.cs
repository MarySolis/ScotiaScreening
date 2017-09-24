using System;
using System.Linq;

namespace Scotia.Sudoku.ExtensionMethods
{
    /// <summary>
    /// In a realistic scenario I would create an extension methods class for each type that I would be extending,
    /// for this small exercise I put them all in the same class as a shortcut
    /// </summary>
    static class ExtensionsMethods
    {
        /// <summary>
        /// An extension methods to calculate the predescesor of an uint
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The predescesor of <paramref name="value"/></returns>
        public static uint Pred(this uint value)
        {
            if (value == 0)
            {
                throw new ArgumentOutOfRangeException("value", value, "value must be greater than 0");
            }

            return value - 1;
        }

        /// <summary>
        /// An extension method that calculates the sum of all the numbers in a block inside a Matrix
        /// </summary>
        /// <param name="values"></param>
        /// <param name="firstRow"></param>
        /// <param name="lastRow"></param>
        /// <param name="firstColumn"></param>
        /// <param name="lastColumn"></param>
        /// <param name="rowsSize"></param>
        /// <returns></returns>
        public static uint Sum(this uint[] values, uint firstRow, uint lastRow, uint firstColumn, uint lastColumn, uint rowsSize)
        {
            var result = 0u;
            
            for (var columnIndex = firstColumn; columnIndex <= lastColumn; columnIndex++)
            {
                for (var rowIndex = firstRow; rowIndex <= lastRow; rowIndex++)
                {
                    result += values[rowIndex * rowsSize + columnIndex];
                }
            }

            return result;
        }

        /// <summary>
        /// An extension method that finds if all numbers in a block inside a Matrix stored as an array are unique in O(n) where n is rows x columns
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="firstRow"></param>
        /// <param name="lastRow"></param>
        /// <param name="firstColumn"></param>
        /// <param name="lastColumn"></param>
        /// <param name="rowsSize"></param>
        /// <returns></returns>
        public static bool ArrayContainsUniqueNumbers(this uint[] matrix, uint firstRow, uint lastRow, uint firstColumn, uint lastColumn, uint rowsSize)
        {
            var rowsCount = lastRow - firstRow + 1;
            var columnsCount = lastColumn - firstColumn + 1;
            var size = rowsCount*columnsCount;

            var map = new uint[size];

            for (var columnIndex = firstColumn; columnIndex <= lastColumn; columnIndex++)
            {
                for (var rowIndex = firstRow; rowIndex <= lastRow; rowIndex++)
                {
                    var element = matrix[rowIndex * rowsSize + columnIndex];

                    //Pred since indices start at 0 while values start at 1
                    map[element.Pred()] = 1;
                }
            }

            //Given a block of N elements, if all the elements are different then using them as indices would result 
            //in an array of N elements with no zeros
            return !map.Contains(0u);
        }
    }
}
