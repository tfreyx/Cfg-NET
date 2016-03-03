﻿#region license
// Cfg.Net
// Copyright 2015 Dale Newman
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System;
using System.Collections.Generic;

namespace Cfg.Net.Contracts {

    [Obsolete]
    public interface IValidators : IDependency, IEnumerable<KeyValuePair<string, IValidator>> {
        void Add(string name, IValidator validator);
        [Obsolete("This goes un-used 99% of the time.")]
        void AddRange(IEnumerable<KeyValuePair<string, IValidator>> validators);
        [Obsolete("This goes un-used 99% of the time.")]
        void Remove(string name);
    }
}