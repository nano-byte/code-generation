# Identifiers

Every generated type is referenced by a <xref:NanoByte.CodeGeneration.CSharpIdentifier>, which captures the namespace, name, nullability and generic type arguments of a type. The library tracks identifiers throughout your model so that the correct `using` directives can be emitted automatically.

```csharp
var myModel = new CSharpIdentifier(ns: "MyApp.Models", name: "MyModel");
var nullableModel = myModel.ToNullable();
var modelList = CSharpIdentifier.ListOf(myModel);
var lookup = CSharpIdentifier.DictionaryOf(CSharpIdentifier.String, myModel);
```

## Built-in types

Convenience accessors are provided for common built-in types:

- `CSharpIdentifier.Bool`
- `CSharpIdentifier.Int`
- `CSharpIdentifier.Long`
- `CSharpIdentifier.Float`
- `CSharpIdentifier.Double`
- `CSharpIdentifier.String`
- `CSharpIdentifier.Object`
- `CSharpIdentifier.Uri`

These emit the corresponding C# keywords (or imported types) rather than fully qualified names.

## Generics

Set <xref:NanoByte.CodeGeneration.CSharpIdentifier.TypeArguments> via a collection initializer to construct a generic type reference:

```csharp
var endpoint = new CSharpIdentifier("TypedRest.Endpoints.Generic", "ICollectionEndpoint")
{
    TypeArguments = {new CSharpIdentifier("MyApp.Models", "MyModel")}
};
```

## Deriving identifiers

- `ToNullable()` returns a copy with <xref:NanoByte.CodeGeneration.CSharpIdentifier.Nullable> set to `true`.
- `ToInterface()` returns a copy with an `I` prepended to the name. Useful when generating matching interface types alongside classes.
