using Bookinist.Persistense.Context;
using Bookinist.Persistense.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookinist.Data
{
    public class DbInitialaizer
    {
        private readonly BookinistDb _db;
        private readonly ILogger<DbInitialaizer> _logger;

        public DbInitialaizer(BookinistDb db, ILogger<DbInitialaizer> logger) =>
            (_db, _logger) = (db, logger);

        public async Task InitializeAsync()
        {
            var timer = Stopwatch.StartNew();

            _logger.LogInformation("Инициализация БД...");

            _logger.LogInformation("Удаление существующей БД...");
            await _db.Database.EnsureDeletedAsync().ConfigureAwait(false);
            _logger.LogInformation("Удаление существующей БД выполнено за {0} мс", timer.ElapsedMilliseconds);

            _logger.LogInformation("Миграция БД...");
            await _db.Database.MigrateAsync();
            _logger.LogInformation("Миграция БД выполнена за {0} мс", timer.ElapsedMilliseconds);

            if (await _db.Books.AnyAsync()) return;

            await InitializeGenres();
            await InitializeAuthors();
            await InitializeBooks();
            await InitializeSellers();
            await InitializeBuyers();
            await InitializeDeals();

            _logger.LogInformation("Инициализация БД выполнена за {0} с", timer.Elapsed.TotalSeconds);
        }

        private const int __GenresCount = 10;

        private Genre[] _genres;
        private async Task InitializeGenres()
        {
            var timer = Stopwatch.StartNew();

            _logger.LogInformation("Инициализация жанров...");

            _genres = new Genre[__GenresCount];
            for (int i = 0; i < __GenresCount; i++)
            {
                _genres[i] = new Genre { Name = $"Категория {i + 1}" };
            }

            await _db.Genres.AddRangeAsync(_genres);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация жанров выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int __AuthorsCount = 10;

        private Author[] _authors;
        private async Task InitializeAuthors()
        {
            var timer = Stopwatch.StartNew();

            _logger.LogInformation("Инициализация авторов...");

            var rnd = new Random();
            _authors = Enumerable.Range(1, __AuthorsCount)
                .Select(i => new Author
                {
                    Name = $"Автор-Имя {i}",
                    Surname = $"Автор-Фамилия {i}",
                    Patronymic = $"Автор-Отчество {i}"

                })
                .ToArray();

            await _db.Authors.AddRangeAsync(_authors);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация авторов выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int __BooksCount = 10;

        private Book[] _books;
        private async Task InitializeBooks()
        {
            var timer = Stopwatch.StartNew();

            _logger.LogInformation("Инициализация книг...");

            var rnd = new Random();
            _books = Enumerable.Range(1, __BooksCount)
                .Select(i => new Book
                {
                    Name = $"Книга {i}",
                    Author = rnd.NextItem(_authors),
                    Genre = rnd.NextItem(_genres)
                    
                })
                .ToArray();

            await _db.Books.AddRangeAsync(_books);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация книг выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int __SellersCount = 10;

        private Seller[] _sellers;
        private async Task InitializeSellers()
        {
            var timer = Stopwatch.StartNew();

            _logger.LogInformation("Инициализация продавцов...");

            var rnd = new Random();
            _sellers = Enumerable.Range(1, __SellersCount)
                .Select(i => new Seller
                {
                    Name = $"Продавец-Имя {i}",
                    Surname = $"Продавец-Фамилия {i}",
                    Patronymic = $"Продавец-Отчество {i}"

                })
                .ToArray();

            await _db.Sellers.AddRangeAsync(_sellers);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация продавцов выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int __BuyersCount = 10;

        private Buyer[] _buyers;
        private async Task InitializeBuyers()
        {
            var timer = Stopwatch.StartNew();

            _logger.LogInformation("Инициализация покупателей...");

            var rnd = new Random();
            _buyers = Enumerable.Range(1, __BuyersCount)
                .Select(i => new Buyer
                {
                    Name = $"Покупатель-Имя {i}",
                    Surname = $"Покупатель-Фамилия {i}",
                    Patronymic = $"Покупатель-Отчество {i}"

                })
                .ToArray();

            await _db.Buyers.AddRangeAsync(_buyers);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация покупателей выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

        private const int __DealsCount = 1000;
        private async Task InitializeDeals()
        {
            var timer = Stopwatch.StartNew();

            _logger.LogInformation("Инициализация сделок...");

            var rnd = new Random();

            var deals = Enumerable.Range(1, __BuyersCount)
                    .Select(i => new Deal
                    {
                        Book = rnd.NextItem(_books),
                        Seller = rnd.NextItem(_sellers),
                        Buyer = rnd.NextItem(_buyers),
                        Price = (decimal)(rnd.NextDouble() * 4000 + 700)
                    });

            await _db.Deals.AddRangeAsync(deals);
            await _db.SaveChangesAsync();

            _logger.LogInformation("Инициализация сделок выполнена за {0} мс", timer.ElapsedMilliseconds);
        }

    }
}
