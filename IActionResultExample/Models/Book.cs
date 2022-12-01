using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Models
{
    public class Book
    {
        // [FromQuery]
        public int? BookId { get; set; }

        // [FromRoute]
        public string? Author { get; set; }


        public override string ToString()
        {
            return $"Book Id: {BookId}, Author: {Author}";
        }
    }
}
