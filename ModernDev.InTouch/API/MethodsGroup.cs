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
using System.Threading.Tasks;

namespace ModernDev.InTouch
{
    public class MethodsGroup
    {
        protected readonly InTouch API;
        private readonly string _groupName;

        protected readonly int[] UserIdsRange = {0, 1000000000};
        
        public MethodsGroup(InTouch api, string groupName)
        {
            API = api;
            _groupName = groupName;
        }

        protected async Task<Response<T>> Request<T>(string methodName, MethodParams methodParams = null,
            bool isOpenMethod = false, string path = null)
        {
            if (string.IsNullOrEmpty(methodName))
            {
                throw new ArgumentNullException(nameof(methodName), "The value cannot be null or empty.");
            }

            return await API.Request<T>($"{_groupName}.{methodName}", methodParams?.GetParams(), isOpenMethod, path);
        }

        protected async Task<Response<T>> Request<T>(string methodName, MethodParamsGroup paramsGroup,
            bool isOpenMethod = false, string path = null)
            => await Request<T>(methodName, paramsGroup?.GetParams(API), isOpenMethod, path);
    }
}
