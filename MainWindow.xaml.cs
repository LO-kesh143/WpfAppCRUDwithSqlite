using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfAppCRUD.Data;

namespace WpfAppCRUD
{
    public partial class MainWindow : Window
    {
        private readonly ProductDbContext _context;
        Product NewProduct = new Product();
        Product selectedProduct = new Product();
        public MainWindow(ProductDbContext context)
        {
            _context = context;
            InitializeComponent();
            GetProducts();
            NewProductGrid.DataContext = NewProduct;
        }
        private void GetProducts()
        {
            ProductDG.ItemsSource = _context.Products.ToList();
        }
        private void AddItem(object s, RoutedEventArgs e)
        {
            _context.Products.Add(NewProduct);
            _context.SaveChanges();
            GetProducts();
        }
        private void UpdateItem(object s, RoutedEventArgs e)
        {
            _context.Update(selectedProduct);
            _context.SaveChanges();
            GetProducts();
        }
        private void SelectProductToEdit(object s, RoutedEventArgs e)
        {
            selectedProduct = (s as FrameworkElement).DataContext as Product;
            UpdateProductGrid.DataContext = selectedProduct;
        }
        private void DeleteProduct(object s, RoutedEventArgs e)
        {
            var productToDelete = (s as FrameworkElement).DataContext as Product;
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
            GetProducts();
        }
    }
}
