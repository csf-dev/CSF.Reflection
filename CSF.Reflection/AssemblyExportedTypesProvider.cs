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
using System.Reflection;

namespace CSF.Reflection
{
    /// <summary>
    /// <para>
    /// Implementation of <see cref="IGetsTypes"/> which gets the exported types defined in the assembly
    /// where the current type is declared.
    /// </para>
    /// <para>
    /// This class is intended to be subclassed in your own projects, providing access to the types in the
    /// assembly where the subclass is declared.
    /// </para>
    /// </summary>
    public abstract class AssemblyExportedTypesProvider : IGetsTypes
    {
        readonly IGetsTypes provider;

        /// <summary>
        /// Get a collection of types.
        /// </summary>
        /// <returns>A collection of types.</returns>
        public virtual IReadOnlyCollection<Type> GetTypes() => provider.GetTypes();

        /// <summary>
        /// Initializes a new instance of the <see cref="AssemblyExportedTypesProvider"/> class.
        /// </summary>
        protected AssemblyExportedTypesProvider()
        {
            var assembly = GetType().GetTypeInfo().Assembly;
            provider = new AssemblyExportedTypesAdapter(assembly);
        }
    }
}
