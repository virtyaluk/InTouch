using System.Resources;
using RichardSzalay.MockHttp;

namespace ModernDev.InTouch.Tests
{
    public static class Ex
    {
        public static MockHttpMessageHandler WhenAndRespond(this MockHttpMessageHandler @this, string url, string json)
        {
            @this.When($"/method/{url}.json").Respond("application/json", json);

            return @this;
        }

        public static ResourceManager Responses { get; } = MockJsonResponses.ResourceManager;

        public static InTouch GetMockedClient(string cat = null, bool setSessionData = true)
        {
            var mochHttp = new MockHttpMessageHandler();

            switch (cat)
            {
                case "users":
                {
                    mochHttp
                        .WhenAndRespond($"{cat}.get", Responses.GetString("usersList"))
                        .WhenAndRespond($"{cat}.search", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.isAppUser", Responses.GetString("responseTrue"))
                        .WhenAndRespond($"{cat}.getSubscriptions", Responses.GetString("profilesMixedList"))
                        .WhenAndRespond($"{cat}.getFollowers", Responses.GetString("usersItemsList"))
                        .WhenAndRespond($"{cat}.report", Responses.GetString("responseFalse"))
                        .WhenAndRespond($"{cat}.getNearby", Responses.GetString("usersItemsList"));
                    }
                    break;
            }

            var client = new InTouch(mochHttp, 12345, "super_secret");

            if (setSessionData)
            {
                client.SetSessionData("super_secret_access_token", 1);
            }

            return client;
        }
    }
}