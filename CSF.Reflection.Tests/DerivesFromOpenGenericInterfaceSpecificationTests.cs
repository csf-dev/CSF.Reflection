//
// DerivesFromOpenGenericInterfaceSpecificationTests.cs
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
using NUnit.Framework;
using CSF.Specifications;

namespace CSF.Reflection.Tests
{
    [TestFixture]
    public class DerivesFromOpenGenericInterfaceSpecificationTests
    {
        [Test]
        public void Matches_returns_true_for_a_derived_class()
        {
            // Arrange
            var sut = new DerivesFromOpenGenericInterfaceSpecification(typeof(IBase<>));

            // Act
            var result = sut.Matches(typeof(Derived));

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void Matches_returns_false_for_a_non_derived_class()
        {
            // Arrange
            var sut = new DerivesFromOpenGenericInterfaceSpecification(typeof(IBase<>));

            // Act
            var result = sut.Matches(typeof(NotDerived));

            // Assert
            Assert.That(result, Is.False);
        }

        internal interface IBase<T> { }
        internal class Derived : IBase<string> { }
        internal class NotDerived { }
    }
}
