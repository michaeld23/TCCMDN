using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.Hosting;

namespace TCCMDN
{
    public partial class Courts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtAddDay.Attributes.Add("placeholder", "Saisissez le jour");
                txtAddHour.Attributes.Add("placeholder", "Saisissez les heures");
                txtAddPerson.Attributes.Add("placeholder", "Saisissez le membre");
                txtAddDay.Visible = false;
                txtAddHour.Visible = false;
                txtAddPerson.Visible = false;
                btnConfirmBooking.Visible = false;
                lblError.Text = "";
            }


            /* GET CSV content and store it into tables ========================================================== */
            var csv =System.Web.Hosting.HostingEnvironment.MapPath("~/src/bookings.csv");
            List<string> listDays = new List<string>();
            List<string> listHours = new List<string>();
            List<string> listPersons = new List<string>();
            var reader = new StreamReader(csv);
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                listDays.Add(values[0]);
                listHours.Add(values[1]);
                listPersons.Add(values[2]);
            }
            tblInsertor(listDays, listHours, listPersons);

            /* ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('content: "+listDays[0]+"');", true); ALERT BOX EXAMPLE*/
        }

        /* handles the insertion of the csv content into the table */
        protected void tblInsertor(List<string> lstDays, List<string> lstHours, List<string> lstPerson)
        {
            int total = lstDays.Count;

            for (int i = 0; i < total;i++ )
            {
                /* target the good row */
                string element = lstHours[i];
                int targetRow = -1;

                if (element == "08h") { targetRow = 1; }
                else if (element == "09h") { targetRow = 2; }
                else if (element == "10h") { targetRow = 3; }
                else if (element == "11h") { targetRow = 4; }
                else if (element == "12h") { targetRow = 5; }
                else if (element == "13h") { targetRow = 6; }
                else if (element == "14h") { targetRow = 7; }
                else if (element == "15h") { targetRow = 8; }
                else if (element == "16h") { targetRow = 9; }
                else if (element == "17h") { targetRow = 10; }
                else if (element == "18h") { targetRow = 11; }
                else if (element == "19h") { targetRow = 12; }
                else if (element == "20h") { targetRow = 13; }
                else if (element == "21h") { targetRow = 14; }
                else if (element == "22h") { targetRow = 15; }

                /* target the good cell */
                element = lstDays[i];
                int targetCell = -1;

                if (element == "Lundi") { targetCell = 1; }
                else if (element == "Mardi") { targetCell = 2; }
                else if (element == "Mercredi") { targetCell = 3; }
                else if (element == "Jeudi") { targetCell = 4; }
                else if (element == "Vendredi") { targetCell = 5; }
                else if (element == "Samedi") { targetCell = 6; }
                else if (element == "Dimanche") { targetCell = 7; }

                tblCourt1.Rows[targetRow].Cells[targetCell].Text = lstPerson[i];
            }
                


            
        }

        protected void add_day_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Ajouter une réservation")
            {
                btnAdd.Text = "Cacher";
                txtAddDay.Visible = true;
                txtAddHour.Visible = true;
                txtAddPerson.Visible = true;
                btnConfirmBooking.Visible = true;
            }
            else
            {
                btnAdd.Text = "Ajouter une réservation";
                txtAddDay.Visible = false;
                txtAddHour.Visible = false;
                txtAddPerson.Visible = false;
                btnConfirmBooking.Visible = false;
            }

        }

        protected void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            if(txtAddDay.Text=="")
                lblError.Text = "Veuillez saisir le champ jour";
            else if (txtAddHour.Text == "")
                lblError.Text = "Veuillez saisir le champ heure";
            else if (txtAddPerson.Text == "")
                lblError.Text = "Veuillez saisir le champ membre";
            else
            {
                if(testIfDayIsFree(txtAddDay.Text, txtAddHour.Text, txtAddPerson.Text)==true)
                {
                    int row = aimRow(txtAddHour.Text);
                    int cell = aimCell(txtAddDay.Text);
                    /* btnAdd.Text = row + " " + cell; */
                    if (cell != -1 && row != -1)
                    {
                        txtAddDay.Text = "";
                        txtAddHour.Text = "";
                        txtAddPerson.Text = "";
 
                        tblCourt1.Rows[row].Cells[cell].Text = txtAddPerson.Text;
                        lblError.Text = "";
                    }
                    else
                        lblError.Text = "Erreur de saisie.";
                }
                else 
                {
                    lblError.Text = "Le court est pris ce jour là et à cette heure ci.";
                }


            }
        }

        protected Boolean testIfDayIsFree(string day, string hour, string person)
        {
            /* target the good row */
            string element = hour;
            int targetRow = -1;

            if (element == "08h" || element == "8" || element == "08" || element == "08h00") { targetRow = 1; }
            else if (element == "09h" || element == "9" || element == "09" || element == "09h00") { targetRow = 2; }
            else if (element == "10h" || element == "10" || element == "10" || element == "10h00") { targetRow = 3; }
            else if (element == "11h" || element == "11" || element == "11" || element == "11h00") { targetRow = 4; }
            else if (element == "12h" || element == "12" || element == "12" || element == "12h00") { targetRow = 5; }
            else if (element == "13h" || element == "13" || element == "13" || element == "13h00") { targetRow = 6; }
            else if (element == "14h" || element == "14" || element == "14" || element == "14h00") { targetRow = 7; }
            else if (element == "15h" || element == "15" || element == "15" || element == "15h00") { targetRow = 8; }
            else if (element == "16h" || element == "16" || element == "16" || element == "16h00") { targetRow = 9; }
            else if (element == "17h" || element == "17" || element == "17" || element == "17h00") { targetRow = 10; }
            else if (element == "18h" || element == "18" || element == "18" || element == "18h00") { targetRow = 11; }
            else if (element == "19h" || element == "19" || element == "19" || element == "19h00") { targetRow = 12; }
            else if (element == "20h" || element == "20" || element == "20" || element == "20h00") { targetRow = 13; }
            else if (element == "21h" || element == "21" || element == "21" || element == "21h00") { targetRow = 14; }
            else if (element == "22h" || element == "22" || element == "22" || element == "22h00") { targetRow = 15; }

            element = day;
            int targetCell = -1;

            if (element == "Lundi" || element == "lundi") { targetCell = 1; }
            else if (element == "Mardi" || element == "mardi") { targetCell = 2; }
            else if (element == "Mercredi" || element == "mercredi") { targetCell = 3; }
            else if (element == "Jeudi" || element == "jeudi") { targetCell = 4; }
            else if (element == "Vendredi" || element == "vendredi") { targetCell = 5; }
            else if (element == "Samedi" || element == "samedi") { targetCell = 6; }
            else if (element == "Dimanche" || element == "dimanche") { targetCell = 7; }

            if (tblCourt1.Rows[targetRow].Cells[targetCell].Text == "&nbsp;")
                return true;

            return false;
        }



        protected int aimRow(string hour)
        {
            int targetRow = -1;
            string element = hour;
            if (element == "08h" || element == "8" || element == "08" || element == "08h00") { targetRow = 1; }
            else if (element == "09h" || element == "9" || element == "09" || element == "09h00") { targetRow = 2; }
            else if (element == "10h" || element == "10" || element == "10" || element == "10h00") { targetRow = 3; }
            else if (element == "11h" || element == "11" || element == "11" || element == "11h00") { targetRow = 4; }
            else if (element == "12h" || element == "12" || element == "12" || element == "12h00") { targetRow = 5; }
            else if (element == "13h" || element == "13" || element == "13" || element == "13h00") { targetRow = 6; }
            else if (element == "14h" || element == "14" || element == "14" || element == "14h00") { targetRow = 7; }
            else if (element == "15h" || element == "15" || element == "15" || element == "15h00") { targetRow = 8; }
            else if (element == "16h" || element == "16" || element == "16" || element == "16h00") { targetRow = 9; }
            else if (element == "17h" || element == "17" || element == "17" || element == "17h00") { targetRow = 10; }
            else if (element == "18h" || element == "18" || element == "18" || element == "18h00") { targetRow = 11; }
            else if (element == "19h" || element == "19" || element == "19" || element == "19h00") { targetRow = 12; }
            else if (element == "20h" || element == "20" || element == "20" || element == "20h00") { targetRow = 13; }
            else if (element == "21h" || element == "21" || element == "21" || element == "21h00") { targetRow = 14; }
            else if (element == "22h" || element == "22" || element == "22" || element == "22h00") { targetRow = 15; }
            return targetRow;
        }

        protected int aimCell(string day)
        {
            int targetCell = -1;
            string element = day;
            if (element == "Lundi" || element == "lundi") { targetCell = 1; }
            else if (element == "Mardi" || element == "mardi") { targetCell = 2; }
            else if (element == "Mercredi" || element == "mercredi") { targetCell = 3; }
            else if (element == "Jeudi" || element == "jeudi") { targetCell = 4; }
            else if (element == "Vendredi" || element == "vendredi") { targetCell = 5; }
            else if (element == "Samedi" || element == "samedi") { targetCell = 6; }
            else if (element == "Dimanche" || element == "dimanche") { targetCell = 7; }
            return targetCell;
        }

    }
}