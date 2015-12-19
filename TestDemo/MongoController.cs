using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace TestDemo
{
    /// <summary>
    /// 数据库控制（注释下的为另外几种写法<发生Bug概不负责>< >.< </发生Bug概不负责>>）
    /// </summary>
    public class MongoController
    {
        private const string ipAdress = "mongodb://192.168.20.101";//IP地址
        private const string databaseName = "test";//数据库名

        /// <summary>
        /// 获取连接的数据库
        /// </summary>
        public MongoCollection<Collections> MyDB { get; set; }

        /// <summary>
        /// 实例化数据库
        /// </summary>
        /// <param name="tab"></param>
        public MongoController(string tab)
        {
            MongoHelp helper = new MongoHelp(ipAdress, databaseName);
            MyDB = helper.GetCollection<Collections>(tab);
        }

        /// <summary>
        /// 批量插入数据(暂未实现)
        /// </summary>
        /// <param name="dt"></param>
        public void InsertSome(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                MyDB.Insert(new Collections
                {
                    name = dt.Rows[i][0].ToString(),
                    age = (int)dt.Rows[i][1]
                });
            }
        }

        /// <summary>
        /// 插入一条数据
        /// </summary>
        /// <param name="collection"></param>
        public void InsertOne(Collections collection)
        {
            MyDB.Insert(collection);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(ObjectId id)
        {
            var query = Query<Collections>.EQ(e => e._id, id);
            MyDB.Remove(query);
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public List<Collections> GetCollectionsPaged(Int32 pageIndex, Int32 pageSize, out Int64 recordCount)
        {
            //var records = MyDB.FindAll();

            //recordCount = records.Count();

            //return records.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            recordCount = 10000;

            return MyDB.FindAll().ToList();
            //var db = MyDB.FindAll();
            //recordCount = db.Count();
            //return db.SetLimit(20).ToList();
        }

        /// <summary>
        /// 查询部分结果集
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Collections> FindSomeDataByName(string name)
        {
            return MyDB.AsQueryable().Where(e => e.name == name).ToList();

            //var query = Query<Collections>.EQ(e => e.name, name);
            //return MyDB.Find(query).ToList();
        }

        /// <summary>
        /// 根据ID进行查询
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
        public Collections FindOneData(ObjectId _id)
        {
            var query = Query<Collections>.EQ(e => e._id, _id);

            //return MyDB.FindOneById(_id);

            //var result = MyDB.AsQueryable().Where(item => item.name == name).FirstOrDefault();

            return MyDB.FindOne(query);
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public List<Collections> FindAllData()
        {
            //return MyDB.FindAll().ToList();
            var result = MyDB.AsQueryable().ToList();
            return result;

        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="_id"></param>
        /// <param name="collection"></param>
        public void UpdateData(ObjectId _id, Collections collection)
        {
            var query = Query<Collections>.EQ(e => e._id, _id);
            MyDB.Update(query, Update<Collections>.Set(item => item.age, collection.age).Set(item => item.name, collection.name), UpdateFlags.Upsert);

        }

        /// <summary>
        /// 批量修改(暂未实现)
        /// </summary>
        /// <param name="_idList"></param>
        /// <param name="collection"></param>
        public void UpdateSomeData(List<ObjectId> _idList, Collections collection)
        {
            //var query = Query<>
            //MyDB.Update(query, Update<Collections>.Set(item => item.age, collection.age), UpdateFlags.Upsert);
        }
    }
}