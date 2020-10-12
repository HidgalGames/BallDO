#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("db0bXB/gBHtO2UNtHaY6S7tPZ7ZnX35pzJbxWtHig0kWvYPBnD3IiVzubU5cYWplRuok6pthbW1taWxvzeslJsQJqgAho+KGlOwjZf50hieE+b9aiOktJyW+xlke7/vGVp0gGNXhaem2umNOc8VD1MldBm82sR7ZL/ezg70ChtbWzz5VkjTw+ux/4AMDuuTMuAGTPFOAfnUx+qbqZObxZ45xYyJocvIE7cSuDidAC5bYBp92gd4Z7lmW1bOnsv479VT/c6hLnHIOuhuJp9YeqiyQXb1w+9iE6fMKUu5tY2xc7m1mbu5tbWzuAtrykg8Pc+BnehulETpQIfElKtwxJS9P34M5hRRIxSG65JEjyahGhynpPI6U4KoaXrr5CMewK25vbWxt");
        private static int[] order = new int[] { 2,9,2,10,8,5,7,10,10,11,13,11,13,13,14 };
        private static int key = 108;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
