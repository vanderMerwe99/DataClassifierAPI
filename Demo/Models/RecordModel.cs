using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class RecordModel
    {
        [BsonId]
        public int Id { get; set; }
        public string record { get; set; }
    }
}