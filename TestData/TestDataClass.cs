using System.Collections;
using NUnit.Framework;

namespace TurnupNunitMay20
{
    public class TestDataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("100","testdesc1");
                yield return new TestCaseData("8055","testde2");

            }
        }
    }
}