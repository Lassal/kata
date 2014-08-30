using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.lassal.Kata.Kata02
{
    public class SequentialSearch_SecImpl: IBinarySearch
    {
        public int Chop(int numberToFind, int[] dataSet)
        {
            int indexFound = -1;

            if (dataSet != null)
            {
                for (int i = 0; i < dataSet.Length; i++)
                {
                    if (dataSet[i].Equals(numberToFind))
                    {
                        indexFound = i;
                        break;
                    }
                }
            }

            return indexFound;
        }
    }
}
