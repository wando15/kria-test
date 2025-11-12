namespace Domain.Utils
{
    public static class Utils
    {
        public static string GetEnumDescription<T>(this T value) where T : Enum
        {
            var type = typeof(T);
            var memInfo = type.GetMember(value.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((System.ComponentModel.DescriptionAttribute)attrs[0]).Description;
                }
            }
            return value.ToString();
        }
    }
}
