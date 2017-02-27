using System;
using NUnit.Framework;

namespace CastleWindsorPOC.Tests
{
    internal static class CustomAssertimes
    {
        public static void ArgumentNullExceptionIsThrown(Action action, string parameterName)
        {
            var exception = Assert.Throws<ArgumentNullException>(action.Invoke);
            Assert.AreEqual(parameterName, exception.ParamName);
        }
    }
}
