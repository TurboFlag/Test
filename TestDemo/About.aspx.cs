using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace TestDemo
{
    public partial class About : System.Web.UI.Page
    {
        private ObjectId ID { get; set; }

        private Collections OldCollection { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MongoController myDB = new MongoController("collection1");
            var id = Request.QueryString["_id"];
            ID = new ObjectId(id);
            OldCollection = myDB.FindOneData(ID);

            if (!IsPostBack)
            {
                tb_name.Text = OldCollection.name;
                tb_age.Text = OldCollection.age.ToString();
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if(tb_name == null)
            {
                tb_name.Text = OldCollection.name;
            }

            if (tb_age == null)
            {
                tb_age.Text = OldCollection.name;
            }

            Collections new_collection = new Collections();
            new_collection.name = tb_name.Text;
            new_collection.age = Convert.ToInt32(tb_age.Text);

            DialogResult dr = MessageBox.Show("确认修改？", "修改", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                MongoController myDB = new MongoController("collection1");
                myDB.UpdateData(ID, new_collection);
                Response.Redirect("WebForm1.aspx");
            }
            else
            {

            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("删除？", "是否删除", MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                MongoController myDB = new MongoController("collection1");
                myDB.Delete(ID);
                Response.Redirect("WebForm1.aspx");
            }
            else
            {

            }
        }

        protected void Close_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}