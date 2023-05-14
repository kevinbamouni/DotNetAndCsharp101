using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Statistics;
using MathNet.Numerics.Distributions;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfMvvmArchitecture101.Model 
{
    public class EuropeanCallOption : ObservableObject
    {
        private double _S0 = 95;
        public double S0 { get => _S0; set=>SetProperty(ref _S0, value); }

        private double _K = 100;
        public double K { get => _K; set => SetProperty(ref _K, value); }

        private double _r = 0.05;
        public double r { get => _r; set => SetProperty(ref _r, value); }

        private double _T = 1;
        public double T { get => _T; set => SetProperty(ref _T, value); }

        private double _sigma = 0.1;
        public double sigma { get => _sigma; set => SetProperty(ref _sigma, value); }

        private int _N = 252;
        public int N { get => _N; set => SetProperty(ref _N, value); }

        private int _M = 100;
        public int M { get => _M; set => SetProperty(ref _M, value); }

        //private double _stddev = 3.0;
        //public double stddev { get => _stddev; set => SetProperty(ref _stddev, value); }

        private double? _price = null;
        public double? price { get => _price; set => SetProperty(ref _price, value); }

        private double? _pay_stddev = null;
        public double? pay_stddev { get => _pay_stddev; set => SetProperty(ref _pay_stddev, value); }

        private double? _moypayoff = null;
        public double? moypayoff { get => _moypayoff; set => SetProperty(ref _moypayoff, value); }

        private double? _testCalcul = null;
        public double? testCalcul { get => _testCalcul; set => SetProperty(ref _testCalcul, value); }

        public void settescalcul()
        {
            _testCalcul = 9999.98;
        }

        public EuropeanCallOption(double S0, double K, double r, double T, double sigma, int N, int M)
        {
            _S0 = S0;
            _K = K;
            _r = r;
            _T = T;
            _sigma = sigma;
            _N = N;
            _M = M;
            //_stddev = stddev;
        }

        public EuropeanCallOption()
        {

        }

        public void PriceComputation()
        {
            double[] S = new double[_N + 1]; S[0] = _S0;
            double dt = _T / _N;
            double[] payoffs = new double[_M];
            // 2 payoffs simulation loop
            for (int j = 0; j < _M; j++)
            {
                // 3 path simulation loop
                for (int i = 0; i < _N; i++)
                {
                    S[i + 1] = S[i] * Math.Exp((_r - (0.5 * _sigma * _sigma)) * dt + _sigma * Math.Sqrt(dt) * Normal.Sample(0.0, 1.0));
                    // 4 compute the sum of payoffs of the simulations
                    payoffs[j] = Math.Max(S[_N] - _K, 0.0);
                }
            }
            // discounted  expected premium computation
            moypayoff = payoffs.Average(); // simulated payoff mean estimation
            price = Math.Exp(-r * T) * (moypayoff); // Actualise la moyenne des payoff pour fournir le prix

            // estimation precisions details
            pay_stddev = Statistics.StandardDeviation(payoffs); // standard deviation of the payoffs simulated
        }
    }
}
