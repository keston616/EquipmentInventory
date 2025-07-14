using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using EquipmentAccounting.Data.Models;
using EquipmentAccounting.Services;

namespace EquipmentAccounting.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private readonly IDataService _dataService;

        public ObservableCollection<Equipment> EquipmentList { get; } = new();
        private Equipment selectedEquipment;

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand LoadDataCommand { get; }
        public Equipment SelectedEquipment
        {
            get => selectedEquipment;
            set
            {
                selectedEquipment = value; OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            _dataService = new SqliteDataService();

            AddCommand = new RelayCommand(_ =>
            {
                Application.Current.MainWindow.DataContext = new AddEquipmentViewModel();
            });
            EditCommand = new RelayCommand(_ =>
            {
                if (SelectedEquipment == null) return;
                Application.Current.MainWindow.DataContext = new EditEquipmentViewModel(SelectedEquipment);
            });
            DeleteCommand = new AsyncRelayCommand(
    execute: DeleteEquipmentAsync,
    canExecute: () => SelectedEquipment != null
);
            LoadDataCommand = new AsyncRelayCommand(LoadDataAsync);

            LoadDataCommand.Execute(null);
        }



        private async Task DeleteEquipmentAsync()
        {
            if (SelectedEquipment == null) return;

            var confirm = MessageBox.Show(
                $"Вы уверены, что хотите удалить оборудование '{SelectedEquipment.Name}'?", "Предупреждение", MessageBoxButton.YesNo);

            if (confirm == MessageBoxResult.No) return;

            try
            {
                await _dataService.DeleteEquipmentAsync(SelectedEquipment.Id);
                MessageBox.Show("Оборудование удалено");
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении: {ex.Message}");
            }
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var equipment = await _dataService.GetAllEquipmentAsync();
                EquipmentList.Clear();
                foreach (var item in equipment)
                {
                    EquipmentList.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
