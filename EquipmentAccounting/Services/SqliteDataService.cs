using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EquipmentAccounting.Data.Models;
using EquipmentAccounting.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace EquipmentAccounting.Services
{
    public class SqliteDataService : IDataService
    {
        private readonly AppDbContext _context;

        public SqliteDataService()
        {
            _context = new AppDbContext();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            try
            {
                // Проверяем существует ли файл БД
                 string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "equipment.db");

                if (!File.Exists(dbPath))
                {
                    throw new FileNotFoundException($"Файл базы данных не найден: {dbPath}");
                }

                // Применяем миграции (если используются)
                _context.Database.Migrate();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка инициализации базы данных", ex);
            }
        }

        public async Task<IEnumerable<Equipment>> GetAllEquipmentAsync()
        {
            try
            {
                return await _context.Equipment
                    .Include(e => e.Type)
                    .Include(e => e.Status)
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении списка оборудования", ex);
            }
        }

        public async Task<Equipment> GetEquipmentByIdAsync(int id)
        {
            try
            {
                return await _context.Equipment
                    .Include(e => e.Type)
                    .Include(e => e.Status)
                    .FirstOrDefaultAsync(e => e.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при оборудования", ex);
            }
        }

        public async Task AddEquipmentAsync(Equipment equipment)
        {
            try
            {
                _context.Equipment.Add(equipment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Ошибка при добавлении оборудования. Возможно, такое оборудование уже существует.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Неизвестная ошибка при добавлении оборудования", ex);
            }
        }

        public async Task UpdateEquipmentAsync(Equipment equipment)
        {
            try
            {
                _context.Equipment.Update(equipment);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении информации об оборудования", ex);
            }
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            try
            {
                var equipment = await _context.Equipment.FindAsync(id);
                if (equipment != null)
                {
                    _context.Equipment.Remove(equipment);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при удаление оборудования", ex);
            }
        }

        public async Task<IEnumerable<EquipmentType>> GetEquipmentTypesAsync()
        {
            try
            {
                return await _context.EquipmentTypes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при полученя списка типов оборудования", ex);
            }
        }

        public async Task<IEnumerable<EquipmentStatus>> GetEquipmentStatusesAsync()
        {
            try
            {
                return await _context.EquipmentStatuses.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при полученя списка стутусов", ex);
            }
        }
    }
}
