using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataClassifierAPI
{
    public class MongoManager
    {
        IMongoDatabase db;

        public MongoManager(string database)
        {
            var client = new MongoClient("mongodb+srv://project_user:projuserpass@cluster0.z5c5c.mongodb.net/test");
            db = client.GetDatabase(database);
        }

        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }

        public List<T> LoadRecords<T>(string table)
        {
            var collection = db.GetCollection<T>(table);
            return collection.Find(new BsonDocument()).ToList();
        }

        public T LoadRecordById<T>(string table, int id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Id", id);

            return collection.Find(filter).First();
        }
        //Similar to a merge function,
        //If it's there update it ptherwise create it.
        public void UpsertRecord<T>(string table, int id, T record)
        {
            var collection = db.GetCollection<T>(table);
            var result = collection.ReplaceOne(
                new BsonDocument("_id", id),
                record,
                new ReplaceOptions { IsUpsert = true });
        }

        public void DeleteRecord<T>(string table, int id)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", id);
            collection.DeleteOne(filter);
        }
    }
}
