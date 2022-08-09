using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class DND : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GridView1.DataSource = SqlDataSource1;
            GridView1.DataBind();
        }

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();
        Label10.Text = "";
        GridView1.EditRowStyle.BackColor = System.Drawing.Color.Orange;
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();
        Label10.Text = "";
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        Label srno = GridView1.Rows[e.RowIndex].FindControl("Label9") as Label;
        TextBox letterno = GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox;
        TextBox letterheading = GridView1.Rows[e.RowIndex].FindControl("TextBox2") as TextBox;
        TextBox dated = GridView1.Rows[e.RowIndex].FindControl("TextBox3") as TextBox;
        TextBox DG = GridView1.Rows[e.RowIndex].FindControl("TextBox4") as TextBox;
        TextBox ADG = GridView1.Rows[e.RowIndex].FindControl("TextBox5") as TextBox;
        TextBox Status = GridView1.Rows[e.RowIndex].FindControl("TextBox6") as TextBox;
        String mycon = @"Data Source=.\sqlexpress; Initial Catalog=DND; Integrated Security=True";
        String updatedata = "Update DNDdata set letterno='" + letterno.Text + "', letterheading='" + letterheading.Text + "', dated='" + dated.Text + "', DG='" + DG.Text + "', ADG='" + ADG.Text + "', Status='" + Status.Text + "' where srno=" + srno.Text;
        SqlConnection con = new SqlConnection(mycon);
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = updatedata;
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        Label10.Text = "Row Data Has Been Updated Successfully";
        GridView1.EditIndex = -1;
        SqlDataSource1.DataBind();
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();
    }

    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        TextBox srno = GridView1.FooterRow.FindControl("TextBox7") as TextBox;
        TextBox letterno = GridView1.FooterRow.FindControl("TextBox8") as TextBox;
        TextBox letterheading = GridView1.FooterRow.FindControl("TextBox9") as TextBox;
        TextBox dated = GridView1.FooterRow.FindControl("TextBox10") as TextBox;
        TextBox DG = GridView1.FooterRow.FindControl("TextBox11") as TextBox;
        TextBox ADG = GridView1.FooterRow.FindControl("TextBox12") as TextBox;
        TextBox Status = GridView1.FooterRow.FindControl("TextBox13") as TextBox;
        String query = "insert into DNDdata(srno,letterno,letterheading,dated,DG,ADG,Status) values(" + srno.Text + ",'" + letterno.Text + "','" + letterheading.Text + "','" + dated.Text + "','" + DG.Text + "','" + ADG.Text + "','" + Status.Text + "')";
        String mycon = @"Data Source=.\sqlexpress; Initial Catalog=DND; Integrated Security=true";
        SqlConnection con = new SqlConnection(mycon);
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = query;
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        Label10.Text = "New Row Inserted Successfully";
        SqlDataSource1.DataBind();
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label srno = GridView1.Rows[e.RowIndex].FindControl("Label2") as Label;
        String mycon = @"Data Source=.\sqlexpress; Initial Catalog=DND; Integrated Security=true";
        String updatedata = "delete from DNDdata where srno=" + srno.Text;
        SqlConnection con = new SqlConnection(mycon);
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = updatedata;
        cmd.Connection = con;
        cmd.ExecuteNonQuery();
        Label10.Text = "Row Data Has Been Deleted Successfully";
        GridView1.EditIndex = -1;
        SqlDataSource1.DataBind();
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();
    }
}