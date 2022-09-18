using System.ComponentModel;

namespace ModelDB.Core.Enum
{
    /// <summary>
    ///     Роль
    /// </summary>
    public enum Role
    {
        /// <summary>
        ///     Админ
        /// </summary>
        [Description("Роль Админ")]
        Admin = 1,
        /// <summary>
        ///     Бухгалтер
        /// </summary>
        [Description("Роль Бухгалтер")]
        Accountant = 2,
        /// <summary>
        ///     Кассир
        /// </summary>
        [Description("Роль Кассир")]
        Cashier = 3

    }
}
