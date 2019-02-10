# CSF.Reflection
This is a very small library designed to assist in using **reflection** in .NET projects.

## Static reflection
Static reflection uses Linq Expressions to get references to members, without
needing to resort to string names.  This keeps your code safe across
refactoring/renaming.  Here's an example:

```csharp
using System.Reflection;
using CSF.Reflection;

PropertyInfo prop = Reflect.Property<MyClass>(x => x.MyProperty);
```

## Getting types from an assembly
The abstract type `CSF.Reflection.AssemblyTypeProvider` is intended to be **subclassed** in
your own projects.  It will return a collection of all of the [exported types] which are in
the same assembly as your subclass is declared.  This collection of types may then be *filtered*
using specifications (below).

[exported types]: https://docs.microsoft.com/en-us/dotnet/api/system.reflection.assembly.getexportedtypes?view=netframework-4.7.2

## Specifications for types
A few specification classes are provided for filtering types (such as those returned by an `AssemblyTypeProvider`).
These are built using [CSF.Specfications] and may be applied to a Linq `.Where()` method.
Here is an example of these two concepts together, to search an assembly for all concrete
implementations of an interface:

```csharp
new MyAssemblyTypeProvider()
    .GetTypes()
    .Where(new IsConcreteSpecification())
    .Where(new DerivesFromSpecification(typeof(IMyInterface)))
```

This logic may then be put into a class of its own, deriving from `CSF.Reflection.IGetsTypes`.  This new
class will then encapsulate the logic required to get all of those concrete implementation types.

[CSF.Specfications]: https://github.com/csf-dev/CSF.Specifications

## Getting the text of a resource file
Provided for convenience, an extension method to `System.Reflection.Assembly`: `GetManifestResourceText`.
This is a shortcut for reading the text/string content of an embedded manifest resource.

## Open source license
All source files within this project are released as open source software,
under the terms of [the MIT license].

[the MIT license]: http://opensource.org/licenses/MIT

This software is distributed in the hope that it will be useful, but please
remember that:

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.