<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConsolidatedReport.aspx.cs" Inherits="KaramMarketingWeb.ConsolidatedReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet"  href="Login/Style.css"/>
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

    <script type="text/javascript" src="NewTable/DataTables/datatables.min.js"></script>

    <script type="text/javascript">
        //DataTables Initialization for Map Table Example
        $(document).ready(function () {
            $('#inventory').dataTable(
            );
        });

    </script>
     <script type="text/javascript">
         function ShowCreateReservation() { 
             window.open('ReservationCreate.aspx', "width=" + screen.availWidth + ",height=" + screen.availHeight);
         }
     </script>

     <script type="text/javascript">
         function ShowReservationItems(ReserveID) {
             window.open("ReservedItems.aspx?Id=" + ReserveID, "_self");
         }
     </script>

       <script type="text/javascript">
           function ShowPackTypes(Reservation) {
               window.open('EditSO.aspx?ID=' + Reservation, "width=" + screen.availWidth + ",height=" + screen.availHeight);
           }
       </script>


       <script type="text/javascript">
           function ShowLoadOptimisation(SalesOrder) {
               window.open('LoadPalletAdd.aspx?ID=' + SalesOrder, "_self");
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
                            <h5 class="m-0 text-dark">Consolidated Report</h5>
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <%--<ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">Logistic Report</li>
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
                              <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>  
                              <asp:ListItem Text="Pending" Value="Pending" ></asp:ListItem>
                                <asp:ListItem Text="In-Progress" Value="In-Progress"></asp:ListItem>
                                <asp:ListItem Text="Done" Value="Done"></asp:ListItem>

                            </asp:DropDownList>
                    <asp:Button ID ="btnSearch" runat="server" OnClick="btnSearch_Click"  CausesValidation="false" Text="Search" Width="90px"  class="btn btn-primary" Height="32px" />
                      </div>
                              
                 </div>
            </div>
           <div class="table-responsive" style="overflow: auto">
                         <asp:ListView ID="lvRMGateinDetails" runat="server" OnItemDataBound="lvRMGateinDetails_ItemDataBound" >
                            <LayoutTemplate>
                                <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                    <thead>
                                        <tr>
                                          <th>S.No
                                            </th>
                                             <th>Reservation ID
                                            </th>
                                            <th>Demand Date
                                            </th>
                                             <th>Qty
                                            </th>
                                            <th>Customer
                                            </th>
                                             <th>Sales Order
                                            </th>
                                            <th>SO Date
                                            </th>
                                            <th>MTDOD
                                            </th>
                                            <th>MTDOD-R
                                            </th>
                                            <th>Status
                                            </th>
                                            <th>Remarks
                                            </th>
                                             <th>LogTDOD
                                            </th>
                                            <th>LogTDOD-R
                                            </th>
                                            <th>Status
                                            </th>
                                            <th>Remarks
                                            </th>
                                            <th>WHTDOD
                                            </th>
                                            <th>WHTDOD-R
                                            </th>
                                            <th>Status
                                            </th>
                                            <th>Remarks
                                            </th>
                                            <th>ProdTDOD
                                            </th>
                                            <th>ProdTDOD-R
                                            </th>
                                            <th>Status
                                            </th>
                                            <th>Remarks
                                            </th>
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
                                 <td><a href="#" id="Reserveid123" onclick="ShowReservationItems('<%# Eval("ReservationID")%>'); "/>
                                        <%# Eval("ReservationID")%>
                                    </td>
                                    <td>
                                        <%# Eval("DemandDate")%>
                                    </td>
                                     <td>
                                        <%# Eval("Qty")%>
                                    </td>
                                    <td>
                                        <%# Eval("CustomerName")%>
                                    </td>
                                     <td>
                                        <%# Eval("SalesOrder")%>
                                    </td>
                                     <td>
                                        <%# Eval("SalesOrderDate")%>
                                    </td>
                                    <td>
                                        <%# Eval("MTDOD")%>
                                    </td>
                                    <td>
                                        <%# Eval("RMTDOD")%>
                                    </td>
                                     <td> 
                                        <%# Eval("ReservationStatus")%>
                                    </td>
                                    <td>
                                        <%# Eval("MTDODRemarks")%>
                                    </td>

                                     <td>
                                        <%# Eval("LogTDOD")%>
                                    </td>
                                    <td>
                                        <%# Eval("LogRTDOD")%>
                                    </td>
                                     <td> 
                                        <%# Eval("LogisticStatus")%>
                                    </td>
                                    <td>
                                        <%# Eval("LogTDODRemarks")%>
                                    </td>

                                      <td>
                                        <%# Eval("WHTDOD")%>
                                    </td>
                                    <td>
                                        <%# Eval("WHETDOD")%>
                                    </td>
                                     <td> 
                                        <%# Eval("WHReferenceStatus")%>
                                    </td>
                                    <td>
                                        <%# Eval("WHTDODRemarks")%>
                                    </td>

                                      <td>
                                        <%# Eval("ProductionTDOD")%>
                                    </td>
                                    <td>
                                        <%# Eval("ProductionRTDOD")%>
                                    </td>
                                     <td> 
                                        <%# Eval("ProdReserveStatus")%>
                                    </td>
                                    <td>
                                        <%# Eval("ProdTDODRemarks")%>
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
                                            <th>Demand Date
                                            </th>
                                             <th>Qty
                                            </th>
                                            <th>Customer
                                            </th>
                                             <th>Sales Order
                                            </th>
                                            <th>SO Date
                                            </th>
                                            <th>MTDOD
                                            </th>
                                            <th>MTDOD-R
                                            </th>
                                            <th>Status
                                            </th>
                                            <th>Remarks
                                            </th>
                                             <th>LogTDOD
                                            </th>
                                            <th>LogTDOD-R
                                            </th>
                                            <th>Status
                                            </th>
                                            <th>Remarks
                                            </th>
                                            <th>WHTDOD
                                            </th>
                                            <th>WHTDOD-R
                                            </th>
                                            <th>Status
                                            </th>
                                            <th>Remarks
                                            </th>
                                            <th>ProdTDOD
                                            </th>
                                            <th>ProdTDOD-R
                                            </th>
                                            <th>Status
                                            </th>
                                            <th>Remarks
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
</asp:Content>



