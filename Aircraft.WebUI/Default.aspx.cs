using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aircraft.WebUI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            var client = ServiceClient.GetClient();

            if (client != null)
            {
                DataGrid.DataSource = client.Retrieve();
                DataGrid.DataBind();
            }
        }

        protected void DataGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {

            DataGrid.EditItemIndex = e.Item.ItemIndex;
            BindGrid();
        }

        protected void DataGrid_CancelCommand(object source, DataGridCommandEventArgs e)
        {

            DataGrid.EditItemIndex = -1;
            BindGrid();
        }

        protected void DataGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            TextBox txtModel = (TextBox)e.Item.Cells[0].Controls[0];
            TextBox txtSerial = (TextBox)e.Item.Cells[1].Controls[0];
            int Id = (int)DataGrid.DataKeys[e.Item.ItemIndex];

            var client = ServiceClient.GetClient();

            if (client != null)
            {
                client.Persist(Id, txtModel.Text, txtSerial.Text);
            }

            DataGrid.EditItemIndex = -1;
            BindGrid();
        }

        protected void DataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int Id = (int)DataGrid.DataKeys[e.Item.ItemIndex];

            var client = ServiceClient.GetClient();

            if (client != null)
            {
                client.Remove(Id);
            }

            DataGrid.EditItemIndex = -1;
            BindGrid();
        }

        protected void cmdInsert_Click(object sender, EventArgs e)
        {
            var client = ServiceClient.GetClient();

            if (client != null)
            {
                client.Persist(-1, txtModel.Text, txtSerial.Text);
            }

            DataGrid.EditItemIndex = -1;
            BindGrid();
        }
    }
}