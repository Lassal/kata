using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.lassal.Kata.Kata02
{
    public class BinarySearchStats : IBinarySearch 
    {
        public BinarySearchStats(IBinarySearch binarySearch)
        {
            this.binarySearch = binarySearch;
        }

        private IBinarySearch binarySearch = null;
        private List<long> ticksRecords = new List<long>();

        public int Chop(int numberToFind, int[] dataSet)
        {
            DateTime startT = DateTime.Now;
            int result = this.binarySearch.Chop(numberToFind, dataSet);
            DateTime endT = DateTime.Now;

            this.AddTimeRecord(startT, endT);

            return result;
        }

        private void AddTimeRecord(DateTime start, DateTime end)
        {
            TimeSpan tSpan = end.Subtract(start);

            this.ticksRecords.Add(tSpan.Ticks);
            this.averageSearchTime = null;
        }

        public int NumberOfSearchs
        {
            get
            {
                return this.ticksRecords.Count;
            }
        }

        private double? averageSearchTime = null;
        public double AverageSearchTime
        {
            get
            {
                if (this.averageSearchTime == null)
                {
                    this.averageSearchTime = this.CalculateAverageSearchTime();
                }

                return this.averageSearchTime.Value;
            }
        }

        private double CalculateAverageSearchTime()
        {
            return this.ticksRecords.Average();
        }
    }
}
