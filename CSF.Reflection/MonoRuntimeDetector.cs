//
// MonoDetector.cs
//
// Author:
//       Craig Fowler <craig@csf-dev.com>
//
// Copyright (c) 2019 CSF Software Limited
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
namespace CSF.Reflection
{
  /// <summary>
  /// Implementation of <see cref="IDetectsMono"/> which uses the mechanism documented here:
  /// https://www.mono-project.com/docs/faq/technical/#how-can-i-detect-if-am-running-in-mono
  /// </summary>
  public class MonoRuntimeDetector : IDetectsMono
  {
    const string MONO_TYPE = "Mono.Runtime";

    /// <summary>
    /// Determines whether the application is executing using the Mono framework.  This uses the supported manner of
    /// detecting mono.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the application is executing on the mono framework; otherwise, <c>false</c>.
    /// </returns>
    public bool IsExecutingWithMono()
    {
      return Type.GetType(MONO_TYPE) != null;
    }
  }
}
