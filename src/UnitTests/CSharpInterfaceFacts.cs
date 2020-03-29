using Xunit;

namespace NanoByte.CodeGeneration
{
    public class CSharpInterfaceFacts : CSharpTypeFactsBase
    {
        [Fact]
        public void GeneratesCorrectCode()
        {
            var myInterface = new CSharpIdentifier(ns: "Namespace1", name: "MyInterface");
            var baseInterface = new CSharpIdentifier(ns: "Namespace2", name: "BaseInterface");
            var endpointInterface = new CSharpIdentifier("TypedRest.Endpoints.Generic", "ICollectionEndpoint")
            {
                TypeArguments = {new CSharpIdentifier(ns: "Models", name: "MyModel")}
            };

            var dummyAttribute = new CSharpAttribute(new CSharpIdentifier("Attributes", "Dummy")) {Arguments = {"myValue"}};
            Assert(new CSharpInterface(myInterface)
            {
                Description = "My interface\nDetails",
                Attributes = {dummyAttribute},
                Interfaces = {baseInterface},
                Properties =
                {
                    new CSharpProperty(endpointInterface, "MyProperty")
                    {
                        Description = "My property",
                        Attributes = {dummyAttribute}
                    }
                }
            }, @"using Attributes;
using Models;
using Namespace2;
using TypedRest.Endpoints.Generic;

namespace Namespace1
{
    /// <summary>
    /// My interface
    /// Details
    /// </summary>
    [Dummy(""myValue"")]
    public partial interface MyInterface : BaseInterface
    {
        /// <summary>
        /// My property
        /// </summary>
        [Dummy(""myValue"")]
        ICollectionEndpoint<MyModel> MyProperty
        {
            get;
        }
    }
}");
        }
    }
}
