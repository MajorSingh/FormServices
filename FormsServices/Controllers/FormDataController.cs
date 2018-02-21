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
                vpath = createFolder("FormsData");

               IEnumerable<string> files= System.IO.Directory.EnumerateFileSystemEntries(vpath);
                foreach(string file in files)
                array.Add(file.Replace(vpath + "\\",""));

            }catch(Exception ex)
            {
                array.Add(ex.ToString());
            }
            return array;
        }

        // GET: api/FormData/5
        [HttpGet("{id}", Name = "Get")]
        public void Get(string id)
        {
            string vpath = createFolder("FormsData");

            vpath = string.Format("{0}\\{1}", vpath, id);

           byte[] buffer = System.IO.File.ReadAllBytes(vpath);

            Response.ContentLength=buffer.Length;
            Response.ContentType = "application/json";
            Response.Body.Write(buffer, 0, buffer.Length);
            
        }
        
        // POST: api/FormData
        [HttpPost]
        public object Post([FromBody]object value)
        {
           
            string vpath = string.Empty;
            vpath = createFolder("FormsData");
            try
            {
                vpath = FName(vpath);
                System.IO.StreamWriter f = System.IO.File.CreateText(vpath);
                f.WriteLine(value);
                f.Dispose();

            }
            catch (Exception ex)
            {

                return new string[] { ex.ToString() };
            }
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

        private string FName(string path)
        {
            string vpath = string.Empty;



            do
            {
                vpath = path;

                string filename = string.Format("\\datafile-{0}-{1}{2}.json", DateTime.Now.ToShortDateString().Replace("/", ""), string.Format("{0}{1}{2}",DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second), DateTime.Now.Millisecond.ToString());
                vpath += filename;
            } while (System.IO.File.Exists(vpath));

            return vpath;

        }

        private string createFolder(string folderName)
        {
            string vpath = string.Empty;
            try
            {
                vpath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                vpath = string.Format("{0}\\{1}",vpath, folderName);
                if (!System.IO.Directory.Exists(vpath))
                {
                    System.IO.Directory.CreateDirectory(vpath);
                }
            }
            catch (Exception ex)
            {
            }
            return vpath;
        }
    }
}
