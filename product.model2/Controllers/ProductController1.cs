using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using product.model2.Helper;
using product.model2.Models;
using product.model2.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace product.model2.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;//AppDbContext türünde  _context almış olduk.
        private readonly ProductRepository _productRepository;
        private IHelper _Helper;
        private readonly IMapper _mapper;


        public ProductsController(AppDbContext context, IHelper Helper, IMapper mapper)
        {
            _productRepository = new ProductRepository(); // nesnesini oluşturduk.
            _context = context;// bu nesne örneği üretilmiş bir dbcontext sınıfı. Bu sayede new kullanmadan üretilir. buna depanties injections denir
            _Helper = Helper;
            _mapper = mapper;

        }



        public IActionResult Index(int page = 1)
        {
            var products = _context.Products.ToList();
            return View(_mapper.Map<List<ProductViewModel>>(products));//product view e gönderdik.
        }







        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);// primeriy key e göre arama yapar.
            _context.Products.Remove(product);
            _context.SaveChanges();
            //_productRepository.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()// view göstermek için action
        {

            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay", 1},
                {"3 Ay", 3},
                {"6 Ay",6 },
                {"12 Ay",12 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>
            {
                new (){ Data="Mavi", Value="Mavi"},
                 new (){ Data="Kırmızı", Value="Kırmızı"},
                  new (){ Data="Yeşil", Value="Yeşil"}
            }, "Value", "Data"); //kullnıcıya görünecek, değer oarak kullanılacak

            return View();
        }




        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)// bu ise reques tin budy sinde gelen veriler için
        {
            ViewBag.Expire = new Dictionary<string, int>()
                {
                {"1 Ay", 1},
                {"3 Ay", 3},
                {"6 Ay",6 },
                {"12 Ay",12 }
                };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>
                {
                new (){ Data="Mavi", Value="Mavi"},
                new (){ Data="Kırmızı", Value="Kırmızı"},
                new (){ Data="Yeşil", Value="Yeşil"}
                }, "Value", "Data"); //kullnıcıya görünecek, değer oarak kullanılacak

            if (ModelState.IsValid)
            {
                try
                {
                    // throw   new Exception("Ha ha hata");
                    _context.Products.Add(_mapper.Map<Product>(newProduct));// hafızada tutulan veri tabanına ekler
                    _context.SaveChanges();//hafızadaki değişiklikleri veritabanına kayıt eder.
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(string.Empty, "kayıt sırasında bir hata oluştu lütfen tekrar deneyiniz.");
                    return View();
                }

            }
            else
            {

                return View();
            }


        }







        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            ViewBag.ExpireValue = product.Expire;

            ViewBag.Expire = new Dictionary<string, int>()
            {
                {"1 Ay", 1},
                {"3 Ay", 3},
                {"6 Ay",6 },
                {"12 Ay",12 }
            };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>
            {
                new (){ Data="Mavi", Value="Mavi"},
                 new (){ Data="Kırmızı", Value="Kırmızı"},
                  new (){ Data="Yeşil", Value="Yeşil"}
            }, "Value", "Data", product.Color); //kullnıcıya görünecek, değer oarak kullanılacak,seçili değer 



            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {
            if (!ModelState.IsValid)
            {
                

                ViewBag.ExpireValue = updateProduct.Expire;

                ViewBag.Expire = new Dictionary<string, int>()
                {
                {"1 Ay", 1},
                {"3 Ay", 3},
                {"6 Ay",6 },
                {"12 Ay",12 }
                };

                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>
                {
                new (){ Data="Mavi", Value="Mavi"},
                 new (){ Data="Kırmızı", Value="Kırmızı"},
                  new (){ Data="Yeşil", Value="Yeşil"}
                }, "Value", "Data", updateProduct.Color); //kullnıcıya görünecek, değer oarak kullanılacak,seçili değer 
                return View();
            }

            // var deneme = _Helper.ToUpper(updateProduct.Name);//interface ile yaptık.
            _context.Products.Update(_mapper.Map<Product>(updateProduct));//gelen veriyi güncelledik
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla güncellendi";
            return RedirectToAction("Index");
        }




        [AcceptVerbs("GET", "POST")]
        public IActionResult HasProductName(string Name)
        {
            var anyProduct = _context.Products.Any(x => x.Name.ToLower() == Name.ToLower());
            if (anyProduct)
            {
                return Json("Bu ürün zaten bulunmaktadır.");
            }
            else
            {
                return Json(true);
            }


        }




    }
}
