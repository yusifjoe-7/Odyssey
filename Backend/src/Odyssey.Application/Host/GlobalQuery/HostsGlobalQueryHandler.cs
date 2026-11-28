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
        bool IsNotNew = !(request.LastElement is null);
        
        var hosts = await _db.Hosts
            .AsNoTracking()
            .OrderBy(h => h.Id)
            .Where(h => IsNotNew ? h.Id > request.LastElement : true)
            .Take(request.NumberOfPages)
            .ToListAsync(cancellationToken);


        return new HostGlobalQueryResponse
        {
            Hosts = hosts,
            LastElement = hosts.Count > 0 ? hosts[^1].Id : request.LastElement,
        };
    }
}
