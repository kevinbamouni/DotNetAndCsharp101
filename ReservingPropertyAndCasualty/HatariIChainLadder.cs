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

        //Step 2 OK
        public static decimal[,] AgeToAgeLinkRatios(decimal[,] triangleArray)
        {
            int nRows = triangleArray.GetLength(0);
            int nColumns = triangleArray.GetLength(1);
            decimal[,] linkRatioTriangleArray = new decimal[nRows - 1, nColumns - 1];
            int decalage = 1;
            for (int j = 0; j < nColumns - 1; j++)
            {
                for (int i = 0; i < nRows - decalage; i++)
                {
                    linkRatioTriangleArray[i, j] = triangleArray[i, j + 1] / triangleArray[i, j];
                }
                decalage++;
            }
            return linkRatioTriangleArray; 
        }
        //Step 3
        //public decimal[,] AverageAgeToAgeLinkRatios()
        //{

        //}
        // Step 6 OK
        public static decimal[]CumulativeClaimDevelopmentLinkRatios(decimal[,] triangleArray)
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
        public static decimal[] CumulativePercentagePattern(decimal[] linkRatio)
        {
            int nRows = linkRatio.Length;
            decimal[] Pattern = new decimal[nRows];
            for (int i = 0; i < nRows; i++)
            {
                Pattern[i] = 1 / linkRatio[i];
            }
            return Pattern;
        }

        public static decimal[] IncrementalPercentagePattern(decimal[] linkRatio)
        {
            int nRows = linkRatio.Length;
            decimal[] Pattern = new decimal[nRows];
            Pattern[0] = linkRatio[0];
            for (int i = 1; i < nRows; i++)
            {
                Pattern[i] = linkRatio[i] - linkRatio[i-1];
            }
            return Pattern;
        }

        //// lag of CumulativeReportingPattern :
        //// IncremetalReportingtPattern(0) = CumulativeReportingPattern(0)
        //// n > 0 : IncremetalReportingtPattern(n) = CumulativeReportingPattern(n) - CumulativeReportingPattern(n-1)
        //public static decimal[] IncremetalReportedOrPaidtPattern(decimal[] cumulativeReportedOrPaidPattern)
        //{
        //    decimal[] Pattern = cumulativeReportedOrPaidPattern;
        //    int nRows = cumulativeReportedOrPaidPattern.GetLength(1);
        //    Pattern[0] = cumulativeReportedOrPaidPattern[0];
        //    for (int i = 1; i < nRows; i++)
        //    {
        //        Pattern[i] = cumulativeReportedOrPaidPattern[i] - cumulativeReportedOrPaidPattern[i-1];
        //    }
        //
        //    return Pattern;
        //}

        public static decimal[,] ProjectionToFullTriangle(decimal[,] cumulativeReportedOrPaidTriangle, decimal[] CumulativelinkRatios)
        {
            decimal[,] fulltriangle = cumulativeReportedOrPaidTriangle;
            int nRows = cumulativeReportedOrPaidTriangle.GetLength(0);
            int nColumns = cumulativeReportedOrPaidTriangle.GetLength(1);
            int n = 0;
            int lr = 0;
            for (int j = 1; j < nColumns; j++)
            {
                for (int i = nRows-1-n; i < nRows; i++)
                {
                    fulltriangle[i, j] = fulltriangle[i, j-1] * CumulativelinkRatios[lr];
                }
                lr+=1;
                n+=1;
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

        public static dynamic TotalReserve(decimal[] ReservePerOrigin)
        {
            //decimal totalreserve = 0;
            //int nColumns = ReservePerOrigin.GetLength(1);
            //for (int i = 0; i < nColumns; i++)
            //{
            //    totalreserve = totalreserve + ReservePerOrigin[i];
            //}
            return ReservePerOrigin.Sum();
        }

        public static decimal[] SimpleAverage(decimal[,] triangleArray)
        {
            //decimal[,] AgeToAgeFactors = AgeToAgeLinkRatios(triangleArray);
            int nColumns = triangleArray.GetLength(1);
            decimal[] result = new decimal[nColumns];
            for(int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns-i).Average();
            }
            return result;
        }

        public static decimal[] SimpleAverageLatest5(decimal[,] triangleArray)
        {
            //decimal[,] AgeToAgeFactors = AgeToAgeLinkRatios(triangleArray);
            int nColumns = triangleArray.GetLength(1);
            decimal[] result = new decimal[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i).Skip(Math.Max(nColumns - i - 5, 0)).Average();
                    //Math.Min(GeneralArrayFuntions.GetColumnN(AgeToAgeFactors, i).Take(nColumns - i).Skip(nColumns - i - 5).Count(), 5);
                    // /GeneralArrayFuntions.GetColumnN(AgeToAgeFactors, i).Take(nColumns - i).Skip(Math.Max(nColumns - i - 5, 0)).Count();
            }
            return result;
        }
        public static decimal[] SimpleAverageLatest3(decimal[,] triangleArray)
        {
            //decimal[,] AgeToAgeFactors = AgeToAgeLinkRatios(triangleArray);
            int nColumns = triangleArray.GetLength(1);
            decimal[] result = new decimal[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i).Skip(Math.Max(nColumns - i - 3, 0)).Average();
                    /// Math.Min(GeneralArrayFuntions.GetColumnN(AgeToAgeFactors, i).Take(nColumns - i).Skip(nColumns - i - 3).Count(), 3);
                    // /GeneralArrayFuntions.GetColumnN(AgeToAgeFactors, i).Take(nColumns - i).Skip(Math.Max(nColumns - i - 3, 0)).Count();
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
            int nColumns = triangleArray.GetLength(1);
            decimal[] result = new decimal[nColumns-1];
            for (int i = 0; i < nColumns-1; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(triangleArray, i+1).Take(nColumns - i - 1).Sum() 
                    / GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i - 1).Sum();
            }
            return result;
        }
        public static decimal[] VolumeWeightedAverageLatest5(decimal[,] triangleArray) {
            int nColumns = triangleArray.GetLength(1);
            decimal[] result = new decimal[nColumns - 1];
            for (int i = 0; i < nColumns - 1; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(triangleArray, i + 1).Take(nColumns - i - 1).Skip(Math.Max(nColumns - i - 5 + 1,0)).Sum()
                    / GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i - 1).Skip(Math.Max(nColumns - i - 5 + 1, 0)).Sum();
            }
            return result;
        }
        public static decimal[] VolumeWeightedAverageLatest3(decimal[,] triangleArray) {
            int nColumns = triangleArray.GetLength(1);
            decimal[] result = new decimal[nColumns - 1];
            for (int i = 0; i < nColumns - 1; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(triangleArray, i + 1).Take(nColumns - i - 1).Skip(Math.Max(nColumns - i - 3 + 1, 0)).Sum()
                    / GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i - 1).Skip(Math.Max(nColumns - i - 3 + 1, 0)).Sum();
            }
            return result;
        }
        public static decimal[] GeometricAverageLatest4(decimal[,] triangleArray) {
            //decimal[,] AgeToAgeFactors = AgeToAgeLinkRatios(triangleArray);
            int nColumns = triangleArray.GetLength(1);
            decimal[] result = new decimal[nColumns];
            decimal productOfVectorValues, power;
            double geomAverage;
            for (int i = 0; i < nColumns; i++)
            {
                productOfVectorValues = GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i).Skip(Math.Max(nColumns - i - 4,0)).Aggregate((num1, num2) => num1 * num2);
                power = 1/GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i).Skip(Math.Max(nColumns - i - 4, 0)).Count();
                geomAverage = Math.Pow(Convert.ToDouble(productOfVectorValues), Convert.ToDouble(power));
                result[i] = Convert.ToDecimal(geomAverage);
            }
            return result;
        }

        public static decimal[] CumulativeClaimDevelopmentFactor(decimal[] linkRatio)
        {
            decimal[] result = new decimal[linkRatio.Length];
            for (int i = 0; i < linkRatio.Length; i++)
            {
                result[i] = linkRatio.Skip(i).Aggregate((num1, num2) => num1 * num2);
            }
            return result;
        }



    }
}
