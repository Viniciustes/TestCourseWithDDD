using System;
using Xunit;

namespace TestCourseWithDDD.Test.Exceptions
{
    public static class AssertExtension
    {
        public static void WithMessage(this ArgumentException exception, string message)
        {
            if (exception.Message == message)
                Assert.True(true);
            else
                Assert.True(false, $"Mensagem incorreta, deveria ser: '{message}'");
        }
    }
}