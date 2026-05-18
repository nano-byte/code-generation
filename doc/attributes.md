# Attributes

<xref:NanoByte.CodeGeneration.CSharpAttribute> can be added to types, properties and enum values. Both positional and named arguments are supported, and the `Attribute` suffix is stripped automatically when emitting code.

```csharp
var obsolete = new CSharpAttribute(new CSharpIdentifier("System", "ObsoleteAttribute"))
{
    Arguments = {"Use NewMethod instead."},
    NamedArguments = {("DiagnosticId", "MYAPP001")}
};

myClass.Attributes.Add(obsolete);
```

The example above emits `[Obsolete("Use NewMethod instead.", DiagnosticId = "MYAPP001")]` and adds `using System;` to the generated file.

Argument values are written as C# literals, so strings, numbers and booleans are supported out of the box.
