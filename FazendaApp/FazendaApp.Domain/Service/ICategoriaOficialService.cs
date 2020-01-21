using FazendaApp.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FazendaApp.Domain.Service
{
  public interface ICategoriaOficialService
  {
    Task<IEnumerable<CategoriaOficialModel>> GetAsync();
  }
}
