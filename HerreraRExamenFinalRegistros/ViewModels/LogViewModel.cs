using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using HerreraRExamenFinalRegistros.Models;
using HerreraRExamenFinalRegistros.Repositories;
using System.Windows.Input;

namespace HerreraRExamenFinalRegistros.ViewModels
{
    public class LogViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _nombreProyecto;
        public string NombreProyecto
        {
            get => _nombreProyecto;
            set
            {
                _nombreProyecto = value;
                OnPropertyChanged(nameof(NombreProyecto));
            }
        }

        private string _responsable;
        public string Responsable
        {
            get => _responsable;
            set
            {
                _responsable = value;
                OnPropertyChanged(nameof(Responsable));
            }
        }

        private decimal _progreso;
        public decimal Progreso
        {
            get => _progreso;
            set
            {
                _progreso = value;
                OnPropertyChanged(nameof(Progreso));
            }
        }

        private int _duracionDias;
        public int DuracionDias
        {
            get => _duracionDias;
            set
            {
                _duracionDias = value;
                OnPropertyChanged(nameof(DuracionDias));
            }
        }

        public ICommand GuardarCommand { get; }

        public LogViewModel()
        {
            GuardarCommand = new Command(async () => await GuardarProyectoAsync());
        }

        private async Task GuardarProyectoAsync()
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(NombreProyecto) || string.IsNullOrWhiteSpace(Responsable))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, complete todos los campos de texto.", "Aceptar");
                return;
            }

            //Validación lógica
            if (Progreso <= 0 || Progreso > 100 || DuracionDias <= 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El progreso debe estar entre 1% y 100%, y la duración debe ser mayor a 0 días.", "Aceptar");
                return;
            }

            // Validación del ejercicio
            if (Progreso > 50 && DuracionDias < 365)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Restricción",
                    "No se puede ingresar un progreso mayor al 50% en proyectos con duración menor a 1 año (365 días).",
                    "Aceptar");
                return;
            }

            // Crear y guardar proyecto
            var proyecto = new Proyecto
            {
                NombreProyecto = this.NombreProyecto,
                Responsable = this.Responsable,
                Progreso = this.Progreso,
                DuracionDias = this.DuracionDias
            };

            await App.ModelRepository.InsertProyectoAsync(proyecto);
            await LogRepository.EscribirLogAsync(proyecto);

            await Application.Current.MainPage.DisplayAlert("Éxito", "Proyecto guardado correctamente.", "Aceptar");

            // Limpiar campos
            NombreProyecto = string.Empty;
            Responsable = string.Empty;
            Progreso = 0;
            DuracionDias = 0;

            OnPropertyChanged(nameof(NombreProyecto));
            OnPropertyChanged(nameof(Responsable));
            OnPropertyChanged(nameof(Progreso));
            OnPropertyChanged(nameof(DuracionDias));
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 