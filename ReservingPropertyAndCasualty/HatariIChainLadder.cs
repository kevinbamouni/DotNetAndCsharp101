using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservingPropertyAndCasualty
{
    public class HatariIChainLadder
    {
        decimal[,] TriangleData { get; }
        public HatariIChainLadder(decimal[,] triangleData)
        {
            TriangleData = triangleData;
        }

        //Step 2
        public static decimal[,] AgeToAgeLinkRatios(decimal[,] triangleArray)
        {
            int nRows = triangleArray.GetLength(0);
            int nColumns = triangleArray.GetLength(1);
            decimal[,] linkRatioTriangleArray = new decimal[nRows-1, nColumns-1];
            for (int i = 0; i < nRows-1; i++)
            {
                for (int j = 0; j < nColumns-1; j++)
                {
                    linkRatioTriangleArray[i, j] = triangleArray[i, j+1] / triangleArray[i, j];
                }
            }
            return linkRatioTriangleArray;
        }
        //Step 3
        //public decimal[,] AverageAgeToAgeLinkRatios()
        //{

        //}
        // Step 6
        public static decimal[] CumulativeClaimDevelopmentLinkRatios(decimal[,] triangleArray)
        {
            int nRows = triangleArray.GetLength(0);
            int nColumns = triangleArray.GetLength(1);
            decimal[] linkRatio = new decimal[nColumns - 1];
            decimal[] numerator = new decimal[nColumns-1];
            decimal[] denominator =  new decimal[nColumns - 1];

            // Numerator Calculation
            int n = nRows - 1;
            for (int j = 1; j < nColumns; j++)
            {
                numerator[j-1] = triangleArray[0, j];
                for (int i = 1; i < n; i++)
                {
                    numerator[j-1] = numerator[j-1] + triangleArray[i,j];
                }
                n--;
            }

            // Denominator calculation
            n = nRows - 1;
            for (int j = 0; j < nColumns-1; j++)
            {
                denominator[j] = triangleArray[0, j];
                for (int i = 1; i < n; i++)
                {
                    denominator[j] = denominator[j] + triangleArray[i, j];
                }
                n--;
            }

            // Link Ratios Calculation
            for (int i = 0; i < nColumns - 1; i++)
            {
                linkRatio[i] = numerator[i] / denominator[i];
            }

            return linkRatio;
        }

        // 1 divide by CumulativeClaimDevelopmentLinkRatios
        public static decimal[] CumulativeReportedOrPaidPattern(decimal[] linkRatio)
        {
            decimal[] Pattern = linkRatio;
            int nRows = linkRatio.GetLength(1);
            for (int i = 0; i < nRows; i++)
            {
                Pattern[i] = 1 / linkRatio[i];
            }
            return Pattern;
        }

        //// lag of CumulativeReportingPattern :
        //// IncremetalReportingtPattern(0) = CumulativeReportingPattern(0)
        //// n > 0 : IncremetalReportingtPattern(n) = CumulativeReportingPattern(n) - CumulativeReportingPattern(n-1)
        public static decimal[] IncremetalReportedOrPaidtPattern(decimal[] cumulativeReportedOrPaidPattern)
        {
            decimal[] Pattern = cumulativeReportedOrPaidPattern;
            int nRows = cumulativeReportedOrPaidPattern.GetLength(1);
            Pattern[0] = cumulativeReportedOrPaidPattern[0];
            for (int i = 1; i < nRows; i++)
            {
                Pattern[i] = cumulativeReportedOrPaidPattern[i] - cumulativeReportedOrPaidPattern[i-1];
            }

            return Pattern;
        }

        public static decimal[,] ProjectionToFullTriangle(decimal[,] cumulativeReportedOrPaidTriangle, decimal[] CumulativelinkRatios)
        {
            decimal[,] fulltriangle = cumulativeReportedOrPaidTriangle;
            int nRows = cumulativeReportedOrPaidTriangle.GetLength(0);
            int nColumns = cumulativeReportedOrPaidTriangle.GetLength(1);
            int n = 1;
            int lr = 0;
            for (int j = 1; j < nColumns; j++)
            {
                for (int i = nRows-1; j < nRows-1-n; i--)
                {
                    fulltriangle[i, j] = fulltriangle[i, j-1] * CumulativelinkRatios[lr];
                }
                lr++;
                n++;
            }
            return fulltriangle;
        }

        public static decimal[] ReservePerOrigin(decimal[,] projectionToFullTriangle)
        {
            int nColumns = projectionToFullTriangle.GetLength(1);
            decimal[] diag = GeneralArrayFuntions.ChainLadderLastDiagonal(projectionToFullTriangle);
            decimal[] ultimateColumn = GeneralArrayFuntions.GetColumnN(projectionToFullTriangle, nColumns-1);
            decimal[] reserves = new decimal[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                reserves[i] = ultimateColumn[i] - diag[i];
            }
            return reserves;
        }

        public static decimal TotalReserve(decimal[] ReservePerOrigin)
        {
            decimal totalreserve = 0;
            int nColumns = ReservePerOrigin.GetLength(1);
            for (int i = 0; i < nColumns; i++)
            {
                totalreserve = totalreserve + ReservePerOrigin[i];
            }
            return totalreserve;
        }

        public static decimal[] SimpleAverage(decimal[,] triangleArray)
        {
            decimal[,] AgeToAgeFactors = AgeToAgeLinkRatios(triangleArray);
            int nColumns = AgeToAgeFactors.GetLength(1);
            decimal[] result = new decimal[nColumns];
            for(int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(AgeToAgeFactors, i).Sum()/nColumns;
            }
            return result;
        }

        public static decimal[] SimpleAverageLatest5(decimal[,] triangleArray)
        {
            decimal[,] AgeToAgeFactors = AgeToAgeLinkRatios(triangleArray);
            int nColumns = AgeToAgeFactors.GetLength(1);
            decimal[] result = new decimal[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(AgeToAgeFactors, i).Take(nColumns-i).Skip(nColumns - 5).Sum() / 5;
            }
            return result;
        }
        public static decimal[] SimpleAverageLatest3(decimal[,] triangleArray) 
        {
            decimal[,] AgeToAgeFactors = AgeToAgeLinkRatios(triangleArray);
            int nColumns = AgeToAgeFactors.GetLength(1);
            decimal[] result = new decimal[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(AgeToAgeFactors, i).Take(nColumns - i).Skip(nColumns - 3).Sum() / 3; ;
            }
            return result;
        }
        public static decimal[] MedialAverageLatest5x1(decimal[,] triangleArray)
        {
            decimal[,] AgeToAgeFactors = AgeToAgeLinkRatios(triangleArray);
            int nColumns = AgeToAgeFactors.GetLength(1);
            decimal[] result = new decimal[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(AgeToAgeFactors, i).Sum() / nColumns;
            }
            return result;
        }
        public static decimal[] VolumeWeightedAverage(decimal[,] triangleArray) {
            decimal[,] AgeToAgeFactors = AgeToAgeLinkRatios(triangleArray);
            int nColumns = AgeToAgeFactors.GetLength(1);
            decimal[] result = new decimal[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(AgeToAgeFactors, i).Sum() / nColumns;
            }
            return result;
        }
        public static decimal[] VolumeWeightedAverageLatest5(decimal[,] triangleArray) {
            decimal[,] AgeToAgeFactors = AgeToAgeLinkRatios(triangleArray);
            int nColumns = AgeToAgeFactors.GetLength(1);
            decimal[] result = new decimal[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(AgeToAgeFactors, i).Sum() / nColumns;
            }
            return result;
        }
        public static decimal[] VolumeWeightedAverageLatest3(decimal[,] triangleArray) {
            decimal[,] AgeToAgeFactors = AgeToAgeLinkRatios(triangleArray);
            int nColumns = AgeToAgeFactors.GetLength(1);
            decimal[] result = new decimal[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(AgeToAgeFactors, i).Sum() / nColumns;
            }
            return result;
        }
        public static decimal[] GeometricAverageLatest4(decimal[,] triangleArray) {
            decimal[,] AgeToAgeFactors = AgeToAgeLinkRatios(triangleArray);
            int nColumns = AgeToAgeFactors.GetLength(1);
            decimal[] result = new decimal[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(AgeToAgeFactors, i).Sum() / nColumns;
            }
            return result;
        }


    }
}
