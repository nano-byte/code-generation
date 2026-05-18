# Interfaces

<xref:NanoByte.CodeGeneration.CSharpInterface> generates a `public partial interface` declaration. It works analogously to <xref:NanoByte.CodeGeneration.CSharpClass> but emits properties without setters or bodies.

```csharp
var myInterface = new CSharpInterface(new CSharpIdentifier("MyApp", "IMyService"))
{
    Summary = "Provides access to my service.",
    Interfaces = {new CSharpIdentifier("MyApp", "IBaseService")},
    Properties =
    {
        new CSharpProperty(CSharpIdentifier.String, "Name") {Summary = "The display name."}
    }
};
```

Add identifiers to <xref:NanoByte.CodeGeneration.CSharpInterface.Interfaces> to declare base interfaces. Properties added via <xref:NanoByte.CodeGeneration.CSharpInterface.Properties> are emitted as get-only members on the interface; any setters or initializers configured on a <xref:NanoByte.CodeGeneration.CSharpProperty> only take effect when the property is used on a <xref:NanoByte.CodeGeneration.CSharpClass>.
