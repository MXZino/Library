using Library.Database.Entities;
using Library.Dto.Authors;
using Library.Dto.Books;

namespace Library.AutoMapper.Extensions;

public static class BookExtensions
{
    public static BookByAuthorDto ToBookByAuthorDto(this Book book) =>
        new()
        {
            Ibnr = book.Ibnr,
            Title = book.Title,
            Year = book.Year
        };
    
    public static Book ToEntity(this AddBookDto book) =>
        new()
        {
            Ibnr = book.Ibnr,
            Title = book.Title,
            Year = book.Year,
            AuthorId = book.AuthorId
        };
}