﻿#region license
// Cfg.Net
// An Alternative .NET Configuration Handler
// Copyright 2015-2017 Dale Newman
//  
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   
//       http://www.apache.org/licenses/LICENSE-2.0
//   
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cfg.Net.Shorthand {
    internal static class Utility {

        internal static readonly string[] ExpressionSplitter = { ")." };
        internal const string Close = ")";
        internal const string Escape = "\\";
        internal const char ParameterSplitter = ',';
        internal const char Open = '(';
        internal static string ControlString = ((char)31).ToString();
        internal const char ControlChar = (char)31;

        internal static string[] Split(string arg, char splitter, int skip = 0) {
            if (arg.Equals(string.Empty))
                return new string[0];

            var split = arg.Replace("\\" + splitter, ControlString).Split(splitter);
            return split.Where(s => s != null).Skip(skip).Select(s => s.Replace(ControlChar, splitter)).ToArray();
        }

        public static string NormalizeName(string name) {
            return string.Concat(name.ToCharArray().Where(char.IsLetterOrDigit).Select(character => char.IsUpper(character) ? char.ToLowerInvariant(character) : character));
        }
    }
}
