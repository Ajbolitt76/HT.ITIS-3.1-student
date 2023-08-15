using Dotnet.Homeworks.Domain.Entities;

namespace Dotnet.Homeworks.Domain.Abstractions.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> GetAllOrdersFromUserAsync(Guid userId, CancellationToken cancellationToken);
    Task<Order?> GetOrderByGuidAsync(Guid orderGuid, CancellationToken cancellationToken);
    Task DeleteOrderByGuidAsync(Guid orderGuid, CancellationToken cancellationToken);
    Task UpdateOrderAsync(Order order, CancellationToken cancellationToken);
    Task<Guid> InsertOrderAsync(Order order, CancellationToken cancellationToken);
}