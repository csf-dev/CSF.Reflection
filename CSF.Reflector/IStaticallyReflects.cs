//
// IStaticallyReflects.cs
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

namespace CSF.Reflection
{
    /// <summary>
    /// A service which performs static reflection.  It gets <c>MemberInfo</c> instances based upon
    /// an expression lambda indicating a property, field, method or other member.
    /// </summary>
    public interface IStaticallyReflects
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
        MemberInfo Member<TObject>(Expression<Func<TObject, object>> expression);

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
        MemberInfo Member<TObject, TReturn>(Expression<Func<TObject, TReturn>> expression);

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
        MemberInfo Member<TObject>(Expression<Action<TObject>> expression);

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
        PropertyInfo Property<TObject>(Expression<Func<TObject, object>> expression);

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
        PropertyInfo Property<TObject, TReturn>(Expression<Func<TObject, TReturn>> expression);

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
        FieldInfo Field<TObject>(Expression<Func<TObject, object>> expression);

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
        FieldInfo Field<TObject, TReturn>(Expression<Func<TObject, TReturn>> expression);

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
        MethodInfo Method<TObject>(Expression<Func<TObject, object>> expression);

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
        MethodInfo Method<TObject, TReturn>(Expression<Func<TObject, TReturn>> expression);

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
        MethodInfo Method<TObject>(Expression<Action<TObject>> expression);
    }
}
