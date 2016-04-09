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

using NUnit.Framework;

namespace ModernDev.InTouch.Tests
{
    [TestFixture]
    public class GeneralClientTest
    {
        private InTouch _inTouch;

        [OneTimeSetUp]
        public void TestSetup()
        {
            _inTouch = Ex.GetMockedClient();
        }



        [OneTimeTearDown]
        public void TestTearDown()
        {
            _inTouch.Dispose();
        }
    }
}