namespace ServiceLifetimes
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    public class CustomMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationSingleton _singletondOperation;

        public CustomMiddleware(
            ILogger<CustomMiddleware> logger,
            RequestDelegate next,
            IOperationTransient transientOperation,
            IOperationSingleton singletondOperation)
        {
            this._logger = logger;
            this._next = next;
            this._transientOperation = transientOperation;
            this._singletondOperation = singletondOperation;
        }

        public async Task InvokeAsync(HttpContext httpContext, IOperationTransient transientOperation, IOperationScoped scopedOperation, IOperationSingleton singletondOperation, IOperationTransient t2, IOperationScoped s2, IOperationSingleton si2)
        {
            var log = @"
{0}TRANSIENT{0}SCOPED{0}SINGLETON{0}
DI no construtor:             {1}{0}  Erro{0}     {4}{0}
DI por parâmetro:             {2}{0}  {3}{0}     {5}{0}";

            this._logger.LogInformation(
                string.Format(log,
                    Common.Hyphen(25),
                    this._transientOperation.OperationId,
                    transientOperation.OperationId,
                    scopedOperation.OperationId,
                    this._singletondOperation.OperationId,
                    singletondOperation.OperationId));

            this._logger.LogInformation(t2.OperationId);
            this._logger.LogInformation(s2.OperationId);
            this._logger.LogInformation(si2.OperationId);

            await this._next(httpContext);
        }
    }
}