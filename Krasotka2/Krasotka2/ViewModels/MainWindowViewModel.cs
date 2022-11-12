using Krasotka2.Entities;
using Krasotka2.Entities.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krasotka2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private List<Product> _products;
        public MainWindowViewModel()
        {
            using (ApplicationDbContext context = new())
            {
                _products = context.Products.ToList();
                    
            } 
        }
    }
}
