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

using System.Linq;
using System.Reflection;

namespace ModernDev.InTouch
{
    /// <summary>
    /// A base class for all method parameters classes.
    /// </summary>
    public abstract class MethodParamsGroup
    {
        protected InTouch API;

        /// <summary>
        /// Iterates over all non-nullable class properties and adds them to the <see cref="MethodParamsGroup"/> collection.
        /// </summary>
        /// <returns>A <see cref="MethodParamsGroup"/> instance containing all the non-nullable properties of the current class.</returns>
        private MethodParams GetParams()
        {
            var mp = new MethodParams();

#if WINDOWS_UWP81 || PORTABLE_LIB || NET_STANDARD
            var properties = GetType().GetTypeInfo().DeclaredProperties.Where(propInfo => propInfo.CanRead);
#else
            var properties = GetType().GetProperties(BindingFlags.Public).Where(prop => prop.CanRead);
#endif

            foreach (var prop in properties)
            {
                var mpa = prop.GetCustomAttribute<MethodParamAttribute>(true);

                mp.Add(mpa.Name, prop.GetValue(this), mpa.IsRequired, mpa.Extra);
            }

            return mp;
        }

        public MethodParams GetParams(InTouch api)
        {
            API = api;

            return GetParams();
        }
    }
}