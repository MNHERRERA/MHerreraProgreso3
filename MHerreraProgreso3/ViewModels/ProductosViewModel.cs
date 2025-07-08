using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MHerreraProgreso3.Models;
using MHerreraProgreso3.Services;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MHerreraProgreso3.ViewModels
{
    class ProductosViewModel: BaseViewModel
    {
        private readonly ProductoDatabase _database;
        private readonly LoggerService _logger;
        public ObservableCollection<Producto> Productos { set; get; } = new();
        public string Nombre { set; get; }
        public string Categoria { set; get; }
        public int Cantidad { set; get; }
        public Decimal PrecioEstimado { set; get; }
        public ICommand AgregarProductoCommand { get; }
        public ProductosViewModel(ProductoDatabase db, LoggerService logger)
        {
            _database = db;
            _logger = logger;
            AgregarProductoCommand = new Command(async () => await AgregarProducto());
            CargarProductos();
        }
        private async Task CargarProductos()
        {
            var lista = await _database.GetProductosAsync();
            Productos.Clear();
            foreach (var p in lista)
                Productos.Add(p);
        }
        private async Task AgregarProducto()
        {
            if (Cantidad< 1 && Categoria.ToLower() != "ropa")
            {
                await App.Current.MainPage.DisplayAlert("Advertencia","Cantidad no valida (minimo 1, exepto ropa).","OK");
                return;
            }
            var producto = new Producto
            {
                Nombre = Nombre,
                Categoria = Categoria,
                Cantidad = Cantidad,
                PrecioEstimado = PrecioEstimado
            };
            await _database.SaveProductoAsync(producto);
            await _logger.RegistrarAccionAsync($"Producto Agregado:{producto.Nombre},cantidad:{producto.Cantidad}");
            Productos.Add(producto);
            Nombre = Categoria = string.Empty;
            Cantidad = 1;
            PrecioEstimado = 0;
           
        }
    }
}
