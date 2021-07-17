using System;
using System.Text;
using MathNet.Numerics.Statistics;
using MathNet.Numerics.Distributions;
using System.Linq;

namespace databasesoft
{
    class Pricer
    {

        public StringBuilder Call_pricer(double S0, double K, double r, int T, double sigma, int N, int M)
        {
            double[] S = new double[N + 1]; S[0] = S0;
            double[] payoffs = new double[M];
            double premium;

            // 2 payoffs simulation loop
            for (int j = 0; j < M; j++)
            {
                for (int i = 0; i < N; i++)
                {
                    S[i + 1] = S[i] * Math.Exp((r - (0.5 * sigma * sigma)) * ((float)T/N) + sigma * Math.Sqrt((float)T/N) * Normal.Sample(0.0, sigma));
                    payoffs[j] = Math.Max(S[N-1] - K, 0.0);
                }
            }
            // discounted  expected premium computation
            double moypayoff = payoffs.Average(); // simulated payoff mean estimation
            premium = Math.Exp(-r * T) * (moypayoff); // Actualise la moyenne des payoff pour fournir le prix

            var sb = new System.Text.StringBuilder();
            sb.Append("-- EUROPEAN CALL OPTION PRICING -- \n\n");
            sb.Append("-- INPUTS -- \n\n");
            sb.Append(String.Format("{0,-60} {1,5}\n", "S0", S0));
            sb.Append(String.Format("{0,-60} {1,5}\n", "Strike K", K));
            sb.Append(String.Format("{0,-60} {1,5}\n", "Risk free rate r", r));
            sb.Append(String.Format("{0,-60} {1,5}\n", "Horizon T", T));
            sb.Append(String.Format("{0,-60} {1,5}\n", "Volatiliyt sigma", sigma));
            sb.Append(String.Format("{0,-60} {1,5}\n", "Monte carlo number of simulations M", M));
            sb.Append(String.Format("{0,-60} {1,5}\n\n", "Number of days", N));
            sb.Append(String.Format("{0,-30} \n\n", "-- RESULTS --"));
            sb.Append(String.Format("{0,-30} {1,-15}\n", "The payoffs mean", moypayoff));
            sb.Append(String.Format("{0,-30} {1,-15}\n", "Call option premium", premium));
            sb.Append(String.Format("{0,-30} {1,-25} {1,-25}\n", "Confidence interval", premium - 2 * (Statistics.StandardDeviation(payoffs) / Math.Sqrt(M)), premium + 2 * (Statistics.StandardDeviation(payoffs) / Math.Sqrt(M))));
            sb.Append(String.Format("{0,-30} {1,-15} \n", "Confidence interval size", premium + 2 * (Statistics.StandardDeviation(payoffs) / Math.Sqrt(M)) - (premium - 2 * (Statistics.StandardDeviation(payoffs) / Math.Sqrt(M)))));

            return sb;
        }
    }
}
