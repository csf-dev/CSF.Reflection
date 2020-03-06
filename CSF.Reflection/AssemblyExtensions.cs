//
// AssemblyExtensions.cs
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
using System.Reflection;
using System.IO;
using System.Resources;


namespace CSF.Reflection
{
    /// <summary>
    /// Extension methods for the Assembly type.
    /// </summary>
    public static class AssemblyExtensions
    {
        /// <summary>
        /// Extension method reads a text-based resource stored within an assembly.
        /// </summary>
        /// <returns>
        /// The manifest resource text.
        /// </returns>
        /// <param name='assembly'>
        /// The assembly
        /// </param>
        /// <param name='resourceName'>
        /// Resource name.
        /// </param>
        public static string GetManifestResourceText(this Assembly assembly, string resourceName)
        {
            if (assembly == null)
                throw new ArgumentNullException(nameof(assembly));

            using (var resourceStream = assembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                    throw new MissingManifestResourceException($@"The requested manifest resource was not found in assembly '{assembly.FullName}'.
Resource name:{resourceName}");

                using (var reader = new StreamReader(resourceStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Extension method reads a text-based resource stored within an assembly.
        /// </summary>
        /// <returns>
        /// The manifest resource text.
        /// </returns>
        /// <param name='assembly'>
        /// The assembly.
        /// </param>
        /// <param name='type'>
        /// A type by which to namespace the resource.
        /// </param>
        /// <param name='resourceName'>
        /// Resource name.
        /// </param>
        public static string GetManifestResourceText(this Assembly assembly, Type type, string resourceName)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var fullResourceName = $"{type.Namespace}.{resourceName}";
            return GetManifestResourceText(assembly, fullResourceName);
        }
    }
}

