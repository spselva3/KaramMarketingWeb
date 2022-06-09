<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DashBoardReservation.aspx.cs" Inherits="KaramMarketingWeb.DashBoardReservation" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--  <a href="Pollux/PolluxTable.scss">Pollux/PolluxTable.scss</a>--%>
    <link href="/W3S/w3css.css" rel="stylesheet" />
    
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
        .White {
            background-color: #e0ecff;
           
            color: black;
          }
        .Orange
        {
            background-color: darkorange;
             
            color: white;
        }
      .Green {
        background-color: #37e666;
         
        color: White;
      }
      .Red {
        background-color: red;
        
        color: White;
      }

      .SearchButton {
          height:33px;
          width:90px;
          padding-bottom: 0px;
          padding-top: 0px;
          margin-top: 0px;
          margin-bottom: 3px;
      }
      .MouseHoverView{
        cursor: pointer;
    }
    </style>
     <script type="text/javascript" src="/NewTable/DataTables/datatables.min.js"></script>
     <script type="text/javascript">
         //DataTables Initialization for Map Table Example
         $(document).ready(function () {
             $('#inventory').dataTable();
         });

     </script>
       <script type="text/javascript">
           function ShowCreateReservation() {
               window.open('CreateReservation.aspx', "_self");
           }
       </script>

        <script type="text/javascript">
            function ShowReserveItems(ReserveID) {
                window.open("frmMarketingItems.aspx?Id=" + ReserveID, "_self");
            }
        </script>

       <script type="text/javascript">
           function ShowPackTypes(Reservation) {
               window.open('EditReservation.aspx?ID=' + Reservation, "_self");
           }
       </script>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <%--<script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                title: 'Reserved Items',
                hAxis: {
                    title: 'Year', titleTextStyle: { color: '#333' },
                    gridlines: {
                        color: 'aliceblue'
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
                },
                bar: { groupWidth: "20%" },

                chartArea: { left: 50, top: 100, width: "100%", height: "100%" }
            };
            $.ajax({
                type: "POST",
                url: "DashBoardReservation.aspx/GraphReserve",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.BarChart($("#chartReserve")[0]);
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
                 title: 'Expired Reservations',
                 hAxis: {
                     title: 'Year', titleTextStyle: { color: '#333' },
                     gridlines: {
                         color: 'aliceblue'
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
                 bar: { groupWidth: "20%" },
                 chartArea: { left: 50, top: 100, width: "100%", height: "100%" },
                  colors: ['red'],

             };
             $.ajax({
                 type: "POST",
                 url: "DashBoardReservation.aspx/GraphCanellation",
                 data: '{}',
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (r) {
                     var data = google.visualization.arrayToDataTable(r.d);
                     var chart = new google.visualization.BarChart($("#chartCancel")[0]);
                     chart.draw(data, options);
                 },
                 failure: function (r) {
                    
                 },
                 error: function (r) {
                     
                 }

             });
             $(window).resize(function () {
                 drawChart();
             });
         }
     </script>--%>
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
                        <div class="col-sm-3">
                            <h5 class="m-0 text-dark">Reservation DashBoard</h5>
                        </div>
                        <!-- /.col -->
                        <%--<div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">Reservation Report</li>
                            </ol>
                        </div>--%>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                  <div class="container-fluid">
                         <div class="row mb-2">
                              <div class="col-sm-2">
                                  <ol style="float:left; padding-left: 10px;">
                                       <asp:Button ID ="Create" runat="server"   CausesValidation="false" Text="Create Reservation" OnClick="Create_Click" class="btn btn-success" Width="130px"  Height="31px" />
                                   </ol>
                               </div>

                              <div class="col-sm-10" >
                                  <div style="float:right;">
                                <input class="w-1\/4  py-1 text-gray-1000 bg-blue-200 rounded" runat="server" id="txtFrom" name="From" type="date"  placeholder="From Date" aria-label="username">
            
                                <input class="w-1\/4  py-1 text-gray-1000 bg-blue-200 rounded" runat="server" id="txtTo" name="To" type="date"  placeholder="To Date" aria-label="username">
            
                             <asp:DropDownList ID="ddlRegion" class="w-1\/4  py-1 text-gray-1000 bg-blue-200 rounded" Width="100px" runat="server" Height="31px" >
                            </asp:DropDownList>

                                <asp:Button ID ="btnSearch" runat="server" OnClick="btnSearch_Click"  CausesValidation="false" Text="Apply"   class="btn btn-primary SearchButton"  />
                          
                                  </div>
                             
                      
                      
                              </div>
                              
                         </div>
                    </div>
               <div class="w3-row-padding w3-margin-bottom">

                 <div class="w3-quarter">
                  <div class="w3-container w3-blue w3-padding-16">
                    <div class="w3-left"><i class="fa fa-list w3-xxlarge"></i></div>
                    <div class="w3-right">
                      <h1> <asp:Label ID="lblReserved" runat="server" Font-Size="24" Text="100" ForeColor="White"></asp:Label></h1>
                    </div>
                    <div class="w3-clear"></div>
                       <asp:LinkButton ID="btnReserved" runat="server" ToolTip="Reserved"
                           CausesValidation="false" OnClick="btnReserved_Click">
                                     <h4 style="color:White;">Reserved</h4>                        
                       </asp:LinkButton>
                  </div>
                </div>

               

               <div class="w3-quarter">
                  <div class="w3-container w3-indigo w3-text-white w3-padding-16">
                    <div class="w3-left"><i class="fa fa-clock w3-xxlarge"></i></div>
                    <div class="w3-right">
                       <h1> <asp:Label ID="lblPending" runat="server" Font-Size="24" Text="100"></asp:Label></h1>
                    </div>
                    <div class="w3-clear"></div>
                       <asp:LinkButton ID="btnPrnding" runat="server" ToolTip="SO-Pending"
                           CausesValidation="false" OnClick="btnPrnding_Click">
                                     <h4 style="color:White;">SO-Pending</h4>                       
                       </asp:LinkButton>
                   
                  </div>
                </div>


                     <div class="w3-quarter">
                  <div class="w3-container w3-orange w3-text-white w3-padding-16">
                    <div class="w3-left"><i class="fa fa-spinner w3-xxlarge"></i></div>
                    <div class="w3-right">
                       <h1> <asp:Label ID="lblProgress" runat="server" Font-Size="24" Text="100"></asp:Label></h1>
                    </div>
                    <div class="w3-clear"></div>
                       <asp:LinkButton ID="btnProgress" runat="server" ToolTip="In-Progress"
                           CausesValidation="false" OnClick="btnProgress_Click">
                                    <h4 style="color:White;">In-Progress</h4>                       
                       </asp:LinkButton>
                    
                  </div>
                </div>
   
                <div class="w3-quarter">
                  <div class="w3-container w3-teal w3-padding-16">
                    <div class="w3-left"><i class="fa fa-truck w3-xxlarge"></i></div>
                    <div class="w3-right">
                       <h1> <asp:Label ID="lblDispatch" runat="server" Font-Size="24" Text="100"></asp:Label></h1>
                    </div>
                    <div class="w3-clear"></div>
                       <asp:LinkButton ID="btnDispatch" runat="server" ToolTip="Dispatched"
                           CausesValidation="false" OnClick="btnDispatch_Click">
                                     <h4 style="color:White;">Dispatched</h4>                    
                       </asp:LinkButton>
                    
                  </div>
                </div>
    

                <div class="w3-quarter">
                  <div class="w3-container w3-red w3-padding-16">
                    <div class="w3-left"><i class="fa fa-ban w3-xxlarge"></i></div>
                    <div class="w3-right">
                       <h1> <asp:Label ID="lblExpired" runat="server" Font-Size="24" Text="100"></asp:Label></h1>
                    </div>
                    <div class="w3-clear"></div>
                        <asp:LinkButton ID="btnExpired" runat="server" ToolTip="Cancelled/Expired"
                           CausesValidation="false" OnClick="btnExpired_Click">
                                     <h4 style="color:White;">Cancelled/Expired</h4>                    
                       </asp:LinkButton>
                    
                  </div>
                </div>
   
              </div>

      </div>
    <div class="content">
        <div class="container-fluid">
             <div class="row">
                  <%--<div class="col-lg-2">
                      <div class="card">
                          <div class="card-header border-0">
                                    <div class="d-flex justify-content-between">
                                        <h3 class="card-title">Reserved Items</h3>
                                    </div>
                               <div class="card-body">
                                   

                                    <div class="position-relative mb-4">
                                        <div id="chartReserve" class="chart" >
                                       </div> 
                                    </div>
                                </div>
                           </div>
                      </div>
                      
                  </div>--%>
                  <div class="col-lg-12">
                      <div class="card">
                           <div class="table-responsive" style="overflow: auto" >
                         <asp:ListView ID="lvRMGateinDetails" runat="server" OnItemDataBound="lvRMGateinDetails_ItemDataBound" >
                            <LayoutTemplate>
                                <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                    <thead>
                                        <tr>
                                                <th>Sr.No
                                                </th>
                                                <th>Region
                                                </th>
                                                <th>Reservation ID
                                                </th>
                                                <th>Creation Date   
                                                </th>
                                                <th>Customer Name
                                                </th>
                                                 <th>Required Qty
                                                </th>
                                                 <th>Required by Date
                                                </th>
                                                 <th>Sales Order No
                                                </th>
                                                <th>Status
                                                </th>
                                             <th>User
                                                </th>
                                               <th>Action</th>
                                        </tr>
                                    </thead>
                                    <tbody id="ItemPlaceholder" runat="server">
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr >  <%--<="<%# GetClassName(Convert.ToString( Eval("ReservationStatus"))) %>">--%>

                                   <td class="<%# GetClassName(Convert.ToString( Eval("ReservationStatus"))) %>">
                                            <%# Container.DataItemIndex + 1%>
                                        </td>
                                     <td class="<%# GetClassName(Convert.ToString( Eval("ReservationStatus"))) %>">
                                            <%# Eval("Region")%>
                                        </td>

                                     <td class="<%# GetClassName(Convert.ToString( Eval("ReservationStatus"))) %> MouseHoverView " >
                                         <a   id="id123" onclick="ShowReserveItems('<%# Eval("ReservationID")%>'); "/>
                                            <%# Eval("ReservationID")%>
                                      </td>

                                     <td class="<%# GetClassName(Convert.ToString( Eval("ReservationStatus"))) %>">
                                            <%# Eval("ModifiedDate")%>
                                     </td>

                                     <td class="<%# GetClassName(Convert.ToString( Eval("ReservationStatus"))) %>">
                                            <%# Eval("CustomerName")%>
                                     </td>

                                     <td class="<%# GetClassName(Convert.ToString( Eval("ReservationStatus"))) %>">
                                            <%# Eval("Qty")%>
                                     </td>
                                        
                                      <td class="<%# GetClassName(Convert.ToString( Eval("ReservationStatus"))) %>">
                                            <%# Eval("DemandDate")%>
                                      </td>

                                      <td class="<%# GetClassName(Convert.ToString( Eval("ReservationStatus"))) %>"> 
                                            <%--<%# Eval("SalesOrder")%>--%>
                                          <asp:Label ID="lblSalesOrder" runat="server" Text='<%# Eval("SalesOrder") %>'></asp:Label>
                                      </td>

                                      <td class="<%# GetClassName(Convert.ToString( Eval("ReservationStatus"))) %>">
                                             <asp:Label ID="lblReservationStatus" runat="server" Text='<%# Eval("ReservationStatus") %>'></asp:Label>
                                           <%-- <%# Eval("ReservationStatus")%>--%>
                                      </td>

                                      <td class="<%# GetClassName(Convert.ToString( Eval("ReservationStatus"))) %>">
                                             <asp:Label ID="lblUser" runat="server" Text='<%# Eval("ModifiedBy") %>'></asp:Label>
                                           <%-- <%# Eval("ReservationStatus")%>--%>
                                        </td>

                                      <td class="<%# GetClassName(Convert.ToString( Eval("ReservationStatus"))) %>">
                                            <a href="#" id="id1234" onclick="ShowPackTypes('<%# Eval("ReservationID")%>');">
                                                <asp:Image ID="imgclose" runat="server" ImageUrl="~/images/editPencil.png" Width="20" Height="20" alt="" />
                                            </a>
                                       </td>
                                       
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <th>Sr.No
                                        </th>
                                        <th>Reservation ID
                                        </th>
                                        <th>Creation Date   
                                        </th>
                                        <th>Customer Name
                                        </th>
                                        <th>Required Qty
                                        </th>
                                        <th>Required by Date
                                        </th>
                                        <th>Sales Order No
                                        </th>
                                        <th>Status
                                        </th>
                                         <th>Action</th>
                                      </tr>
                                      <tr>
                                        <td colspan="30">No Records Found.
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:ListView>

                    </div>
                      </div>
                 </div>
                  <%--<div class="col-lg-2">
                           
                           <div class="card">
                          <div class="card-header border-0">
                                    <div class="d-flex justify-content-between">
                                        <h3 class="card-title">Expired Reservation</h3>
                                    </div>
                               <div class="card-body">
                                   <div class="d-flex">
                                        <p class="d-flex flex-column">
                                            
                                        </p>
                                   </div>

                                    <div class="position-relative mb-4">
                                       <div id="chartCancel" class="chart" >
                                       </div>
                                    </div>
                                </div>
                           </div>
                      </div>
                        </div>--%>
                
             </div>
         </div>
         <%--<div class="table-responsive" style="overflow: auto">
             <div id="chartContainer" style="height: 370px; width: 100%;"></div>

             </div>--%>

                <%--<div class="table-responsive" style="overflow: auto">
                         <asp:GridView ID="gvInventoryOrderprogress" OnRowDataBound="gvInventoryOrderprogress_RowDataBound" class="table table-bordered"  runat="server">
                            <HeaderStyle BackColor="#007B72" Font-Bold="True" ForeColor="White" />
                                
                            
                         </asp:GridView>
                </div>--%>
            </div>
</asp:Content>

