using Application.Core.Abstractions.Data;
using Application.Core.Abstractions.Messaging;
using Domain.Orders;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetAllOrders;

internal sealed class GetAllOrdersOfUserQueryHandler : IQueryHandler<GetAllOrdersOfUserQuery, List<Order>>
{
    private readonly IDbContext _dbContext;

    public GetAllOrdersOfUserQueryHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Order>> Handle(GetAllOrdersOfUserQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Order>().Where(o => o.UserId == request.UserId).ToListAsync(cancellationToken);
    }
}
