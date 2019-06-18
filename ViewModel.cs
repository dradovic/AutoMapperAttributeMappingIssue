using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace AttributeBasedMapping
{
    [AutoMap(typeof(Company), ReverseMap = true)]
    public class ViewModel
    {
        public int Id { get; set; }
        [SourceMember(nameof(Company.Name))]
        public string CompanyName { get; set; }
    }
}
