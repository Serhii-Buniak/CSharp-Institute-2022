﻿namespace IdentityMicroService.BLL.Subscribers;

public class CountrySubscribed : ModelPublished
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
}
