using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.Response
{
    public class Response<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccesfull { get; set; }
        public List<string> Errors { get; set; }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { StatusCode = statusCode, IsSuccesfull = true };
        }
        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccesfull = true };
        }
        public static Response<T> Fail(T data, List<string> errors, int statusCode)
        {
            return new Response<T> { Data = data, Errors = errors, IsSuccesfull = false, StatusCode = statusCode };
        }
        public static Response<T> Fail(List<string> errors, int statusCode)
        {
            return new Response<T> { Errors = errors, IsSuccesfull = false, StatusCode = statusCode };
        }
        public static Response<T> Fail(string error, int statusCode)
        {
            return new Response<T> { Errors = new List<string> { error }, IsSuccesfull = false, StatusCode = statusCode };
        }
    }
}
