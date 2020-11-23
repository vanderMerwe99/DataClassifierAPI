using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataClassifierAPI.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataClassifierAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadToController : ControllerBase
    {
        private MongoManager dbManager = new MongoManager("Data_Classifier");
        // GET: api/<CreateAccountController>
        [HttpGet]
        public int Get()
        {
            List<UserModel> list = dbManager.LoadRecords<UserModel>("Users");
            return list.Count;
        }

        // GET api/<CreateAccountController>/5
        [HttpGet("Loader")]
        public string Get(int id)
        {
            string str = dbManager.LoadRecordById<string>("Uploads", id);
            return str;
        }

        // POST api/<CreateAccountController>
        [HttpPost("Insert")]
        public string Post(string record, int id)
        {
            var doc = new BsonDocument();
            BsonElement element = new BsonElement("record", new BsonString(record));
            doc.Add(element);
            BsonElement elementID = new BsonElement("id", new BsonInt32(id));
            doc.Add(elementID);
            dbManager.InsertRecord("Uploads", doc);
            return "";
        }

        // PUT api/<CreateAccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CreateAccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
