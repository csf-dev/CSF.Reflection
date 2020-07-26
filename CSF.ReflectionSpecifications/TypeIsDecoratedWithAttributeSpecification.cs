//
// TypeIsDecoratedWithAttributeSpecification.cs
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
using CSF.Specifications;
using System.Reflection;

namespace CSF.Reflection
{
    /// <summary>
    /// Specification for types which are decorated with a specified attribute.
    /// </summary>
    public class TypeIsDecoratedWithAttributeSpecification : ISpecificationExpression<Type>
    {
        readonly Type attributeType;

        /// <summary>
        /// Gets the match expression.
        /// </summary>
        /// <returns>The expression.</returns>
        public Expression<Func<Type, bool>> GetExpression()
        {
            return x => x.GetCustomAttribute(attributeType) != null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeIsDecoratedWithAttributeSpecification"/> class.
        /// </summary>
        /// <param name="attributeType">The attribute type for which to test.</param>
        public TypeIsDecoratedWithAttributeSpecification(Type attributeType)
        {
            this.attributeType = attributeType ?? throw new ArgumentNullException(nameof(attributeType));
        }
    }
}
