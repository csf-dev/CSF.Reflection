﻿//
// DerivesFromSpecification.cs
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
using System.Linq.Expressions;
using System.Reflection;
using CSF.Specifications;

namespace CSF.Reflection
{
    /// <summary>
    /// Specification for a <c>System.Type</c> which matches types which derive from a given type.
    /// </summary>
    public class DerivesFromSpecification : SpecificationExpression<Type>
    {
        readonly Type baseType;

        /// <summary>
        /// Gets the match expression.
        /// </summary>
        /// <returns>The expression.</returns>
        public override Expression<Func<Type, bool>> GetExpression()
        {
            return x => baseType.GetTypeInfo().IsAssignableFrom(x.GetTypeInfo());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CSF.Reflection.DerivesFromSpecification"/> class.
        /// </summary>
        /// <param name="baseType">Base type.</param>
        public DerivesFromSpecification(Type baseType)
        {
            if (baseType == null)
                throw new ArgumentNullException(nameof(baseType));
            this.baseType = baseType;
        }
    }
}
