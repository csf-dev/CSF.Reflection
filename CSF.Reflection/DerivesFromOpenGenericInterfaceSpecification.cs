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
  public class DerivesFromOpenGenericInterfaceSpecification : SpecificationExpression<Type>
  {
    readonly Type baseType;

    /// <summary>
    /// Gets the match expression.
    /// </summary>
    /// <returns>The expression.</returns>
    public override Expression<Func<Type, bool>> GetExpression()
    {
      return x => (from iface in x.GetTypeInfo().ImplementedInterfaces
                   where iface.GetTypeInfo().IsGenericType
                   let genericIface = iface.GetGenericTypeDefinition()
                   where genericIface == baseType
                   select iface)
        .Any();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="T:CSF.Reflection.DerivesFromOpenGenericInterfaceSpecification"/> class.
    /// </summary>
    /// <param name="baseType">Base type.</param>
    public DerivesFromOpenGenericInterfaceSpecification(Type baseType)
    {
      if(baseType == null)
        throw new ArgumentNullException(nameof(baseType));
      if(!baseType.GetTypeInfo().IsGenericTypeDefinition)
        throw new ArgumentException("The base type must be an open generic type.", nameof(baseType));

      this.baseType = baseType;
    }
  }
}
