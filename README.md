# CSF.Reflection
This library introduces a small number of utility classes to assist in tasks
related to reflection.

## Static reflection
The most interesting of the types included is `Reflect`.  It is used to perform
static reflection, which is a compiler & refactor-safe alternative to getting
members by their string names.  In the following example, the two lines of code
shown will both produce the same results.

```csharp
var myProperty = typeof(MyClass).GetProperty("MyProperty");
var myProperty = Reflect.Property<MyClass>(x => x.MyProperty);
```

## Getting the text of a resource file
A simple extension method to `System.Reflection.Assembly` is
`GetManifestResourceText`.  This gets a manifest resource and reads all string
content from inside, returning it.

## Getting implementors of a type
Another simple/convenience extension method (for `System.Type`) is
`GetImplementors`.  This returns a collection of types which are derived from
the given type.

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