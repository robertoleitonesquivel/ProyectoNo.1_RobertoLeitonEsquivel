using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoNo._1.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public int Status { get; set; } 
        public string Message { get; set; }
    }
}