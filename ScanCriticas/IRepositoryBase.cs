using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScanCriticas
{
    public interface IRepositoryBase<T>
    {
        List<T> GetAll();
        T GetForIdentificador(int identificador);
    }
}
