//
// DerivesFromOpenGenericSpecification.cs
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
using System.Linq.Expressions;
using System.Reflection;
using CSF.Specifications;

namespace CSF.Reflection
{
    /// <summary>
    /// Specification for a <c>System.Type</c> which matches types which derive from a generic form of an
    /// open-generic interface.
    /// </summary>
    public class DerivesFromOpenGenericSpecification : ISpecificationExpression<Type>
    {
        readonly Type type;

        /// <summary>
        /// Gets the match expression.
        /// </summary>
        /// <returns>The expression.</returns>
        public Expression<Func<Type, bool>> GetExpression()
        {
            return type.GetTypeInfo().IsInterface ? GetInterfaceExpression() : GetClassExpression();
        }

        Expression<Func<Type, bool>> GetInterfaceExpression()
        {
            return x => (from iface in x.GetTypeInfo().ImplementedInterfaces
                         where iface.GetTypeInfo().IsGenericType
                         let genericIface = iface.GetGenericTypeDefinition()
                         where genericIface == type
                         select iface)
              .Any();
        }

        Expression<Func<Type, bool>> GetClassExpression()
        {
            return x => (from baseType in GetAllBaseTypes(x)
                         where baseType.GetTypeInfo().IsGenericType
                         let genericBaseType = baseType.GetGenericTypeDefinition()
                         where genericBaseType == type
                         select baseType)
              .Any();
        }

        IEnumerable<Type> GetAllBaseTypes(Type t)
        {
            var currentType = t.GetTypeInfo().BaseType;
            while(currentType != null)
            {
                yield return currentType;
                if (currentType == typeof(object)) yield break;
                currentType = t.GetTypeInfo().BaseType;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DerivesFromOpenGenericSpecification"/> class.
        /// </summary>
        /// <param name="type">An open generic type.</param>
        public DerivesFromOpenGenericSpecification(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (!type.GetTypeInfo().IsGenericTypeDefinition)
                throw new ArgumentException("The base type must be an open generic type.", nameof(type));

            this.type = type;
        }
    }
}
