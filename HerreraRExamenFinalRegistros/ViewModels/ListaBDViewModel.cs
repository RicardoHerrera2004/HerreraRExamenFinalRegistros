using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HerreraRExamenFinalRegistros.Models;

namespace HerreraRExamenFinalRegistros.ViewModels
{
    class ListaBDViewModel : INotifyPropertyChanged                                                         
    {
        public ObservableCollection<Proyecto> Proyectos { get; set; } = new();

        public event PropertyChangedEventHandler PropertyChanged;

        public ListaBDViewModel()
        {
            _ = CargarProyectosAsync();
        }

        private async Task CargarProyectosAsync()
        {
            var lista = await App.ModelRepository.GetProyectosAsync();
            Proyectos.Clear();
            foreach (var proyecto in lista)
            {
                Proyectos.Add(proyecto);
            }
        }

        protected void OnPropertyChanged(string propiedad)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propiedad));
        }
    }
}
