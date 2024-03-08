namespace GrpcGreeterClient
{
    class CustomHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            response.Headers.Remove("grpc-status");

            return response;
        }
    }
}
