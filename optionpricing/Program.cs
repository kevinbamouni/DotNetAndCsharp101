using System;
using System.Linq;
using MathNet.Numerics.Statistics;
using MathNet.Numerics.Distributions;

namespace optionpricing
{
    class Program
    {
        static void Main(string[] args)
        {
            double S0 = 95;
            double K = 100;
            double r = 0.05;
            double T = 1;
            double sigma = 0.1;
            int N = 252;
            int M = 100000;
            double[] S = new double[N + 1]; S[0] = S0;
            double dt = T / N;
            double[] payoffs = new double[M];
            double premium = 0;
            double stddev = 3.0;

            Console.WriteLine("THE CALL PARAMETERS :");
            Console.WriteLine($"S0 = {S0,8:c}");
            Console.WriteLine($"Strike K = {K}");
            Console.WriteLine($"Risk free rate r = {r}");
            Console.WriteLine($"Horizon T = {T}");
            Console.WriteLine($"Volatiliyt sigma = {sigma}");
            Console.WriteLine($"Monte carlo number of simulations N = {M}");
            Console.WriteLine("********************************************************");
            Console.WriteLine("REAL CALL PREMIUM COMPUTE WITH B&S : ");
            Console.WriteLine("********************************************************");

            // 2 payoffs simulation loop
            for (int j = 0; j < M; j++)
            {
                // 3 path simulation loop
                for (int i=0; i < N; i++)
                {
                    S[i + 1] = S[i] * Math.Exp((r - (0.5 * sigma * sigma)) * dt + sigma * Math.Sqrt(dt) * Normal.Sample(0.0, stddev));
                    // 4 compute the sum of payoffs of the simulations
                    payoffs[j] = Math.Max(S[N] - K, 0.0);
                }
            }
            // discounted  expected premium computation
            var moypayoff = payoffs.Average(); // simulated payoff mean estimation
            premium = Math.Exp(-r * T) * (moypayoff); // Actualise la moyenne des payoff pour fournir le prix

            // estimation precisions details
            double pay_stddev = 0; // standard deviation of the payoffs simulated
            pay_stddev = Statistics.StandardDeviation(payoffs); // standard deviation of the payoffs simulated

            Console.WriteLine("THE SIMULATION DETAILS : ");
            Console.WriteLine($"The payoffs mean : {moypayoff}");
            Console.WriteLine($"Call option premium : = {premium}");
            Console.WriteLine($"Confidence interval of the mean estimation : = {premium - 2 * (pay_stddev / Math.Sqrt(M))} ; {premium + 2 * (pay_stddev / Math.Sqrt(M))} ");
            Console.WriteLine($"The confidence interval size:  : = {premium + 2 * (pay_stddev / Math.Sqrt(M)) - (premium - 2 * (pay_stddev / Math.Sqrt(M)))}");
        }
    }
}
