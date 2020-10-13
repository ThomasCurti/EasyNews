using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.DataAccess.Interfaces
{
    public interface IDubiousArticleRepository
    {
        public Task<bool> DeleteAll();
        public Task<Dbo.Model.dubious_article> InsertWithoutDuplicate(Dbo.Model.dubious_article article);
    }
}
