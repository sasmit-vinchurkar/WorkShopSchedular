using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using BLL;

namespace WorkShopSchedular.Admin
{
    public partial class WorkShop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetWorkShops();
                GetTrainers();
                ResetTextFields();
            }
        }

        private void GetTrainers()
        {
            UserBusiness userBusiness = new UserBusiness();
            List<UserBO> userBOs = userBusiness.GetTrainers();
            
            ckbLTrainers.DataSource = userBOs;
            ckbLTrainers.DataTextField = "FirstName";
            ckbLTrainers.DataValueField = "UserID";
            ckbLTrainers.DataBind();
        }

        private void GetWorkShops()
        {
            WorkShopBusiness workShopBusiness = new WorkShopBusiness();
            List<WorkShopBO> ls = workShopBusiness.GetAllWorkShops();
            GridView1.DataSource = ls;
            GridView1.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            WorkShopBO workShopBO = new WorkShopBO();

            workShopBO.WorkShopTitle = txtWorkShopTitle.Text.ToUpper().ToString();
            workShopBO.WorkShopDate = DateTime.Parse(txtWorkShopDate.Text.ToString());
            workShopBO.WorkShopDuration = txtWorkShopDuration.Text.ToUpper().ToString();
            workShopBO.WorkShopTopics = txtWorkShopTopics.Text.ToString();
            workShopBO.CreatedDate = DateTime.Now;

            WorkShopBusiness workShopBusiness = new WorkShopBusiness();

            if (workShopBusiness.InsertWorkShop(workShopBO) == true)
            {
                lblDataSucess.Text = "Data Inserted Sucessfully.....";
            }
            else
            {
                lblDataFail.Text = "Data Insertion was Unscessfull....Contact Administrator";
            }

            ResetTextFields();

            GetWorkShops();
            Response.Redirect(Request.Url.AbsoluteUri);



        }

        private void ResetTextFields()
        {
            txtWorkShopId.Text = string.Empty;
            txtWorkShopTitle.Text = string.Empty;
            txtWorkShopDate.Text = string.Empty;
            txtWorkShopDuration.Text = string.Empty;
            txtWorkShopTopics.Text = string.Empty;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetTextFields();
            int id = int.Parse(GridView1.SelectedValue.ToString());

            WorkShopBusiness workShopBusiness = new WorkShopBusiness();
            WorkShopBO workShopBO = workShopBusiness.GetWorkShopById(id);

            txtWorkShopId.Text = workShopBO.WorkShopId.ToString();
            txtWorkShopTitle.Text = workShopBO.WorkShopTitle.ToString();
            txtWorkShopDate.Text = workShopBO.WorkShopDate.ToString();
            txtWorkShopDuration.Text = workShopBO.WorkShopDuration.ToString();
            txtWorkShopTopics.Text = workShopBO.WorkShopTopics.ToString();
            ckbLTrainers.ClearSelection();

            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            WorkShopBO workShopBO = new WorkShopBO();

            workShopBO.WorkShopTitle = txtWorkShopTitle.Text.ToUpper().ToString(); 
            workShopBO.WorkShopDate = DateTime.Parse(txtWorkShopDate.Text);
            workShopBO.WorkShopDuration = txtWorkShopDuration.Text.ToUpper().ToString(); 
            workShopBO.WorkShopTopics = txtWorkShopTopics.Text;
            workShopBO.UpdatedDate = DateTime.Now;

            WorkShopBusiness workShopBusiness = new WorkShopBusiness();
            int id = int.Parse(GridView1.SelectedValue.ToString());
            workShopBusiness.UpdateWorkShopById(workShopBO, id);

            if (workShopBusiness.UpdateWorkShopById(workShopBO, id) == true)
            {
                lblDataSucess.Text = "Updated Sucessfully";
            }
            else
            {
                lblDataFail.Text = "Update was Unsucessfull";
            }
            ResetTextFields();
            GetWorkShops();
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(GridView1.SelectedValue.ToString());

            WorkShopBusiness workShopBusiness = new WorkShopBusiness();
            workShopBusiness.DeleteWorkShopById(id);
            ResetTextFields();
            GetWorkShops();
        }

        protected void btnAssignTrainer_Click(object sender, EventArgs e)
        {

            List<TrainerWorkShopMappingBO> ls = new List<TrainerWorkShopMappingBO>();

            int WorkShopId = int.Parse(GridView1.SelectedValue.ToString());

            foreach (ListItem item in ckbLTrainers.Items)
            {
                if(item.Selected)
                {
                    int TrainerId = int.Parse(item.Value);

                    TrainerWorkShopMappingBO twm = new TrainerWorkShopMappingBO();
                    twm.TrainerId = TrainerId;
                    twm.WorkShopId = WorkShopId;

                    ls.Add(twm);
                }
            }

            WorkShopBusiness workShopBusiness = new WorkShopBusiness();
            if (ls.Count() > 0)
            {
                
                workShopBusiness.AssignTrainersToWorkShop(ls);
            }
            ckbLTrainers.ClearSelection();
            ResetTextFields();
            //if (workShopBusiness.AssignTrainersToWorkShop(ls) == true)
            //{
            //    lblAssignSucess.Text = "Trainer Assigned Sucessfully.";
            //}
            //else
            //{
            //    lblAssignFail.Text = "Trainer was not assigned, Please Contact Administrator.!";
            //}




        }
    }
}