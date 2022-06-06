<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DashBoardReserve.aspx.cs" Inherits="KaramMarketingWeb.DashBoardReserve" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--  <a href="Pollux/PolluxTable.scss">Pollux/PolluxTable.scss</a>--%>
    <link href="W3S/w3css.css" rel="stylesheet" />
    <style type="text/css">
          .White {
            background-color: #e6e6e6;
            border: medium;
            border-color:black;
            color: black;
          }
        .Orange
        {
            background-color: darkorange;
             border-color:black;
            color: white;
        }
      .Green {
        background-color: #37e666;
         border-color:black;
        color: White;
      }
      .Red {
        background-color: red;
         border-color:black;
        color: White;
      }
    </style>
    <style>

         table.lamp th {
                color: white;
                background-color: #007B72;
                padding: 10px;
                padding-left: 10px;
                text-align: left;
                cursor: pointer;
                *cursor: hand;
            }
         .chart {
  width: 100%; 
  min-height: 450px;
}
    </style>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                title: 'DeadStock Data',
                hAxis: {
                    title: 'Year', titleTextStyle: { color: '#333' },
                    gridlines: {
                        color: 'transparent'
                    },
                },
                vAxis: {
                    gridlines: {
                        color: 'transparent'
                    },
                    minValue: 0
                },
                animation: {
                    duration: 1500,
                    easing: 'out',
                    startup: true
                }
                
            };
            $.ajax({
                type: "POST",
                url: "DashBoardReserve.aspx/GetChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.BarChart($("#chart")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    //alert(r.d);
                },
                error: function (r) {
                    //alert(r.d);
                }
               
            });
            $(window).resize(function () {
                drawChart();
            });
        }
    </script>

     <script type="text/javascript">
         google.load("visualization", "1", { packages: ["corechart"] });
         google.setOnLoadCallback(drawChart);
         function drawChart() {
             var options = {
                 title: 'DeadStock Data',
                 hAxis: {
                     title: 'Year', titleTextStyle: { color: '#333' },
                     gridlines: {
                         color: 'transparent'
                     },
                 },
                 vAxis: {
                     gridlines: {
                         color: 'transparent'
                     },
                     minValue: 0
                 },
                 animation: {
                     duration: 1000,
                     easing: 'out',
                     startup: true
                 },
                 chartArea: { left: 10, top: 0, width: "100%", height: "100%" }
             };
             $.ajax({
                 type: "POST",
                 url: "DashBoardReserve.aspx/GetChartData",
                 data: '{}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (r) {
                     var data = google.visualization.arrayToDataTable(r.d);
                     var chart = new google.visualization.PieChart($("#chart1")[0]);
                     chart.draw(data, options);
                 },
                 failure: function (r) {
                     //alert(r.d);
                 },
                 error: function (r) {
                     //alert(r.d);
                 }

             });
             $(window).resize(function () {
                 drawChart();
             });
         }
     </script>
    <script type="text/javascript">
        function ShowReservation() {
            window.open("frmMarketingList.aspx", "_self");
        }
    </script>
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div id="ErrorMsg" class="alert alert-danger alert-dismissable" style="display: none" runat="server">
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
        <strong>
            <asp:Label ID="lblMessage" runat="server" Text="Error"></asp:Label>
        </strong>
    </div>
    <div class="content-header">
                <div class="container-fluid">
                    <div class="row mb-2">
                        <div class="col-sm-6">
                            <h5 class="m-0 text-dark">Reservation DashBoard</h5>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">Reservation Report</li>
                            </ol>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>

               <div class="w3-row-padding w3-margin-bottom">

                 <div class="w3-quarter">
                  <div class="w3-container w3-blue w3-padding-16">
                    <div class="w3-left"><i class="fa fa-list w3-xxlarge"></i></div>
                    <div class="w3-right">
                      <h1> <asp:Label ID="lblReserved" runat="server" Font-Size="24" Text="100"></asp:Label></h1>
                    </div>
                    <div class="w3-clear"></div>
                    <h4>Reserved</h4>
                  </div>
                </div>

                 <div class="w3-quarter">
                  <div class="w3-container w3-orange w3-text-white w3-padding-16">
                    <div class="w3-left"><i class="fa fa-spinner w3-xxlarge"></i></div>
                    <div class="w3-right">
                       <h1> <asp:Label ID="lblProgress" runat="server" Font-Size="24" Text="100"></asp:Label></h1>
                    </div>
                    <div class="w3-clear"></div>
                    <h4>In-Progress</h4>
                  </div>
                </div>

               <div class="w3-quarter">
                  <div class="w3-container w3-indigo w3-text-white w3-padding-16">
                    <div class="w3-left"><i class="fa fa-clock w3-xxlarge"></i></div>
                    <div class="w3-right">
                       <h1> <asp:Label ID="lblPending" runat="server" Font-Size="24" Text="100"></asp:Label></h1>
                    </div>
                    <div class="w3-clear"></div>
                    <h4>Pending</h4>
                  </div>
                </div>
   
                <div class="w3-quarter">
                  <div class="w3-container w3-teal w3-padding-16">
                    <div class="w3-left"><i class="fa fa-truck w3-xxlarge"></i></div>
                    <div class="w3-right">
                       <h1> <asp:Label ID="lblDispatch" runat="server" Font-Size="24" Text="100"></asp:Label></h1>
                    </div>
                    <div class="w3-clear"></div>
                    <h4>Dispatch</h4>
                  </div>
                </div>
    

                <div class="w3-quarter">
                  <div class="w3-container w3-red w3-padding-16">
                    <div class="w3-left"><i class="fa fa-ban w3-xxlarge"></i></div>
                    <div class="w3-right">
                       <h1> <asp:Label ID="lblExpired" runat="server" Font-Size="24" Text="100"></asp:Label></h1>
                    </div>
                    <div class="w3-clear"></div>
                    <h4>Expired</h4>
                  </div>
                </div>
   
              </div>

      </div>
    <div class="content">
        <div class="container-fluid">
             <div class="row">
                  <div class="col-lg-6">
                      <div class="card">
                          <div class="card-header border-0">
                                    <div class="d-flex justify-content-between">
                                        <h3 class="card-title">Reserved Items</h3>
                                        <a href="javascript:void(0);"  onclick="javascript:ShowReservation(0);">View Report</a>
                                    </div>
                               <div class="card-body">
                                   

                                    <div class="position-relative mb-4">
                                        <div id="chart1" class="chart" >
                                       </div> 
                                    </div>
                                </div>
                           </div>
                      </div>
                      
                  </div>
                  <div class="col-lg-6">
                           
                            <!-- /.card -->

                           <div class="card">
                          <div class="card-header border-0">
                                    <div class="d-flex justify-content-between">
                                        <h3 class="card-title">Reserved Items</h3>
                                        <a href="javascript:void(0);">View Report</a>
                                    </div>
                               <div class="card-body">
                                   <div class="d-flex">
                                        <p class="d-flex flex-column">
                                            
                                        </p>
                                   </div>

                                    <div class="position-relative mb-4">
                                       <div id="chart" class="chart" >
                                       </div>
                                    </div>
                                </div>
                           </div>
                      </div>
                            <!-- /.card -->
                        </div>
             </div>
         </div>
         <%--<div class="table-responsive" style="overflow: auto">
             <div id="chartContainer" style="height: 370px; width: 100%;"></div>

             </div>--%>

                <div class="table-responsive" style="overflow: auto">
                         <asp:GridView ID="gvInventoryOrderprogress" OnRowDataBound="gvInventoryOrderprogress_RowDataBound" class="table table-bordered"  runat="server">
                            <HeaderStyle BackColor="#007B72" Font-Bold="True" ForeColor="White" />
                                
                             <%-- <Columns>
                                      <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Names="Calibri (Body)" Font-Size="15pt" ForeColor="Navy" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Reservation ID">
                                        <ItemTemplate>
                                            <%#Eval("ReservationID") %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Names="Calibri (Body)" Font-Size="15pt" ForeColor="Navy" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Customer">
                                        <ItemTemplate>
                                            <%#Eval("CustomerName") %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Names="Calibri (Body)" Font-Size="15pt" ForeColor="Navy" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Sales Order">
                                        <ItemTemplate>
                                            <%#Eval("SalesOrder") %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Names="Calibri (Body)" Font-Size="15pt" ForeColor="Navy" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Demand Qty">
                                        <ItemTemplate>
                                            <%#Eval("Qty") %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Names="Calibri (Body)" Font-Size="15pt" ForeColor="Navy" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Demand Date">
                                        <ItemTemplate>
                                            <%#Eval("DemandDate") %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Names="Calibri (Body)" Font-Size="15pt" ForeColor="Navy" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <%#Eval("ReservationStatus") %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Names="Calibri (Body)" Font-Size="15pt" ForeColor="Navy" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="TimeStamp">
                                        <ItemTemplate>
                                            <%#Eval("ModifiedDate") %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Font-Names="Calibri (Body)" Font-Size="15pt" ForeColor="Navy" />
                                    </asp:TemplateField>

                                </Columns>--%>
                         </asp:GridView>
                </div>
            </div>
</asp:Content>
