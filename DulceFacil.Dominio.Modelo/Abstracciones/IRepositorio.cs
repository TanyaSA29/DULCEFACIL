using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DulceFacil.Dominio.Modelo.Abstracciones
{
    public interface IRepositorio<T> where T : class
    {
        Task AddAsync(T entidad); //Insertar
        Task DeleteAsync(int id); //Eliminar 
        Task UpdateAsync(T entidad); //Actualizar   
        Task<IEnumerable<T>> GetAllAsync(); //select +from
        Task<T> GetByIdAsync(int id); //buscar por id                            
    }


}