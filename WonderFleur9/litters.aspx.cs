using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Custom.Data;
using Custom.Objects;
using DevExpress.Web.ASPxEditors;

namespace WonderFleur9
{
    public partial class litters : System.Web.UI.Page
    {

        private void BindGrid()
        {
            GridView1.DataSource = DataProvider.GetLittersList();
            GridView1.KeyFieldName = "Id";
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.lbTitle.Text = Custom.Settings.UserLanguage == Custom.Settings.Language.English ? "Comming litters" : "Ожидаемые пометы";
                this.BindGrid();
            }
        }

        protected void GridView1_RowCommand(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e)
        {
            Custom.Objects.Person litter = DataProvider.GetPerson((int)e.KeyValue);
            if (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design)
            {
                switch (e.CommandArgs.CommandName)
                {
                    case "Add":
                        Custom.Objects.Person person = new Custom.Objects.Person();
                        person.IsLitter = true;
                        DataProvider.AddPerson(person);
                        break;
                    case "Save":
                        ASPxMemo tb = (ASPxMemo)GridView1.FindRowCellTemplateControl(e.VisibleIndex, GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "tbTitle");
                        if (tb != null)
                            litter.Comment = tb.Text.Trim();
                        ASPxComboBox c2 = (ASPxComboBox)GridView1.FindRowCellTemplateControl(e.VisibleIndex, GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "cbFather");
                        if (c2 != null)
                        {
                            try
                            {
                                litter.FatherId = (int)c2.Value;
                            }
                            catch
                            {
                                litter.FatherId = 0;
                            }
                            litter.Father = c2.Text;
                        }
                        c2 = (ASPxComboBox)GridView1.FindRowCellTemplateControl(e.VisibleIndex, GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "cbMother");
                        if (c2 != null)
                        {
                            try
                            {
                                litter.MotherId = (int)c2.Value;
                            }
                            catch
                            {
                                litter.MotherId = 0;
                            }
                            litter.Mother = c2.Text;
                        }
                        Custom.Objects.Image[] images = DataProvider.Gallery.GetImagesList(litter.GalleryId);
                        if (images != null && images.Length == 2)
                        {
                            DevExpress.Web.ASPxUploadControl.ASPxUploadControl upload = (DevExpress.Web.ASPxUploadControl.ASPxUploadControl)GridView1.FindRowCellTemplateControl(e.VisibleIndex, GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "uploadFather");
                            if (upload != null && upload.UploadedFiles != null && upload.UploadedFiles.Length > 0 && upload.UploadedFiles[0].FileBytes.Length > 0)
                            {
                                images[0].Body = upload.UploadedFiles[0].FileBytes;
                                DataProvider.Gallery.UpdateImage(images[0]);
                            }
                            upload = (DevExpress.Web.ASPxUploadControl.ASPxUploadControl)GridView1.FindRowCellTemplateControl(e.VisibleIndex, GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "uploadMother");
                            if (upload != null && upload.UploadedFiles != null && upload.UploadedFiles.Length > 0 && upload.UploadedFiles[0].FileBytes.Length > 0)
                            {
                                images[1].Body = upload.UploadedFiles[0].FileBytes;
                                DataProvider.Gallery.UpdateImage(images[1]);
                            }
                        }
                        DataProvider.SavePerson(litter);
                        break;
                    case "Delete":
                        DataProvider.DelPerson(litter.Id);
                        break;
                }
            }
            this.BindGrid();
        }

        protected void cbFather_Load(object sender, EventArgs e)
        {
            ASPxComboBox cb2 = (ASPxComboBox)sender;
            cb2.Items.Clear();
            cb2.Items.Add("", 0);
            foreach (Custom.Objects.Person pers in DataProvider.GetPersonListBySex(0))
            {
                cb2.Items.Add(pers.Name_en, pers.Id);
            }
        }

        protected void cbMother_Load(object sender, EventArgs e)
        {
            ASPxComboBox cb2 = (ASPxComboBox)sender;
            cb2.Items.Clear();
            cb2.Items.Add("", 0);
            foreach (Custom.Objects.Person pers in DataProvider.GetPersonListBySex(1))
            {
                cb2.Items.Add(pers.Name_en, pers.Id);
            }
        }

        protected void cmdNew_Click(object sender, ImageClickEventArgs e)
        {
            Custom.Objects.Person person = new Custom.Objects.Person();
            person.IsLitter = true;
            if(Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design)
                DataProvider.AddPerson(person);
            this.BindGrid();
        }
    }
}
