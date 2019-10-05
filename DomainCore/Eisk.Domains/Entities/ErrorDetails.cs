using Newtonsoft.Json;

namespace Eisk.Domains.Entities
{
    public class ErrorDetails
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
