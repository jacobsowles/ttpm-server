namespace TinyTwoProjectManager.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ProjectManagerDbContext _dbContext;

        public ProjectManagerDbContext Init()
        {
            return _dbContext ?? (_dbContext = new ProjectManagerDbContext());
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }                
        }
    }
}