using Library.Dto.Abstract;

namespace Library.Dto.Authors;

public class GetAuthorsFilterDto : BasePaginationDto
{
    public string Name { get; set; }
}