using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSubject = CardConsole.Utils.Utilities;

namespace CardConsole.Test.Utils
{
    public class Utilities
    {
        /// <summary>
        /// Simple class for testing
        /// </summary>
        private class Helper { }

        /// <summary>
        /// Method to replace "\r\n" line ending with "\n".
        /// </summary>
        private string NormalizeLineEndings(string input)
        {
            return input.Replace("\r\n", "\n");
        }

        [Fact]
        public void Utilities_ListToString_ListString()
        {
            List<string> list = ["one", "two", "three"];
            string expected = "[one, two, three]";

            Assert.Equal(expected, TestSubject.ListToString(list));
        }

        [Fact]
        public void Utilities_ListToString_ListInt()
        {
            List<int> list = [1, 2, 3, 4, 5];
            string expected = "[1, 2, 3, 4, 5]";

            Assert.Equal(expected, TestSubject.ListToString(list));
        }

        [Fact]
        public void Utilities_ListToString_ListCustomClass()
        {
            List<Helper> list = [new Helper(), new Helper()];
            string expected = $"[{list[0].ToString()}, {list[1].ToString()}]";

            Assert.Equal(expected, TestSubject.ListToString(list));
        }

        [Fact]
        public void Utilities_ListToString_ListNull()
        {
            List<Helper> list = [null, null];
            string expected = $"[null, null]";

            Assert.Equal(expected, TestSubject.ListToString(list));
        }

        [Fact]
        public void Utilities_DictionaryToString_EmptyDictionary()
        {
            // Arrange
            var dict = new Dictionary<string, object>();

            // Act
            var result = TestSubject.DictionaryToString(dict);

            // Assert
            var expected = "{\n}\n";
            Assert.Equal(expected, NormalizeLineEndings(result));
        }

        [Fact]
        public void Utilities_DictionaryToString_SimpleDictionary()
        {
            // Arrange
            var dict = new Dictionary<string, object>
            {
                { "key1", "value1" },
                { "key2", 42 },
                { "key3", 3.14 }
            };

            // Act
            var result = TestSubject.DictionaryToString(dict);

            // Assert
            var expected = "{\n\t\"key1\": \"value1\",\n\t\"key2\": 42,\n\t\"key3\": 3.14,\n}\n";
            Assert.Equal(expected, NormalizeLineEndings(result));
        }

        [Fact]
        public void Utilities_DictionaryToString_DictionaryWithList()
        {
            // Arrange
            var dict = new Dictionary<string, object>
            {
                { "key1", new List<int> { 1, 2, 3 } }
            };

            // Act
            var result = TestSubject.DictionaryToString(dict);

            // Assert
            var expected = "{\n\t\"key1\": [1, 2, 3],\n}\n";
            Assert.Equal(expected, NormalizeLineEndings(result));
        }

        [Fact]
        public void Utilities_DictionaryToString_NestedDictionary()
        {
            // Arrange
            var dict = new Dictionary<string, object>
            {
                { "key1", new Dictionary<string, object> { { "nestedKey", "nestedValue" } } }
            };

            // Act
            var result = TestSubject.DictionaryToString(dict);

            // Assert
            var expected = "{\n\t\"key1\": System.Collections.Generic.Dictionary`2[System.String,System.Object],\n}\n";
            Assert.Equal(expected, NormalizeLineEndings(result));
        }
    }
}
