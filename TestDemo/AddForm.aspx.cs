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
    public partial class AddForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            Collections new_collection = new Collections();
            new_collection._id = ObjectId.GenerateNewId();  //生成一个新的ID
            new_collection.name = tb_name.Text;
            new_collection.age = Convert.ToInt32(tb_age.Text);

            MongoController myDB = new MongoController("collection1");
            myDB.InsertOne(new_collection);

            DialogResult dr = MessageBox.Show("添加成功!", "结束添加?", MessageBoxButtons.OKCancel);

            if (dr == DialogResult.OK)
            {
                Response.Redirect("WebForm1.aspx");
            }
            else
            {
                //
            }
        }


        protected void Cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm1.aspx");
        }
    }
}