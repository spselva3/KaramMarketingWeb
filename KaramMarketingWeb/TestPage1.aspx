<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TestPage1.aspx.cs" Inherits="KaramMarketingWeb.TestPage1" %>
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
                *cursor: hand;
            }
    </style>

    <script type="text/javascript" src="NewTable/DataTables/datatables.min.js"></script>

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
           function ShowPackTypes(Reservation) {
               var x = screen.width / 2 - 900 / 2;
               var y = screen.height / 2 - 400 / 2;
               window.open('EditSO.aspx?ID=' + Reservation, "width=" + screen.availWidth + ",height=" + screen.availHeight);
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
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">Reservation Report</li>
                            </ol>
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
                      <div class="col-sm-6">
                    <input class="w-1\/4 px-5 py-1 text-gray-1000 bg-blue-200 rounded" runat="server" id="txtFrom" name="From" type="date" required="" placeholder="From Date" aria-label="username">
            
                    <input class="w-1\/4 px-5 py-1 text-gray-1000 bg-blue-200 rounded" runat="server" id="txtTo" name="To" type="date" required="" placeholder="To Date" aria-label="username">
            
                    <asp:Button ID ="btnSearch" runat="server" OnClick="btnSearch_Click"  CausesValidation="false" Text="Search" class="btn btn-primary" Height="31px" />
                          </div>
                     <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                               <a href="javascript:void(0);" style="text-decoration: none" onclick="javascript:ShowCreateReservation(0);">
                                 <asp:Button ID ="Create" runat="server"   CausesValidation="false" Text="Create" class="btn btn-success" Width="90px"  Height="31px" /></a>
                          </ol>
                      </div>
                              
                 </div>
            </div>
           <div class="table-responsive" style="overflow: auto">
                         <asp:ListView ID="lvRMGateinDetails" runat="server"  >
                            <LayoutTemplate>
                                <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                    <thead>
                                        <tr>
                                           <th>S.No
                                                </th>
                                                <th>Reservation ID
                                                </th>
                                                <th>Customer
                                                </th>
                                                 <th>Sales Order
                                                </th>
                                                <th>Demand Qty
                                                </th>
                                                <th>Demand Date
                                                </th>
                                                <th>Status
                                                </th>
                                                <th>User
                                                </th>
                                                <th>TimeStamp
                                                </th>
                                             <th>Edit</th>
                        
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
                                     <td><a href="#" id="id123" onclick="ShowReserveItems('<%# Eval("ReservationID")%>'); "/>
                                            <%# Eval("ReservationID")%>
                     
                                        </td>

                                        <td>
                                            <%# Eval("CustomerName")%>
                                        </td>
                                         <td>
                                            <%# Eval("SalesOrder")%>
                                        </td>
                                        <td>
                                            <%# Eval("Qty")%>
                                        </td>
                                        <td>
                                            <%# Eval("DemandDate")%>
                                        </td>
                                         <td>
                                             <asp:Label ID="lblReservationStatus" runat="server" Text='<%# Eval("ReservationStatus") %>'></asp:Label>
                                           <%-- <%# Eval("ReservationStatus")%>--%>
                                        </td>
                                        <td>
                                            <%# Eval("ModifiedBy")%>
                                        </td>
               
                                        <td>
                                            <%# Eval("ModifiedDate")%>
                                        </td>
                                   <td>
                                        <a href="#" id="id123" onclick="ShowPackTypes('<%# Eval("ReservationID")%>');">
                        
                                            <asp:Image ID="imgclose" runat="server" ImageUrl="~/images/editPencil.png" Width="20" Height="20" alt="" />
                                        </a>
                                    </td>
                 
                                </tr>
                            </ItemTemplate>
                            <EmptyDataTemplate>
                                <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                         <th>S.No
                                            </th>
                                             <th>Reservation ID
                                            </th>
                                            <th>Customer
                                            </th>
                                             <th>Sales Order
                                            </th>
                                            <th>Demand Qty
                                            </th>
                                            <th>Demand Date
                                            </th>
                                            <th>Status
                                            </th>
                                            <th>User
                                            </th>
                                            <th>TimeStamp
                                            </th>
                                            <th>Edit</th>
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
