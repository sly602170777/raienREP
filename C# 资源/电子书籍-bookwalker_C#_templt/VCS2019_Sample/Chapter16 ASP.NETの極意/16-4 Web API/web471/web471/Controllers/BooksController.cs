using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web471.Controllers
{
    [Produces("application/xml")]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        List<Models.Book> _lst;
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BooksController()
        {
            _lst = new List<Models.Book>();
            _lst.Add(new Models.Book { ID = 1, Title = "逆引き大全C#", Price = 1500, Pages = 500 });
            _lst.Add(new Models.Book { ID = 2, Title = "逆引き大全VB", Price = 2000, Pages = 300 });
            _lst.Add(new Models.Book { ID = 3, Title = "逆引き大全F#", Price = 1000, Pages = 200 });
            _lst.Add(new Models.Book { ID = 4, Title = "リファレンス本", Price = 1000, Pages = 200 });
        }



        // GET: api/Books
        [HttpGet]
        public IEnumerable<Models.Book> Get()
        {
            return _lst;
        }

        // GET: api/Books/5
        [HttpGet("{id}", Name = "Get")]
        public Models.Book Get(int id)
        {
            return _lst.FirstOrDefault(x => x.ID == id);
        }

        // POST: api/Books
        [HttpPost]
        public string Post([FromBody] Models.Book value)
        {
            return string.Format("post Title:{0}", value.Title);
        }

        // PUT: api/Books/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] Models.Book value)
        {
            return string.Format("post Title:{0}", value.Title);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return string.Format("delete ID:{0}", id);
        }
    }
}
