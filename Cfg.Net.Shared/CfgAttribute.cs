#region license
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

namespace Cfg.Net {
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class CfgAttribute : Attribute {
        private string _domain;
        private int _maxLength;
        private object _maxValue;
        private int _minLength;
        private object _minValue;
        private object _value;
        private string _regex;

        // ReSharper disable InconsistentNaming

        /// <summary>
        /// The default value.
        /// </summary>
        public object value
        {
            get { return _value; }
            set
            {
                if (value == null) return;
                _value = value;
                ValueIsSet = true;
            }
        }

        /// <summary>
        /// Is this property required?
        /// </summary>
        public bool required { get; set; }

        /// <summary>
        /// Is this property unique?
        /// </summary>
        public bool unique { get; set; }

        /// <summary>
        /// Convert this property's value to upper case.
        /// </summary>
        public bool toUpper { get; set; }

        /// <summary>
        /// Convert this property's value to lower case.
        /// </summary>
        public bool toLower { get; set; }

        /// <summary>
        /// Trim this property's value
        /// </summary>
        public bool trim { get; set; }

        /// <summary>
        /// Trim the start of this property's value
        /// </summary>
        public bool trimStart { get; set; }

        /// <summary>
        /// Trim the end of this property's value
        /// </summary>
        public bool trimEnd { get; set; }

        /// <summary>
        /// Serialize this property.
        /// </summary>
        public bool serialize { get; set; } = true;

        /// <summary>
        /// A list of values representing this property's domain (list of valid values). 
        /// Use <see cref="delimiter"/> to set the delimiter.
        /// </summary>
        public string domain
        {
            get { return _domain; }
            set
            {
                _domain = value;
                DomainSet = true;
            }
        }

        /// <summary>
        /// The delimiter used in <see cref="domain"/>.
        /// </summary>
        public char delimiter { get; set; } = ',';

        /// <summary>
        /// Ignore case for this property.
        /// </summary>
        public bool ignoreCase { get; set; }

        /// <summary>
        /// Minimum length for this property.
        /// </summary>
        public int minLength
        {
            get { return _minLength; }
            set
            {
                _minLength = value;
                MinLengthSet = true;
            }
        }

        /// <summary>
        /// Maximum length for this property.
        /// </summary>
        public int maxLength
        {
            get { return _maxLength; }
            set
            {
                _maxLength = value;
                MaxLengthSet = true;
            }
        }

        /// <summary>
        /// Minimum value for this property.
        /// </summary>
        public object minValue
        {
            get { return _minValue; }
            set
            {
                if (value == null) return;
                _minValue = value;
                MinValueSet = true;
            }
        }

        /// <summary>
        /// Maximum value for this property.
        /// </summary>
        public object maxValue
        {
            get { return _maxValue; }
            set
            {
                if (value == null) return;
                _maxValue = value;
                MaxValueSet = true;
            }
        }

        /// <summary>
        /// Regex validator for this property.
        /// </summary>
        public string regex
        {
            get { return _regex; }
            set
            {
                if (value == null) return;
                _regex = value;
                RegexIsSet = true;
            }
        }

        /// <summary>
        /// Serialization name for this property.
        /// </summary>
        public string name { get; set; }

        public bool MaxLengthSet { get; private set; }
        public bool MinLengthSet { get; private set; }
        public bool MaxValueSet { get; private set; }
        public bool MinValueSet { get; private set; }
        public bool DomainSet { get; private set; }
        public bool ValueIsSet { get; private set; }
        public bool RegexIsSet { get; private set; }

        // ReSharper restore InconsistentNaming
    }
}