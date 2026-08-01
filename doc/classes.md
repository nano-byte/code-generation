# Classes

<xref:NanoByte.CodeGeneration.CSharpClass> generates a `public partial class` declaration with properties, attributes, optional base class and optional implemented interfaces.

```csharp
var myClass = new CSharpClass(new CSharpIdentifier("MyNamespace", "MyClass"))
{
    Summary = "My class",
    Properties =
    {
        new CSharpProperty(CSharpIdentifier.String, "MyProperty")
        {
            Summary = "My property",
            HasSetter = true
        }
    }
};
```

## Base class with constructor forwarding

Set <xref:NanoByte.CodeGeneration.CSharpClass.BaseConstructor> to derive from a base class. Parameters without a `Value` are forwarded from the generated constructor; parameters with a literal `Value` are passed directly to the base call.

```csharp
var baseClass = new CSharpIdentifier("MyApp.Endpoints", "BaseEndpoint");
var referrer = new CSharpIdentifier("TypedRest.Endpoints", "IEndpoint");

var myClass = new CSharpClass(new CSharpIdentifier("MyApp", "SampleEndpoint"))
{
    BaseConstructor = new CSharpObjectCreation(baseClass)
    {
        Parameters =
        {
            new CSharpParameter(referrer, "referrer"),
            new CSharpParameter(CSharpIdentifier.String, "relativeUri") {Value = "./sample"}
        }
    }
};
```

This emits a constructor that takes `referrer` as an argument and forwards it to the base call together with the literal `relativeUri: "./sample"`.

## Property initializers

Properties can be configured with a default value via <xref:NanoByte.CodeGeneration.CSharpProperty.Initializer> or as a computed read-only property via <xref:NanoByte.CodeGeneration.CSharpProperty.GetterExpression>. Both accept a <xref:NanoByte.CodeGeneration.CSharpObjectCreation>. Use `new ThisReference()` as a parameter value to pass `this` to the constructor call.

```csharp
new CSharpProperty(otherClass, "Child")
{
    GetterExpression = new CSharpObjectCreation(otherClass)
    {
        Parameters =
        {
            new CSharpParameter(myClass, "parent") {Value = new ThisReference()},
            new CSharpParameter(CSharpIdentifier.String, "name") {Value = "sample"}
        }
    }
}
```

`Initializer` can only express a constructor call. Set <xref:NanoByte.CodeGeneration.CSharpProperty.InitializerExpression> to emit an arbitrary C# expression instead; it is parsed and emitted as-is, so the caller is responsible for its validity.

```csharp
new CSharpProperty(CSharpIdentifier.String, "Name")
{
    HasSetter = true,
    InitializerExpression = "default!"
}
```

`Initializer`, `InitializerExpression` and `GetterExpression` are mutually exclusive.

## Instantiating the generated class

Call <xref:NanoByte.CodeGeneration.CSharpClass.ToObjectCreation> to obtain a <xref:NanoByte.CodeGeneration.CSharpObjectCreation> for the class. Useful when one generated class needs to instantiate another (for example as a property initializer).
