using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace WpfChainladder101
{
    internal class triangle
    {
        public Matrix<double> m { get; }

        public triangle() { m = Matrix<double>.Build.Random(10, 10); }
    }
}
