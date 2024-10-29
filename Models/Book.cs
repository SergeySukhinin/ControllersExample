using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Models
{
    public class Book
    {
        [FromQuery]
        public string? Name { get; set; }
        [FromQuery]
        public string? Author { get; set; }

        public override string ToString()
        {
            return $"Book object - Book id: {Name}, Author: {Author}";
        }
    }
}
