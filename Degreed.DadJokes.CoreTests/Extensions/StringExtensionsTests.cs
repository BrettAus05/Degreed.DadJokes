using NUnit.Framework;
using Degreed.DadJokes.Core.Utilities;

namespace Degreed.DadJokes.CoreTests.Extensions
{
    public class StringExtensionsTests
    {
        private string _searchTerm = "hello";

        [Test]
        public void StringExtensionEmptyString()
        {
            var input = string.Empty;

            var output = input.Emphasize(_searchTerm);

            Assert.IsEmpty(output);
        }

        [Test]
        public void StringExtensionValid()
        {
            var input = "Hello World";

            var output = input.Emphasize(_searchTerm);

            Assert.IsTrue(output.Contains(_searchTerm.ToUpper()));
        }
    }
}
