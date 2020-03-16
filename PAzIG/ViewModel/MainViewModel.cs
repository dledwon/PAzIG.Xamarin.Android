using MvvmCross.Commands;
using MvvmCross.ViewModels;
using PAzIG.Model;
using PAzIG.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PAzIG.ViewModel
{
    public class MainViewModel : MvxViewModel
    {
        private string _twoWayTest;
        public string TwoWayTest
        {
            get { return _twoWayTest; }
            set
            {
                _twoWayTest = value;
                RaisePropertyChanged();
            }
        }
        //

        private IProductManager _productManager;

        private string _newProductName;
        private double _newProductPrice;

        private MvxObservableCollection<Product> _products;
        public MvxObservableCollection<Product> Products
        {
            get { return _products; }
            set
            {
                SetProperty(ref _products, value);
            }
        }

        public string NewProductName
        {
            get { return _newProductName; }
            set
            {
                _newProductName = value;
                RaisePropertyChanged();
                AddProductCommand.RaiseCanExecuteChanged();
            }
        }
        public double NewProductPrice
        {
            get { return _newProductPrice; }
            set
            {
                _newProductPrice = value;
                RaisePropertyChanged();
                AddProductCommand.RaiseCanExecuteChanged();
            }
        }

        public MvxCommand AddProductCommand { get; private set; }

        public MainViewModel(IProductManager productManager)
        {
            TwoWayTest = "Test bindingu dwukierunkowego";
            //
            _productManager = productManager;
            Products = new MvxObservableCollection<Product>();
            RefreshProductList();

            AddProductCommand = new MvxCommand(AddProduct, AddProductCanExecute);


        }

        public void AddProduct()
        {
            _productManager.AddProduct(new Product(NewProductName, NewProductPrice));
            NewProductName = "";
            NewProductPrice = 0;
            RefreshProductList(); // lub Products.Add() - czyli niezale¿nie zarz¹dzamy stanem bazy i viewmodelu (przyda³oby siê wtedy sprawdziæ, czy uda³o siê dodaæ do db - AddProduct powinien zwracaæ bool)
        }
        public bool AddProductCanExecute()
        {
            return !(NewProductName == null || NewProductPrice == 0);
        }

         private void RefreshProductList()
        {
            Products = new MvxObservableCollection<Product>(_productManager.GetProducts());
        }

    }
}