using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservingPropertyAndCasualty
{
    public class HatariIChainLadder
    {
        public HatariIChainLadder()
        {

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
                    linkRatioTriangleArray[i, j] = linkRatioTriangleArray[i, j+1] / linkRatioTriangleArray[i, j];
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
        public decimal[] CumulativeReportedOrPaidPattern(decimal[] linkRatio)
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
        public decimal[] IncremetalReportedOrPaidtPattern(decimal[] cumulativeReportedOrPaidPattern)
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

        //public decimal[] ProjectionToFullTriangle()
        //{

        //}

        //public decimal[] ReservePerOrigin()
        //{

        //}

        //public decimal[] TotalReserve()
        //{

        //}

        //public Dictionary<string,dynamic> ChainLadderFinalResults()
        //{

        //}
    }
}
