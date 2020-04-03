using Xunit;

namespace NanoByte.CodeGeneration
{
    public class CSharpEnumFacts : CSharpTypeFactsBase
    {
        [Fact]
        public void GeneratesCorrectCode()
        {
            var myEnum = new CSharpIdentifier(ns: "Namespace1", name: "MyEnum");
            var dummyAttribute = new CSharpAttribute(new CSharpIdentifier("Attributes", "DummyAttribute"))
            {
                Arguments = {"myValue"},
                NamedArguments = {("Extra", "extra")}
            };

            Assert(new CSharpEnum(myEnum)
            {
                Summary = "My enum\nDetails",
                Values =
                {
                    new CSharpEnumValue("Value1")
                    {
                        Summary = "My value 1",
                        Attributes = {dummyAttribute}
                    },
                    new CSharpEnumValue("Value2")
                    {
                        Summary = "My value 2",
                        Attributes = {dummyAttribute}
                    }
                }
            }, @"using Attributes;

namespace Namespace1
{
    /// <summary>
    /// My enum
    /// Details
    /// </summary>
    public enum MyEnum
    {
        /// <summary>
        /// My value 1
        /// </summary>
        [Dummy(""myValue"", Extra = ""extra"")]
        Value1,
        /// <summary>
        /// My value 2
        /// </summary>
        [Dummy(""myValue"", Extra = ""extra"")]
        Value2
    }
}");
        }
    }
}
