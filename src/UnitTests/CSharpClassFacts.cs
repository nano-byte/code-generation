using Xunit;

namespace NanoByte.CodeGeneration
{
    public class CSharpClassFacts : CSharpTypeFactsBase
    {
        [Fact]
        public void GeneratesCorrectCode()
        {
            var myClass = new CSharpIdentifier(ns: "Namespace1", name: "MyClass");
            var myModel = new CSharpIdentifier(ns: "Models", name: "MyModel");
            var myInterface = new CSharpIdentifier(ns: "Namespace1", name: "MyInterface") {TypeArguments = {myModel}};
            var otherClass = new CSharpIdentifier(ns: "Namespace1", name: "OtherClass") {TypeArguments = {myModel}};
            var baseClass = new CSharpIdentifier(ns: "Namespace2", name: "BaseClass");
            var endpointInterface = new CSharpIdentifier("TypedRest.Endpoints", "IEndpoint");

            var dummyAttribute = new CSharpAttribute(new CSharpIdentifier("Attributes", "Dummy")) {Arguments = {"myValue"}};
            Assert(new CSharpClass(myClass)
            {
                Summary = "My class\nDetails",
                Attributes = {dummyAttribute},
                BaseClass = new CSharpConstructor(baseClass)
                {
                    Parameters =
                    {
                        new CSharpParameter(endpointInterface, "referrer"),
                        new CSharpParameter(CSharpIdentifier.String, "relativeUri") {Value = "./sample"}
                    }
                },
                Interfaces = {myInterface},
                Properties =
                {
                    new CSharpProperty(myInterface, "MyProperty")
                    {
                        Summary = "My property",
                        Attributes = {dummyAttribute},
                        GetterExpression = new CSharpConstructor(otherClass)
                        {
                            Parameters =
                            {
                                new CSharpParameter(CSharpIdentifier.String, "arg1") {Value = "value"}
                            }
                        }
                    }
                }
            }, @"using Attributes;
using Models;
using Namespace2;
using TypedRest.Endpoints;

namespace Namespace1
{
    /// <summary>
    /// My class
    /// Details
    /// </summary>
    [Dummy(""myValue"")]
    public partial class MyClass : BaseClass, MyInterface<MyModel>
    {
        public MyClass(IEndpoint referrer): base(referrer, relativeUri: ""./sample"")
        {
        }

        /// <summary>
        /// My property
        /// </summary>
        [Dummy(""myValue"")]
        public MyInterface<MyModel> MyProperty => new OtherClass<MyModel>(arg1: ""value"");
    }
}");
        }
    }
}
