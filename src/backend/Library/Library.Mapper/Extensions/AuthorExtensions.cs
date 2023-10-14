using Library.Database.Entities;
using Library.Dto.Abstract;
using Library.Dto.Authors;
using Library.Repository.Abstract;

namespace Library.AutoMapper.Extensions;

public static class AuthorExtensions
{
    public static Author ToEntity(this AddAuthorDto addAuthorDto) 
        => new()
        {
            Description = addAuthorDto.Description,
            FirstName = addAuthorDto.FirstName,
            LastName = addAuthorDto.LastName,
            DateOfBirth = addAuthorDto.DateOfBirth
        };

    public static AuthorWithBooksDto ToAuthorWithBooksDto(this Author author) =>
        new()
        {
            Description = author.Description,
            FirstName = author.FirstName,
            LastName = author.LastName,
            DateOfBirth = author.DateOfBirth,
            Books =  author.Books?.Select(x => x.ToBookByAuthorDto()),
            Id = author.Id,
            Modified = author.Modified,
            Created = author.Created
        };

    public static void Map(this EditAuthorDto editAuthorDto, Author author)
    {
        author.DateOfBirth = editAuthorDto.DateOfBirth;
        author.Description = editAuthorDto.Description;
        author.FirstName = editAuthorDto.FirstName;
        author.LastName = editAuthorDto.LastName;
    }

    public static PageResultDto<AuthorWithBooksDto> ToAuthorsWithBooksDto(this PageResult<Author> pageResult) =>
        new()
        {
            CurrentPage = pageResult.CurrentPage,
            TotalCount = pageResult.TotalCount,
            TotalPages = pageResult.TotalPages,
            PageSize = pageResult.PageSize,
            Items = pageResult.Items.Select(x => x.ToAuthorWithBooksDto())
        };
}