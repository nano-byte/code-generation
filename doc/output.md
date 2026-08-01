# Writing output

The <xref:NanoByte.CodeGeneration.CSharpTypeExtensions> class provides two helpers for writing generated code to disk:

- `WriteToFile(path)` writes the generated code to a specific file.
- `WriteToDirectory(path)` writes the code to `{path}/{TypeName}.cs`, which is convenient when generating many types in a loop.

```csharp
foreach (var type in generatedTypes)
    type.WriteToDirectory("Generated");
```

Both helpers use UTF-8 encoding.

## Nullable reference types

Generated files otherwise inherit the consuming project's `<Nullable>` setting, so any nullable reference type annotation you emit means nothing there until it is enabled — and warns with `CS8632` if it is not. Set <xref:NanoByte.CodeGeneration.ICSharpType.NullableContext> to `true` to emit a `#nullable enable` directive at the top of the file.

```csharp
var myClass = new CSharpClass(new CSharpIdentifier("MyApp", "MyModel"))
{
    NullableContext = true,
    Properties = {new CSharpProperty(CSharpIdentifier.String.ToNullable(), "Nickname") {HasSetter = true}}
};
```

Defaults to `false`. Available on every <xref:NanoByte.CodeGeneration.ICSharpType>, so it applies to enums as well as classes and interfaces. It also turns on null-state analysis, so non-nullable properties need either <xref:NanoByte.CodeGeneration.CSharpProperty.IsRequired> or an [initializer](classes.md#property-initializers) to avoid `CS8618`.

## Raw syntax trees

If you need the raw Roslyn syntax tree (for example to merge generated code into an existing compilation), call <xref:NanoByte.CodeGeneration.ICSharpType.ToSyntax> directly to obtain a `CompilationUnitSyntax`.

```csharp
CompilationUnitSyntax unit = myClass.ToSyntax();
string code = unit.ToFullString();
```
