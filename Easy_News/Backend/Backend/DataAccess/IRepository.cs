using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DataAccess
{
    public interface IRepository<DBEntity, ModelEntity>
    {
        Task<IEnumerable<ModelEntity>> Get(long id = -1);
        Task<ModelEntity> Insert(ModelEntity entity);
        Task<ModelEntity> Update(ModelEntity entity);
        Task<bool> Delete(long idEntity);
    }
}
