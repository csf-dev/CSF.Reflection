//
// Reflect.cs
//
// Author:
//       Craig Fowler <craig@csf-dev.com>
//
// Copyright (c) 2015 CSF Software Limited
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

namespace CSF.Reflection
{
    /// <summary>
    /// A service implementation which uses expression analysis to perform static reflection.
    /// </summary>
    public class Reflector : IStaticallyReflects
    {
        /// <summary>
        /// Gets a <see cref="MemberInfo"/> from an expression that indicates a member of a specified type.
        /// </summary>
        /// <returns>
        /// The member information.
        /// </returns>
        /// <param name='expression'>
        /// The lambda expression that indicates a type, such as <c>x => x.MyProperty</c>.
        /// </param>
        /// <typeparam name='TObject'>
        /// The type that contains the member which we are interested in.
        /// </typeparam>
        /// <exception cref='ArgumentNullException'>
        /// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
        /// </exception>
        /// <exception cref='ArgumentException'>
        /// Is thrown when an argument passed to a method is invalid.
        /// </exception>
        public MemberInfo Member<TObject>(Expression<Func<TObject, object>> expression)
        {
            return Member(expression.Body);
        }

        /// <summary>
        /// Gets a <see cref="MemberInfo"/> from an expression that indicates a member of a specified type.
        /// </summary>
        /// <returns>
        /// The member information.
        /// </returns>
        /// <param name='expression'>
        /// The lambda expression that indicates a type, such as <c>x => x.MyProperty</c>.
        /// </param>
        /// <typeparam name='TObject'>
        /// The type that contains the member which we are interested in.
        /// </typeparam>
        /// <typeparam name='TReturn'>
        /// The return/output type of the member.
        /// </typeparam>
        /// <exception cref='ArgumentNullException'>
        /// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
        /// </exception>
        /// <exception cref='ArgumentException'>
        /// Is thrown when an argument passed to a method is invalid.
        /// </exception>
        public MemberInfo Member<TObject, TReturn>(Expression<Func<TObject, TReturn>> expression)
        {
            return Member(expression.Body);
        }

        /// <summary>
        /// Gets a <see cref="MemberInfo"/> from an expression that indicates a member of a specified type.
        /// </summary>
        /// <returns>
        /// The member information.
        /// </returns>
        /// <param name='expression'>
        /// The lambda expression that indicates a type, such as <c>x => x.MyProperty</c>.
        /// </param>
        /// <typeparam name='TObject'>
        /// The type that contains the member which we are interested in.
        /// </typeparam>
        /// <exception cref='ArgumentNullException'>
        /// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
        /// </exception>
        /// <exception cref='ArgumentException'>
        /// Is thrown when an argument passed to a method is invalid.
        /// </exception>
        public MemberInfo Member<TObject>(Expression<Action<TObject>> expression)
        {
            return Member(expression.Body);
        }

        /// <summary>
        /// Gets a <see cref="PropertyInfo"/> from an expression that indicates a member of a specified type.
        /// </summary>
        /// <returns>
        /// The property information.
        /// </returns>
        /// <param name='expression'>
        /// The lambda expression that indicates a type, such as <c>x => x.MyProperty</c>.
        /// </param>
        /// <typeparam name='TObject'>
        /// The type that contains the member which we are interested in.
        /// </typeparam>
        /// <exception cref='ArgumentNullException'>
        /// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
        /// </exception>
        /// <exception cref='ArgumentException'>
        /// Is thrown when an argument passed to a method is invalid.
        /// </exception>
        public PropertyInfo Property<TObject>(Expression<Func<TObject, object>> expression)
        {
            return Member(expression) as PropertyInfo;
        }

        /// <summary>
        /// Gets a <see cref="PropertyInfo"/> from an expression that indicates a member of a specified type.
        /// </summary>
        /// <returns>
        /// The property information.
        /// </returns>
        /// <param name='expression'>
        /// The lambda expression that indicates a type, such as <c>x => x.MyProperty</c>.
        /// </param>
        /// <typeparam name='TObject'>
        /// The type that contains the member which we are interested in.
        /// </typeparam>
        /// <typeparam name='TReturn'>
        /// The return type of the property which we are reflecting.
        /// </typeparam>
        /// <exception cref='ArgumentNullException'>
        /// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
        /// </exception>
        /// <exception cref='ArgumentException'>
        /// Is thrown when an argument passed to a method is invalid.
        /// </exception>
        public PropertyInfo Property<TObject, TReturn>(Expression<Func<TObject, TReturn>> expression)
        {
            return Member(expression) as PropertyInfo;
        }

        /// <summary>
        /// Gets a <see cref="FieldInfo"/> from an expression that indicates a member of a specified type.
        /// </summary>
        /// <returns>
        /// The field information.
        /// </returns>
        /// <param name='expression'>
        /// The lambda expression that indicates a type, such as <c>x => x.MyProperty</c>.
        /// </param>
        /// <typeparam name='TObject'>
        /// The type that contains the member which we are interested in.
        /// </typeparam>
        /// <exception cref='ArgumentNullException'>
        /// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
        /// </exception>
        /// <exception cref='ArgumentException'>
        /// Is thrown when an argument passed to a method is invalid.
        /// </exception>
        public FieldInfo Field<TObject>(Expression<Func<TObject, object>> expression)
        {
            return Member(expression) as FieldInfo;
        }

        /// <summary>
        /// Gets a <see cref="FieldInfo"/> from an expression that indicates a member of a specified type.
        /// </summary>
        /// <returns>
        /// The field information.
        /// </returns>
        /// <param name='expression'>
        /// The lambda expression that indicates a type, such as <c>x => x.MyProperty</c>.
        /// </param>
        /// <typeparam name='TObject'>
        /// The type that contains the member which we are interested in.
        /// </typeparam>
        /// <typeparam name='TReturn'>
        /// The return type of the field which we are reflecting.
        /// </typeparam>
        /// <exception cref='ArgumentNullException'>
        /// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
        /// </exception>
        /// <exception cref='ArgumentException'>
        /// Is thrown when an argument passed to a method is invalid.
        /// </exception>
        public FieldInfo Field<TObject, TReturn>(Expression<Func<TObject, TReturn>> expression)
        {
            return Member(expression) as FieldInfo;
        }

        /// <summary>
        /// Gets a <see cref="MethodInfo"/> from an expression that indicates a member of a specified type.
        /// </summary>
        /// <returns>
        /// The method information.
        /// </returns>
        /// <param name='expression'>
        /// The lambda expression that indicates a type, such as <c>x => x.MyProperty</c>.
        /// </param>
        /// <typeparam name='TObject'>
        /// The type that contains the member which we are interested in.
        /// </typeparam>
        /// <exception cref='ArgumentNullException'>
        /// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
        /// </exception>
        /// <exception cref='ArgumentException'>
        /// Is thrown when an argument passed to a method is invalid.
        /// </exception>
        public MethodInfo Method<TObject>(Expression<Func<TObject, object>> expression)
        {
            return Member(expression) as MethodInfo;
        }

        /// <summary>
        /// Gets a <see cref="MethodInfo"/> from an expression that indicates a member of a specified type.
        /// </summary>
        /// <returns>
        /// The method information.
        /// </returns>
        /// <param name='expression'>
        /// The lambda expression that indicates a type, such as <c>x => x.MyProperty</c>.
        /// </param>
        /// <typeparam name='TObject'>
        /// The type that contains the member which we are interested in.
        /// </typeparam>
        /// <typeparam name='TReturn'>
        /// The return type of the method which we are reflecting.
        /// </typeparam>
        /// <exception cref='ArgumentNullException'>
        /// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
        /// </exception>
        /// <exception cref='ArgumentException'>
        /// Is thrown when an argument passed to a method is invalid.
        /// </exception>
        public MethodInfo Method<TObject, TReturn>(Expression<Func<TObject, TReturn>> expression)
        {
            return Member(expression) as MethodInfo;
        }

        /// <summary>
        /// Gets a <see cref="MethodInfo"/> from an expression that indicates a member of a specified type.
        /// </summary>
        /// <returns>
        /// The method information.
        /// </returns>
        /// <param name='expression'>
        /// The lambda expression that indicates a type, such as <c>x => x.MyProperty</c>.
        /// </param>
        /// <typeparam name='TObject'>
        /// The type that contains the member which we are interested in.
        /// </typeparam>
        /// <exception cref='ArgumentNullException'>
        /// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
        /// </exception>
        /// <exception cref='ArgumentException'>
        /// Is thrown when an argument passed to a method is invalid.
        /// </exception>
        public MethodInfo Method<TObject>(Expression<Action<TObject>> expression)
        {
            return Member(expression) as MethodInfo;
        }

        /// <summary>
        /// Gets a <see cref="System.Reflection.MemberInfo"/> from the given linq expression.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This private method wraps the differing mechanisms by which static reflection can be performed:
        /// </para>
        /// <list type="number">
        /// <item>
        /// Determine whether or not the expression is a unary (value type) expression or not.  If it is then use the
        /// operand for further analysis.
        /// </item>
        /// <item>
        /// Determine whether the expression-to-analyse is a member expression or a method call expression.
        /// </item>
        /// <item>
        /// Cast the expression appropriately and retirve the member.
        /// </item>
        /// </list>
        /// </remarks>
        /// <param name='expression'>
        /// The expression to parse for a member.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Raised if the <paramref name="expression"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Raised if the <paramref name="expression"/> does not reflect a single member.
        /// </exception>
        static MemberInfo Member(Expression expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            if (expression is UnaryExpression unaryExpression)
                return Member(unaryExpression.Operand);

            if (expression is MemberExpression memberExpression)
                return memberExpression.Member;

            if (expression is MethodCallExpression methodCallExpression)
                return methodCallExpression.Method;

            throw new ArgumentException($@"The expression must indicate a member.
Expression:{expression}", nameof(expression));
        }
    }
}

