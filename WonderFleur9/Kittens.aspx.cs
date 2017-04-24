using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Custom.Data;
using DevExpress.Web.ASPxEditors;

namespace WonderFleur9
{
    public partial class Kittens : System.Web.UI.Page
    {
        private void BindGrid()
        {
            Custom.Objects.Person[] persons = DataProvider.GetKittensList();
            GridView1.DataSource = persons;
            GridView1.KeyFieldName = "Id";
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label1.Text = Custom.Settings.UserLanguage == Custom.Settings.Language.English ? "Kittens" : "Котята для Вас";
                GridView1.Columns[GridView1.Columns.Count - 1].Visible = Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design;
                this.BindGrid();
            }
        }

        protected void GridView1_RowCommand(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewRowCommandEventArgs e)
        {
            if (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design)
            {
                switch (e.CommandArgs.CommandName)
                {
                    case "Add":
                        DataProvider.AddPerson(new Custom.Objects.Person(true));
                        break;
                    case "Edit":
                        GridView1.StartEdit(e.VisibleIndex);
                        break;
                    case "Update":
                        Custom.Objects.Person person = DataProvider.GetPerson((int)e.KeyValue);
                        ASPxDateEdit c1 = (ASPxDateEdit)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "cbDate");
                        if (c1 != null)
                            person.DateBirth = c1.Text;
                        ASPxComboBox c2 = (ASPxComboBox)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "cbSex");
                        if (c2 != null)
                            person.Sex = (int)c2.Value;
                        c2 = (ASPxComboBox)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "cbFather");
                        if (c2 != null)
                        {
                            try
                            {
                                person.FatherId = (int)c2.Value;
                            }
                            catch
                            {
                                person.FatherId = 0;
                            }
                            person.Father = c2.Text;
                        }
                        c2 = (ASPxComboBox)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "cbMother");
                        if (c2 != null)
                        {
                            try
                            {
                                person.MotherId = (int)c2.Value;
                            }
                            catch
                            {
                                person.MotherId = 0;
                            }
                            person.Mother = c2.Text;
                        }
                        ASPxTextBox c3 = (ASPxTextBox)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "tbColor");
                        if (c3 != null)
                            person.Color = c3.Text;
                        c3 = (ASPxTextBox)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "tbPomet");
                        if (c3 != null)
                            person.Comment = c3.Text;
                        ASPxMemo c4 = (ASPxMemo)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "tbComment");
                        if (c4 != null)
                            person.Titul = c4.Text;
                        DevExpress.Web.ASPxUploadControl.ASPxUploadControl upload = (DevExpress.Web.ASPxUploadControl.ASPxUploadControl)GridView1.FindEditRowCellTemplateControl(GridView1.Columns[0] as DevExpress.Web.ASPxGridView.GridViewDataColumn, "Upload1");
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
                        }
                        DataProvider.SavePerson(person);
                        GridView1.CancelEdit();
                        break;
                    case "Delete":
                        DataProvider.DelPerson((int)e.KeyValue);
                        break;
                    case "Cancel":
                        GridView1.CancelEdit();
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
            if (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.Design)
                DataProvider.AddPerson(new Custom.Objects.Person(true));
            this.BindGrid();
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
    }
}
