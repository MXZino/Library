namespace Library.Repository.Filters.Abstract;

public abstract class BasePagination
{
    public int Page { get; set; } = 1;
    
    private uint _recordsPerPage = 20;
    public uint RecordsPerPage 
    { 
        get => _recordsPerPage;
        set
        {
            _recordsPerPage = value switch
            {
                < 10 => 10,
                > 100 => 100,
                _ => value
            };
        }
    }
}