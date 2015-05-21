using System.Web;
using Arjen.Data.UnitOfWork;

namespace Cms.EntityData
{
    public class PerRequestUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private const string CacheUnitOfWorkFactory = "___UNIT_OF_WORK_FACTORY___";

        private PerRequestUnitOfWorkFactory()
        {
        }

        private static PerRequestUnitOfWorkFactory Instance { get; set; }
        public static PerRequestUnitOfWorkFactory GetInstance()
        {
            return Instance ?? (Instance = new PerRequestUnitOfWorkFactory());
        }


        public IUnitOfWork RequireUnitInstance()
        {
            if (HttpContext.Current.Items[CacheUnitOfWorkFactory] == null)
            {
                HttpContext.Current.Items[CacheUnitOfWorkFactory] = new CmsObjectContext(   );
            }

            return HttpContext.Current.Items[CacheUnitOfWorkFactory] as CmsObjectContext;
        }

        public void DestroyUnitInstance()
        {
            var unitOfWork = HttpContext.Current.Items[CacheUnitOfWorkFactory] as IUnitOfWork;
            if (unitOfWork != null)
                unitOfWork.Cancel();
        }
    }
}
