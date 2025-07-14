using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EquipmentAccounting.Data.Models;
using EquipmentAccounting.Services;
using System.Windows.Input;
using System.Windows;

namespace EquipmentAccounting.ViewModels
{
    public class EditEquipmentViewModel : INotifyPropertyChanged
    {
        private readonly IDataService _dataService = new SqliteDataService();
        private readonly Action _closeAction;
        private readonly Equipment _originalEquipment;

        public ObservableCollection<EquipmentType> EquipmentTypes { get; } = new();

        public int Id { get; }

        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private int _typeId;
        public int TypeId
        {
            get => _typeId;
            set { _typeId = value; OnPropertyChanged(); }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EditEquipmentViewModel(Equipment equipment)
        {
            _originalEquipment = equipment;

            Id = equipment.Id;
            Name = equipment.Name;
            TypeId = equipment.TypeId;

            SaveCommand = new AsyncRelayCommand(SaveEquipment);
            CancelCommand = new RelayCommand(_ => App.Current.MainWindow.DataContext = new MainViewModel());

            LoadEquipmentTypes();
        }

        private async Task LoadEquipmentTypes()
        {
            try
            {
                var types = await _dataService.GetEquipmentTypesAsync();
                EquipmentTypes.Clear();
                foreach (var type in types)
                {
                    EquipmentTypes.Add(type);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки типов оборудования: {ex.Message}", "Предупреждение");
            }
        }

        private async Task SaveEquipment()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("Наименование не может быть пустым", "Предупреждение");
                return;
            }

            try
            {
                var equipment = new Equipment
                {
                    Id = Id,
                    Name = Name,
                    TypeId = TypeId,
                    StatusId = _originalEquipment.StatusId
                };

                await _dataService.UpdateEquipmentAsync(equipment);
                MessageBox.Show("Изменения сохранены", "Предупреждение");
                App.Current.MainWindow.DataContext = new MainViewModel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Предупреждение");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
