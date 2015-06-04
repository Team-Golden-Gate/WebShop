namespace GoldenGateShop.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    using GoldenGateShop.Contracts;


    public class DeletableEntityRepository<T> : EFRepository<T>, IDeletableEntityRepository<T>
        where T : class, IDeletableEntity
    {
        public DeletableEntityRepository(DbContext context)
            : base(context)
        {
        }

        public override IQueryable<T> All()
        {
            return base.All().Where(x => !x.IsDeleted);
        }

        public IQueryable<T> AllWithDeleted()
        {
            return base.All();
        }
    }
}
