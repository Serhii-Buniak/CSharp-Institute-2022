namespace EventMicroService.Domain.Common;

public class ExternalEntity<EKey> : BaseEntity, IExternalEntity<EKey>
{
    public EKey ExternalId { get; set; } = default!;
}

public class ExternalEntity : ExternalEntity<long>
{

}
