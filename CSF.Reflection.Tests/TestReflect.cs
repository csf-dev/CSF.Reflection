//
// TestReflect.cs
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

using NUnit.Framework;
using System.Reflection;

namespace CSF.Reflection.Tests
{
    [TestFixture]
    public class TestReflect
    {
        #region static reflection tests

        [Test]
        public void TestReferenceTypeField()
        {
            FieldInfo member;
            member = Reflect.Field<StubType>(x => x.ReferenceTypeField);

            Assert.IsNotNull(member, "Member nullability");
            Assert.AreEqual("ReferenceTypeField", member.Name, "Member name");
        }

        [Test]
        public void TestValueTypeField()
        {
            FieldInfo member;
            member = Reflect.Field<StubType>(x => x.ValueTypeField);

            Assert.IsNotNull(member, "Member nullability");
            Assert.AreEqual("ValueTypeField", member.Name, "Member name");
        }

        [Test]
        public void TestReferenceTypeProperty()
        {
            PropertyInfo member;
            member = Reflect.Property<StubType>(x => x.ReferenceTypeProperty);

            Assert.IsNotNull(member, "Member nullability");
            Assert.AreEqual("ReferenceTypeProperty", member.Name, "Member name");
        }

        [Test]
        public void TestValueTypeProperty()
        {
            PropertyInfo member;
            member = Reflect.Property<StubType>(x => x.ValueTypeProperty);

            Assert.IsNotNull(member, "Member nullability");
            Assert.AreEqual("ValueTypeProperty", member.Name, "Member name");
        }

        [Test]
        public void TestReferenceTypeMethod()
        {
            MethodInfo member;
            member = Reflect.Method<StubType>(x => x.ReferenceTypeMethod());

            Assert.IsNotNull(member, "Member nullability");
            Assert.AreEqual("ReferenceTypeMethod", member.Name, "Member name");
        }

        [Test]
        public void TestValueTypeMethod()
        {
            MethodInfo member;
            member = Reflect.Method<StubType>(x => x.ValueTypeMethod());

            Assert.IsNotNull(member, "Member nullability");
            Assert.AreEqual("ValueTypeMethod", member.Name, "Member name");
        }

        [Test]
        public void TestActionMethod()
        {
            MethodInfo member;
            member = Reflect.Method<StubType>(x => x.Action());

            Assert.IsNotNull(member, "Member nullability");
            Assert.AreEqual("Action", member.Name, "Member name");
        }

        [Test]
        public void TestMember()
        {
            MemberInfo member;
            member = Reflect.Member<StubType>(x => x.Action());

            Assert.IsNotNull(member, "Member nullability");
            Assert.AreEqual("Action", member.Name, "Member name");
        }

        #endregion

        #region stubs

        public class StubType
        {
            public string ReferenceTypeField;

            public int ValueTypeField;

            public string ReferenceTypeProperty
            {
                get;
                set;
            }

            public int ValueTypeProperty
            {
                get;
                set;
            }

            public string ReferenceTypeMethod()
            {
                return this.ReferenceTypeProperty;
            }

            public int ValueTypeMethod()
            {
                return this.ValueTypeProperty;
            }

            public void Action()
            {
                // Intentional no-op
            }

            public StubType()
            {
                this.ReferenceTypeProperty = "Foo bar baz";

                // Chosen by fair dice roll, guaranteed to be random!
                this.ValueTypeProperty = 4;
            }
        }

        #endregion
    }
}

