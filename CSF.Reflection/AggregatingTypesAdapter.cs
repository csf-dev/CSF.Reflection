//
// AggregatingTypesAdapter.cs
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
using System.Collections.Generic;
using System.Linq;

namespace CSF.Reflection
{
    /// <summary>
    /// A service which gets and returns types from many other implementations of <see cref="IGetsTypes"/>,
    /// specified as constructor parameters to the current instance.
    /// </summary>
    public class AggregatingTypesAdapter : IGetsTypes
    {
        readonly IEnumerable<IGetsTypes> providers;

        /// <summary>
        /// Get a collection of types.
        /// </summary>
        /// <returns>The types.</returns>
        public IReadOnlyCollection<Type> GetTypes() => providers.SelectMany(x => x.GetTypes()).ToArray();

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregatingTypesAdapter"/> class.
        /// </summary>
        /// <param name="providers">The providers from which to aggregate the results.</param>
        public AggregatingTypesAdapter(params IGetsTypes[] providers) : this((IEnumerable<IGetsTypes>) providers) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AggregatingTypesAdapter"/> class.
        /// </summary>
        /// <param name="providers">The providers from which to aggregate the results.</param>
        public AggregatingTypesAdapter(IEnumerable<IGetsTypes> providers)
        {
            this.providers = providers ?? throw new ArgumentNullException(nameof(providers));
        }
    }
}
