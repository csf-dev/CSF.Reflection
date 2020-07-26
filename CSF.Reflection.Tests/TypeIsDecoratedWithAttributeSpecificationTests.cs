//
// TypeIsDecoratedWithAttributeSpecificationTests.cs
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
using CSF.Specifications;
using NUnit.Framework;

namespace CSF.Reflection.Tests
{
    [TestFixture,Parallelizable]
    public class TypeIsDecoratedWithAttributeSpecificationTests
    {
        [Test]
        public void Matches_returns_true_for_a_class_decorated_with_the_attribute()
        {
            var sut = new TypeIsDecoratedWithAttributeSpecification(typeof(DesiredAttributeAttribute));
            Assert.That(() => sut.Matches(typeof(DecoratedWithRightAttribute)), Is.True);
        }

        [Test]
        public void Matches_returns_false_for_a_class_decorated_with_no_attributes()
        {
            var sut = new TypeIsDecoratedWithAttributeSpecification(typeof(DesiredAttributeAttribute));
            Assert.That(() => sut.Matches(typeof(NotDecoratedWithAnyAttribute)), Is.False);
        }

        [Test]
        public void Matches_returns_false_for_a_class_decorated_with_a_different_attribute()
        {
            var sut = new TypeIsDecoratedWithAttributeSpecification(typeof(DesiredAttributeAttribute));
            Assert.That(() => sut.Matches(typeof(DecoratedWithWrongAttribute)), Is.False);
        }

        [DesiredAttribute]
        class DecoratedWithRightAttribute { }

        [UndesiredAttribute]
        class DecoratedWithWrongAttribute { }

        class NotDecoratedWithAnyAttribute { }

        class DesiredAttributeAttribute : Attribute { }

        class UndesiredAttributeAttribute : Attribute { }
    }
}
