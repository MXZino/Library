using Library.Database.Entities;
using Library.Dto.Authors;

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
}