using Library.Database.Entities;
using Library.Dto.Authors;

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
}