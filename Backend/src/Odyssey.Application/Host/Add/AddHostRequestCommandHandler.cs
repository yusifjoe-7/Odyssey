using MediatR;
using Odyssey.Application.Common.Persistence.Interfaces;
using Odyssey.Application.Common.Storage;
using Odyssey.Domain.Common;
using Odyssey.Domain.Hosts;

namespace Odyssey.Application.Host.Add;

public class AddHostRequestCommandHandler : IRequestHandler<AddHostRequestCommand>
{
    private readonly IAddHostRequestDb _db;
    private readonly IUploadFileStorage _uploadFileStorage;

    public AddHostRequestCommandHandler(IAddHostRequestDb db, IUploadFileStorage uploadFileStorage)
    {
        _db = db;
        _uploadFileStorage = uploadFileStorage;
    }

    public async Task Handle(AddHostRequestCommand request, CancellationToken cancellationToken)
    {
        var addHostRequest = new Odyssey.Domain.Hosts.AddHostRequest
        {
            OwnerUserName = request.OwnerUserName,
            Description = request.Description,
            Situation = AddRequestState.WAITING,
        };

        // Add the images in MinIO (main image first, then the additional host images).
        IEnumerable<Microsoft.AspNetCore.Http.IFormFile> allImages =
            request.HostImages.Prepend(request.MainImageKey);

        var imageKeys = await _uploadFileStorage.UploadManyAsync(allImages, cancellationToken);

        foreach (var imageKey in imageKeys)
            addHostRequest.HostImages.Add(new HostImages { ImageKey = imageKey });

        _db.AddHostRequests.Add(addHostRequest);
        await _db.SaveChangesAsync(cancellationToken);
    }
}
