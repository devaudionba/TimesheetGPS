using SQLite;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TimesheetGPS.Model
{
    public class Entity : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        private DateTime createdAt;
        public DateTime CreatedAt
        {
            get { return createdAt; }
            set
            {
                if (value.Equals(createdAt))
                {
                    return;
                }
                createdAt = value;
                OnPropertyChanged();
            }
        }

        private DateTime modifiedAt;
        public DateTime ModifiedAt
        {
            get { return modifiedAt; }
            set
            {
                if (value.Equals(modifiedAt))
                {
                    return;
                }
                modifiedAt = value;
                OnPropertyChanged();
            }
        }

        private bool deleted;
        public bool Deleted
        {
            get { return deleted; }
            set
            {
                if (value.Equals(deleted))
                {
                    return;
                }
                deleted = value;
                OnPropertyChanged();
            }
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Entity()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
    }
}
