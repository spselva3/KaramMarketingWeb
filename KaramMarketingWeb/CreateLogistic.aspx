<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateLogistic.aspx.cs" Inherits="KaramMarketingWeb.CreateLogistic" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
       <%--<link href="FormDesign/form.css" rel="stylesheet" />--%>
   
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
      .center {
      display: flex;
            justify-content: center;
    }
    </style>
     <script type="text/javascript">
         //DataTables Initialization for Map Table Example
         $(document).ready(function () {
             $('#inventory').dataTable();
         });

     </script>
    <script type="text/javascript">

        function ValidateData() {
            debugger;

            var Firstname = document.getElementById("txtFName").value;
            if (Firstname == "") {
                alert("Please enter First Name.");
                document.getElementById("txtFName").focus();
                return false;
            }
            var Username = document.getElementById("txtUname").value;
            if (Username == "") {
                alert("Please enter User Name.");
                document.getElementById("txtUname").focus();
                return false;
            }
            var Password = document.getElementById("txtPswd").value;
            if (Password == "") {
                alert("Please enter Password");
                document.getElementById("txtPswd").focus();
                return false;
            }

            var Role = document.getElementById("ddlRole").value;
            if (Role == "-1") {
                alert("Please Select Role");
                document.getElementById("ddlRole").focus();
                return false;
            }
            var Status = document.getElementById("ddlStatus").value;
            if (Status == "Please Select") {
                alert("Please Select Status");
                document.getElementById("ddlStatus").focus();
                return false;
            }
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

     <div id="lblMsg" class="alert alert-success alert-dismissable" style="display: none" runat="server">
        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
        <strong>
            <asp:Label ID="lblMessage1" runat="server" Text="Error"></asp:Label>
        </strong>
    </div>

    <div class="content-header">
                <div class="container-fluid">
                    <div class="row mb-2">
                        <div class="col-sm-3">
                             <asp:Label ID="lblHeading" runat="server" Text="Create Logistic" Font-Size="Larger" Font-Bold="true" class="m-0 text-dark"></asp:Label>
                           
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">Logistic Management</li>
                            </ol>
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
      </div>
    <div class="content">
        <div class="container-fluid">
             <div class="row">
                  <div class="col-lg-4">
                      <div class="card" >
                          
                               <div class="card-body"  >

                                   <div class="form-group">
                                      <label for="Firstname">Reservation ID:</label>
                                          <input type="text" class="form-control" id="lblReservation" autocomplete="off" runat="server" placeholder="" name="Firstname" >
                                     </div>

                                   <div class="form-group">
                                      <label for="Lastname">TDOD Date:</label>
                                         <input type="date" class="form-control" id="txtDemandDate" autocomplete="off" runat="server"  placeholder="" name="Date" format="dd-MM-yyyy" >
                                
                                       <%--<input type="date" id="txtDemandDate" class="form-control"  runat="server" format="dd-MM-yyyy"  >--%>
                                     <%--<ajaxtoolkit:calendarextender ID="CalendarExtender1" PopupPosition="BottomLeft" runat="server"  TargetControlID="txtDemandDate" Format="dd-MM-yyyy" />--%>

                                </div>
                           
                      </div>
                      
                  </div>
                 </div>
                  <div class="col-lg-4">
                      <div class="card" >
                               <div class="card-body"  >

                                   <div class="form-group">
                                      <label for="Firstname">Sales Order:</label>
                                          <input type="text" class="form-control" id="lblSalesOrder" autocomplete="off" runat="server" placeholder="" name="Firstname" >
                                     </div>

                                   <div class="form-group">
                                      <label for="Lastname">SO Date:</label>
                                      <input type="text" class="form-control" id="lblSoDate" autocomplete="off" runat="server" placeholder="" name="Lastname" >
                                    </div>
                               
                                </div>
                           </div>
                      
                      
                  </div>
                  <div class="col-lg-4">
                      <div class="card" >
                          
                               <div class="card-body"  >

                                   <div class="form-group">
                                      <label for="Firstname">Customer:</label>
                                          <input type="text" class="form-control" id="lblCustomer" autocomplete="off" runat="server" placeholder="" name="Firstname" >
                                     </div>

                                   <div class="form-group">
                                      <label for="Lastname">MTDOD:</label>
                                      <input type="text" class="form-control" id="lblMTDOD" autocomplete="off" runat="server" placeholder="" name="Lastname" >
                                    </div>
                               
                                </div>
                           
                      </div>
                      
                  </div>
                  <div id="pnlRemarks" runat="server" class="col-lg-12">
                      <div class="card" >
                               <div class="card-body"  >
                                   <div class="form-group">
                                      <label for="Firstname">Remarks :</label>
                                          <asp:TextBox ID="txtRemarks"  class="form-control" runat="server"></asp:TextBox>
                                      </div>
                                </div>
                           </div>
                  </div>

                  <div id="panelReservation" runat="server" class="col-lg-12">
                      <div class="card" >   
                               <div class="card-body">
                                  <div class="table-responsive" style="overflow: auto">
                                       <asp:ListView ID="lvMatdetails" runat="server">
                                        <LayoutTemplate>
                                           <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                                <tr>
                                                    <th>
                                                        <asp:CheckBox ID="chkHeader" runat="server" OnCheckedChanged="chkHeader_CheckedChanged" AutoPostBack="true" />
                                                    </th>
                                                    <th style="width: 10px;">S.No.</th>
                                                    <th>Item Code</th>
                                                     <th style="display: none;">Item Desc</th>
                                                    <th>Item Desc</th>
                                                    <th>Category</th>
                                                    <th>UOM</th>
                                                    <th>Available Qty</th>
                                                    <th>Pack Style</th>
                                                    <th>Pack Req.</th>
                                                    <th>Demand Qty</th>
                                                </tr>
                                                <tr id="ItemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkSelect" runat="server"  />
                                                </td>
                                                <td style="text-align: center;"><%# Container.DataItemIndex + 1%></td>
                                                <td>
                                                    <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                                </td>
                                                <td style="display: none;">
                                                    <asp:Label ID="lblItemDesc1" runat="server" Text='<%# Eval("ItemDesc") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblItemDesc" runat="server" Text='<%# Eval("ItemDesc").ToString().Length > 45 ? 
                                                            Eval("ItemDesc").ToString().Substring(0,45) : Eval("ItemDesc") %>'></asp:Label>
                                                </td>
                                               <%-- <td>
                                                    <asp:Label ID="lblItemDesc" runat="server" Text='<%# Eval("ItemDesc") %>'></asp:Label>
                                                </td>--%>
                                                <td>
                                                    <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblUOM" runat="server" Text='<%# Eval("UOM") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAvailableQty" runat="server" Text='<%# Eval("AvailableQty") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblPackStyle" runat="server" Text='<%# Eval("PackStyle") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblPackReq" runat="server" Text='<%# Eval("PackReq") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblDemandQty" runat="server" Text='<%# Eval("Qty") %>'></asp:Label>
                                                </td>
                                               
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                                <tr>
                                                    <th style="width: 10px;">S.No.</th>
                                                    <th>Item Code</th>
                                                    <th>Item Desc</th>
                                                    <th>Category</th>
                                                    <th>UOM</th>
                                                    <th>Available Qty</th>
                                                     <th>Pack Style</th>
                                                    <th>Pack Required</th>
                                                    <th>Demand Qty</th>
                                                </tr>
                                                <tr>
                                                    <td colspan="20">No Records Found.
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:ListView>

                                      </div>
                               </div>
                      </div>
                      
                  </div>
                  <div id="panelSalesorder" runat="server" class="col-lg-12">
                      <div class="card" >   
                               <div class="card-body">
                                  <div class="table-responsive" style="overflow: auto">
                                      <asp:ListView ID="lvSalesOrder" runat="server" OnItemDataBound="lvSalesOrder_ItemDataBound" >
                                        <LayoutTemplate>
                                              <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%; max-height:250px;"  id="inventory">
                                                <tr>
                                                     <th>
                                                        <asp:CheckBox ID="chkHeaderSalesOrder" runat="server" OnCheckedChanged="chkHeaderSalesOrder_CheckedChanged" AutoPostBack="true" />
                                                    </th>
                                                    <th style="width: 10px;">S.No.</th>
                                                     <th>Item Code</th>
                                                    <th>Item Desc</th>
                                                    <th>Available Qty</th>
                                                    <th>Demand Qty</th>
                                                    <th>UOM</th>
                                                     <th>PackStyle</th>
                                                    <th>Status</th>
                                                </tr>
                                                <tr id="ItemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkSelectSalesOrder" runat="server"  />
                                                </td>
                                                <td style="text-align: center;"><%# Container.DataItemIndex + 1%></td>
                                               <td>
                                                    <asp:Label ID="lblItemCode1" runat="server" Text='<%# Eval("SO_MatCode") %>'></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:Label ID="lblItemDesc1" runat="server" Text='<%# Eval("SO_Matdesc") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAvailableQty" runat="server" Text='<%# Eval("AvailableQty") %>'></asp:Label>
                                                </td>

                                                <td>
                                                    <asp:Label ID="lblSOQty" runat="server" Text='<%# Eval("SO_SOQuantity") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblUOM1" runat="server" Text='<%# Eval("SO_UOM") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                     <asp:Label ID="lblPackStyle" runat="server" Text='<%# Eval("SO_PackType") %>'></asp:Label>
                                                       <%--<asp:Label ID="lblPackStyle" runat="server"  Text='<%# Eval("PackStyle") %>'  Visible="false"></asp:Label>--%>
                                                       <%--<asp:DropDownList ID="dllPackStyle" runat="server" Width="100px"></asp:DropDownList>--%>

                                                 </td>
                                                 <td>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("SO_Rowstatus") %>'></asp:Label>
                                                </td>
                                                
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                     <th style="width: 10px;">S.No.</th>
                                                     <th>Item Code</th>
                                                    <th>Item Desc</th>
                                                    <th>Available Qty</th>
                                                    <th>Demand Qty</th>
                                                    <th>UOM</th>
                                                     <th>PackStyle</th>
                                                    <th>Status</th>
                                                </tr>
                                                <tr>
                                                    <td colspan="20">No Records Found.
                                                    </td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:ListView>

                                      </div>
                               </div>
                      </div>
                      
                  </div>
                  <div class="col-lg-12">
                      <div class="card" >   
                               <div class="card-body">
                                  <div class ="center">
                                        <asp:Button ID ="btnClear" runat="server"   CausesValidation="false" Text="Clear" class="btn btn-warning" OnClick="btnClear_Click" Width="90px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnCreate" runat="server"  Text="Send Request to WH" class="btn btn-success" OnClick="btnCreate_Click" OnClientClick="return ValidateData();" Width="150px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnClose" runat="server"   CausesValidation="false" Text="Close" class="btn btn-danger" OnClick="btnClose_Click" Width="90px"  Height="31px" />
                                     
                                   </div>
                               </div>
                      </div>
                      
                  </div>
             </div>
         </div>
       </div>
    
</asp:Content>

