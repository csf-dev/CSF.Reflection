This repository provides **three NuGet packages**, related to using reflection in .NET Framework or Dotnet Core applications. Those packages are:

* **[CSF.Reflector]**

    A utility service which performs [static reflection] for properties, fields & methods.
* **[CSF.ReflectionSpecifications]**

    Some [specification classes] for filtering types, particularly useful when assembly-scanning.
* **[CSF.Reflection]**

    An assortment of other very small utility types and functions related to reflection. Each too small to be worth a package of its own.

## Documentation
Documentation for these packages may be found on [the wiki for this repository].

## A note about version 3.x
In version 2.x and lower of this code, all of the functionality above was part of a single NuGet package named `CSF.Reflection`. Version 3+ has split the functionality up to avoid package and dependency bloat.

[CSF.Reflector]: https://www.nuget.org/packages/CSF.Reflector/
[CSF.Reflection]: https://www.nuget.org/packages/CSF.Reflection/
[CSF.ReflectionSpecifications]: https://www.nuget.org/packages/CSF.ReflectionSpecifications/
[static reflection]: https://github.com/csf-dev/CSF.Reflection/wiki/StaticReflection
[specification classes]: https://github.com/csf-dev/CSF.Specifications
[the wiki for this repository]: https://github.com/csf-dev/CSF.Reflection/wiki
