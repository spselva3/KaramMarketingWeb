<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="frmMarketingList.aspx.cs" Inherits="KaramMarketingWeb.frmMarketingList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet"  href="Login/Style.css"  />
    <style>

         table.lamp th {
                color: white;
                background-color: #007B72;
                padding: 10px;
                padding-left: 10px;
                text-align: left;
                cursor: pointer;
                *cursor: move;
            }

        
    </style>

    <%--<script type="text/javascript" src="NewTable/DataTables/datatables.min.js"></script>--%>
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body"  runat="server">
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
                            <h5 class="m-0 text-dark">Reservation List</h5>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                           <%-- <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">Reservation Report</li>
                            </ol>--%>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.container-fluid -->
            </div>
       <div class="content-header">
               <%-- <div class="container-fluid">--%>
            <div class="container-fluid">
                 <div class="row mb-2">
                      <div class="col-sm-12">
                    <input class="w-1\/4  py-1 text-gray-1000 bg-blue-200 rounded" runat="server" id="txtFrom" name="From" type="date"  placeholder="From Date" aria-label="username">
            
                    <input class="w-1\/4  py-1 text-gray-1000 bg-blue-200 rounded" runat="server" id="txtTo" name="To" type="date"  placeholder="To Date" aria-label="username">
            
                          <asp:DropDownList ID="ddlStatus" class="w-1\/4  py-1 text-gray-1000 bg-blue-200 rounded" Width="100px" runat="server" Height="31px" >
                                <asp:ListItem Text="SO Pending" Value="Pending" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="In-Process" Value="In-Progress"></asp:ListItem>
                                <asp:ListItem Text="Dispatched" Value="Done"></asp:ListItem>
                               <asp:ListItem Text="Cancelled/Expired" Value="Cancelled"></asp:ListItem>
                            </asp:DropDownList>
                    <asp:Button ID ="btnSearch" runat="server" OnClick="btnSearch_Click"  CausesValidation="false" Text="Search" Width="90px"  class="btn btn-primary" Height="32px" />
                        <%--  <ol style="float:right;">
                               <a href="javascript:void(0);" style="text-decoration: none" onclick="javascript:ShowCreateReservation(0);">
                                 <asp:Button ID ="Create" runat="server"   CausesValidation="false" Text="Create" class="btn btn-success" Width="90px"  Height="31px" /></a>
                          </ol>--%>
                      
                      
                      </div>
                              
                 </div>
            </div>
           <div class="table-responsive" style="overflow: auto">
                         <asp:ListView ID="lvRMGateinDetails" runat="server" OnItemDataBound="lvRMGateinDetails_ItemDataBound" >
                            <LayoutTemplate>
                                <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                    <thead>
                                        <tr>
                                                <th>Sr.No
                                                </th>
                                                <th>Requester
                                                </th>
                                                <th>Reservation ID
                                                </th>
                                                <th>Creation Date
                                                </th>
                                                <th>Customer Name
                                                </th>
                                                 <th>Sales Order No
                                                </th>
                                                <th>Required Qty
                                                </th>
                                                <th>Required by Date
                                                </th>
                                                <th>Status
                                                </th>
                                                <th>Action</th>
                        
                                        </tr>
                                    </thead>
                                    <tbody id="ItemPlaceholder" runat="server">
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                        <td>
                                            <%# Container.DataItemIndex + 1%>
                                        </td>
                                        <td>
                                             <asp:Label ID="lblUser" runat="server" Text='<%# Eval("ModifiedBy") %>'></asp:Label>
                                           <%-- <%# Eval("ModifiedBy")%>--%>
                                        </td>

                                         <td><a href="#" id="id123" onclick="ShowReserveItems('<%# Eval("ReservationID")%>'); "/>
                                            <%# Eval("ReservationID")%>
                                        </td>

                                         <td>
                                            <%# Eval("ModifiedDate")%>
                                        </td>
                                        <td>
                                            <%# Eval("CustomerName")%>
                                        </td>

                                        <td>
                                            <asp:Label ID="lblSalesOrder" runat="server" Text='<%# Eval("SalesOrder") %>'></asp:Label>
                                        </td>

                                       <td>
                                            <%# Eval("Qty")%>
                                        </td>

                                        <td>
                                            <%# Eval("DemandDate")%>
                                        </td>

                                         <td>
                                             <asp:Label ID="lblReservationStatus" runat="server" Text='<%# Eval("ReservationStatus") %>'></asp:Label>
                                        </td>

                                        <td>
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
                                                <th>Requester
                                                </th>
                                                <th>Reservation ID
                                                </th>
                                                <th>Creation Date
                                                </th>
                                                <th>Customer Name
                                                </th>
                                                 <th>Sales Order No
                                                </th>
                                                <th>Required Qty
                                                </th>
                                                <th>Required by Date
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
</asp:Content>

