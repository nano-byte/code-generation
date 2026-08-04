namespace NanoByte.CodeGeneration;

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
        var dummyAttribute = new CSharpAttribute(new CSharpIdentifier("Attributes", "DummyAttribute"))
        {
            Arguments = {"myValue"},
            NamedArguments = {("Extra", "extra")}
        };

        Assert(new CSharpInterface(myInterface)
        {
            Summary = "My interface\nDetails",
            Attributes = {dummyAttribute},
            Interfaces = {baseInterface},
            Properties =
            {
                new CSharpProperty(endpointInterface, "MyProperty")
                {
                    Summary = "My property",
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
    [Dummy(""myValue"", Extra = ""extra"")]
    public partial interface MyInterface : BaseInterface
    {
        /// <summary>
        /// My property
        /// </summary>
        [Dummy(""myValue"", Extra = ""extra"")]
        ICollectionEndpoint<MyModel> MyProperty { get; }
    }
}");
    }

    [Fact]
    public void GeneratesIndexersAndMethods()
    {
        var myModel = new CSharpIdentifier(ns: "Models", name: "MyModel");

        Assert(new CSharpInterface(new CSharpIdentifier(ns: "Namespace1", name: "MyInterface"))
        {
            Indexers =
            {
                new CSharpIndexer(myModel, new CSharpParameter(CSharpIdentifier.String, "id")) {Summary = "My indexer"}
            },
            Methods =
            {
                new CSharpMethod(myModel, "MyMethod")
                {
                    Summary = "My method",
                    Parameters = {new CSharpParameter(CSharpIdentifier.String, "id")}
                }
            }
        }, @"using Models;

namespace Namespace1
{
    public partial interface MyInterface
    {
        /// <summary>
        /// My indexer
        /// </summary>
        MyModel this[string id] { get; }

        /// <summary>
        /// My method
        /// </summary>
        MyModel MyMethod(string id);
    }
}");
    }

    [Fact]
    public void IgnoresRequiredOnInterfaceMembers()
    {
        Assert(new CSharpInterface(new CSharpIdentifier(ns: "Namespace1", name: "MyInterface"))
        {
            Properties =
            {
                new CSharpProperty(CSharpIdentifier.String, "MyProperty") {HasSetter = true, IsRequired = true}
            }
        }, @"namespace Namespace1
{
    public partial interface MyInterface
    {
        string MyProperty { get; set; }
    }
}");
    }
}
