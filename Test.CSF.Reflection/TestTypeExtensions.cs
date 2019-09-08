//
// TestTypeExtensions.cs
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
using NUnit.Framework;
using CSF.Reflection;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Test.CSF.Reflection
{
  [TestFixture]
  public class TestTypeExtensions
  {
    #region tests

    [Test]
    public void GetDefaultValue_gets_correct_value_for_value_type()
    {
      // Arrange
      

      // Act
      var result = typeof(int).GetDefaultValue();

      // Assert
      Assert.AreEqual(0, result);
    }

    [Test]
    public void GetDefaultValue_gets_correct_value_for_reference_type()
    {
      // Arrange


      // Act
      var result = typeof(Foo).GetDefaultValue();

      // Assert
      Assert.AreEqual(null, result);
    }

    #endregion
    
    #region contained classes
    
    class Foo {}
    
    class Bar : Foo, IMarker {}
    
    class Baz : Bar, IMarker<int> {}

    interface IMarker {}

    interface IMarker<T> {}
    
    #endregion
  }
}

