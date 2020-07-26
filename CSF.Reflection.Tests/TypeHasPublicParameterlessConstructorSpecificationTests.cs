//
// TypeHasPublicParameterlessConstructorSpecificationTests.cs
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
    public class TypeHasPublicParameterlessConstructorSpecificationTests
    {
        [Test]
        public void Matches_returns_true_for_a_class_with_no_declared_constructor()
        {
            var sut = new TypeHasPublicParameterlessConstructorSpecification();
            Assert.That(() => sut.Matches(typeof(NoConstructor)), Is.True);
        }

        [Test]
        public void Matches_returns_true_for_a_class_with_one_declared_parameterless_constructor()
        {
            var sut = new TypeHasPublicParameterlessConstructorSpecification();
            Assert.That(() => sut.Matches(typeof(ParameterlessConstructor)), Is.True);
        }

        [Test]
        public void Matches_returns_true_for_a_class_with_two_declared_constructors_where_one_is_parameterless()
        {
            var sut = new TypeHasPublicParameterlessConstructorSpecification();
            Assert.That(() => sut.Matches(typeof(ParameterlessAndNonParameterlessConstructor)), Is.True);
        }

        [Test]
        public void Matches_returns_false_for_a_class_with_one_declared_non_parameterless_constructor()
        {
            var sut = new TypeHasPublicParameterlessConstructorSpecification();
            Assert.That(() => sut.Matches(typeof(NoParameterlessConstructor)), Is.False);
        }

        [Test]
        public void Matches_returns_false_for_a_class_with_one_declared_private_parameterless_constructor()
        {
            var sut = new TypeHasPublicParameterlessConstructorSpecification();
            Assert.That(() => sut.Matches(typeof(PrivateConstructor)), Is.False);
        }

        [Test]
        public void Matches_returns_false_for_a_class_with_one_declared_protected_parameterless_constructor()
        {
            var sut = new TypeHasPublicParameterlessConstructorSpecification();
            Assert.That(() => sut.Matches(typeof(ProtectedConstructor)), Is.False);
        }

        [Test]
        public void Matches_returns_false_for_an_abstract_class()
        {
            var sut = new TypeHasPublicParameterlessConstructorSpecification();
            Assert.That(() => sut.Matches(typeof(AbstractClass)), Is.False);
        }

        class NoConstructor { }

        class ParameterlessConstructor
        {
            public ParameterlessConstructor() { }
        }

        class ParameterlessAndNonParameterlessConstructor
        {
            public ParameterlessAndNonParameterlessConstructor() { }
            public ParameterlessAndNonParameterlessConstructor(string aParam) { }
        }

        class NoParameterlessConstructor
        {
            public NoParameterlessConstructor(string aParam) { }
        }

        class PrivateConstructor
        {
            private PrivateConstructor() { }
        }

        class ProtectedConstructor
        {
            protected ProtectedConstructor() { }
        }

        abstract class AbstractClass { }
    }
}
