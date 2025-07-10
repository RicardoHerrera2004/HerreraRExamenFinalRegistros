using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerreraRExamenFinalRegistros.Models;
using HerreraRExamenFinalRegistros.Repositories;

namespace HerreraRExamenFinalRegistros.ViewModels
{
        public class ListaLogsViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<Log> Logs { get; set; } = new();

            public event PropertyChangedEventHandler PropertyChanged;

            public ListaLogsViewModel()
            {
                _ = CargarLogsAsync();
            }

            private async Task CargarLogsAsync()
            {
                var lista = await LogRepository.LeerLogsAsync();
                Logs.Clear();

                foreach (var log in lista)
                {
                    Logs.Add(log);
                }
            }

            protected void OnPropertyChanged(string propiedad)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
            }
        }
}
