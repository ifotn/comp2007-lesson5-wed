using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference the EF models
using comp2007_lesson5_wed.Models;
using System.Web.ModelBinding;

namespace comp2007_lesson5_wed
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading the page for the first time, populate student grid
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        {
            //connect to EF
            using (comp2007Entities db = new comp2007Entities()) {

                //query the students table using EF and LINQ
                var Students = from s in db.Students
                               select s;

                //bind the result to the gridview
                grdStudents.DataSource = Students.ToList();
                grdStudents.DataBind();

            }
        }
    }
}