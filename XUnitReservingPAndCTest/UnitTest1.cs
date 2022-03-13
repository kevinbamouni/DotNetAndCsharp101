using Xunit;
using ReservingPropertyAndCasualty;
using System;

namespace XUnitReservingPAndCTest
{
    public class UnitTest1
    {
        decimal[,] arr2d = new decimal[5, 5]{
                                {1, 0, 0, 4, 3},
                                {9, 0, 3, 3, 2},
                                {5, 6, 0, 5, 0},
                                {4, 3, 6, 9, 7},
                                {3, 8, 7, 8, 2}
                            };
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void ChainLadderGetRowNTest1()
        {
            decimal[] a = new decimal[5]{ 4, 3, 6, 9, 7 };
            Assert.Equal<decimal[]>(a, GeneralArrayFuntions.GetRowN(this.arr2d, 3));
        }

        [Fact]
        public void ChainLadderGetRowNTest2()
        {
            decimal[] a = new decimal[5] { 1, 0, 0, 4, 3 };
            Assert.Equal<decimal[]>(a, GeneralArrayFuntions.GetRowN(this.arr2d, 0));
        }

        [Fact]
        public void ChainLadderGetRowNTest3()
        {
            decimal[] a = new decimal[5] { 3, 8, 7, 8, 2 };
            Assert.Equal<decimal[]>(a, GeneralArrayFuntions.GetRowN(this.arr2d, 4));
        }

        [Fact]
        public void ChainLadderGetRowNTest4()
        {
            Assert.Throws<IndexOutOfRangeException>(()=> GeneralArrayFuntions.GetRowN(this.arr2d, 10));
        }

        [Fact]
        public void ChainLadderGetColumnNTest1()
        {
            decimal[] a = new decimal[5] { 4, 3, 5, 9, 8 };
            Assert.Equal<decimal[]>(a, GeneralArrayFuntions.GetColumnN(this.arr2d, 3));
        }

        [Fact]
        public void ChainLadderGetColumnNTest2()
        {
            decimal[] a = new decimal[5] { 1,9,5,4,3 };
            Assert.Equal<decimal[]>(a, GeneralArrayFuntions.GetColumnN(this.arr2d, 0));
        }

        [Fact]
        public void ChainLadderGetColumnNTest3()
        {
            decimal[] a = new decimal[5] { 3,2,0,7,2 };
            Assert.Equal<decimal[]>(a, GeneralArrayFuntions.GetColumnN(this.arr2d, 4));
        }
    }
}