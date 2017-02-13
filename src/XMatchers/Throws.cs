using System;
using XMatchers.Core;

namespace XMatchers
{
    public static class Throws
    {
        public static IMatcher<Action> An<T>() where T : Exception
        {
            return new ThrowsMatcher<T>();
        }
    }
}