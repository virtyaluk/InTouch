/**
 * This file\code is part of InTouch project.
 *
 * InTouch - is a .NET wrapper for the vk.com API.
 * https://github.com/virtyaluk/InTouch
 *
 * Copyright (c) 2016 Bohdan Shtepan
 * http://modern-dev.com/
 *
 * Licensed under the GPLv3 license.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ModernDev.InTouch.Helpers;

namespace ModernDev.InTouch
{
    /// <summary>
    /// Represents a list of query params.
    /// </summary>
    public class MethodParams : IEnumerable
    {
        private readonly Dictionary<string, string> _internalList;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodParams"/> class that is empty and has the default initial capacity.
        /// </summary>
        public MethodParams()
        {
            _internalList = new Dictionary<string, string>();
        }

        /// <summary>
        /// Adds a query parameter to the end of the <see cref="MethodParams"/>.
        /// </summary>
        /// <param name="name">The name of the param.</param>
        /// <param name="valObj">The value of the param.</param>
        /// <param name="required">Whether the para is required.</param>
        /// <param name="extra">Extra options</param>
        public void Add(string name, object valObj, bool required = false, object extra = null)
        {
            if (valObj != null)
            {
                if (valObj is int || valObj is double)
                {
                    AddNumber(name, Convert.ToDouble(valObj), required, extra as int[]);
                } else if (valObj is string)
                {
                    AddString(name, (string)valObj, required);
                } else if (valObj is bool)
                {
                    AddBool(name, (bool) valObj);
                } else if (valObj is IList)
                {
                    AddList(name, (IList) valObj, required, extra as int?);
                }
                else
                {
                    AddOther(name, valObj, required, extra as bool? ?? false);
                }
            }
        }

        private void AddNumber(string name, double? value, bool required, IReadOnlyList<int> valueRange = null)
        {
            if (required && !value.HasValue)
            {
                throw new InTouchException($"Required parameter `{name}` cannot be null.");
            }

            if (value.HasValue && valueRange != null && (value < valueRange[0] || value > valueRange[1]))
            {
                throw new InTouchException($"The parameter `{name}` was out of range. The value must be in the range {valueRange[0]}...{valueRange[1]}.");
            }

            if (value.HasValue)
            {
                _internalList.Add(name, value.ToString());
            }
        }

        private void AddList(string name, ICollection list, bool required, int? maxAllowed = null)
        {
            var l = list.Cast<object>().ToList();

            if (required && (list == null || !l.Any()))
            {
                throw new InTouchException($"Required parameter `{name}` cannot be null or empty.");
            }

            if (list != null && l.Any())
            {
                if (list.GetType().GenericTypeArguments.FirstOrDefault().GetTypeInfo().IsEnum)//list.GetType().GetGenericArguments().FirstOrDefault().GetTypeInfo().IsEnum)
                {
                    _internalList.Add(name, string.Join(",", l.Select(Utils.ToEnumString)));
                }
                else
                {
                    _internalList.Add(name, string.Join(",", l.Where(item => item != null)
                        .Take(maxAllowed ?? list.Count)
                        .Select(item => item.ToString())));
                }
            }
        }

        private void AddBool(string name, bool value)
        {
            _internalList.Add(name, value ? "1" : "0");
        }

        private void AddString(string name, string value, bool isRequired)
        {
            if (isRequired && string.IsNullOrEmpty(value))
            {
                throw new InTouchException($"Required parameter `{name}` cannot be null or empty.");
            }

            _internalList.Add(name, value);
        }

        private void AddOther(string name, object value, bool required, bool flag)
        {
            if (required && value == null)
            {
                throw new InTouchException($"Required parameter `{name}` cannot be null.");
            }
            
            if (value != null)
            {
                if (value is DateTime)
                {
                    _internalList.Add(name, ((DateTime) value).ToUnixTimeStamp().ToString());
                }
                else if (value.GetType().GetTypeInfo().IsEnum)
                {
                    _internalList.Add(name, flag ? ((int) value).ToString() : Utils.ToEnumString(value));
                }
                else
                {
                    _internalList.Add(name, value.ToString());
                }
            } 
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator() => _internalList.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) _internalList).GetEnumerator();

        public Dictionary<string, string> GetParams() => _internalList;
    }
}