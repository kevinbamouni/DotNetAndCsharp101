using System;
using System.Linq;
using System.Data;

namespace ReservingPropertyAndCasualty {

    class Program {
        static void Main(string[] args) {
            // See https://aka.ms/new-console-template for more information
            

            // U.S. Industry Auto Data Reported Claims as of (months)
            decimal[,] ReportedClaims = new decimal[10, 10]{
            {37017487,43169009,45568919,46784558,47337318,47533264,47634419,47689655,47724678,47742304},
            {38954484,46045718,48882924,50219672,50729292,50926779,51069285,51163540,51185767,0},
            {41155776,49371478,52358476,53780322,54303086,54582950,54742188,54837929,0,0},
            {42394069,50584112,53704296,55150118,55895583,56156727,56299562,0,0,0},
            {44755243,52971643,56102312,57703851,58363564,58592712,0,0,0,0},
            {45163102,52497731,55468551,57015411,57565344,0,0,0,0,0},
            {45417309,52640322,55553673,56976657,0,0,0,0,0,0},
            {46360869,53790061,56786410,0,0,0,0,0,0,0},
            {46582684,54641339,0,0,0,0,0,0,0,0},
            {48853563,0,0,0,0,0,0,0,0,0}
        };
            // U.S. Industry Auto Data Paid Claims as of (months)
            double[,] PaidClaims = new double[10, 10]{
            {18539254,33231039,40062008,43892039,45896535,46765422,47221322,47446877,47555456,47644187},
            {20410193,36090684,43259402,47159241,49208532,50162043,50625757,50878808,51000534,0},
            {22120843,38976014,46389282,50562385,52735280,53740101,54284334,54533225,0,0},
            {22992259,40096198,47767835,52093916,54363436,55378801,55878421,0,0,0},
            {24092782,41795313,49903803,54352884,56754376,57807215,0,0,0,0},
            {24084451,41399612,49070332,53584201,55930654,0,0,0,0,0},
            {24369770,41489863,49236678,53774672,0,0,0,0,0,0},
            {25100697,42702229,50644994,0,0,0,0,0,0,0},
            {25608776,43606497,0,0,0,0,0,0,0,0},
            {27229969,0,0,0,0,0,0,0,0,0}
        };

            decimal[,] agetogae = HatariIChainLadder.AgeToAgeLinkRatios(ReportedClaims);
            decimal[] cumulativeDev = HatariIChainLadder.CumulativeClaimDevelopmentLinkRatios(ReportedClaims);
            decimal[,] proj = HatariIChainLadder.ProjectionToFullTriangle(ReportedClaims, cumulativeDev);
            decimal[] reserv = HatariIChainLadder.ReservePerOrigin(proj);
            decimal total = HatariIChainLadder.TotalReserve(reserv);
            decimal[] simpleav = HatariIChainLadder.SimpleAverage(agetogae);
            decimal[] simpleav1 = HatariIChainLadder.SimpleAverageLatest3(agetogae);
            decimal[] simpleav2 = HatariIChainLadder.SimpleAverageLatest5(agetogae);
            decimal[] vmav = HatariIChainLadder.VolumeWeightedAverage(ReportedClaims);
            decimal[] vmav3 = HatariIChainLadder.VolumeWeightedAverageLatest3(ReportedClaims);
            decimal[] vmav5 = HatariIChainLadder.VolumeWeightedAverageLatest5(ReportedClaims);
            decimal[] geom = HatariIChainLadder.GeometricAverageLatest4(agetogae);
            decimal[] cdf = HatariIChainLadder.CumulativeClaimDevelopmentFactor(cumulativeDev);
            decimal[] pat1 = HatariIChainLadder.CumulativePercentagePattern(cdf);
            decimal[] pat2 = HatariIChainLadder.IncrementalPercentagePattern(pat1);

            MethodChainLadder mtest = new MethodChainLadder(PaidClaims);
            mtest.fit();
            Dictionary<string, dynamic> restest = new Dictionary<string, dynamic>();
            restest = mtest.FullModelResult();
            string js;
            js = mtest.FullModelResultJsonText();
            Console.WriteLine("Hello, World!");

        }
    }
}