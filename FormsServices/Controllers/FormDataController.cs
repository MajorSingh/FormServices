using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormsServices.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FormDataController : Controller
    {
        // GET: api/FormData
        [HttpGet]
        public IEnumerable<string> Get()

        {

            string vpath="empty";
            List<string> array = new List<string>();
            array.Add("item 00001");
            try
            {
                vpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                array.Add(vpath);
            }catch(Exception ex)
            {
                array.Add(ex.ToString());
            }
            return array;
        }

        // GET: api/FormData/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/FormData
        [HttpPost]
        public object Post([FromBody]object value)
        {
            return value;
        }
        
        // PUT: api/FormData/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private void sendEmail(object value)
        {

            System.Net.Mail.MailMessage mailmessage = new System.Net.Mail.MailMessage();
          

        }
    }
}
