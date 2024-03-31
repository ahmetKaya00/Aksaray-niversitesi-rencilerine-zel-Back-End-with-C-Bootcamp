
namespace ETicaret.Models
{
    public class Repository{
        private static readonly List<Product> _product = new();
        private static readonly List<Category> _category = new();

        static Repository(){
            _category.Add(new Category{CategoryId = 1, Name = "Telefon"});
            _category.Add(new Category{CategoryId = 2, Name = "Bilgisayar"});

            _product.Add(new Product{ProductId=1, Name= "Iphone 15", Price = 85000, IsActive=true,Image="1.jpg",CategoryId = 1});
            _product.Add(new Product{ProductId=2, Name= "Iphone 15 Pro Max", Price = 95000, IsActive=true,Image="2.jpg",CategoryId = 1});
            _product.Add(new Product{ProductId=3, Name= "Iphone 14 Pro Max", Price = 75000, IsActive=true,Image="3.jpg",CategoryId = 1});
            _product.Add(new Product{ProductId=4, Name= "Iphone 14", Price = 65000, IsActive=true,Image="4.jpg",CategoryId = 1});

            _product.Add(new Product{ProductId=5, Name= "Mac Book", Price = 85000, IsActive=true,Image="5.jpg",CategoryId = 2});
            _product.Add(new Product{ProductId=6, Name= "Mac Book Air", Price = 95000, IsActive=false,Image="6.jpg",CategoryId = 2});
        }

        public static void CreateProduct(Product entity){
            _product.Add(entity);
        }
        public static void EditProduct(Product updatedProduct){
            var entity = _product.FirstOrDefault(p=>p.ProductId == updatedProduct.ProductId);

            if(entity != null){
                if(!string.IsNullOrEmpty(updatedProduct.Name)){
                entity.Name = updatedProduct.Name;
                }
                entity.Price = updatedProduct.Price;
                entity.Image = updatedProduct.Image;
                entity.CategoryId = updatedProduct.CategoryId;
                entity.IsActive = updatedProduct.IsActive;
            }
        }
        public static void EditIsActive(Product updatedProduct){
            var entity = _product.FirstOrDefault(p=>p.ProductId == updatedProduct.ProductId);

            if(entity != null){
                entity.IsActive = updatedProduct.IsActive;
            }
        }

        public static void DeleteProduct(Product entities){
            var entity = _product.FirstOrDefault(p=>p.ProductId == entities.ProductId);

            if(entity != null){
                _product.Remove(entity);
            }
        }

        public static List<Product> Products{get{return _product;}}
        public static List<Category> Categories{get{return _category;}}
    }
}