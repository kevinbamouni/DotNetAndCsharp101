using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord;
using NumSharp;

namespace ReservingPropertyAndCasualty
{
    public static class GeneralArrayFuntions
    {
        // Les tableaux sont indexés sur zéro : un tableau avec n éléments est indexée de 0 à n-1
        public static decimal[,] CumulativeSumTriangle(decimal[,] triangleArray)
        {
            decimal[,] sumTriangleArray = triangleArray;
            int nRows = triangleArray.GetLength(0);
            int nColumns = triangleArray.GetLength(1);
            for(int i=0; i < nRows; i++){
                for (int j = 1; j < nColumns; j++){
                    sumTriangleArray[i,j]= sumTriangleArray[i,j]+ sumTriangleArray[i,j-1];
                }
            }
            return sumTriangleArray;
        }

        public static decimal[] GetColumnN(decimal[,] triangleArray, int n)
        {
            int nColumns = triangleArray.GetLength(1);
            if (n < nColumns)
            {
                decimal[] array = new decimal[nColumns];
                for (int i = 0; i < nColumns; i++)
                {
                    array[i] = triangleArray[i, n];
                }
                return array;
            }
            else { throw new IndexOutOfRangeException(); }
        }

        public static decimal[] GetRowN(decimal[,] triangleArray, int n)
        {
            
            int nRows = triangleArray.GetLength(0);
            if (n < nRows)
            {
                decimal[] array = new decimal[nRows];
                for (int i = 0; i < nRows; i++)
                {
                    array[i] = triangleArray[n, i];
                }
                return array;
            }
            else { throw new IndexOutOfRangeException(); }
        }

        public static decimal[] TriangleMainDiagonal(decimal[,] triangleArray)
        {
            int nRows = triangleArray.GetLength(0);
            decimal[] array = new decimal[nRows];
            for (int i = 0; i < nRows; i++)
            {
                array[i] = triangleArray[i, i];
            }
            return array;
        }

        public static decimal[] ChainLadderLastDiagonal(decimal[,] triangleArray)
        {
            int nRows = triangleArray.GetLength(0);
            decimal[] array = new decimal[nRows];
            int nColumns = triangleArray.GetLength(1);
            for (int i = 0; i < nRows; i++)
            {
                array[i] = triangleArray[i, nColumns-1-i];
            }
            return array;
        }

        public static decimal[] FirstVectorLessSecondVector(decimal[] v1, decimal[] v2)
        {
            decimal[] result = new decimal[v1.Length];
            for (int i = 0; i < v1.Length; i++)
            {
                result[i] = v1[i]-v2[i];
            }
            return result;
        }

        public static decimal[] FirstVectorPlusSecondVector(decimal[] v1, decimal[] v2)
        {
            decimal[] result = new decimal[v1.Length];
            for (int i = 0; i < v1.Length; i++)
            {
                result[i] = v1[i] + v2[i];
            }
            return result;
        }

        public static decimal[] FirstVectorTimeSecondVector(decimal[] v1, decimal[] v2)
        {
            decimal[] result = new decimal[v1.Length];
            for (int i = 0; i < v1.Length; i++)
            {
                result[i] = v1[i] * v2[i];
            }
            return result;
        }

        public static decimal[] FirstVectorTimeSecondVector(decimal[] v1, decimal v2)
        {
            decimal[] result = new decimal[v1.Length];
            for (int i = 0; i < v1.Length; i++)
            {
                result[i] = v1[i] * v2;
            }
            return result;
        }

        public static decimal[] FirstVectorDivideSecondVector(decimal[] v1, decimal v2)
        {
            decimal[] result = new decimal[v1.Length];
            for (int i = 0; i < v1.Length; i++)
            {
                result[i] = v1[i] / v2;
            }
            return result;
        }

        public static decimal[] FirstVectorDivideSecondVector(decimal[] v1, decimal[] v2)
        {
            decimal[] result = new decimal[v1.Length];
            for (int i = 0; i < v1.Length; i++)
            {
                result[i] = v1[i] / v2[i];
            }
            return result;
        }

        public static decimal TwoVectorsProduct(decimal[] v1, decimal[] v2)
        {
            decimal result = 0;
            for (int i = 0; i < v1.Length; i++)
            {
                result = result + v1[i] * v2[i];
            }
            return result;
        }
    }
}