<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DashBoardDeadStock.aspx.cs" Inherits="KaramMarketingWeb.DashBoardDeadStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--  <a href="Pollux/PolluxTable.scss">Pollux/PolluxTable.scss</a>--%>
    <%--<link href="W3S/w3css.css" rel="stylesheet" />--%>
    <link href="W3S/w3css4Block.css" rel="stylesheet" />
    
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
    </style>
     <script type="text/javascript">
         //DataTables Initialization for Map Table Example
         $(document).ready(function () {
             $('#inventory').dataTable();
         });

     </script>
       <script type="text/javascript">
           function ShowCreateReservation() {
               window.open('ReservationCreate.aspx', "width=" + screen.availWidth + ",height=" + screen.availHeight);
           }
       </script>

     
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                title: 'WareHouse Stock',
                hAxis: {
                    title: 'Category', titleTextStyle: { color: '#333' },
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
                },
                bar: { groupWidth: "20%" },

                chartArea: { left: 50, top: 50, bottom:100, width: "100%", height: "100%" }
            };
            $.ajax({
                type: "POST",
                url: "DashBoardDeadStock.aspx/CategoryWiseStock",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.ColumnChart($("#chartReserve")[0]);
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
                            <h5 class="m-0 text-dark">Dead Stock / Slow Moving DashBoard</h5>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <%--<ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">DeadStock/Slow Moving</li>
                            </ol>--%>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                
               <div class="w3-row-padding w3-margin-bottom">

                 <div class="w3-half">
                  <div class="w3-container w3-red w3-padding-16">
                    <div class="w3-left"><i class="fa fa-times-circle w3-xxlarge"></i></div>
                    <div class="w3-right">
                      <h1> <asp:Label ID="lblDeadStock" runat="server" Font-Size="24" Text="100" ForeColor="White"></asp:Label></h1>
                    </div>
                    <div class="w3-clear"></div>
                       <asp:LinkButton ID="btnDeadStock" runat="server"  ToolTip="Dead Stock Items"
                           CausesValidation="false" OnClick="btnDeadStock_Click">
                                     <h4 style="color:White;">Dead Stock Value</h4>                        
                       </asp:LinkButton>
                  </div>
                </div>

                 <div class="w3-half">
                  <div class="w3-container w3-green w3-text-white w3-padding-16">
                    <div class="w3-left"><i class="fa fa-spinner w3-xxlarge"></i></div>
                    <div class="w3-right">
                       <h1> <asp:Label ID="lblSlowMoving" runat="server" Font-Size="24" Text="100"></asp:Label></h1>
                    </div>
                    <div class="w3-clear"></div>
                       <asp:LinkButton ID="btnSlow" runat="server"  ToolTip="Slow Moving Items"
                           CausesValidation="false" OnClick="btnSlow_Click" >
                                    <h4 style="color:White;">Slow Moving Value</h4>                       
                       </asp:LinkButton>
                    
                  </div>
                </div>


   
           </div>

      </div>
    <div class="content">
        <div class="container-fluid">
             <asp:Label ID="lblReportName" runat="server" Text="Dead Stock Report" Font-Size="Medium" Font-Bold="true"></asp:Label>
             <div class="row">
                  <div class="col-lg-12">
                        <div class="card">
                           <div class="table-responsive" style="overflow: auto" >
                         <asp:ListView ID="lvRMGateinDetails" runat="server"  >
                            <LayoutTemplate>
                                <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                    <thead>
                                        <tr>
                                                <th>Sr.No
                                                </th>
                                                <th>Item Category
                                                </th>
                                                <th>Item Code
                                                </th>
                                                <th>Item Description
                                                </th>
                                                <th>UOM
                                                </th>
                                                <th>Available Qty in Warehouse
                                                </th>
                                                <th>Available Qty in Other Location
                                                </th>
                                                <th>Total Stock
                                                </th>
                                                <th>StockValue
                                                </th>
                                        </tr>
                                    </thead>
                                    <tbody id="ItemPlaceholder" runat="server">
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr >  <%--<="<%# GetClassName(Convert.ToString( Eval("ReservationStatus"))) %>">--%>
                                   <td>
                                            <%# Container.DataItemIndex + 1%>
                                        </td>
                                     <td>
                                            <%# Eval("Category")%>
                     
                                        </td>

                                        <td>
                                            <%# Eval("ItemCode")%>
                                        </td>

                                         <td> 
                                            <%# Eval("ItemDesc")%>
                                        </td>
                                     <td> 
                                            <%# Eval("UOM")%>
                                        </td>

                                        <td>
                                            <%# Eval("WHLoc")%>
                                        </td>

                                        <td>
                                            <%# Eval("OthLoc")%>
                                        </td>
                                         <td>
                                              <%# Eval("TotalStock")%>

                                         </td>
                                        <td>
                                            <%# Eval("StockValue")%>
                                        </td>
                                   
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                                <th>Sr.No
                                                </th>
                                                <th>Item Category
                                                </th>
                                                <th>Item Code
                                                </th>
                                                 <th>Item Description
                                                </th>
                                          <th>UOM
                                                </th>
                                                <th>Available Qty in Warehouse
                                                </th>
                                                <th>Available Qty in Other Location
                                                </th>
                                                <th>Total Stock
                                                </th>
                                               <th>StockValue
                                                </th>
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
                 </div>
             <div class="row">
                   <div class="col-lg-12">
                      <div class="card">
                          <div class="card-header border-0">
                                    <div class="d-flex justify-content-between">
                                        <h3 class="card-title">Category wise Stock Value</h3>
                                       <%-- <a href="javascript:void(0);"  onclick="javascript:ShowReservation(0);">View Report</a>--%>
                                    </div>
                               <div class="card-body">
                                   

                                    <div class="position-relative mb-4">
                                        <div id="chartReserve" class="chart" >
                                       </div> 
                                    </div>
                                </div>
                           </div>
                      </div>
                      
                  </div>
                  <div class="col-lg-9">
                    
                 </div>
                 
             </div>
         </div>
            </div>
</asp:Content>
