 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservingPropertyAndCasualty
{
    public static class HatarilMethodBasicDouble
    {
        public static double[,] AgeToAgeLinkRatios(double[,] triangleArray)
        {
            int nRows = triangleArray.GetLength(0);
            int nColumns = triangleArray.GetLength(1);
            double[,] linkRatioTriangleArray = new double[nRows - 1, nColumns - 1];
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

        // 1 divide by CumulativeClaimDevelopmentLinkRatios
        public static double[] CumulativePercentagePattern(double[] linkRatio)
        {
            int nRows = linkRatio.Length;
            double[] Pattern = new double[nRows];
            for (int i = 0; i < nRows; i++)
            {
                Pattern[i] = 1 / linkRatio[i];
            }
            return Pattern;
        }

        public static double[] IncrementalPercentagePattern(double[] linkRatio)
        {
            int nRows = linkRatio.Length;
            double[] Pattern = new double[nRows];
            Pattern[0] = linkRatio[0];
            for (int i = 1; i < nRows; i++)
            {
                Pattern[i] = linkRatio[i] - linkRatio[i - 1];
            }
            return Pattern;
        }

        public static double[,] ProjectionToFullTriangle(double[,] cumulativeReportedOrPaidTriangle, double[] CumulativelinkRatios)
        {
            double[,] fulltriangle = cumulativeReportedOrPaidTriangle;
            int nRows = cumulativeReportedOrPaidTriangle.GetLength(0);
            int nColumns = cumulativeReportedOrPaidTriangle.GetLength(1);
            int n = 0;
            int lr = 0;
            for (int j = 1; j < nColumns; j++)
            {
                for (int i = nRows - 1 - n; i < nRows; i++)
                {
                    fulltriangle[i, j] = fulltriangle[i, j - 1] * CumulativelinkRatios[lr];
                }
                lr += 1;
                n += 1;
            }
            return fulltriangle;
        }

        public static double[] ReservePerOrigin(double[,] projectionToFullTriangle)
        {
            int nColumns = projectionToFullTriangle.GetLength(1);
            double[] diag = GeneralArrayFuntions.ChainLadderLastDiagonal(projectionToFullTriangle);
            double[] ultimateColumn = GeneralArrayFuntions.GetColumnN(projectionToFullTriangle, nColumns - 1);
            double[] reserves = new double[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                reserves[i] = ultimateColumn[i] - diag[i];
            }
            return reserves;
        }

        public static dynamic TotalReserve(double[] ReservePerOrigin)
        {
            return ReservePerOrigin.Sum();
        }

        public static double[] SimpleAverage(double[,] triangleArray)
        {
            int nColumns = triangleArray.GetLength(1);
            double[] result = new double[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i).Average();
            }
            return result;
        }

        public static double[] SimpleAverageLatest5(double[,] triangleArray)
        {
            int nColumns = triangleArray.GetLength(1);
            double[] result = new double[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i).Skip(Math.Max(nColumns - i - 5, 0)).Average();
            }
            return result;
        }

        public static double[] SimpleAverageLatest3(double[,] triangleArray)
        {
            int nColumns = triangleArray.GetLength(1);
            double[] result = new double[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i).Skip(Math.Max(nColumns - i - 3, 0)).Average();
            }
            return result;
        }
        public static double[] MedialAverageLatest5x1(double[,] triangleArray)
        {
            int nColumns = triangleArray.GetLength(1);
            double[] result = new double[nColumns];
            for (int i = 0; i < nColumns; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(triangleArray, i).Sum() / nColumns;
            }
            return result;
        }

        public static double[] VolumeWeightedAverage(double[,] triangleArray)
        {
            int nColumns = triangleArray.GetLength(1);
            double[] result = new double[nColumns - 1];
            for (int i = 0; i < nColumns - 1; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(triangleArray, i + 1).Take(nColumns - i - 1).Sum()
                    / GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i - 1).Sum();
            }
            return result;
        }
        public static double[] VolumeWeightedAverageLatest5(double[,] triangleArray)
        {
            int nColumns = triangleArray.GetLength(1);
            double[] result = new double[nColumns - 1];
            for (int i = 0; i < nColumns - 1; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(triangleArray, i + 1).Take(nColumns - i - 1).Skip(Math.Max(nColumns - i - 5 + 1, 0)).Sum()
                    / GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i - 1).Skip(Math.Max(nColumns - i - 5 + 1, 0)).Sum();
            }
            return result;
        }
        public static double[] VolumeWeightedAverageLatest3(double[,] triangleArray)
        {
            int nColumns = triangleArray.GetLength(1);
            double[] result = new double[nColumns - 1];
            for (int i = 0; i < nColumns - 1; i++)
            {
                result[i] = GeneralArrayFuntions.GetColumnN(triangleArray, i + 1).Take(nColumns - i - 1).Skip(Math.Max(nColumns - i - 3 + 1, 0)).Sum()
                    / GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i - 1).Skip(Math.Max(nColumns - i - 3 + 1, 0)).Sum();
            }
            return result;
        }
        public static double[] GeometricAverageLatest4(double[,] triangleArray)
        {
            int nColumns = triangleArray.GetLength(1);
            double[] result = new double[nColumns];
            double productOfVectorValues, power;
            double geomAverage;
            for (int i = 0; i < nColumns; i++)
            {
                productOfVectorValues = GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i).Skip(Math.Max(nColumns - i - 4, 0)).Aggregate((num1, num2) => num1 * num2);
                power = 1 / GeneralArrayFuntions.GetColumnN(triangleArray, i).Take(nColumns - i).Skip(Math.Max(nColumns - i - 4, 0)).Count();
                geomAverage = Math.Pow(productOfVectorValues, power);
                result[i] = geomAverage;
            }
            return result;
        }
        public static double[] CumulativeClaimDevelopmentFactor(double[] linkRatio)
        {
            double[] result = new double[linkRatio.Length];
            for (int i = 0; i < linkRatio.Length; i++)
            {
                result[i] = linkRatio.Skip(i).Aggregate((num1, num2) => num1 * num2);
            }
            return result;
        }
    }
}
