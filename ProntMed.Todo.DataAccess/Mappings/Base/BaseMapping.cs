using ProntMed.Todo.Domain.Entities.Base;
using System.Data.Entity.ModelConfiguration;

namespace ProntMed.Todo.DataAccess.Mappings.Base
{
    public abstract class BaseMapping<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseMapping()
        {
            this.HasKey(t => t.Codigo);
        }
    }
}
