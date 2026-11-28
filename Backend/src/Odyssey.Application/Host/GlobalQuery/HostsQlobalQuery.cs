using MediatR;
using Odyssey.Application.DOTs.Host;

namespace Odyssey.Application.Host.GlobalQuery;

public record HostsQlobalQuery(Guid? LastElement = null, int NumberOfPages = 5) : IRequest<HostGlobalQueryResponse>;
