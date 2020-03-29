A thin wrapper around the [Roslyn API](https://docs.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/) to simplify generating C# code.

## Usage

Add a reference to the [NanoByte.CodeGeneration](https://www.nuget.org/packages/NanoByte.CodeGeneration/) NuGet package to your project. It is available for .NET Standard 2.0+.

You can then generate a class like this:

```csharp
var myClass = new CSharpClass(new CSharpIdentifier("MyNamespace", "MyClass"))
{
    Description = "My class\nDetails",
    Properties =
    {
        new CSharpProperty(CSharpIdentifier.String, "MyProperty")
        {
            Description = "My property",
            HasSetter = true
        }
    }
};
myClass.WriteToFile("MyClass.cs");
```

## Building and contributing

See the [GitHub project](https://github.com/nano-byte/code-generation) for more information.
