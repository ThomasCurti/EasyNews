using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Backend.DataAccess.Interfaces
{
    public interface IDubiousArticleRepository
    {
        public Task<bool> DeleteAll();
    }
}
