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
using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using static NUnit.Framework.Assert;

namespace ModernDev.InTouch.Tests
{
    [TestFixture]
    public class GeneralClientTest
    {
        private InTouch _inTouch;
        private InTouch _it1;
        private string _jsonRespErr = "{'error':{'error_code':1,'error_msg':'some msg'}}";
        private string _jsonRespErrPlain = "{'error':'error msg'}";
        private string _jsonRespData = "{'response':481516}";
        private string _jsonNestedRespData = "{'response':{'nested':481516}}";
        private readonly Dictionary<string, string> _emptyDict = new Dictionary<string, string>();

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient("");
        }

        [Test]
        public void BasicInitialization()
        {
            Throws<ArgumentException>(() => { _it1 = new InTouch(0, ""); });
            Throws<ArgumentNullException>(() => { _it1 = new InTouch(1, ""); });
            DoesNotThrow(() => { _it1 = new InTouch(12345, "super_secret"); });
        }

        [Test]
        public void SettingSessionData()
        {
            _it1 = new InTouch(12345, "super_secret");

            Throws<ArgumentNullException>(() => _it1.SetSessionData("", 0));
            Throws<ArgumentException>(() => _it1.SetSessionData("access_token", 0));
            Throws<ArgumentException>(() => _it1.SetSessionData("access_token", 1, -1));
            Throws<ArgumentNullException>(() => _it1.SetSessionData(null));
            DoesNotThrow(() => _it1.SetSessionData("access_token", 1));
            IsNotNull(_it1.Session, "_it1.Session != null");

            _it1.SetApplicationSettings(123456, "super_secret2");
            
            IsNull(_it1.Session, "_it1.Session != null");

            _it1.SetSessionData("access_token", 1);
            _it1.SetApplicationSettings(123456, "super_secret2");

            IsNotNull(_it1.Session, "_it1.Session != null");
        }

        [Test]
        public void ParsingJsonResponse()
        {
            Throws<InTouchException>(() => _inTouch.ParseJsonReponse<int>(null));
            Throws<InTouchException>(() => _inTouch.ParseJsonReponse<int>(""));
            Throws<InTouchException>(() => _inTouch.ParseJsonReponse<int>("foo bar"));

            _inTouch.ThrowExceptionOnResponseError = true;

            Throws<InTouchResponseErrorException>(() => _inTouch.ParseJsonReponse<int>(_jsonRespErr));

            try
            {
                _inTouch.ParseJsonReponse<int>(_jsonRespErr);
            }
            catch (InTouchResponseErrorException ex)
            {
                IsNotNull(ex.ResponseError, "ex.ResponseError != null");
                IsTrue(ex.ResponseError.Code == 1, "ex.ResponseError.Code == 1");
                IsTrue(ex.ResponseError.Message == "some msg", "ex.ResponseError.Message == 'some msg'");
            }

            var parsedResp = _inTouch.ParseJsonReponse<int>(_jsonRespData);

            IsNotNull(parsedResp, "parsedResp != null");
            IsTrue(parsedResp.Data == 481516, "parsedResp.Data == 481516");

            Throws<InTouchException>(() => _inTouch.ParseJsonReponse<int>(_jsonNestedRespData, "brokenPath"));
            DoesNotThrow(() =>
            {
                parsedResp = _inTouch.ParseJsonReponse<int>(_jsonNestedRespData, "nested");
            });
            IsNotNull(parsedResp, "parsedResp != null");
            IsTrue(parsedResp.Data == 481516, "parsedResp.Data == 481516");
        }

        [Test]
        public void Post()
        {
            _inTouch.InitApiClient();

            ThrowsAsync<InTouchException>(async () => await _inTouch.Post(null, null));
            ThrowsAsync<InTouchException>(async () => await _inTouch.Post("method/test.json", null));

            var respJson = "";

            DoesNotThrowAsync(async () =>
            {
                respJson = await _inTouch.Post("/method/test", _emptyDict);
            });

            IsNotEmpty(respJson, "respJson");

            ThrowsAsync<InTouchException>(async () => await _inTouch.Post("/method/test2.json", _emptyDict));
        }

        [Test]
        public void ParsingUploadServerJsonResponse()
        {
            Throws<InTouchException>(() => _inTouch.ParseUploadServerResponse<uint>(null));
            Throws<InTouchException>(() => _inTouch.ParseUploadServerResponse<uint>(""));
            Throws<InTouchException>(() => _inTouch.ParseUploadServerResponse<uint>("foo bar"));
            Throws<InTouchResponseErrorException>(() => _inTouch.ParseUploadServerResponse<int>(_jsonRespErrPlain));
            Throws<InTouchException>(() => _inTouch.ParseUploadServerResponse<int>(_jsonRespData, "brokenPath"));

            var parsedResp = _inTouch.ParseUploadServerResponse<int>(_jsonRespData, "response");

            IsTrue(parsedResp == 481516, "parsedResp == 481516");
        }

        [Test]
        public void Request()
        {
            _inTouch.SetApplicationSettings(123456, "super_secret2");

            IsNull(_inTouch.Session, "_inTouch.Session != null");
            ThrowsAsync<NullReferenceException>(async () => await _inTouch.Request<bool>("test"));
            DoesNotThrowAsync(async () => await _inTouch.Request<bool>("test", isOpenMethod: true));

            /* 
             * Next won't work since session duration could be equal to zero
             * _inTouch.Session = new APISession("access_token", 12345, 0);
             * ThrowsAsync<InTouchException>(async () => await _inTouch.Request<bool>("test"));
             * _inTouch.SetApplicationSettings(12345, "super_secret");
             */
        }

        [Test]
        public void ClientEvents()
        {
            var authFailed = false;
            var captchaNeeded = false;

            _inTouch.ThrowExceptionOnResponseError = false;
            _inTouch.AuthorizationFailed += (s, e) => authFailed = true;
            _inTouch.CaptchaNeeded += (s, e) => captchaNeeded = true;

            DoesNotThrowAsync(async () => await _inTouch.Users.Get());
            DoesNotThrowAsync(async () => await _inTouch.Users.Search("Foo"));
            IsTrue(authFailed, "authFailed");
            IsTrue(captchaNeeded, "captchaNeeded");
        }

        [Test]
        public async Task HandlingResponses()
        {
            _inTouch.ThrowExceptionOnResponseError = true;
            _inTouch.IncludeRawResponse = true;

            try
            {
                await _inTouch.Users.Get();
            }
            catch (InTouchResponseErrorException ex)
            {
                IsNotNull(ex.ResponseError, "ex.ResponseError != null");
                IsTrue(ex.ResponseError.Code == 5, "ex.ResponseError.Code == 5");
            }

            _inTouch.ThrowExceptionOnResponseError = false;

            var resp = await _inTouch.Users.Search("Foo");

            IsNotNull(resp, "resp != null");
            IsTrue(resp.IsError, "resp.IsError");
            IsNotNull(resp.Error, "resp.Error != null");
            IsTrue(resp.Error.Code == 14, "resp.Error.Code == 14");
            IsNotEmpty(resp.Raw, "resp.Raw");

            DoesNotThrowAsync(async () => await _inTouch.TrySendRequestAgain<ItemsList<User>>());

            ThrowsAsync<ArgumentNullException>(async () => await _inTouch.SendCaptcha<ItemsList<User>>(null, null));
            ThrowsAsync<ArgumentNullException>(async () => await _inTouch.SendCaptcha<ItemsList<User>>("", null));
            ThrowsAsync<ArgumentNullException>(async () => await _inTouch.SendCaptcha<ItemsList<User>>("captcha_key", null));

            _inTouch.ThrowExceptionOnResponseError = true;

            DoesNotThrowAsync(async () =>
            {
                resp = await _inTouch.SendCaptcha<ItemsList<User>>("captcha_key", resp.Error);
            });
            IsFalse(resp.IsError, "resp.IsError");
            IsNotNull(resp.Data, "resp.Data != null");
            IsNotEmpty(resp.Data.Items, "resp.Data.Items");
        }

        [TearDown]
        public void EachTestTearDown()
        {
            _it1?.Dispose();
        }

        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch.Dispose();
        }
    }
}