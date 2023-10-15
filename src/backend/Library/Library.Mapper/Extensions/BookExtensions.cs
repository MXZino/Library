using Library.Database.Entities;
using Library.Dto.Abstract;
using Library.Dto.Authors;
using Library.Dto.Books;
using Library.Repository.Abstract;

namespace Library.AutoMapper.Extensions;

public static class BookExtensions
{
    public static BookByAuthorDto ToBookByAuthorDto(this Book book) =>
        new()
        {
            Id = book.Id,
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

    public static void Map(this EditBookDto editBookDto, Book book)
    {
        book.Ibnr = editBookDto.Ibnr;
        book.Title = editBookDto.Title;
        book.AuthorId = editBookDto.AuthorId;
        book.Year = editBookDto.Year;
    }

    public static BookWithAuthorDto ToBookWithAuthorDto(this Book book) =>
        new()
        {
            Year = book.Year,
            Title = book.Title,
            Created = book.Created,
            Ibnr = book.Ibnr,
            Modified = book.Modified,
            Id = book.Id,
            Author = new AuthorByBookDto
            {
                Description = book.Author.Description,
                FirstName = book.Author.FirstName,
                LastName = book.Author.LastName,
                DateOfBirth = book.Author.DateOfBirth,
                Id = book.Author.Id
            }
        };

    public static PageResultDto<BookWithAuthorDto> ToBooksWithAuthors(this PageResult<Book> pageResult) =>
        new()
        {
            CurrentPage = pageResult.CurrentPage,
            TotalCount = pageResult.TotalCount,
            TotalPages = pageResult.TotalPages,
            PageSize = pageResult.PageSize,
            Items = pageResult.Items.Select(x => x.ToBookWithAuthorDto())
        };
}