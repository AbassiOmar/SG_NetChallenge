using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SG_Net_Challenge.Test.Tests
{
    public class UnitTestExecutor<T>
    {
        private readonly IValidator<T> validator;
        public UnitTestExecutor(IValidator<T> validator)
        {
            this.validator = validator;
        }

        public void Execute(T objectToTest, bool expectedResult)
        {
            var res = this.validator.Validate(objectToTest);

            if (expectedResult)
            {
                Assert.True(res.IsValid);
            }
            else
            {
                Assert.False(res.IsValid);
            }
        }

        public void Execute(T objectToTest, string expectedError)
        {
            var res = this.validator.Validate(objectToTest);
            var errors = res.Errors.Select(e => e.ErrorMessage);

            Assert.Contains(expectedError, errors);
        }
    }
}
