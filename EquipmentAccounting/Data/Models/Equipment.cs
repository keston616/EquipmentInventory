using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentAccounting.Data.Models
{
    public class Equipment : INotifyPropertyChanged
    {
        private int _id;
        private string _name;
        private int _typeId;
        private int _statusId;
        private EquipmentType _type;
        private EquipmentStatus _status;
      

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        [Column("TypeId")] // Должно точно соответствовать имени в БД
        public int TypeId
        {
            get => _typeId;
            set { _typeId = value; OnPropertyChanged(); }
        }

        [Column("StatusId")] // Должно точно соответствовать имени в БД
        public int StatusId
        {
            get => _statusId;
            set { _statusId = value; OnPropertyChanged(); }
        }

        [ForeignKey("TypeId")]
        public EquipmentType Type
        {
            get => _type;
            set { _type = value; OnPropertyChanged(); }
        }

        [ForeignKey("StatusId")]
        public EquipmentStatus Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        public string TypeName
        {
            get => Type.Name;
        }

        public string StatusName
        {
            get => Status.Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
