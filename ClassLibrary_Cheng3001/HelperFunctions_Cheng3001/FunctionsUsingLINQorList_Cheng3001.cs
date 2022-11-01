using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace ClassLibrary_Cheng3001.HelperFunctions_Cheng3001
{
    public class FunctionsUsingLINQorList_Cheng3001
    {
        public int HighestIndex, LowestIndex;

        #region ListSorted
        /// <summary>
        /// Linqs the double list sorted by ascending.
        /// </summary>
        /// <param name="dataList">The data list.</param>
        /// <returns></returns>
        public static IEnumerable<double> Linq_DoubleListSortedByAscending(List<double>dataList)
        {
            // use orderby clause to sort original values in ascending order
            var sorted =
               from data in dataList // data source is values
                orderby data
                select data;
            return sorted;
        } //end of Linq_DoubleListSortedByAscending

        /// <summary>
        /// Linqs the double list sorted by descending.
        /// </summary>
        /// <param name="dataList">The data list.</param>
        /// <returns></returns>
        public static IEnumerable<double> Linq_DoubleListSortedByDescending(List<double> dataList)
        {
            // use orderby clause to sort original values in descending order
            var sorted =
               from data in dataList // data source is values
               orderby data descending
               select data;
            return sorted;
        } //end of Linq_DoubleListSortedByDescending
        #endregion ListSorted

        #region CompareWithThreshold
        /// <summary>
        /// LinQ for the double array filtered specified value via defined threshold value.
        /// </summary>
        /// <param name="dataList">The data list.</param>
        /// <param name="thresholdValue">The threshold value.</param>
        /// <returns></returns>
        public static IEnumerable<double> Linq_DoubleListEqual2Threshold(List<double> dataList, double thresholdValue)
        {
            var filtered = 
                from data in dataList
                where data == thresholdValue
                select data;

            return filtered;
        } // end of Linq_DoubleListEqual2Threshold

        public static IEnumerable<double> Linq_DoubleListAbove2Threshold(List<double> dataList, double thresholdValue)
        {
            var filtered =
                from data in dataList
                where data >= thresholdValue
                select data;

            return filtered;
        } //end of Linq_DoubleListAbove2Threshold
        #endregion CompareWithThreshold

        #region FindTheGoal
        public double FindHighestForList(List<double> _listValues)
        {
            double highestValue = _listValues[0];

            for (int i = 0; i < _listValues.Count; i++)
            {
                if (_listValues[i] > highestValue)
                {
                    highestValue = _listValues[i];
                    HighestIndex = i;
                }
            }
            return highestValue;
        } // end of FindHighestForList

        public double FindLowestForList(List<double> _listValues)
        {
            double lowestValue = _listValues[0];

            for (int i = 0; i < _listValues.Count; i++)
            {
                if (_listValues[i] < lowestValue)
                {
                    lowestValue = _listValues[i];
                    LowestIndex = i;
                }
            }
            return lowestValue;
        } // end of FindLowestForList

        public static double FindAverageForList(List<double> _listValues)
        {
            double total = 0;
            foreach (double value in _listValues)
                total += value;

            return (double)total / _listValues.Count;
        } //end of FindAverageForList

        #endregion FindTheGoal

        /// <summary>
        /// Selects the range.
        /// </summary>
        /// <param name="dataList">The data list.</param>
        /// <param name="_upperLimit">The upper limit.</param>
        /// <param name="_lowLimit">The low limit.</param>
        /// <returns></returns>
        public static IEnumerable<double> selectRange(List<double> dataList, double _upperLimit, double _lowLimit)
        {
            var rangeSelect = 
                from data in dataList
                where data >= _lowLimit && data < _upperLimit
                select data;

            return rangeSelect;
        } //end of selectRange

        #region LinqForArray        
        /// <summary>
        /// Linqs the double array above threshold.
        /// </summary>
        /// <param name="arrayData">The array data.</param>
        /// <param name="thresholdValue">The threshold value.</param>
        /// <returns></returns>
        public static IEnumerable<double> Linq_DoubleArrayAboveThreshold(double[] arrayData, double thresholdValue)
        {
            var filtered =
                from data in arrayData
                where data >= thresholdValue
                select data;

            return filtered;
        } //end of Linq_DoubleArrayAboveThreshold

        /// <summary>
        /// Linqs the double array below threshold.
        /// </summary>
        /// <param name="arrayData">The array data.</param>
        /// <param name="thresholdValue">The threshold value.</param>
        /// <returns></returns>
        public static IEnumerable<double> Linq_DoubleArrayBelowThreshold(double[] arrayData, double thresholdValue)
        {
            var filtered =
                from data in arrayData
                where data <= thresholdValue
                select data;

            return filtered;
        } //end of Linq_DoubleArrayBelowThreshold

        /// <summary>
        /// Linqs the double array sorted by ascending.
        /// </summary>
        /// <param name="arrayData">The array data.</param>
        /// <returns></returns>
        public static IEnumerable<double> Linq_DoubleArraySortedByAscending(double[] arrayData)
        {
            var sorted =
                from data in arrayData
                orderby data
                select data;

            return sorted;
        } //end of Linq_DoubleArraySortedByAscending

        /// <summary>
        /// Linqs the double array sorted by descending.
        /// </summary>
        /// <param name="arrayData">The array data.</param>
        /// <returns></returns>
        public static IEnumerable<double> Linq_DoubleArraySortedByDescending(double[] arrayData)
        {
            var sorted =
                from data in arrayData
                orderby data descending
                select data;

            return sorted;
        } //end of Linq_DoubleArraySortedByDescending
        #endregion LinqForArray

        #region FindAmountUsingList
        public static int FindAmountAboveThresholdUsingList(List<double> _listValues, double thresholdValue)
        {
            int numAbove = 0;

            foreach (double value in _listValues)
            {
                if (value > thresholdValue)
                    numAbove++;
            }

            return numAbove;
        } //end of FindAmountAboveThresholdUsingList

        public static int FindAmountBelowThresholdUsingList(List<double> _listValues, double thresholdValue)
        {
            int numBelow = 0;

            foreach (double value in _listValues)
            {
                if (value < thresholdValue)
                    numBelow++;
            }

            return numBelow;
        } //end of FindAmountBelowThresholdUsingList
        #endregion FindAmountUsingList
    }
}
