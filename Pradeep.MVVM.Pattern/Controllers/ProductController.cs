using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Pradeep.MVVM.DataLayer;
using Pradeep.MVVM.ViewModelLayer;
using Newtonsoft.Json;

namespace Pradeep.MVVM.Pattern.Controllers
{  
    public class ProductController : Controller  
    {    
        private readonly IProductRepository _repo;    
        private readonly ProductViewModel _viewModel;
        
        public ProductController(IProductRepository repo, ProductViewModel vm)    
        {      
            _repo = repo;      
            _viewModel = vm;
        }
        
        public IActionResult Products()
        {
            // Load products  
            _viewModel.SortExpression = "Name";  
            _viewModel.EventCommand = "sort";
            _viewModel.Pager.PageSize = 5;
            _viewModel.HandleRequest();
            HttpContext.Session.SetString("Products", JsonConvert.SerializeObject(_viewModel.AllProducts));
            return View(_viewModel);    
        }  

        [HttpPost]
        public IActionResult Products(ProductViewModel vm)
        {
            vm.Repository = _repo;  
            vm.Pager.PageSize = 5;
            vm.AllProducts = JsonConvert.DeserializeObject<List<Pradeep.MVVM.EntityLayer.Product>>(HttpContext.Session.GetString("Products"));
            vm.HandleRequest();
            ModelState.Clear();
            return View(vm);
        }
    }
}