#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class AppleTangle
    {
        private static byte[] data = System.Convert.FromBase64String("WMlnjiIFdLBmhdg8ExIQERCykxBrIZMQZyEfFxJEDB4QEO4VFRITEGZmP3BhYX10P3J+fD5wYWF9dHJwIZMVqiGTErKxEhMQExMQEyEcFxh9dDFYf3I/IDchNRcSRBUaAgxQYSw3djGbInvmHJPez/qyPuhCe0p1mgiYz+hafeQWujMhE/kJL+lBGMJDdH14cH9ydDF+fzFleXhiMXJ0Y5MQERcYO5dZl+ZydRQQIZDjITsXaDFwYmJkfHRiMXBycnRhZXB/cnQ7l1mX5hwQEBQUESFzIBohGBcSRHUkMgRaBEgMooXm542P3kGr0ElBP1G35lZcbhlPIQ4XEkQMMhUJIQc3ITUXEkQVGgIMUGFhfXQxUnRjZaAhSf1LFSOdeaKeDM90Yu52T3StFyEeFxJEDAIQEO4VFCESEBDuIQzYCGPkTB/Ebk6K4zQSq0SeXEwc4CEAFxJEFRsCG1BhYX10MVh/cj8gIidLIXMgGiEYFxJEFRcCE0RCIAK6smCDVkJE0L4+UKLp6vJh3PeyXQ6Ayg9WQfoU/E9olTz6J7NGXUT9Y3ByZXhydDFiZXBldHx0f2ViPyGmCqyCUzUDO9YeDKdcjU9y2VqRBlRvDl16QYdQmNVlcxoBklCWIpuQdp4ZpTHm2r09MX5hpy4QIZ2mUt7IJ27QlkTItoioI1PqycRgj2+wQ0i2FBhtBlFHAA9lwqaaMipWssR+Hows4jpYOQvZ79+kqB/ITw3H2iwxfncxZXl0MWV5dH8xcGFhfXhycBcSRAwfFQcVBTrBeFaFZxjv5XqcHBcYO5dZl+YcEBAUFBESkxAQEU0niF08aab8nYrN4maK42fDZiFe0AchBRcSRBUSAhxQYWF9dDFDfn5lPTFydGNleHd4cnBldDFhfn14cmgxUlAhkxAzIRwXGDuXWZfmHBAQEGF9dDFSdGNleHd4cnBleH5/MVBkNfP6wKZhzh5U8Dbb4Hxp/PakBgYxcH91MXJ0Y2V4d3hycGV4fn8xYRUXAhNEQiACIQAXEkQVGwIbUGFhGU8hkxAAFxJEDDEVkxAZIZMQFSEkIyAlISInSwYcIiQhIyEoIyAlIX91MXJ+f3V4ZXh+f2IxfncxZGJ0r+Viiv/DdR7aaF4lybMv6GnuetkZOhcQFBQWExAHD3llZWFiKz4+Zj4hkNIXGToXEBQUFhMTIZCnC5CiFBESkxAeESGTEBsTkxAQEfWAuBh4d3hycGV4fn8xUGRleX5jeGVoIISPax21VppKxQcmItrVHlzfBXjAuc1vMyTbNMTIHsd6xbM1MgDmsL1leX5jeGVoIAchBRcSRBUSAhxQYZEFOsF4VoVnGO/lepw/UbfmVlxuZXh3eHJwZXQxc2gxcH9oMWFwY2UW/WwokppCMcIp1aCui14beu467Z5ikHHXCkoYPoOj6VVZ4XEpjwTkpCu85R4fEYMaoDAHP2XELRzKcwdhfXQxQ35+ZTFSUCEPBhwhJyElI9FyImbmKxY9R/rLHjAfy6tiCF6kc310MWJlcH91cGN1MWV0Y3xiMXBuULmJ6MDbd401egDBsqr1CjvSDg6UkpQKiCxWJuO4ilGfPcWggQPJQbubxMv17cEYFiahZGQw");
        private static int[] order = new int[] { 27,28,36,27,27,56,16,38,34,40,28,20,31,28,26,29,19,40,34,24,29,46,59,25,46,58,52,59,41,30,47,48,48,44,41,59,53,45,53,44,53,43,50,59,45,52,47,59,54,56,54,52,52,55,58,59,57,58,59,59,60 };
        private static int key = 17;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
