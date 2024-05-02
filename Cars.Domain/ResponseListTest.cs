
namespace Cars.Domain
{
    public class ResponseListTest<T>
    {
        public T Value { get; set; }
        private int PageSize { get; set; } = 2; ///Comment: Количество элементов в странице
        public int PageCount { get; set; } = 1; ///Comment: Количество страниц
        public int TotalCount { get; set; }

        public ResponseListTest(T value, int page, int pageCount, int totalCount)
        {
            Value = value;
            PageSize = page;
            PageCount = pageCount;
            TotalCount = totalCount;
        }
    }
}
