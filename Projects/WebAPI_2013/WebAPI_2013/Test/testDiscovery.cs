﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xunit;

namespace WebAPI_2013.Test
{
    public class testDiscovery
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        [Fact]
        public void FailingTest()
        {
            Assert.Equal(5, Add(2, 2));
          
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void MyFirstTheory(int value)
        {
            Assert.True(isOdd(value));
        }
        bool isOdd(int value)
        {
            return value % 2 == 1;
        }
    }
}