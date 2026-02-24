using System.Reflection.Metadata.Ecma335;

namespace CP1.Models
{
    public class ComplexObject
    {
        public bool Success { get; set; }
        public string Identifier { get { return _uniqueIdentifier; } }
        private string _uniqueIdentifier { get; set; } = Guid.NewGuid().ToString();
        public IEnumerable<object> Entities { get; set; }
        public List<string> Errors { get; set; } = [];
    }
}
