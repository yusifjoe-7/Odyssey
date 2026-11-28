using MediatR;
using Microsoft.EntityFrameworkCore;
using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Application.DOTs.Host;

namespace Odyssey.Application.Host.GlobalQuery;

public class HostsGlobalQueryHandler : IRequestHandler<HostsQlobalQuery, HostGlobalQueryResponse>
{
    private readonly IHostDb _db;

    public HostsGlobalQueryHandler(IHostDb db)
    {
        _db = db;
    }

    public async Task<HostGlobalQueryResponse> Handle(HostsQlobalQuery request, CancellationToken cancellationToken)
    {
        var hostsQuery = _db.Hosts
            .AsNoTracking()
            .Include(h => h.HostImages)
            .OrderBy(h => h.Id)
            .AsQueryable();

        // If a LastElement is provided, start from it.
        if (request.LastElement is not null)
        {
            var lastElement = request.LastElement.Value;
            hostsQuery = hostsQuery.Where(h => h.Id.CompareTo(lastElement) > 0);
        }

        var hosts = await hostsQuery.ToListAsync(cancellationToken);

        return new HostGlobalQueryResponse
        {
            Hosts = hosts,
            LastElement = hosts.Count > 0 ? hosts[^1].Id : request.LastElement,
        };
    }
}
