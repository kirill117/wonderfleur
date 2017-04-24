using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Custom.Data;
using DevExpress.Web.ASPxDataView;

namespace WonderFleur9
{
    public partial class Persons : System.Web.UI.Page
    {
        private void BindGrid()
        {
            Custom.Objects.Person[] persons;
            if (this.Type == 3)
                persons = DataProvider.GetVeteransList();
            else
                persons = DataProvider.GetPersonListBySex(this.Type);
            list.DataSource = persons;
            list.DataBind();

            foreach (DataViewItem dvi in list.Items)
            {
                Custom.Objects.Person pr = dvi.DataItem as Custom.Objects.Person;
                DevExpress.Web.ASPxEditors.ASPxLabel lb1 = (DevExpress.Web.ASPxEditors.ASPxLabel)list.FindItemControl("lbName", dvi);
                if (lb1 != null)
                {
                    lb1.Text = Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.View ? pr.Name : "Кличка";
                }
                lb1 = (DevExpress.Web.ASPxEditors.ASPxLabel)list.FindItemControl("lbTitul", dvi);
                if (lb1 != null)
                {
                    lb1.Text = Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.View ? pr.Titul : "Титул";
                }
                DevExpress.Web.ASPxEditors.ASPxButton ib2 = (DevExpress.Web.ASPxEditors.ASPxButton)list.FindItemControl("btn", dvi);
                if (ib2 != null)
                {
                    ib2.Image.Url = string.Format("~/GetImageUrl.ashx?id={0}&height=120", pr.ImageId);
                    ib2.PostBackUrl = string.Format("~/Person.aspx?PersonId={0}", pr.Id);
                }
                HtmlTable pnl = (HtmlTable)list.FindItemControl("pnEdit", dvi);
                if (pnl != null)
                    pnl.Visible = Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design;
                TextBox tb1 = (TextBox)list.FindItemControl("tbName", dvi);
                if (tb1 != null)
                {
                    tb1.Text = pr.Name;
                    tb1.Visible = Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design;
                }
                tb1 = (TextBox)list.FindItemControl("tbTitul", dvi);
                if (tb1 != null)
                {
                    tb1.Text = pr.Titul;
                    tb1.Visible = Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design;
                }
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string tit_ru = "";
                string tit_en = "Our pets";
                switch (this.Type)
                {
                    case 0:
                        tit_ru = "Наши коты";
                        tit_en = "Our studs";
                        break;
                    case 1:
                        tit_ru = "Наши кошки";
                        tit_en = "Our queens";
                        break;
                    case 3:
                        tit_ru = "Наши ветераны";
                        tit_en = "Our veterans";
                        break;
                }
                this.Label1.Text = Custom.Settings.UserLanguage == Custom.Settings.Language.English ? tit_en : tit_ru;
                if (this.Mode == 1 && Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design)
                    DataProvider.AddPerson(new Custom.Objects.Person(this.Type));
                if (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design)
                {
                    list.AllowPaging = false;
                    this.BindGrid();
                }
            }
            if (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.View)
            {
                list.AllowPaging = true;
                this.BindGrid();
            }
        }

        public int Type
        {
            get
            {
                int ret = -1;
                try
                {
                    int.TryParse(Request.QueryString["type"].ToString(), out ret);
                }
                catch
                {
                }
                return ret;
            }
        }

        public int Mode
        {
            get
            {
                int ret = -1;
                try
                {
                    int.TryParse(Request.QueryString["mode"].ToString(), out ret);
                }
                catch
                {
                }
                return ret;
            }
        }

        protected void list_ItemCommand(object source, DataViewItemCommandEventArgs e)
        {
            int personId = Convert.ToInt32(e.CommandArgument.ToString());
            Custom.Objects.Person person = DataProvider.GetPerson(personId);
            switch (e.CommandName)
            {
                case "Save":
                    list.FindItemControl("Upload", e.Item).Visible = false;
                    TextBox tb1 = (TextBox)list.FindItemControl("tbName", e.Item);
                    person.Name = tb1.Text;
                    tb1 = (TextBox)list.FindItemControl("tbTitul", e.Item);
                    person.Titul = tb1.Text;
                    this.Upload(person, e.Item);
                    DataProvider.SavePerson(person); 
                    break;
                case "Delete":
                    DataProvider.DelPerson(person.Id);
                    break;
                case "Upload":
                    this.Upload(person, e.Item);
                    break;
                case "Add":
                    person = new Custom.Objects.Person(this.Type);
                    person.Id = DataProvider.AddPerson(person);
                    person = DataProvider.GetPerson(person.Id);
                    if (this.Type == 3)
                        person.IsActual = false;
                    DataProvider.SavePerson(person); 
                    break;
            }
            this.BindGrid();
        }

        private void Upload(Custom.Objects.Person person,DataViewItem item)
        {
            DevExpress.Web.ASPxUploadControl.ASPxUploadControl upload = (DevExpress.Web.ASPxUploadControl.ASPxUploadControl)list.FindItemControl("Upload", item);
            if (upload.UploadedFiles != null && upload.UploadedFiles.Length > 0 && upload.UploadedFiles[0].FileBytes.Length > 0)
            {
                Custom.Objects.Image img = DataProvider.Gallery.GetImage(person.ImageId);
                if (img == null)
                    img = new Custom.Objects.Image();
                img.GalleryId = person.GalleryId;
                img.Body = upload.UploadedFiles[0].FileBytes;
                if (img.Id == 0)
                    person.ImageId = DataProvider.Gallery.AddImage(img);
                else
                    DataProvider.Gallery.UpdateImage(img);
                DevExpress.Web.ASPxEditors.ASPxButton ib2 = (DevExpress.Web.ASPxEditors.ASPxButton)list.FindItemControl("btn", item);
                if (ib2 != null)
                {
                    ib2.Image.Url = string.Format("~/GetImageUrl.ashx?id={0}&height=120", person.ImageId);
                }
            }
        }

        protected void cmdNew_Click(object sender, ImageClickEventArgs e)
        {
            var person = new Custom.Objects.Person(this.Type);
            person.Id = DataProvider.AddPerson(person);
            person = DataProvider.GetPerson(person.Id);
            if (this.Type == 3)
                person.IsActual = false;
            DataProvider.SavePerson(person);
            this.BindGrid();
        }

        protected void list_PageIndexChanged(object sender, EventArgs e)
        {
            this.BindGrid();
        }
    }
}
