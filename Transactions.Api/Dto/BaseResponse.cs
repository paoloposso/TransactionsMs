using System.Collections.Generic;

namespace Transactions.Api.Dto
{
    public class BaseResponse
    {
        public bool Successful { get; set; }
        public List<string> ErrorList { get; set; }
    }
}