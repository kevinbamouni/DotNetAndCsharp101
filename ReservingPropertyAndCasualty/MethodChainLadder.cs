using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservingPropertyAndCasualty
{
    public class MethodChainLadder
    {
        public double[,]? TriangleData { get; }
        public double[,]? AgeToAgeLinkRatio { get; set; }
        public double[,]? FullTriangleData { get; set; }
        public double[]? LinkRatio { get; set; }
        double[]? ReservePerOrigin { get; set; }
        public double[]? Ultimate { get; set; }
        double? TotalReserve;
        double[]? CumulativePattern;
        double[]? IncrementalPattern;
        double[]? CumulativeDevelopmentFactor;
        double[]? Diagonale;
        public MethodChainLadder(double[,] triangleData)
        {
            TriangleData = triangleData;
        }
        public void fit()
        {
            AgeToAgeLinkRatio = HatarilMethodBasicDouble.AgeToAgeLinkRatios(TriangleData!);
            LinkRatio = HatarilMethodBasicDouble.VolumeWeightedAverage(TriangleData!);
            CumulativeDevelopmentFactor = HatarilMethodBasicDouble.CumulativeClaimDevelopmentFactor(LinkRatio);
            FullTriangleData = HatarilMethodBasicDouble.ProjectionToFullTriangle(TriangleData!, LinkRatio);
            ReservePerOrigin = HatarilMethodBasicDouble.ReservePerOrigin(FullTriangleData);
            TotalReserve = HatarilMethodBasicDouble.TotalReserve(ReservePerOrigin);
            Ultimate = GeneralArrayFuntions.GetColumnN(FullTriangleData, FullTriangleData.GetLength(1) - 1);
            CumulativePattern = HatarilMethodBasicDouble.CumulativePercentagePattern(CumulativeDevelopmentFactor);
            IncrementalPattern = HatarilMethodBasicDouble.IncrementalPercentagePattern(CumulativePattern);
            Diagonale = GeneralArrayFuntions.ChainLadderLastDiagonal(TriangleData!);
        }

        public Dictionary<string, dynamic> FullModelResult()
        {
            Dictionary<string, dynamic> result = new Dictionary<string, dynamic>();
            result.Add("AgeToAgeLinkRatio", AgeToAgeLinkRatio);
            result.Add("LinkRatio", LinkRatio);
            result.Add("CumulativeDevelopmentFactor", CumulativeDevelopmentFactor);
            result.Add("FullTriangleData", FullTriangleData);
            result.Add("ReservePerOrigin", ReservePerOrigin);
            result.Add("TotalReserve", TotalReserve);
            result.Add("Ultimate", Ultimate);
            result.Add("CumulativePattern", CumulativePattern);
            result.Add("IncrementalPattern", IncrementalPattern);
            result.Add("Diagonale", Diagonale);
            return result;
        }

        public string FullModelResultJsonText()
        {
            string result;
            //result = System.Text.Json.JsonSerializer.Serialize(FullModelResult());
            return "";
        }

    }
}
