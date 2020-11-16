using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataClassifierAPI.Models
{
    public class UserModel
    {
        [BsonId]
        public int Id { get; set; }
        public string username { get; set; }
        public string Password { get; set; }
        public string email { get; set; }
        [BsonElement("DoB")]
        public string DateOfBirth { get; set; }
    }
}
