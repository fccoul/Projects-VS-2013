using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Xunit;

namespace WebAPI_2013.Test
{
    
    public class AbacusTest
    {
        [Fact]
        public void canAddOnePlusOne()
        {
            Abacus abacus = new Abacus(2, 4);
            Assert.Equal(2, abacus.Add(1, 1));
        }
    

        [Fact]
        public void canAddToResultLimit()
        {
            Abacus abacus = new Abacus(2, 4);
            Assert.Equal(4, abacus.Add(5, 2));
        }

        [Fact]
        public void canAddException()
        {
            int resultMax = 10;
            int valMax = 4;
            Abacus abacus = new Abacus(valMax, resultMax);
            //Assert.Equal(7, abacus.Add(5, 2));
            
            Exception ex = Assert.Throws<ValidationException>(() => abacus.Add(3, 8));
            Assert.Equal(string.Format("value must be less than or equal to {0}.", valMax), ex.Message);
        }

        [Theory]
        [InlineData(2,3)]
        [InlineData(4,5)]
        [InlineData(5,11)]
        public void canAddNumbersFromInlineDataInput(int x,int y)
        {
            //arrange :Prepare for the test
            Abacus abacus = new Abacus(Math.Max(x, y), x + y);
            Console.WriteLine("value :" + Math.Max(x, y));
            //act : Run the SUT(System Under Test)
            int result = abacus.Add(x, y);
            //assert : Check et verify the result
            Assert.True(result > 0);
            Assert.Equal(x + y, result);
        }

        [Theory]
        [MemberData("AddPositiveNumberData")]
        public void canAddNumbersFromInlineDataInput2(int x, int y)
        {
            //arrange
            Abacus abacus = new Abacus(Math.Max(x, y), x + y);
            Console.WriteLine("value :" + Math.Max(x, y));
            //act
            int result = abacus.Add(x, y);
            //assert
            Assert.True(result > 0);
            Assert.Equal(x + y, result);
        }

        private static List<object[]> AddPositiveNumberData()
        {
            return new List<object[]>
            {
                new object[] { 1,2},
                new object[] { 2,2},
                new object[] { 5,9},
                new object[] { 5,2}
            };
        }
    }
}