using System.Collections.Generic;
using Pradeep.MVVM.EntityLayer;


namespace Pradeep.MVVM.DataLayer
{
    public interface IProductRepository  
    {    
        List<Product> Get();  

        List<Product> Search(ProductSearch entity);
    }
}
