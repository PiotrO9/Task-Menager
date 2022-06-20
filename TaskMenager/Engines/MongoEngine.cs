using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager.Engines
{
    internal class MongoEngine
    {
        private IMongoDatabase db;

        public MongoEngine(string database)
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://dbUser:dbUserPassword@cluster0.mznot.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            db = client.GetDatabase(database);
        }

        public void InsertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }
        public bool FindRecordToLogin<T>(string table, string login, string password)
        {
            var collection = db.GetCollection<T>(table);
            var LoginFilter = Builders<T>.Filter.Eq("Login", login) & Builders<T>.Filter.Eq("Password", password);

            try
            {
                var FoundRecord = collection.Find(LoginFilter).First();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public T LoadRecordByLogin<T>(string table, string login)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("Login", login);

            return collection.Find(filter).First();
        }
    }
}
