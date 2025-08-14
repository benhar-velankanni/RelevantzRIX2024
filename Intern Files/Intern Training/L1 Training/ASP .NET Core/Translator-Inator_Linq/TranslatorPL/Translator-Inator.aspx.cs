using Org.BouncyCastle.Tls;
using System;
using System.Web.UI.WebControls;
using TranslatorBAL;
using TranslatorMD;

namespace TranslatorPL
{
    public partial class Translator_Inator : System.Web.UI.Page
    {

        TranslatorBal _translatorBAL = new TranslatorBal();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindGrid();
        }

        private void BindGrid()
        {
            grdTranslationData.DataSource = _translatorBAL.GetAllTranslations();
            grdTranslationData.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            string translationString = txtTranslationString.Text.Trim();
            string fromLang = ddlFromLang.SelectedValue;
            string toLang = ddlToLang.SelectedValue;

            if (string.IsNullOrEmpty(translationString) || string.IsNullOrEmpty(fromLang) || string.IsNullOrEmpty(toLang))
            {
                lblError.Text = "All fields are required.";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (fromLang == toLang)
            {
                lblError.Text = "From and To languages cannot be the same.";
                lblError.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Translation translation = new Translation
            {
                TranslationString = txtTranslationString.Text,
                FromLang = ddlFromLang.Text,
                ToLang = ddlToLang.Text,
            };
            _translatorBAL.InsertTranslation(translation);
            BindGrid();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txtSearchBox.Text.Trim(), out id))
            {
                Translation translation = _translatorBAL.GetTranslationById(id);
                if (translation != null)
                {
                    lblSearchResult.ForeColor = System.Drawing.Color.Green;
                    lblSearchResult.Text = $"<b>Translation ID:</b> {translation.TranslationId}<br/>" +
                                           $"<b>Translation String:</b> {translation.TranslationString}<br/>" +
                                           $"<b>From Language:</b> {translation.FromLang}<br/>" +
                                           $"<b>To Language:</b> {translation.ToLang}";
                }
                else
                {
                    lblSearchResult.ForeColor = System.Drawing.Color.Red;
                    lblSearchResult.Text = "No Translation Found.";
                }
            }
            else
            {
                lblSearchResult.ForeColor = System.Drawing.Color.Red;
                lblSearchResult.Text = "Please enter a valid numeric ID.";
            }
        }

        protected void grdTranslationData_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            grdTranslationData.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void grdTranslationData_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(grdTranslationData.DataKeys[e.RowIndex].Value);
            var row = grdTranslationData.Rows[e.RowIndex];
            DropDownList ddlFromLang = (DropDownList)grdTranslationData.Rows[e.RowIndex].FindControl("ddlEditFromLang");
            DropDownList ddlToLang = (DropDownList)grdTranslationData.Rows[e.RowIndex].FindControl("ddlEditToLang");

            Translation translation = new Translation
            {
                TranslationId = id,
                TranslationString = ((TextBox)row.Cells[1].Controls[0]).Text,
                FromLang = ddlFromLang?.SelectedValue,
                ToLang = ddlToLang?.SelectedValue,
            };
            _translatorBAL.UpdateTranslation(translation);
            grdTranslationData.EditIndex = -1;
            BindGrid();
        }

        protected void grdTranslationData_RowCancelingEdit(object sender, System.Web.UI.WebControls.GridViewCancelEditEventArgs e)
        {
            grdTranslationData.EditIndex = -1;
            BindGrid();
        }

        protected void grdTranslationData_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grdTranslationData.DataKeys[e.RowIndex].Value);
            _translatorBAL.DeleteTranslation(id);
            BindGrid();
        }

        protected void grdTranslationData_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
            {
                // Get the current data item
                var dataItem = (Translation)e.Row.DataItem;

                // Find the DropDownLists
                DropDownList ddlFrom = (DropDownList)e.Row.FindControl("ddlEditFromLang");
                DropDownList ddlTo = (DropDownList)e.Row.FindControl("ddlEditToLang");

                if (ddlFrom != null)
                {
                    ddlFrom.SelectedValue = dataItem.FromLang;
                }

                if (ddlTo != null)
                {
                    ddlTo.SelectedValue = dataItem.ToLang;
                }
            }
        }

    }
}