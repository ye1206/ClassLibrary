using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary_Cheng3001.HelperFunctions_Cheng3001
{
    public class FunctionsUseOftenOrArray_Cheng3001
    {
        public double HighestValue, LowestValue;
        public double average;
        public int HighestIndex = 0, LowestIndex = 0;
        public static bool FLAG_IS_EQUAL = true; //Include contidion of "= 0"
        public static int CompareTwoData(double a, double b)
        {
            if (a < b)
                return -1;
            else if (a > b)
                return +1;
            else
                return 0;
        } //end of CompareTwoData

        #region MaxAndMin
        /// <summary>
        /// Gets the minimum.
        /// </summary>
        /// <param name="arrayData">The array data.</param>
        /// <returns></returns>
        public int GetMinimum(int[,] arrayData)
        {
            var lowest = arrayData[0, 0];

            foreach (var data in arrayData)
            {
                if (data < lowest)
                    lowest = data;
            }

            return lowest;
        } //end of GetMinimum

        /// <summary>
        /// Gets the maximum.
        /// </summary>
        /// <param name="arrayData">The array data.</param>
        /// <returns></returns>
        public int GetMaximum(int[,] arrayData)
        {
            var highest = arrayData[0, 0]; //assume the first element of data array is the highest

            foreach (var data in arrayData) //loop through elements of rectangular data array
            {
                if (data > highest)
                    highest = data;
            }

            return highest;
        } //end of GetMaximum
        #endregion MaxAndMin

        #region FindTheGoal
        public double FindAverage(double[] iArray)
        {
            double ALLamounts = 0;
            for (int count = 0; count < iArray.Length; count++)
            {
                ALLamounts += iArray[count];
            }
            return average = ALLamounts / iArray.Length;
        } //end of FindAverage

        // The Highest method accepts an int array argument
        // and returns the highest value in that array.
        public double FindHighest(double[] iArray)
        {
            // Declare a variable to hold the highest value, and
            // initialize it with the first value in the array.
            double highestValue = iArray[0];
            HighestIndex = 0;

            // Step through the rest of the array, beginning at
            // element 1. When a value greater than highest is found,
            // assign that value to highest.
            for (int count = 1; count < iArray.Length; count++)
            {
                if (iArray[count] > highestValue)
                {
                    highestValue = iArray[count];
                    HighestIndex = count;
                }
            }

            // Return the highest value.
            return highestValue;
        } //end of FindHighest

        // The Lowest method accepts an int array argument
        // and returns the lowest value in that array.
        public double FindLowest(double[] iArray)
        {
            // Declare a variable to hold the lowest value, and
            // initialize it with the first value in the array.
            double LowestValue = iArray[0];
            LowestIndex = 0;

            // Step through the rest of the array, beginning at
            // element 1. When a value less than lowest is found,
            // assign that value to lowest.
            for (int count = 1; count < iArray.Length; count++)
            {
                if (iArray[count] < LowestValue)
                {
                    LowestValue = iArray[count];
                    LowestIndex = count;
                }
            }

            // Return the lowest value.
            return LowestValue;
        } //end of FindLowest
        #endregion FindTheGoal

        #region FindAmount
        /// <summary>
        /// Finds the amount above threshold 
        /// </summary>
        /// <param name="_arrayValue">The array value.</param>
        /// <param name="thresholdValue">The threshold value.</param>
        /// <param name="flag4NO">if set to <c>true</c> [flag4 no].</param>
        /// <returns></returns>
        public static int FindAmountAboveThresholdUsingArrayPO(double[] _arrayValue, double thresholdValue, bool flag4NO)
        {
            int numAbove = 0;
            foreach (double value in _arrayValue) //When the system read a data that below the threshold value then +1
            {
                if (flag4NO ? (value >= thresholdValue) : (value > thresholdValue))
                    numAbove++;
            }

            return numAbove;
        } //end of FindAmountAboveThresholdUsingArrayPO

        /// <summary>
        /// Finds the amount below threshold 
        /// </summary>
        /// <param name="_arrayValue">The array value.</param>
        /// <param name="thresholdValue">The threshold value.</param>
        /// <param name="flag4NO">if set to <c>true</c> [flag4 no].</param>
        /// <returns></returns>
        public static int FindAmountBelowThresholdUsingArrayPO(double[] _arrayValue, double thresholdValue, bool flag4NO)
        {
            int numBelow = 0;
            foreach (double value in _arrayValue) //When the system read a data that below the threshold value then +1
            {
                if (flag4NO ? (value <= thresholdValue) : (value < thresholdValue))
                    numBelow++;
            }

            return numBelow;
        } //end of FindAmountBelowThresholdUsingArrayPO
        #endregion FindAmount
    }
}
