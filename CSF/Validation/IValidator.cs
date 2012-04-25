//  
//  IValidator.cs
//  
//  Author:
//       Craig Fowler <craig@craigfowler.me.uk>
// 
//  Copyright (c) 2012 Craig Fowler
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace CSF.Validation
{
  /// <summary>
  /// Interface for a type that can perform object validation.
  /// </summary>
  public interface IValidator<TTarget>
  {
    #region properties
    
    /// <summary>
    /// Gets or sets a collection of the validation tests defined for the current instance.
    /// </summary>
    /// <value>
    /// A collection of the validation rules.
    /// </value>
    /// <exception cref='ArgumentNullException'>
    /// Is thrown when an argument passed to a method is invalid because it is <see langword="null" /> .
    /// </exception>
    IList<IValidationTest<TTarget>> Tests { get; set; }
    
    #endregion
    
    #region test registration
    
    /// <summary>
    /// Adds a new validation test to the current instance.  The test will validate an object in general terms, without
    /// an association to a particular member of the instance.
    /// </summary>
    /// <returns>
    /// The current instance, permitting method-chaining (such as adding many tests together).
    /// </returns>
    /// <param name='test'>
    /// The test to add.
    /// </param>
    IValidator<TTarget> AddTest(ValidationFunction<TTarget> test);
    
    /// <summary>
    /// Adds a new validation test to the current instance.  The test will validate an object in general terms, without
    /// an association to a particular member of the instance.
    /// </summary>
    /// <returns>
    /// The current instance, permitting method-chaining (such as adding many tests together).
    /// </returns>
    /// <param name='test'>
    /// The test to add.
    /// </param>
    /// <param name='testIdentifier'>
    /// An identifier for the test, that allows it to be distinguished from other tests.
    /// </param>
    IValidator<TTarget> AddTest(ValidationFunction<TTarget> test,
                                object testIdentifier);
    
    /// <summary>
    /// Adds a new validation test to the current instance.  The test is associated with a specific member of the
    /// target object being validated and will be performed against the value of that member.
    /// </summary>
    /// <returns>
    /// The current instance, permitting method-chaining (such as adding many tests together).
    /// </returns>
    /// <param name='member'>
    /// The member that this test is to be associated with.
    /// </param>
    /// <param name='test'>
    /// The test to add.
    /// </param>
    /// <typeparam name='TMember'>
    /// The output/return type of the <paramref name="member"/> that this test is associated with.
    /// </typeparam>
    IValidator<TTarget> AddTest<TMember>(Expression<Func<TTarget, TMember>> member,
                                         ValidationFunction<TMember> test);
    
    /// <summary>
    /// Adds a new validation test to the current instance.  The test is associated with a specific member of the
    /// target object being validated and will be performed against the value of that member.
    /// </summary>
    /// <returns>
    /// The current instance, permitting method-chaining (such as adding many tests together).
    /// </returns>
    /// <param name='member'>
    /// The member that this test is to be associated with.
    /// </param>
    /// <param name='test'>
    /// The test to add.
    /// </param>
    /// <typeparam name='TMember'>
    /// The output/return type of the <paramref name="member"/> that this test is associated with.
    /// </typeparam>
    IValidator<TTarget> AddTest<TMember>(MemberInfo member,
                                         ValidationFunction<TMember> test);
    
    /// <summary>
    /// Adds a new validation test to the current instance.  The test is associated with a specific member of the
    /// target object being validated and will be performed against the value of that member.
    /// </summary>
    /// <returns>
    /// The current instance, permitting method-chaining (such as adding many tests together).
    /// </returns>
    /// <param name='member'>
    /// The member that this test is to be associated with.
    /// </param>
    /// <param name='test'>
    /// The test to add.
    /// </param>
    /// <param name='testIdentifier'>
    /// An identifier for the test, that allows it to be distinguished from other tests.
    /// </param>
    /// <typeparam name='TMember'>
    /// The output/return type of the <paramref name="member"/> that this test is associated with.
    /// </typeparam>
    IValidator<TTarget> AddTest<TMember>(Expression<Func<TTarget, TMember>> member,
                                         ValidationFunction<TMember> test,
                                         object testIdentifier);
    
    /// <summary>
    /// Adds a new validation test to the current instance.  The test is associated with a specific member of the
    /// target object being validated and will be performed against the value of that member.
    /// </summary>
    /// <returns>
    /// The current instance, permitting method-chaining (such as adding many tests together).
    /// </returns>
    /// <param name='member'>
    /// The member that this test is to be associated with.
    /// </param>
    /// <param name='test'>
    /// The test to add.
    /// </param>
    /// <param name='testIdentifier'>
    /// An identifier for the test, that allows it to be distinguished from other tests.
    /// </param>
    /// <typeparam name='TMember'>
    /// The output/return type of the <paramref name="member"/> that this test is associated with.
    /// </typeparam>
    IValidator<TTarget> AddTest<TMember>(MemberInfo member,
                                         ValidationFunction<TMember> test,
                                         object testIdentifier);
    
    #endregion
    
    #region validation
    
    /// <summary>
    /// Validates the specified object instance.
    /// </summary>
    /// <returns>
    /// A value that indicates whether validation was successful or not.
    /// </returns>
    /// <param name='target'>
    /// The target object instance to validate.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="target"/> is null.
    /// </exception>
    bool Validate(TTarget target);
    
    /// <summary>
    /// Validates the specified object instance.
    /// </summary>
    /// <returns>
    /// A value that indicates whether validation was successful or not.
    /// </returns>
    /// <param name='target'>
    /// The target object instance to validate.
    /// </param>
    /// <param name='throwOnFailure'>
    /// A value that indicates whether a <see cref="ValidationFailureException"/> should be thrown on unsuccessful
    /// validation.
    /// </param>
    /// <exception cref="ValidationFailureException">
    /// Thrown if <paramref name="throwOnFailure"/> and the validation process fails.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="target"/> is null.
    /// </exception>
    bool Validate(TTarget target, bool throwOnFailure);
    
    /// <summary>
    /// Validates the specified object instance.
    /// </summary>
    /// <returns>
    /// A value that indicates whether validation was successful or not.
    /// </returns>
    /// <param name='target'>
    /// The target object instance to validate.
    /// </param>
    /// <param name='failures'>
    /// Exposes a collection of the validation failures.  If validation is a success this collection will be empty.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="target"/> is null.
    /// </exception>
    bool Validate(TTarget target, out ValidationTestList<TTarget> failures);
    
    #endregion
  }
}
