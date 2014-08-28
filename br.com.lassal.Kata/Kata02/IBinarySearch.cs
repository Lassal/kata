using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace br.com.lassal.Kata.Kata02
{
    /// <summary>
    /// Specificication:: Write a binary chop method that takes an integer search target and 
    /// a sorted array of integers. It should return the integer index of the target in the array, 
    /// or -1 if the target is not in the array. The signature will logically be:
    ///    chop(int, array_of_int)  -> int
    /// 
    /// See http://codekata.com/kata/kata02-karate-chop/
    /// </summary>
    public interface IBinarySearch
    {
        int Chop(int numberToFind, int[] dataSet);
    }
}
