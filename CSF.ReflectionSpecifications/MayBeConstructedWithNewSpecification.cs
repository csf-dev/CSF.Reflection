//
// TypeHasPublicParameterlessConstructorSpecification.cs
//
// Author:
//       Craig Fowler <craig@csf-dev.com>
//
// Copyright (c) 2020 Craig Fowler
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
using System.Linq.Expressions;
using System.Reflection;
using CSF.Specifications;
#if NETSTANDARD1_0
using System.Linq;
#endif

namespace CSF.Reflection
{
    /// <summary>
    /// Specification for types which may be constructed with the <c>new</c> keyword.
    /// </summary>
    public class MayBeConstructedWithNewSpecification : ISpecificationExpression<Type>
    {
        /// <summary>
        /// Gets the match expression.
        /// </summary>
        /// <returns>The expression.</returns>
        public Expression<Func<Type, bool>> GetExpression()
        {
#if NETSTANDARD1_0
            return x => (!x.GetTypeInfo().DeclaredConstructors.Any()
                      || x.GetTypeInfo().DeclaredConstructors.Any(c => c.IsPublic && !c.GetParameters().Any()))
                     && !x.GetTypeInfo().IsAbstract;
#else
            return x => x.GetTypeInfo().GetConstructor(new Type[0]) != null
                     && !x.GetTypeInfo().IsAbstract;
#endif
        }
    }
}
