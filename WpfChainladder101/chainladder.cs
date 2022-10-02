using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace WpfChainladder101
{
    internal class chainladder
    {
        public triangle cl { get; set; }

        public chainladder(triangle t) { cl = t; }

        public Matrix<double> AgeToAgeFactors()
        {
            
            int nc = cl.m.ColumnCount;
            int nr = cl.m.RowCount;
            Matrix<double> result = CreateMatrix.Dense<double>(nr, nc);
            for (int i = 0; i < nc-1; i++)
            {
                result.SetColumn(i, cl.m.Column(i + 1) / cl.m.Column(i));
            }
            return result;
        }
    }
}
