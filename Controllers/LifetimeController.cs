namespace ServiceLifetimes.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    public class LifetimeController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ILifetime _lifetime1;
        private readonly ILifetime _lifetime2;

        public LifetimeController(
            ILogger<LifetimeController> logger,
            ILifetime lifetime1,
            ILifetime lifetime2)
        {
            this._logger = logger;
            this._lifetime1 = lifetime1;
            this._lifetime2 = lifetime2;
        }

        [HttpGet]
        public void Get()
        {
            var log1 = this._lifetime1
                .Information();
            var log2 = this._lifetime2
                .Information();

            var log = $@"{log1}{log2}";
            this._logger.LogInformation(log);
        }
    }
}
