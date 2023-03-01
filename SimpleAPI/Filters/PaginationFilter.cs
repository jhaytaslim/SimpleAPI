
using System.Text.Json.Serialization;

namespace SimpleAPI.Filters
{
public class PaginationFilter
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    [JsonIgnore]
    public int PageFirstIndex { get; private set; }
    [JsonIgnore]
    public int PageLastIndex { get; private set; }
    [JsonIgnore]
    public int Skip { get; private set; }

    public PaginationFilter()
    {
        this.PageNumber = 1;
        this.PageSize = 10;
        this.SetPrivateVariables();
    }

    public PaginationFilter(int pageNumber, int pageSize)
    {
        this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
        this.PageSize = pageSize > 10 ? 10 : pageSize;

        this.SetPrivateVariables();
    }

    private void SetPrivateVariables()
    {
        this.Skip = (this.PageNumber - 1) * this.PageSize;
        this.PageFirstIndex = this.Skip + 1;
        this.PageLastIndex = this.Skip +  this.PageSize;
    }
}
}