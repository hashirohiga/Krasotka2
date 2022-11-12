using Krasotka2.Entities;
using Krasotka2.Entities.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krasotka2.ViewModels
{
    public class UserViewModel:ViewModelBase
    {
        private List<Product> _displayingProduct;
        private string _searchValue;
        private string _sortValue;
        private string _filterValue;
        private int _displayCount;
        private int _productCount;
        private User _user;
        #region свойства
        public int DisplayCount
        {
            get { return _displayCount; }
            set
            {
                Set(ref _displayCount, value, nameof(DisplayCount));

            }
        }

        public int ProductCount
        {
            get { return _productCount; }
            set
            {
                Set(ref _productCount, value, nameof(ProductCount));

            }
        }


        public string FilterValue
        {
            get { return _filterValue; }
            set
            {
                Set(ref _filterValue, value, nameof(FilterValue));
                DisplayProduct();
            }
        }


        public List<string> FilterList => new()
        {
            "Без фильтрации",
            "0 - 9.99%",
            "10 - 14.99%",
            "15% - ..."
        };

        public string SortValue
        {
            get { return _sortValue; }
            set
            {
                Set(ref _sortValue, value, nameof(SortList));
                DisplayProduct();
            }
        }

        public List<string> SortList => new()
        {
            "Без соритровки",
            "Стоимость возр.",
            "Стоимость уб."
        };
        public string SearchValue
        {
            get { return _searchValue; }
            set
            {
                Set(ref _searchValue, value, nameof(SearchValue));
                DisplayProduct();
            }
        }

        public List<Product> DisplayingProduct
        {
            get { return _displayingProduct; }
            set { Set(ref _displayingProduct, value, nameof(DisplayingProduct)); }
        }

        public User User 
        {
            get => _user; 
            set => Set(ref _user,value,nameof(User));
        }
        #endregion
        public UserViewModel(User user)
        {
            DisplayingProduct = new List<Product>(GetProduct());
            SortValue = SortList[0];
            FilterValue = FilterList[0];
            User = user;
        }
        private void DisplayProduct()
        {
            DisplayingProduct = Sorting(Search(Filtering(GetProduct())));
            ProductCount = GetProduct().Count;
            DisplayCount = DisplayingProduct.Count;
        }
        private List<Product> GetProduct()
        {
            using (ApplicationDbContext context = new())
            {
                return context.Products
                    .Include(m=>m.ManufactureNavigation)
                    .ToList();
            }
        }

        private List<Product> Filtering(List<Product> products)
        {
            if (FilterValue == FilterList[1])
                return products.Where(d => d.CurrentDiscount < 10).ToList();
            else if (FilterValue == FilterList[2])
                return products.Where(d => d.CurrentDiscount >= 10 && d.CurrentDiscount < 15).ToList();
            else if (FilterValue == FilterList[3])
                return products.Where(d => d.CurrentDiscount >= 15).ToList();
            else return products;
        }

        private List<Product> Sorting(List<Product> product)
        {


            if (SortValue == SortList[1])
                return product.OrderBy(c => c.Cost).ToList();
            else if (SortValue == SortList[2])
                return product.OrderByDescending(c => c.Cost).ToList();
            else return product;

        }
        private List<Product> Search(List<Product> products)
        {
            if (SearchValue == null || SearchValue == string.Empty)
            {
                return products;
            }

            else return products.Where(p => p.ProductName.ToLower().Contains(SearchValue.ToLower())).ToList();

        }
    }
}
