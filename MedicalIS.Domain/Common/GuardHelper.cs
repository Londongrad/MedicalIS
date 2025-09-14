using MedicalIS.Domain.Enums;

namespace MedicalIS.Domain.Common
{
    public static class GuardHelper
    {
        public static void AgainstNullOrEmpty(string value, string argumentName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{argumentName} cannot be null or empty", argumentName);
        }

        public static void AgainstInvalidDate(DateTime value, string argumentName, bool allowFuture = false)
        {
            if (value == default)
                throw new ArgumentException($"{argumentName} cannot be default", argumentName);

            if (!allowFuture && value > DateTime.UtcNow)
                throw new ArgumentException($"{argumentName} cannot be in the future", argumentName);

            // Дополнительно можно ограничить "нереально древние" даты
            if (value < new DateTime(1900, 1, 1))
                throw new ArgumentException($"{argumentName} is too far in the past", argumentName);
        }

        public static void AgainstEmptyGuid(Guid id, string argumentName)
        {
            if (id == Guid.Empty)
                throw new ArgumentException($"{argumentName} cannot be empty Guid", argumentName);
        }

        public static void AgainstInvalidEnum<TEnum>(TEnum value, string argumentName) where TEnum : struct, Enum
        {
            if (!Enum.IsDefined(value))
                throw new ArgumentException($"{argumentName} has invalid value: {value}", argumentName);
        }
    }
}
