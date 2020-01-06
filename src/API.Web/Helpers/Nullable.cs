using System;
using System.Diagnostics.CodeAnalysis;

namespace API.Web.Helpers
{
    public static class Nullable
    {
        public static T ToObject<T>([AllowNull] T value) {
            if (value == null)
                throw new NullReferenceException();

            return value;
        }

    }
}