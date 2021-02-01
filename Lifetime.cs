namespace ServiceLifetimes
{
    public sealed class Lifetime : ILifetime
    {
        private readonly IOperationTransient _transientOperation;
        private readonly IOperationScoped _scopedOperation;
        private readonly IOperationSingleton _singletondOperation;

        public Lifetime(
            IOperationTransient transientOperation,
            IOperationScoped scopedOperation,
            IOperationSingleton singletondOperation)
        {
            this._transientOperation = transientOperation;
            this._scopedOperation = scopedOperation;
            this._singletondOperation = singletondOperation;
        }

        public string Information()
        {
            var log = @"
{0}TRANSIENT{0}SCOPED{0}SINGLETON{0}
{0}     {1}{0}  {2}{0}     {3}{0}";

            return string.Format(log,
                Common.Hyphen(25),
                this._transientOperation.OperationId,
                this._scopedOperation.OperationId,
                this._singletondOperation.OperationId);
        }
    }
}