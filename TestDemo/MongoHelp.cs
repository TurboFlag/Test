using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestDemo
{
    /// <summary>
    /// 连接数据库
    /// </summary>
    public class MongoHelp
    {
        /// <summary>
        /// 传入的IP和端口
        /// </summary>
        public string Strconn { get; set; }

        /// <summary>
        /// 数据库名
        /// </summary>
        public string DbName { get; set; }


        /// <summary>
        /// 实例化数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="CollectionName"></param>
        /// <returns></returns>
        public MongoCollection<T> GetCollection<T>(string CollectionName)
        {
            MongoClientSettings settings = new MongoClientSettings
                    {
                        Server = new MongoServerAddress(Strconn, 27017)
                    };
            MongoClient _Client;
            _Client = new MongoClient(settings);
            MongoServer server = _Client.GetServer();
            //获得数据库cnblogs MongoDB.Driver.MongoServer.Create(Strconn);
            MongoDatabase db = server.GetDatabase(DbName);

            return db.GetCollection<T>(CollectionName);
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="dbName"></param>
        public MongoHelp(string connectionString, string dbName)
        {
            Strconn = connectionString;
            DbName = dbName;
        }
    }
}