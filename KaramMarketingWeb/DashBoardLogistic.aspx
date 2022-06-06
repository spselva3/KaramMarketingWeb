<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DashBoardLogistic.aspx.cs" Inherits="KaramMarketingWeb.DashBoardLogistic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <%--  <a href="Pollux/PolluxTable.scss">Pollux/PolluxTable.scss</a>--%>
    <link href="W3S/w3css4Block.css" rel="stylesheet" />
    <%--<link href="W3S/w3css.css" rel="stylesheet" />--%>
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
      
      .BoxHeightDash {
       min-height:120px;
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
    </style>
    <script type="text/javascript">
         //DataTables Initialization for Map Table Example
         $(document).ready(function () {
             $('#inventory').dataTable();
         });

    </script>
      <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
     <script type="text/javascript" src="https://www.google.com/jsapi"></script>
     
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
                            <h5 class="m-0 text-dark">Logistic DashBoard</h5>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                          
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                 <div class="container-fluid">
                         <div class="row mb-2">

                              <div class="col-sm-12" >
                                  <div style="float:right;">
                                <input class="w-1\/4  py-1 text-gray-1000 bg-blue-200 rounded" runat="server" id="txtFrom" name="From" type="date"  placeholder="From Date" aria-label="username">
            
                                <input class="w-1\/4  py-1 text-gray-1000 bg-blue-200 rounded" runat="server" id="txtTo" name="To" type="date"  placeholder="To Date" aria-label="username">
            
                                <asp:Button ID ="btnSearch" runat="server" OnClick="btnSearch_Click"  CausesValidation="false" Text="Apply"   class="btn btn-primary SearchButton"  />
                          
                                  </div>
                             
                      
                      
                              </div>
                              
                         </div>
                    </div>
                 <div class="w3-row-padding w3-margin-bottom">

                     <div class="w3-quarter">
                      <div class="w3-container w3-blue w3-padding-16 BoxHeightDash">
                        <div class="w3-left"><i class="fas fa-boxes w3-xxlarge"></i></div><br />
                        <div class="w3-right">
                          <h1> <asp:Label ID="lblNewOrders" runat="server" Font-Size="22" Text="100" ForeColor="White"></asp:Label></h1>
                        </div>
                        <div class="w3-clear"></div>
                           <asp:LinkButton ID="btnNewOrders" runat="server" Enabled="true" ToolTip="New Orders WithOut TDOD"
                               CausesValidation="false" OnClick="btnNewOrders_Click">
                                         <h4 style="color:White;">New Orders WithOut TDOD</h4>                        
                           </asp:LinkButton>
                      </div>
                    </div>

                     <div class="w3-quarter">
                      <div class="w3-container w3-teal w3-text-white w3-padding-16 BoxHeightDash">
                        <div class="w3-left"><i class="fas fa-boxes w3-xxlarge"></i></div><br />
                        <div class="w3-right">
                           <h1> <asp:Label ID="lblTodayOrder" runat="server" Font-Size="22" Text="100"></asp:Label></h1>
                        </div>
                        <div class="w3-clear"></div>
                           <asp:LinkButton ID="btnTodayOrders" runat="server" Enabled="true" ToolTip="Orders for Todays TDOD"
                               CausesValidation="false" OnClick="btnTodayOrders_Click">
                                        <h4 style="color:White;">Orders for Todays TDOD</h4>                       
                           </asp:LinkButton>
                      </div>
                    </div>

                     <div class="w3-quarter">
                      <div class="w3-container w3-indigo w3-text-white w3-padding-16 BoxHeightDash">
                        <div class="w3-left"><i class="fas fa-boxes w3-xxlarge"></i></div><br />
                        <div class="w3-right">
                           <h1> <asp:Label ID="lblWeekTDOD" runat="server" Font-Size="22" Text="100"></asp:Label></h1>
                        </div>
                        <div class="w3-clear"></div>
                           <asp:LinkButton ID="btnWeekTDOD" runat="server" Enabled="true" ToolTip="Stock Items"
                               CausesValidation="false" OnClick="btnWeekTDOD_Click">
                                         <h4 style="color:White;">Orders for 7 days TDOD</h4>                       
                           </asp:LinkButton>
                      </div>
                    </div>
 
                     <div class="w3-quarter">
                      <div class="w3-container w3-orange  w3-text-white w3-padding-16 BoxHeightDash">
                        <div class="w3-left"><i class="fa fa-spinner w3-xxlarge"></i></div><br />
                        <div class="w3-right">
                           <h1> <asp:Label ID="lblPendingOrders" runat="server" Font-Size="22" Text="100"></asp:Label></h1>
                        </div>
                        <div class="w3-clear"></div>
                            <asp:LinkButton ID="btnPendingOrders" runat="server" Enabled="true" ToolTip="Non-Stock Items"
                               CausesValidation="false" OnClick="btnPendingOrders_Click">
                                         <h4 style="color:White;">Total Pending Orders</h4>                    
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
                <div class="table-responsive" style="overflow: auto">
                       <asp:ListView ID="lvRMGateinDetails" runat="server" OnItemDataBound="lvRMGateinDetails_ItemDataBound" >
                            <LayoutTemplate>
                                <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                    <thead>
                                        <tr>
                                                <th>Sr.No
                                                </th>
                                                <th>Customer
                                                </th>
                                                <th>Sales Order   
                                                </th>
                                                <th>ItemCode
                                                </th>
                                                 <th>ItemDesc
                                                </th>
                                                 <th>Qty
                                                </th>
                                                <th>SO Value   
                                                </th>
                                                 <th>Booked Date
                                                </th>
                                                <th>Floor
                                                </th>
                                                <th>WH TDOD
                                                </th>
                                               <th>Prod TDOD</th>
                                        </tr>
                                    </thead>
                                    <tbody id="ItemPlaceholder" runat="server">
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr > 
                                   <td class="<%# GetClassName(Convert.ToString( Eval("ItemStatus"))) %>">
                                            <%# Container.DataItemIndex + 1%>
                                        </td>

                                     <td class="<%# GetClassName(Convert.ToString( Eval("ItemStatus"))) %> " >
                                            <%# Eval("Customer")%>
                                        </td>

                                     <td class="<%# GetClassName(Convert.ToString( Eval("ItemStatus"))) %>">
                                            <%# Eval("SalesOrder")%>
                                        </td>

                                        <td class="<%# GetClassName(Convert.ToString( Eval("ItemStatus"))) %>">
                                            <%# Eval("ItemCode")%>
                                        </td>
                                     <td class="<%# GetClassName(Convert.ToString( Eval("ItemStatus"))) %>">
                                            <%# Eval("ItemDesc")%>
                                        </td>
                                        
                                        <td class="<%# GetClassName(Convert.ToString( Eval("ItemStatus"))) %>">
                                            <%# Eval("RequestedQty")%>
                                        </td>
                                    <td class="<%# GetClassName(Convert.ToString( Eval("ItemStatus"))) %>">
                                            <%# Eval("SO_Value")%>
                                        </td>
                                     <td class="<%# GetClassName(Convert.ToString( Eval("ItemStatus"))) %>"> 
                                          <asp:Label ID="lblRequestedDate" runat="server" Text='<%# Eval("CrDate") %>'></asp:Label>
                                      </td>
                                         <td class="<%# GetClassName(Convert.ToString( Eval("ItemStatus"))) %>">
                                             <asp:Label ID="lblProductionFloor" runat="server" Text='<%# Eval("ProductionFloor") %>'></asp:Label>
                                        </td>
                                     <td class="<%# GetClassName(Convert.ToString( Eval("ItemStatus"))) %>">
                                             <asp:Label ID="lblUser" runat="server" Text='<%# Eval("WHTDOD") %>'></asp:Label>
                                           <%-- <%# Eval("ReservationStatus")%>--%>
                                        </td>
                                      <td class="<%# GetClassName(Convert.ToString( Eval("ItemStatus"))) %>">
                                          <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProdTDOD") %>'></asp:Label>
                                       </td>
                                       
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <th>Sr.No
                                                </th>
                                                <th>Customer
                                                </th>
                                                <th>Sales Order   
                                                </th>
                                                <th>ItemCode
                                                </th>
                                                 <th>ItemDesc
                                                </th>
                                                 <th>Qty
                                                </th>
                                                 <th>SO Value   
                                                </th>
                                                 <th>Booked Date
                                                </th>
                                                <th>Floor
                                                </th>
                                                <th>Requested Date
                                                </th>
                                               <th>Prod TDOD</th>
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
             </div>
            </div>
</asp:Content>