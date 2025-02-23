using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    // BookController, kitap işlemleri (listeleme, detay, oluşturma, düzenleme ve silme) için gerekli işlemleri içerir
    public class BookController : Controller
    {
        // Statik kitap listesi
        public static List<Book> Books = new List<Book>()
        {
            new Book { Id = 1, Title = "1984", AuthorId = 1, Genre = "Dystopian", PublishDate = new DateTime(1949, 6, 8), ISBN = "123-456789", CopiesAvailable = 10 },
            new Book { Id = 2, Title = "Animal Farm", AuthorId = 1, Genre = "Political Satire", PublishDate = new DateTime(1945, 8, 17), ISBN = "987-654321", CopiesAvailable = 5 },
            new Book { Id = 3, Title = "Harry Potter and the Philosopher's Stone", AuthorId = 2, Genre = "Fantasy", PublishDate = new DateTime(1997, 6, 26), ISBN = "111-222333", CopiesAvailable = 15 },
            new Book { Id = 4, Title = "The Hobbit", AuthorId = 3, Genre = "Fantasy", PublishDate = new DateTime(1937, 9, 21), ISBN = "444-555666", CopiesAvailable = 12 },
            new Book { Id = 5, Title = "Murder on the Orient Express", AuthorId = 4, Genre = "Mystery", PublishDate = new DateTime(1934, 1, 1), ISBN = "333-222111", CopiesAvailable = 7 },
            new Book { Id = 6, Title = "The Shining", AuthorId = 5, Genre = "Horror", PublishDate = new DateTime(1977, 1, 28), ISBN = "777-666555", CopiesAvailable = 8 },
            new Book { Id = 7, Title = "Foundation", AuthorId = 6, Genre = "Science Fiction", PublishDate = new DateTime(1951, 5, 1), ISBN = "555-444333", CopiesAvailable = 6 },
            new Book { Id = 8, Title = "2001: A Space Odyssey", AuthorId = 7, Genre = "Science Fiction", PublishDate = new DateTime(1968, 4, 28), ISBN = "888-999777", CopiesAvailable = 9 },
            new Book { Id = 9, Title = "Frankenstein", AuthorId = 8, Genre = "Gothic Fiction", PublishDate = new DateTime(1818, 1, 1), ISBN = "666-777888", CopiesAvailable = 3 },
            new Book { Id = 10, Title = "Dracula", AuthorId = 9, Genre = "Horror", PublishDate = new DateTime(1897, 5, 26), ISBN = "999-111444", CopiesAvailable = 11 },
            new Book { Id = 11, Title = "The Da Vinci Code", AuthorId = 10, Genre = "Thriller", PublishDate = new DateTime(2003, 3, 18), ISBN = "555-111777", CopiesAvailable = 13 },
            new Book { Id = 12, Title = "War and Peace", AuthorId = 11, Genre = "Historical Fiction", PublishDate = new DateTime(1869, 1, 1), ISBN = "444-333222", CopiesAvailable = 4 },
            new Book { Id = 13, Title = "The Great Gatsby", AuthorId = 12, Genre = "Fiction", PublishDate = new DateTime(1925, 4, 10), ISBN = "222-333444", CopiesAvailable = 5 },
            new Book { Id = 14, Title = "To Kill a Mockingbird", AuthorId = 13, Genre = "Fiction", PublishDate = new DateTime(1960, 7, 11), ISBN = "111-000111", CopiesAvailable = 14 },
            new Book { Id = 15, Title = "Carrie", AuthorId = 5, Genre = "Horror", PublishDate = new DateTime(1974, 4, 5), ISBN = "888-555999", CopiesAvailable = 6 },
            new Book { Id = 16, Title = "Pride and Prejudice", AuthorId = 14, Genre = "Romance", PublishDate = new DateTime(1813, 1, 28), ISBN = "444-111999", CopiesAvailable = 8 },
            new Book { Id = 17, Title = "Dune", AuthorId = 15, Genre = "Science Fiction", PublishDate = new DateTime(1965, 8, 1), ISBN = "333-555777", CopiesAvailable = 9 },
            new Book { Id = 18, Title = "Brave New World", AuthorId = 16, Genre = "Dystopian", PublishDate = new DateTime(1932, 1, 1), ISBN = "555-999000", CopiesAvailable = 12 },
            new Book { Id = 19, Title = "The Catcher in the Rye", AuthorId = 17, Genre = "Fiction", PublishDate = new DateTime(1951, 7, 16), ISBN = "111-222333", CopiesAvailable = 10 },
            new Book { Id = 20, Title = "The Picture of Dorian Gray", AuthorId = 17, Genre = "Philosophical Fiction", PublishDate = new DateTime(1890, 6, 1), ISBN = "777-888999", CopiesAvailable = 5 }
        };

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

        // Kitapların listesini görüntüler
        [HttpGet]
        public IActionResult List()
        {
            // Kitaplar listesini, yalnızca Id ve Title bilgilerini içeren view model'e dönüştür
            var viewModel = Books.Select(x => new BookListViewModel()
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();

            return View(viewModel);
        }

        // Belirli bir kitabın detaylarını görüntüler
        public IActionResult Details(int id)
        {
            // Kitap verisini ID'ye göre al
            var book = Books.FirstOrDefault(x => x.Id == id);

            // Detayları içeren view model oluştur
            var viewModel = new BookDetailsViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
                Genre = book.Genre,
                PublishDate = book.PublishDate,
                ISBN = book.ISBN,
                CopiesAvailable = book.CopiesAvailable
            };

            return View(viewModel);
        }

        // Yeni kitap oluşturma sayfasını görüntüler
        [HttpGet]
        public IActionResult Create()
        {
            // Yazarları seçmek için ViewBag kullanarak, kitap oluşturma formu için gerekli veriyi gönder
            ViewBag.Authors = Authors.Select(x => new AuthorListViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Id = x.Id
            }).ToList();

            return View();
        }

        // Yeni kitap oluşturma işlemini işler
        [HttpPost]
        public IActionResult Create(BookCreateViewModel formData)
        {
            // Yeni kitap nesnesi oluştur
            var newBook = new Book()
            {
                Id = Books.Max(x => x.Id) + 1,  // Yeni ID, mevcut en yüksek ID'den bir fazla olacak
                Title = formData.Title,
                Genre = formData.Genre,
                PublishDate = formData.PublishDate,
                ISBN = formData.ISBN,
                CopiesAvailable = formData.CopiesAvailable,               
            };

            // Kitapları listeye ekle
            Books.Add(newBook);

            // Kitaplar listesini tekrar göster
            return RedirectToAction("List");
        }

        // Kitap düzenleme sayfasını görüntüler
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Düzenlenecek kitabı ID'ye göre al
            var book = Books.FirstOrDefault(x => x.Id == id);

            var bookEditViewModel = new BookEditViewModel()
            {
                Id = book.Id,
                Title = book.Title
            };
            return View(bookEditViewModel);
        }

        // Kitap düzenleme işlemini işler
        [HttpPost]
        public IActionResult Edit(BookEditViewModel formData)
        {
            // Düzenlenecek kitabı ID'ye göre al
            var book = Books.FirstOrDefault(x => x.Id == formData.Id);

            book.Title = formData.Title;

            // Kitaplar listesini tekrar göster
            return RedirectToAction("List");
        }

        // Kitap silme işlemi
        public IActionResult Delete(int id)
        {
            // Silinecek kitabı ID'ye göre al
            var book = Books.FirstOrDefault(x => x.Id == id);

            Books.Remove(book);

            return RedirectToAction("List");
        }
    }
}
