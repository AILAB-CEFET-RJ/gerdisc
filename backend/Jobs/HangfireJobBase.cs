using Hangfire.Server;

namespace Jobs
{
    public abstract class HangfireJobBase
    {
        protected readonly ILogger _logger;
        public HangfireJobBase(ILogger<HangfireJobBase> logger)
        {
            _logger = logger;
        }

        public async Task ExecuteAsync(PerformContext? context)
        {
            _logger.LogDebug($"Executing job {context?.BackgroundJob}.");
            await ProcessJobAsync();
            _logger.LogDebug($"Finishing job {context?.BackgroundJob}.");
        }

        protected abstract Task ProcessJobAsync();
    }
}
