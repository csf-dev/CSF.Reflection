//
// AssemblyTypeProvider.cs
//
// Author:
//       Craig Fowler <craig@csf-dev.com>
//
// Copyright (c) 2019 Craig Fowler
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CSF.Reflection
{
    /// <summary>
    /// Implementation of <see cref="IGetsTypes"/> which gets all of the exported types in an assembly.
    /// This class is intended to be subclassed in your own projects, providing access to the types in that
    /// same assembly as your subclass.
    /// </summary>
    public abstract class AssemblyExportedTypesProvider : IGetsTypes
    {
        /// <summary>
        /// Get a collection of types representing those which are in the same assembly as the current instance.
        /// </summary>
        /// <returns>The types.</returns>
        public virtual IReadOnlyCollection<Type> GetTypes()
        {
            var assembly = GetType().GetTypeInfo().Assembly;
            return assembly.ExportedTypes.ToArray();
        }
    }
}
