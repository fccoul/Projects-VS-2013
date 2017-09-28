using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAPI_2013.Test
{
    public class Abacus
    {
        private readonly int ValueMax;
        private readonly int ResultMax;

        public Abacus(int valueMax,int resultMax)
        {
            ValueMax = valueMax;
            ResultMax = resultMax;
        }

        public int Add(int x,int y)
        {
            Validatevalue(x);
            Validatevalue(y);
            ValidateResult(x + y);
            return x + y;
        }

        public int Substract(int x, int y)
        {
            Validatevalue(x);
            Validatevalue(y);
            ValidateResult(x - y);
            return x - y;
        }

        public int Multiply(int x, int y)
        {
            Validatevalue(x);
            Validatevalue(y);
            ValidateResult(x * y);
            return x * y;
        }

        public int Divide(int x, int y)
        {
            Validatevalue(x);
            Validatevalue(y);
            ValidateResult(x / y);
            return x / y;
        }

        void Validatevalue(int value)
        {
            if (value <= 0)
                throw new ValidationException("value must be greater than 0.");
            if (value > ValueMax)
                throw new ValidationException(string.Format("value must be less than or equal to {0}.", ValueMax));
        }

        void ValidateResult(long result)
        {
            if (result <= 0)
                throw new ValidationException("Result must be greater than 0.");
            if (result > ResultMax)
                throw new ValidationException(string.Format("Result must be less than or equal to {0}.", ResultMax));
        }
    }
}