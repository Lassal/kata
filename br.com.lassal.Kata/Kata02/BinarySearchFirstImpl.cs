using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.lassal.Kata.Kata02
{
    public class BinarySearchFirstImpl: IBinarySearch
    {
        public int Chop(int numberToFind, int[] dataSet)
        {
            int indexHit = -1;

            if(dataSet != null && dataSet.Length > 0 )
            {
                int start = 0;
                int end = dataSet.Length - 1;
                int median = dataSet.Length / 2;

                while ((end - start) > 0)
                {
                    if (dataSet[median] == numberToFind)
                    {
                        indexHit = median;
                        break;
                    }
                    else if (numberToFind > dataSet[median])
                    {
                        start = median + 1;
                    }
                    else
                    {
                        end = median - 1;
                    }
                    median = ((end - start) / 2) + start;
                }

                if ((indexHit < 0) && (start == end) && (dataSet[start] == numberToFind))
                {
                    indexHit = start;
                }

            }

            return indexHit;
        }
    }
}
