namespace CapitalPlacement.Core.Utils
{
    public class EnumParser
    {
        public static T ToEnum<T>(string value) where T : struct
        {
            if (string.IsNullOrWhiteSpace(value))
                return default(T);

            return Enum.TryParse(value, true, out T result) ? result : default(T);
        }
    }
}
