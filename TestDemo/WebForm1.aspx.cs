using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestDemo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        static int page = 1;
        long recordCount;
        static Repeater OldData = new Repeater ();

        public MongoController Result { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var result = new MongoController("collection1");
            Result = result;
            Repeater1.DataSource = Result.GetCollectionsPaged(page, 20, out recordCount);
            Repeater1.DataBind();

            if(!IsPostBack)
            {
                OldData = Repeater1;
            }

        }


        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var source = (Collections)e.Item.DataItem;

                Literal ltlid = (Literal)e.Item.FindControl("ltlid");
                ltlid.Text = source._id.ToString();

                Literal ltlname = (Literal)e.Item.FindControl("ltlname");
                ltlname.Text = source.name.ToString();

                Literal ltlage = (Literal)e.Item.FindControl("ltlage");
                ltlage.Text = source.age.ToString();

            }
        }

        protected void Page_Click(object sender, EventArgs e)
        {
            Button pageButton = sender as Button;
            switch (pageButton.Text)
            {
                case "第一页":
                    page = 1;
                    break;
                case "上一页":
                    page--;
                    break;
                case "下一页":
                    page++;
                    break;
                case "最后一页":
                    page = (int)Math.Ceiling((double)recordCount / 20);
                    break;
                default:
                    break;
            }
            if (page < 1) page = 1;
            if (page > (int)recordCount) page = (int)Math.Ceiling((double)recordCount / 20);

            Repeater1.DataSource = Result.GetCollectionsPaged(page, 20, out recordCount);
            Repeater1.DataBind();

            OldData = Repeater1;
        }

        protected void Find_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_findText.Text))
            {
                Repeater1.DataSource = Result.FindAllData();
                Repeater1.DataBind();
            }
            else
            {
                Repeater1.DataSource = Result.FindSomeDataByName(_findText.Text);
                Repeater1.DataBind();
            }

            OldData = Repeater1;

        }

        //批量删除
        protected void Delete_Click(object sender, EventArgs e)
        {

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddForm.aspx");
        }

        //批量修改
        protected void Update_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in OldData.Controls)
            {
                CheckBox _ck = (CheckBox)ctr.FindControl("cbSelected");
                if (_ck != null)
                {
                    if (_ck.Checked)
                    {
                        Literal _ltid = (Literal)ctr.FindControl("cbSelected");
                    }
                }
            }

        }

        protected void Close_Click(object sender, EventArgs e)
        {

        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            var comandName = e.CommandName;
            var commandValue = e.CommandArgument;
            switch (comandName)
            {
                case "Detail":
                    Response.Redirect("About.aspx?_id=" + commandValue);
                    break;
                default:
                    break;
            }
        }

        protected void Checked_Change(object sender, EventArgs e)
        {
            foreach (Control ctr in OldData.Controls)
            {
                CheckBox _ck = (CheckBox)ctr.FindControl("cbSelected");
                if (_ck != null && _ck.Checked == false)
                {
                    _ck.Checked = true;

                }
                else
                {
                    _ck.Checked = false;
                }
            }
        }


    }
}