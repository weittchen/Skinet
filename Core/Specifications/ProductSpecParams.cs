namespace Core.Specifications
{
    public class ProductSpecParams
    {
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
        private string _search;
    }
}