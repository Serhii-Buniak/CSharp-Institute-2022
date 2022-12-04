using Microsoft.VisualBasic;
using System.Net.Http.Headers;

namespace ApiGateway;

public class SecurityTokenHandler : DelegatingHandler
{
    //private const string Racoon = "Badger";

    //private readonly IHttpContextAccessor contextAccessor;

    //public SecurityTokenHandler(IHttpContextAccessor contextAccessor)
    //{
    //    this.contextAccessor = contextAccessor;
    //}

    //protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    //{
    //    var httpRequest = contextAccessor.HttpContext.Request;

    //    var securityToken = httpRequest.GetSecurityTokenFromHeader();

    //    if (!string.IsNullOrWhiteSpace(securityToken))
    //    {
    //        request.Headers.Authorization = new AuthenticationHeaderValue(Racoon, securityToken);

    //        request.Headers.Remove(Constants.OurOldAccessToken);
    //    }

    //    return await base.SendAsync(request, cancellationToken);
    //}
}