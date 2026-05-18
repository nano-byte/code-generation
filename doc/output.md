# Writing output

The <xref:NanoByte.CodeGeneration.CSharpTypeExtensions> class provides two helpers for writing generated code to disk:

- `WriteToFile(path)` writes the generated code to a specific file.
- `WriteToDirectory(path)` writes the code to `{path}/{TypeName}.cs`, which is convenient when generating many types in a loop.

```csharp
foreach (var type in generatedTypes)
    type.WriteToDirectory("Generated");
```

Both helpers use UTF-8 encoding.

## Raw syntax trees

If you need the raw Roslyn syntax tree (for example to merge generated code into an existing compilation), call <xref:NanoByte.CodeGeneration.ICSharpType.ToSyntax> directly to obtain a `CompilationUnitSyntax`.

```csharp
CompilationUnitSyntax unit = myClass.ToSyntax();
string code = unit.ToFullString();
```
