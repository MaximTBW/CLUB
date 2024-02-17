using CLUB.CONTEXT.CONTRACTS.Models;
using Microsoft.EntityFrameworkCore;

namespace CLUB.CONTEXT.CONTRACTS.Interface
{
    /// <summary>
    /// Контекст работы с сущностями
    /// </summary>
    public interface IClubContext
    {
        /// <summary>Список <inheritdoc cref="Models.Client"/></summary>
        DbSet<Client> Clients { get; }

        /// <summary>Список <inheritdoc cref="Models.FreeMen"/></summary>
        DbSet<FreeMen> FreeMens { get; }

        /// <summary>Список <inheritdoc cref="Models.Order"/></summary>
        DbSet<Order> Orders { get; }

        /// <summary>Список <inheritdoc cref="Models.Service"/></summary>
        DbSet<Service> Services { get; }

        /// <summary>Список <inheritdoc cref="Models.WherePay"/></summary>
        DbSet<WherePay> WherePays { get; }

        /// <summary>Список <inheritdoc cref="Models.WherePlace"/></summary>
        DbSet<WherePlace> WherePlaces { get; }
    }
}
