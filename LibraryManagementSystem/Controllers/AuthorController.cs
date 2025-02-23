using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        // Statik yazar listesi
        public static List<Author> Authors = new List<Author>()
        {
            new Author { Id = 1, FirstName = "George", LastName = "Orwell", DateOfBirth = new DateTime(1903, 6, 25) },
            new Author { Id = 2, FirstName = "J.K.", LastName = "Rowling", DateOfBirth = new DateTime(1965, 7, 31) },
            new Author { Id = 3, FirstName = "J.R.R.", LastName = "Tolkien", DateOfBirth = new DateTime(1892, 1, 3) },
            new Author { Id = 4, FirstName = "Agatha", LastName = "Christie", DateOfBirth = new DateTime(1890, 9, 15) },
            new Author { Id = 5, FirstName = "Stephen", LastName = "King", DateOfBirth = new DateTime(1947, 9, 21) },
            new Author { Id = 6, FirstName = "Isaac", LastName = "Asimov", DateOfBirth = new DateTime(1920, 1, 2) },
            new Author { Id = 7, FirstName = "Arthur", LastName = "Clarke", DateOfBirth = new DateTime(1917, 12, 16) },
            new Author { Id = 8, FirstName = "Mary", LastName = "Shelley", DateOfBirth = new DateTime(1797, 8, 30) },
            new Author { Id = 9, FirstName = "Bram", LastName = "Stoker", DateOfBirth = new DateTime(1847, 11, 8) },
            new Author { Id = 10, FirstName = "Dan", LastName = "Brown", DateOfBirth = new DateTime(1964, 6, 22) },
            new Author { Id = 11, FirstName = "Leo", LastName = "Tolstoy", DateOfBirth = new DateTime(1828, 9, 9) },
            new Author { Id = 12, FirstName = "F. Scott", LastName = "Fitzgerald", DateOfBirth = new DateTime(1896, 9, 24) },
            new Author { Id = 13, FirstName = "Harper", LastName = "Lee", DateOfBirth = new DateTime(1926, 4, 28) },
            new Author { Id = 14, FirstName = "Frank", LastName = "Herbert", DateOfBirth = new DateTime(1920, 10, 8) },
            new Author { Id = 15, FirstName = "Aldous", LastName = "Huxley", DateOfBirth = new DateTime(1894, 7, 26) },
            new Author { Id = 16, FirstName = "J.D.", LastName = "Salinger", DateOfBirth = new DateTime(1919, 1, 1) },
            new Author { Id = 17, FirstName = "Oscar", LastName = "Wilde", DateOfBirth = new DateTime(1854, 10, 16) }
        };

        // Yazarlar listesi sayfasını görüntülemek için kullanılan aksiyon metodu.
        [HttpGet]
        public IActionResult List()
        {
            // Yazarları listelemek için bir ViewModel'e dönüştürme.
            var viewModel = Authors.Select(x => new AuthorListViewModel()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
            }).ToList();

            return View(viewModel);
        }

        // Yazarın detaylarını görmek için kullanılan aksiyon metodu.
        public IActionResult Details(int id)
        {
            // ID'ye göre yazar bulunuyor.
            var author = Authors.FirstOrDefault(x => x.Id == id);

            var viewModel = new AuthorDetailsViewModel()
            {
                Id = author.Id,
                FirstName= author.FirstName,
                LastName= author.LastName,
                DateOfBirth= author.DateOfBirth
            };

            return View(viewModel);
        }

        // Yeni bir yazar eklemek için kullanılan GET metodu.
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Yeni yazar verisini alıp, veritabanına ekleyen POST metodu.
        [HttpPost]
        public IActionResult Create(AuthorCreateViewModel formData)
        {
            // Yeni bir yazar nesnesi oluşturuluyor ve listeye ekleniyor.
            var newAuthor = new Author()
            {
                Id = Authors.Max(x => x.Id) + 1,    // Yeni ID, mevcut en yüksek ID'ye 1 eklenerek verilir.
                FirstName = formData.FirstName,
                LastName = formData.LastName,
                DateOfBirth = formData.DateOfBirth,
            };

            Authors.Add(newAuthor);

            // Yazarlar listesine yönlendirilir.
            return RedirectToAction("List");
        }

        // Mevcut bir yazarı düzenlemek için kullanılan GET metodu.
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Düzenlemek istenen yazar bulunuyor.
            var author = Authors.FirstOrDefault(x => x.Id == id);

            var authorEditViewModel = new AuthorEditViewModel()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName
            };
            return View(authorEditViewModel);
        }

        // Yazarın düzenlenen bilgileri alınıp, güncelleniyor.
        [HttpPost]
        public IActionResult Edit(AuthorEditViewModel formData)
        {
            // Düzenlenen yazar bulunuyor.
            var author = Authors.FirstOrDefault(x => x.Id == formData.Id);

            // Yazar bilgileri güncelleniyor.
            author.FirstName = formData.FirstName;
            author.LastName = formData.LastName;

            // Yazarlar listesine yönlendirilir.
            return RedirectToAction("List");
        }
    }
}
