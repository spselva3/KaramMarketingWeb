<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DashBoardWHStock.aspx.cs" Inherits="KaramMarketingWeb.DashBoardWHStock" %>

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

      .BoxHeightDash {
       min-height:120px;
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
                        color: 'aliceblue'
                    },
                    minValue: 0
                },
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                },
                bar: { groupWidth: "15%" },

                chartArea: { left: 80, top: 50 ,bottom:110 , width: "100%", height: "100%" }
            };
            $.ajax({
                type: "POST",
                url: "DashBoardWHStock.aspx/CategoryWiseStock",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d); 

                    var view = new google.visualization.DataView(data);
                    view.setColumns([0, 1,
                        {
                            calc: 'stringify',
                            sourceColumn: 0,
                            type: 'string',
                            role: 'annotation'
                        }
                    ]); 

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
      <div id="pageloaddiv"></div>
    <div class="content-header">
                <div class="container-fluid">
                    <div class="row mb-2">
                        <div class="col-sm-3">
                            <h5 class="m-0 text-dark">WH Stock DashBoard</h5>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <%--<ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">WH Stock</li>
                            </ol>--%>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                
               <div class="w3-row-padding w3-margin-bottom">

                     <div class="w3-quarter">
                      <div class="w3-container w3-indigo w3-padding-16 BoxHeightDash">
                        <div class="w3-left"><i class="fa fa-percent w3-xlarge"></i></div><br />
                        <div class="w3-right">
                          <h1> <asp:Label ID="lblFilled" runat="server" Font-Size="22" Text="100" ForeColor="White"></asp:Label></h1>
                        </div>
                        <div class="w3-clear"></div>
                           <asp:LinkButton ID="btnFilled" runat="server" Enabled="false" ToolTip="Stock Level"
                               CausesValidation="false" OnClick="btnFilled_Click">
                                         <h4 style="color:White;">Stock Level</h4>                        
                           </asp:LinkButton>
                      </div>
                    </div>

                     <div class="w3-quarter">
                      <div class="w3-container w3-indigo w3-text-white w3-padding-16 BoxHeightDash">
                        <div class="w3-left"><i class="fa fa-spinner w3-xlarge"></i></div><br />
                        <div class="w3-right">
                           <h1> <asp:Label ID="lblStock" runat="server" Font-Size="22" Text=""></asp:Label></h1>
                        </div>
                        <div class="w3-clear"></div>
                           <asp:LinkButton ID="btnStock" runat="server" Enabled="false" ToolTip="Stock Value"
                               CausesValidation="false" OnClick="btnStock_Click">
                                        <h4 style="color:White;">Stock Value</h4>                       
                           </asp:LinkButton>
                    
                      </div>
                    </div>

                     <div class="w3-quarter">
                      <div class="w3-container w3-indigo w3-text-white w3-padding-16 BoxHeightDash">
                        <div class="w3-left"><i class="fas fa-boxes w3-xxlarge"></i></div><br />
                        <div class="w3-right">
                           <h1> <asp:Label ID="lblWHItem" runat="server" Font-Size="22" Text="100"></asp:Label></h1>
                        </div>
                        <div class="w3-clear"></div>
                           <asp:LinkButton ID="btnWHItem" runat="server" Enabled="false" ToolTip="Stock Items"
                               CausesValidation="false" OnClick="btnWHItem_Click">
                                         <h4 style="color:White;">Stock Items</h4>                       
                           </asp:LinkButton>
                   
                      </div>
                    </div>
 
                     <div class="w3-quarter">
                      <div class="w3-container w3-indigo w3-padding-16 BoxHeightDash">
                        <div class="w3-left"><i class="fas fa-boxes w3-xxlarge"></i></div><br />
                        <div class="w3-right">
                           <h1> <asp:Label ID="lblnonWH" runat="server" Font-Size="22" Text="100"></asp:Label></h1>
                        </div>
                        <div class="w3-clear"></div>
                            <asp:LinkButton ID="btnNonWHItem" runat="server" Enabled="false" ToolTip="Non-Stock Items "
                               CausesValidation="false" OnClick="btnNonWHItem_Click">
                                         <h4 style="color:White;">Non-Stock Items </h4>                    
                           </asp:LinkButton>
                    
                      </div>
                    </div>
   
              </div>

      </div>
    <div class="content">
        <div class="container-fluid">
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
                                                <th>Item Type
                                                </th>
                                                <th>Item Code
                                                </th>
                                                 <th>Item Description
                                                </th>
                                                <th>UOM
                                                </th>
                                              <th>MOL Qty
                                                </th>
                                              <th>Available Qty
                                                </th>
                                                <th>Standard Packing
                                                </th>
                                                <th>PerPack
                                                </th>
                                             <%-- <th>other Loc
                                                </th>--%>
                                             
                        
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
                                            <%# Eval("ItemType")%>
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
                                            <%# Eval("SafetyStock")%>
                                        </td>
                                      <td>
                                            <%# Eval("EHLoc")%>
                                        </td>
                                        <td>
                                            <%# Eval("PackType")%>
                                        </td>

                                         <td>
                                              <%# Eval("PerPack")%>

                                         </td>
                                   
                                  <%--  <td>
                                            <%# Eval("OtherLocation")%>
                                        </td>--%>
                                  
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                           <th>Sr.No
                                                </th>
                                                <th>Item Category
                                                </th>
                                                <th>Item Type
                                                </th>
                                                <th>Item Code
                                                </th>
                                                 <th>Item Description
                                                </th>
                                                <th>UOM
                                                </th>
                                              <th>MOL Qty
                                                </th>
                                              <th>Available Qty
                                                </th>
                                                <th>Standard Packing
                                                </th>
                                                <th>PerPack
                                                </th>
                                            <%--  <th>other Loc
                                                </th>--%>
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
                                        <h3 class="card-title">Item Category wise Stock Level</h3>
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
                </div>
         </div>
            </div>
</asp:Content>

