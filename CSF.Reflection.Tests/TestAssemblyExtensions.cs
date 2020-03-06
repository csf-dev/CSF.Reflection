//
// TestAssemblyExtensions.cs
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

using System.Reflection;
using NUnit.Framework;
using System.Resources;

namespace CSF.Reflection.Tests
{
    [TestFixture]
    public class TestAssemblyExtensions
    {
        [Test]
        public void TestGetManifestResourceText()
        {
            string resourceText = Assembly.GetExecutingAssembly().GetManifestResourceText("TestResource.txt");
            Assert.AreEqual("This is a test resource file", resourceText, "Correct resource text");
        }

        [Test]
        public void TestGetManifestResourceTextInvalid()
        {

            Assert.That(() => Assembly.GetExecutingAssembly().GetManifestResourceText("Nonexistent.txt"),
                        Throws.InstanceOf<MissingManifestResourceException>());
        }

        [Test]
        public void TestGetManifestResourceTextType()
        {
            string resourceText = Assembly.GetExecutingAssembly().GetManifestResourceText(typeof(TestAssemblyExtensions),
                                                                                          "TestResourceType.txt");
            Assert.AreEqual("This is a test resource file, stored by namespace", resourceText, "Correct resource text");
        }

        [Test]
        public void TestGetManifestResourceTextTypeInvalid()
        {
            Assert.That(() => Assembly.GetExecutingAssembly().GetManifestResourceText(typeof(TestAssemblyExtensions), "Nonexistent.txt"),
                        Throws.InstanceOf<MissingManifestResourceException>());
        }
    }
}

