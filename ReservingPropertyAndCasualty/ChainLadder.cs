using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord;
using NumSharp;

namespace ReservingPropertyAndCasualty
{
    internal class ChainLadder
    {   
        // Les tableaux sont indexés sur zéro : un tableau avec n éléments est indexée de 0 à n-1
        decimal[,] CumulativeSumTriangle(decimal[,] triangleArray)
        {
            decimal[,] sumTriangleArray = triangleArray;
            int nRows = triangleArray.GetLength(0);
            int nColumns = triangleArray.GetLength(1);
            for(int i=0; i<nRows-1; nRows++){
                for (int j = 1; j <= nColumns-1; nRows++){
                    sumTriangleArray[i,j]= sumTriangleArray[i,j]+ sumTriangleArray[i,j-1];
                }
            }
            return sumTriangleArray;
        }

        decimal[] GetColumnN(decimal[,] triangleArray, int n)
        {
            int nRows = triangleArray.GetLength(0);
            decimal[] array = new decimal[nRows];
            for (int i = 0; i < nRows - 1; nRows++)
            {
                array[i] = triangleArray[i,n];
            }
            return array;
        }

        decimal[] GetRowN(decimal[,] triangleArray, int n)
        {
            int nColumns = triangleArray.GetLength(1);
            decimal[] array = new decimal[nColumns];
            for (int i = 0; i < nColumns - 1; nColumns++)
            {
                array[i] = triangleArray[n, i];
            }
            return array;
        }

        decimal[] TriangleMainDiagonal(decimal[,] triangleArray)
        {
            int nRows = triangleArray.GetLength(0);
            decimal[] array = new decimal[nRows];
            for (int i = 0; i < nRows - 1; nRows++)
            {
                array[i] = triangleArray[i, i];
            }
            return array;
        }

        decimal[] ChainLadderLastDiagonal(decimal[,] triangleArray)
        {
            int nRows = triangleArray.GetLength(0);
            decimal[] array = new decimal[nRows];
            int nColumns = triangleArray.GetLength(1);
            for (int i = 0; i < nRows - 1; nRows++)
            {
                array[i] = triangleArray[i, nColumns-1-i];
            }
            return array;
        }
    }
}
