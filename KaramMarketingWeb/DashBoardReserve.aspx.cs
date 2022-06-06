using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace KaramMarketingWeb
{
    public partial class DashBoardReserve : System.Web.UI.Page
    {
        clsDashBoard _CLS = new clsDashBoard();
        string UserName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ErrorMsg.Style.Value = "display:none";
                    lblMessage.Text = "";
                    if (Session["UserName"] != null)
                    {
                        UserName = Session["UserName"].ToString();
                        BindData(UserName);
                        //ChartData("");
                    }
                    else
                    {
                        Response.Redirect("frmSessionOut.aspx");
                    }
                }
                else
                {
                    Response.Redirect("frmSessionOut.aspx");
                }
            }
            catch (Exception exe)
            {

                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }
        public void BindData(string User)
        {
            try
            {
                DataTable dtdetails = new DataTable();
                dtdetails = _CLS.GetReservationDashBoard(User);
                if (dtdetails != null)
                {
                    if (dtdetails.Rows.Count > 0)
                    {

                        gvInventoryOrderprogress.DataSource = dtdetails;
                        gvInventoryOrderprogress.DataBind();

                    }
                    else
                    {

                    }
                }

            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }
        #region chart cut
        //public void ChartData(string User)
        //{
        //    DataTable dtChart = new DataTable();
        //    dtChart.Columns.AddRange(new DataColumn[] {
        //                 new DataColumn("Month",typeof(string)),
        //                    new DataColumn("Value",typeof(double))});

        //    dtChart.Rows.Add("Jan 2022", "100");
        //    dtChart.Rows.Add("Feb 2022", "200");
        //    dtChart.Rows.Add("Mar 2022", "150");
        //    MonthChart.DataSource = dtChart;
        //    MonthChart.Series[0].ChartType = (SeriesChartType)int.Parse("7");
        //    MonthChart.DataBind();

        //    MonthChart.ChartAreas["Chartarea123"].AxisX.MajorGrid.Enabled = false;
        //    MonthChart.ChartAreas["Chartarea123"].AxisY.MajorGrid.Enabled = false;

        //    MonthChart.ChartAreas["Chartarea123"].AxisX.Interval = 1;
        //    MonthChart.ChartAreas["Chartarea123"].AxisX.IsLabelAutoFit = true;
        //    MonthChart.ChartAreas["Chartarea123"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep30;
        //    MonthChart.ChartAreas["Chartarea123"].AxisX.LabelStyle.Enabled = true;


        //    Color[] colors = new Color[]
        //       {
        //                  Color.LawnGreen, Color.DarkViolet, Color.Red, Color.Yellow, Color.Crimson,  Color.Gold, Color.Navy , Color.LightBlue , Color.Orange ,Color.DarkBlue,
        //                  Color.LawnGreen, Color.DarkViolet, Color.Red, Color.Yellow, Color.Crimson,  Color.Gold, Color.Navy , Color.LightBlue , Color.Orange ,Color.DarkBlue,
        //                  Color.LawnGreen, Color.DarkViolet, Color.Red, Color.Yellow, Color.Crimson,  Color.Gold, Color.Navy , Color.LightBlue , Color.Orange ,Color.DarkBlue,
        //                  Color.LawnGreen, Color.DarkViolet, Color.Red, Color.Yellow, Color.Crimson,  Color.Gold, Color.Navy , Color.LightBlue , Color.Orange ,Color.DarkBlue,
        //                  Color.LawnGreen, Color.DarkViolet, Color.Red, Color.Yellow, Color.Crimson,  Color.Gold, Color.Navy , Color.LightBlue , Color.Orange ,Color.DarkBlue

        //       };


        //    foreach (Series series in MonthChart.Series)
        //    {
        //        foreach (DataPoint point in series.Points)
        //        {
        //            //point.LabelBackColor = colors[series.Points.IndexOf(point)];
        //            point.Color = colors[series.Points.IndexOf(point)];
        //        }
        //    }
        //}
        #endregion
        public class clsChart
        {
            public string label { get; set; }
            public double value { get; set; }
            public string color { get; set; }
            public string hightlight { get; set; }
        }

        [WebMethod]
        public static List<object> GetChartData()
        {
            List<clsChart> ChartList = new List<clsChart>();

            List<object> chartData = new List<object>();
            chartData.Add(new object[]
               {
                    "ShipCity", "TotalOrders"
               });

            DataTable dtChart = new DataTable();
            dtChart.Columns.AddRange(new DataColumn[] {
                         new DataColumn("Month",typeof(string)),
                            new DataColumn("Value",typeof(double))});

            dtChart.Rows.Add("Jan 2022", "300");
            dtChart.Rows.Add("Feb 2022", "200");
            dtChart.Rows.Add("Mar 2022", "150");
            dtChart.Rows.Add("Apr 2022", "50");
            dtChart.Rows.Add("May 2022", "20");
            dtChart.Rows.Add("Jun 2022", "90");
            dtChart.Rows.Add("Jul 2022", "47");
            dtChart.Rows.Add("Aug 2022", "30");
            foreach (DataRow dr in dtChart.Rows)
            {
                chartData.Add(new object[]
                     {
                        dr["Month"], dr["Value"]
                     });
            }
           
              return chartData;
                
            
        }

        protected void gvInventoryOrderprogress_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string  Status = e.Row.Cells[5].Text;
                    string setColorClass = string.Empty;
                    if (Status.ToUpper() == "PENDING")
                    {
                        setColorClass = "White"; 
                    }
                    if (Status.ToUpper() == "IN-PROGRESS")
                    {
                        setColorClass = "Orange";
                    }
                    if (Status.ToUpper() == "DONE")
                    {
                        setColorClass = "Green";
                    }
                    if (Status.ToUpper() == "CANCELLED")
                    {
                        setColorClass = "Red";
                    }
                    e.Row.CssClass = setColorClass;

                }
            }
            catch (Exception exe)
            {
                ErrorMsg.Style.Value = "display:block";
                lblMessage.Text = exe.Message;
            }
        }

        //[WebMethod]
        //public List<clsChart> getTrafficSourceData(List<string> gData)
        //{
        //    List<clsChart> ChartList = new List<clsChart>();
        //    string[] arrColor = new string[] { "#231F20", "#FFC200", "#F44937", "#16F27E", "#FC9775", "#5A69A6" };

        //    DataTable dtChart = new DataTable();
        //    dtChart.Columns.AddRange(new DataColumn[] {
        //             new DataColumn("Month",typeof(string)),
        //                new DataColumn("Value",typeof(double))});

        //    dtChart.Rows.Add("Jan 2022", "100");
        //    dtChart.Rows.Add("Feb 2022", "200");
        //    dtChart.Rows.Add("Mar 2022", "150");
        //    int counter = 0;
        //    foreach (DataRow dr in dtChart.Rows)
        //    {
        //        clsChart lp = new clsChart();
        //        lp.label = dr["Month"].ToString();
        //        lp.value = double.Parse(dr["Value"].ToString());
        //        lp.color = arrColor[counter];

        //        ChartList.Add(lp);
        //    }

        //   // JavaScriptSerializer serializer = new JavaScriptSerializer();
        //    return ChartList;
        //}

        protected void CopperChart_Customize(object sender, EventArgs e)
        {

        }
    }
}