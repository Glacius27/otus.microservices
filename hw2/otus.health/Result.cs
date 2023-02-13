using System;
namespace otus.health
{
    public class Result
    {
        public string status { get; set; }
        public Result(string _result)
        {
            this.status = _result;
        }
    }
}
