using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using pozicam_web_forms.Appcode.BussinessLayer;
using pozicam_web_forms.Appcode.Models;
namespace pozicam_web_forms.Forms.ManagmentTools
{
    public partial class PlanningToolForm : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (Session["DelayedReload"] != null)
            {
                if ((bool)Session["DelayedReload"] == true)
                {
                    var script = @"
                setTimeout(location.reload.bind(location), 500);
                ";
                    ClientScript.RegisterStartupScript(this.GetType(), "___refresh___", script, true);
                    Session["DelayedReload"] = false;
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (AppSecurity.CheckAdmin(Session["CurrentUser"] as User))
            {
                formPleaseLogin.Visible = false;
                panelPlanningTool.Visible = true;
                btnDeleteTask.Visible = true;
                btnDeleteTask.CssClass = "btn btn-danger";
                if (GetSelectedTasks().Count == 0)
                { btnDeleteTask.CssClass = "btn btn-danger disabled";
                    btnAddTask.Visible = true;
                }

                if (!IsPostBack)
                {
                    using (var context = new pozicamskEntities())
                    {
                        gvTask.DataSource = context.ManagmentTask.ToList();
                    }
                    gvTask.DataKeyNames = new string[] { "Id" };
                    gvTask.DataBind();
                }
            }
            else
            {
                formPleaseLogin.Visible = true;
                panelPlanningTool.Visible = false;
            }

        }



        protected void btnCompleteTask_Click(object sender, EventArgs e)
        {

        }
        protected List<ManagmentTask> GetSelectedTasks()
        {
            var selectedTasks = new List<ManagmentTask>();
            foreach (GridViewRow gvRow in gvTask.Rows)
            {
                using (var context = new pozicamskEntities())
                {
                    if ((gvRow.FindControl("chbTaskSelector") as CheckBox).Checked)
                    {
                        var taskid = (Int32)gvTask.DataKeys[gvRow.RowIndex]["Id"];
                        selectedTasks.Add(
                            (from task in context.ManagmentTask
                             where task.Id == taskid
                             select task).First());
                    }

                }

            }
            return selectedTasks;
        }

        protected void chbTaskSelector_CheckedChanged(object sender, EventArgs e)
        {
            var row = (sender as CheckBox).Parent.Parent as GridViewRow;
            var index = row.RowIndex;
            var TaskId = (Int32)gvTask.DataKeys[index]["Id"];
            var selectedTasks = GetSelectedTasks();
            if (selectedTasks != null)
            {
                if (selectedTasks.Count > 0)
                {
                    var firstTask = selectedTasks[0];
                    tbTaskName.Text = firstTask.Name;
                    tbTaskDescription.Text = firstTask.Description;
                    tbTaskPriority.Text = firstTask.Priority.ToString();
                    tbTaskCost.Text = firstTask.Cost.ToString();
                    tbTaskRent.Text = firstTask.Rent.ToString();
                    calTaskDeadline.SelectedDate = (DateTime)firstTask.DeadlineDate;
                    btnApplyChanges.Visible = true;
                    btnAddTask.Visible = false;

                }
                else
                {
                    btnApplyChanges.Visible = false;
                    btnAddTask.Visible = true;
                }
            }

        }

        protected void gvTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var task = e.Row.DataItem as ManagmentTask;
                var completeButton = e.Row.FindControl("btnCompleteTask") as Button;
                using (var context = new pozicamskEntities())
                {
                    var state = (from s in context.ManagmentState
                                 where s.id == task.ManagmentStateId
                                 select s).First();

                    if (state.id == 2)
                    {
                        completeButton.Visible = true;

                    }
                    else
                    {
                        completeButton.Visible = false;

                    }
                }
            }
        }

        protected void btnApplyChanges_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddTask_Click(object sender, EventArgs e)
        {
            using (var context = new pozicamskEntities())
            {
                
                if (AppSecurity.CheckAdmin(Session["CurrentUser"] as User))
                {
                    ManagmentTask newTask = new Appcode.Models.ManagmentTask();



                    newTask.Name = tbTaskName.Text;
                    newTask.Description = tbTaskDescription.Text;
                    newTask.Priority = Convert.ToInt32(tbTaskPriority.Text);

                    newTask.Cost = Convert.ToDecimal(tbTaskCost.Text);
                    newTask.Rent = Convert.ToDecimal(tbTaskRent.Text);
                    newTask.CreationDate = DateTime.Now;
                    newTask.CreatorUserId = (Session["CurrentUser"] as User).Id;
                    newTask.DeadlineDate = calTaskDeadline.SelectedDate;

                    newTask.ManagmentStateId = 1;

                    context.ManagmentTask.Add(newTask);
                    context.SaveChanges();
                    Session["DelayedReload"] = true;
                }
                    
                    string url = Request.RawUrl.ToString();
                    Response.Redirect(url); // redirect on itself

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var tesksToDelete = GetSelectedTasks();
            using (var context = new pozicamskEntities())
            {
                
                foreach (var taskToDel in tesksToDelete)
                {
                    var taskToDelete = (from task in context.ManagmentTask
                                        where (task.Id == taskToDel.Id)
                                        select task).First();
                    context.ManagmentTask.Remove(taskToDelete);

                }
                context.SaveChanges();
                string url = Request.RawUrl.ToString();
                Response.Redirect(url); // redirect on itself
            }
        }
    }
}