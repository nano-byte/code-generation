# Enums

Use <xref:NanoByte.CodeGeneration.CSharpEnum> with one <xref:NanoByte.CodeGeneration.CSharpEnumValue> per member.

```csharp
var myEnum = new CSharpEnum(new CSharpIdentifier("MyApp", "Status"))
{
    Summary = "Possible states.",
    Values =
    {
        new CSharpEnumValue("Off") {Summary = "Disabled."},
        new CSharpEnumValue("On")  {Summary = "Enabled."}
    }
};
```

## Explicit underlying values

Set <xref:NanoByte.CodeGeneration.CSharpEnumValue.Value> to assign an explicit underlying integer. If left `null`, the C# compiler assigns one automatically.

```csharp
new CSharpEnum(new CSharpIdentifier("MyApp", "Status"))
{
    Values =
    {
        new CSharpEnumValue("Off") {Value = 0},
        new CSharpEnumValue("On")  {Value = 5}
    }
};
```

Enum values also accept [attributes](attributes.md) and XML doc summaries.
