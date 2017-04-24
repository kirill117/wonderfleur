using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Custom.Data;
using Custom.Objects;
using Custom;

namespace WonderFleur9.Controls
{
    public partial class PersonCart : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Custom.Objects.Person person = DataProvider.GetPerson(PersonId);
            if (!this.Page.IsPostBack)
            {
                if (Custom.Settings.UserLanguage == Settings.Language.English)
                {
                    this.lbColor.Text = "Color";
                    this.lbDateBirth.Text = "Birth";
                    this.lbFather.Text = "Father";
                    this.lbMother.Text = "Mother";
                    this.lbOwner.Text = "Owner";
                    this.cmbGallery.Text = "Gallery";
                }
                if (Custom.Settings.CurrentUser.Mode == Custom.Settings.UserMode.View)
                {
                    this.lbName.Text = person.Name_en + " (" + person.Name_ru + ")";
                    this.lbTitul.Text = person.Titul;
                    this.lbOwnerValue.Text = person.Owner;
                    this.hlFather.Text = person.Father;
                    this.hlMother.Text = person.Mother;
                    if (person.FatherId > 0)
                        this.hlFather.NavigateUrl = string.Format("~/Person.aspx?PersonId={0}", person.FatherId);
                    if (person.MotherId > 0)
                        this.hlMother.NavigateUrl = string.Format("~/Person.aspx?PersonId={0}", person.MotherId);
                    this.lbDateBirthValue.Text = person.DateBirth;
                    this.lbColorValue.Text = person.Color;
                    this.tblPersonView.Visible = true;
                }
                else
                {
                    this.lbName.Text = "";
                    this.lbTitul.Text = "Страница питомца";
                    this.DateEdit.Text = person.DateBirth;
                    this.EditFather.DataSource = DataProvider.GetPersonListBySex(0);
                    this.EditFather.TextField = "Name_en";
                    this.EditFather.ValueField = "Id";
                    this.EditFather.DataBind();
                    this.EditFather.Value = person.FatherId;
                    this.EditFather.Text = person.Father;

                    this.EditMother.DataSource = DataProvider.GetPersonListBySex(1);
                    this.EditMother.TextField = "Name_en";
                    this.EditMother.ValueField = "Id";
                    this.EditMother.DataBind();
                    this.EditMother.Value = person.MotherId;
                    this.EditMother.Text = person.Mother;

                    this.EditName_en.Text = person.Name_en;
                    this.EditName_ru.Text = person.Name_ru;

                    this.EditTitul_en.Text = person.Titul_en;
                    this.EditTitul_ru.Text = person.Titul_ru;
                    this.EditOwner.Text = person.Owner;
                    this.EditColor.Text = person.Color;
                    this.cbxVeteran.Value = person.IsActual;
                    this.tblPersonEdit.Visible = true;
                }
            }
            this.UserContext1.ContextId = person.ContextId;
            this.TitleImage1.GalleryId = person.GalleryId;
            this.cmbGallery.PostBackUrl = string.Format("~/ShowGallery.aspx?id={0}", person.GalleryId);
        }

        public int PersonId
        {
            get
            {
                return Convert.ToInt32(Page.Request.QueryString["PersonId"]);
            }
        }

        protected void cmbSave_Click(object sender, EventArgs e)
        {
            Custom.Objects.Person person = DataProvider.GetPerson(PersonId);
            person.Name_en = this.EditName_en.Text;
            person.Name_ru = this.EditName_ru.Text;
            person.DateBirth = this.DateEdit.Text;
            person.Titul_en = this.EditTitul_en.Text;
            person.Titul_ru = this.EditTitul_ru.Text;
            person.Owner = this.EditOwner.Text;
            person.Color = this.EditColor.Text;
            person.Mother = this.EditMother.Text;
            person.MotherId = this.EditMother.SelectedItem == null ? 0 : (int)this.EditMother.Value;
            person.Father = this.EditFather.Text;
            person.FatherId = this.EditFather.SelectedItem == null ? 0 : (int)this.EditFather.Value;
            person.IsActual = (bool)this.cbxVeteran.Value;
            DataProvider.SavePerson(person);
        }
    }
}