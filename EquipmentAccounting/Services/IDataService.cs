using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentAccounting.Data.Models;

namespace EquipmentAccounting.Services
{
    public interface IDataService
    {
        Task<IEnumerable<Equipment>> GetAllEquipmentAsync();
        Task<Equipment> GetEquipmentByIdAsync(int id);
        Task AddEquipmentAsync(Equipment equipment);
        Task UpdateEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(int id);
        Task<IEnumerable<EquipmentType>> GetEquipmentTypesAsync();
        Task<IEnumerable<EquipmentStatus>> GetEquipmentStatusesAsync();
    }
}
