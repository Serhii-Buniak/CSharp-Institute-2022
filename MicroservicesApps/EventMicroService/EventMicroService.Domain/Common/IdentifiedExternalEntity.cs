namespace EventMicroService.Domain.Common;

public class IdentifiedExternalEntity<Key, EKey> : IdentifiedEntity<Key>, IExternalEntity<EKey>
{
    public EKey ExternalId { get; set; } = default!;
}

public class IdentifiedExternalEntity : IdentifiedExternalEntity<long, long>
{

}
