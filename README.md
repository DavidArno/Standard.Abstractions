## Standard.Abstractions

Interface-based abstractions over all static features of .NET Standard 2.0, that have side effects.

The aim of this project is to provide an abstraction layer over all of the netstandard 2.0 APIs, that:

1. Have side effects (eg reading or writing to the file system)
2. Are either static methods (eg the methods in the `Directory` class), or are in classes that do not implement an interface, or extend a non-side effect abstract bass class (eg, `DirectoryInfo`).

This will then allow code that uses netstandard 2.0 to be unit tested, rather than needing brittle integration tests.