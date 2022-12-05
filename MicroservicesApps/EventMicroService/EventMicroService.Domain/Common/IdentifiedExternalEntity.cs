namespace EventMicroService.Domain.Common;

public class IdentifiedExternalEntity<Key> : IdentifiedEntity<Key>, IExternalEntity<Key>
{
    public Key ExternalId { get; set; } = default!;
}

public class IdentifiedExternalEntity : IdentifiedExternalEntity<long>
{

}
