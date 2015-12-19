using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace TestDemo
{
    [BsonIgnoreExtraElements]
    public class Collections
    {
        /// <summary>
        /// 键
        /// </summary>
        [BsonId]
        [DataMember]
        public ObjectId _id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [DataMember]
        public int age { get; set; }
    }
}