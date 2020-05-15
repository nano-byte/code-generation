# NanoByte Code Generation

[![NuGet](https://img.shields.io/nuget/v/NanoByte.CodeGeneration.svg)](https://www.nuget.org/packages/NanoByte.CodeGeneration/)
[![API documentation](https://img.shields.io/badge/api-docs-orange.svg)](https://code-generation.nano-byte.net/)
[![Build status](https://img.shields.io/appveyor/ci/nano-byte/code-generation.svg)](https://ci.appveyor.com/project/nano-byte/code-generation)  
A thin wrapper around the [Roslyn API](https://docs.microsoft.com/en-us/dotnet/csharp/roslyn-sdk/) to simplify generating C# code.

## Usage

Add a reference to the [NanoByte.CodeGeneration](https://www.nuget.org/packages/NanoByte.CodeGeneration/) NuGet package to your project. It is available for .NET Standard 2.0+.

You can then generate a class like this:

```csharp
var myClass = new CSharpClass(new CSharpIdentifier("MyNamespace", "MyClass"))
{
    Description = "My class",
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

Take a look at the [documentation](https://code-generation.nano-byte.net/) for more features, such as interfaces and attributes.

## Building

The source code is in [`src/`](src/), config for building the API documentation is in [`doc/`](doc/) and generated build artifacts are placed in `artifacts/`. The source code does not contain version numbers. Instead the version is determined during CI using [GitVersion](http://gitversion.readthedocs.io/).

To build [.NET Core SDK 3.1 or newer](https://www.microsoft.com/net/download) and run `.\build.ps1` or `./build.sh`.

## Contributing

We welcome contributions to this project such as bug reports, recommendations and pull requests.

This repository contains an [EditorConfig](http://editorconfig.org/) file. Please make sure to use an editor that supports it to ensure consistent code style, file encoding, etc.. For full tooling support for all style and naming conventions consider using JetBrain's [ReSharper](https://www.jetbrains.com/resharper/) or [Rider](https://www.jetbrains.com/rider/) products.
