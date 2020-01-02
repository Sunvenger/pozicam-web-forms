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


                if (!IsPostBack)
                {
                    LoadReminderControlPicker();
                    using (var context = new pozicamskEntities())
                    {
                        var tasks = (from task in context.ManagmentTask
                                     orderby task.CreationDate descending
                                     select task).ToList();
                        gvTask.DataSource = tasks;
                        gvTask.DataKeyNames = new string[] { "Id" };
                        gvTask.DataBind();
                        if (Request.QueryString["taskid"] != null)
                        {

                            var taskid = Convert.ToInt32(Request.QueryString["taskid"]);
                            // select task in gv
                            foreach (GridViewRow row in gvTask.Rows)
                            {
                                var dataKey = gvTask.DataKeys[row.RowIndex];
                                var keyTaskId = Convert.ToInt32(dataKey["Id"]);
                                if (keyTaskId == taskid)
                                {
                                    var checkBox = row.FindControl("chbTaskSelector") as CheckBox;
                                    checkBox.Checked = true;
                                }
                            }

                            var selectedTask =
                                (from task in context.ManagmentTask
                                 where task.Id == taskid
                                 select task).FirstOrDefault();
                            UpdateTaskForm(new List<ManagmentTask> { selectedTask });






                        }
                    }


                }
                if (GetSelectedTasks().Count == 0)
                {
                    btnDeleteTask.CssClass = "btn btn-danger disabled";
                    btnAddTask.Visible = true;
                }
            }
            else
            {
                formPleaseLogin.Visible = true;
                panelPlanningTool.Visible = false;
            }

        }
        protected void LoadReminderControlPicker()
        {

            var  times = new List<TimeSpan>();

            for (int i = 0; i < 48; i++)
            {
                times.Add(new TimeSpan(18000000000*i));
            }
            var stringTimes = (from t in times
                              select t.ToString()).ToList();



            ddReminder.DataSource = times;
            ddReminder.DataBind();

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
        protected void OnTaskCreated(ManagmentTask newTask)
        {
            MailUtils.SendApprovementRequest(newTask);
        }

        protected void chbTaskSelector_CheckedChanged(object sender, EventArgs e)
        {
            var row = (sender as CheckBox).Parent.Parent as GridViewRow;
            var index = row.RowIndex;
            var TaskId = (Int32)gvTask.DataKeys[index]["Id"];
            var selectedTasks = GetSelectedTasks();
            UpdateTaskForm(selectedTasks);

        }

        private void UpdateTaskForm(List<ManagmentTask> selectedTasks)
        {
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
                    btnDeleteTask.Visible = true;
                    btnApprove.Visible = true;
                    foreach (var taskToCheck in selectedTasks)
                    {
                       if(taskToCheck.ManagmentStateId != 1)
                        { 
                            btnApprove.Visible = false;
                        }
                    }
                    

                }
                else
                {
                    btnApplyChanges.Visible = false;
                    btnAddTask.Visible = true;
                    btnDeleteTask.Visible = false;
                    btnApprove.Visible = false;
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
            if (AppSecurity.CheckAdmin(Session["CurrentUser"] as User))
            {
                var selectedTasks = GetSelectedTasks();
                if (selectedTasks.Count > 0)
                {
                    using (var context = new pozicamskEntities())
                    {
                        var firstId = selectedTasks.First().Id;

                        var taskToEdit = (from task in context.ManagmentTask
                                          where (task.Id == firstId)
                                          select task).First();

                        taskToEdit.Name = tbTaskName.Text;
                        taskToEdit.Description = tbTaskDescription.Text;
                        taskToEdit.Priority = Convert.ToInt32(tbTaskPriority.Text);

                        taskToEdit.Cost = Convert.ToDecimal(tbTaskCost.Text);
                        taskToEdit.Rent = Convert.ToDecimal(tbTaskRent.Text);

                        taskToEdit.CreatorUserId = (Session["CurrentUser"] as User).Id;
                        taskToEdit.DeadlineDate = calTaskDeadline.SelectedDate;
                        taskToEdit.ManagmentStateId = 1;

                        context.SaveChanges();

                    }
                    string url = Request.RawUrl.ToString();
                    Response.Redirect(url); // redirect on itself
                }
            }
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
                    OnTaskCreated(newTask);

                    if (chbReminderSwitch.Checked)
                    {
                        var trigerTime = calTaskDeadline.SelectedDate;
                        trigerTime.Add(TimeSpan.Parse(ddReminder.SelectedValue));

                        DateTime.Parse(ddReminder.SelectedValue);
                        var newRem = new EmailReminder
                        {
                            Subject = $@"Pripomienka! Úloha ""{newTask.Name}""",
                            IsSent = false,
                            Name = "Pripomienka",
                            SourceMailAddress = "info@pozicam.sk",
                            Body = $@"<h2  style=""color:#13aff0;text-decoration:none"" >Pripomienka </h2> <br>
                            Upozornenie na nesplnenú úlohu : ""{newTask.Name}""  <br>
                            Popis úlohy: ""{newTask.Description}"" <br>
                            <a href = ""https://www.pozicam.sk/forms/managmentTools/PlanningTool?taskid={newTask.Id}"">link</a><br>
                            Potrebné stihnúť do {newTask.DeadlineDate}<br>
                            Priorita: {newTask.Priority}<br>
                            <h4 style=""color:#ef3f00""> Náklady: €{newTask.Cost}</h4>
                            <h4 style=""color:#06cf80""> Potencionálny zisk: €{newTask.Rent}</h4>

                            ",
                            TriggerTime = trigerTime,
                            CreationTime = DateTime.Now,
                            DestMailAddress = (Session["CurrentUser"] as User).Email
                        };
                        context.EmailReminder.Add(newRem);
                        context.SaveChanges();
                    }
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

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            var selectedTasks = GetSelectedTasks();
            foreach (var selectedTask in selectedTasks)
            {
                using (var context = new pozicamskEntities())
                {
                    var taskToApprove = (from task in context.ManagmentTask
                                         where task.Id == selectedTask.Id
                                         select task).FirstOrDefault();
                    taskToApprove.ManagmentStateId = 2;
                    context.SaveChanges();
                    MailUtils.SendApprovementComfirmation(taskToApprove);
                }
            }
            string url = Request.RawUrl.ToString();
            Response.Redirect(url); // redirect on itself
        }
    }
}