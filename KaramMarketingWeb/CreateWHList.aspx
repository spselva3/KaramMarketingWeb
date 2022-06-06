<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateWHList.aspx.cs" Inherits="KaramMarketingWeb.CreateWHList" %>
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
       .TextDate {
      width :100px;
    }
    </style>
     <script type="text/javascript">
         //DataTables Initialization for Map Table Example
         $(document).ready(function () {
             $('#inventory').dataTable();
         });

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
                             <asp:Label ID="lblHeading" runat="server" Text="WareHouse Request" Font-Size="Larger" Font-Bold="true" class="m-0 text-dark"></asp:Label>
                           
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">WH Request Management</li>
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
                                      <label for="Lastname">WareHouse TDOD:</label>
                                      <input type="date" class="form-control" id="lblDemandDate" autocomplete="off"  runat="server" placeholder="" name="Lastname" format="dd-MM-yyyy" >
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
                                      <label for="Lastname">Logistic TDOD:</label>
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
                  <div class="col-lg-12">
                      <div class="card" >
                          
                               <div class="card-body"  >

                                   <div class="form-inline">
                                      <label for="Firstname">WHTDOD :</label>

                                         <asp:TextBox ID="txtWHTDODate" TextMode="Date" runat="server" Width="140px"  AutoCompleteType="Disabled"></asp:TextBox> &nbsp;&nbsp;
                                                  
                                       <asp:Button ID ="btnDateUpdate" runat="server"   CausesValidation="false" Text="Update"  class="btn btn-primary" OnClick="btnDateUpdate_Click" Width="90px"  Height="30px" />&nbsp;
                                   </div>
                                </div>
                      </div>
                  </div>
                
              <div class="col-lg-12">
                      <div class="card" >   
                               <div class="card-body">
                                  <div class="table-responsive" style="overflow: auto">
                                       <asp:ListView ID="lvMatdetails" runat="server" OnItemDataBound="lvMatdetails_ItemDataBound">
                                        <LayoutTemplate>
                                           <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%;"  id="inventory">
                                                <tr>
                                                    <th>
                                                        <asp:CheckBox ID="chkHeader" runat="server" OnCheckedChanged="chkHeader_CheckedChanged" AutoPostBack="true" />
                                                    </th>
                                                    <th style="width: 10px;">S.No</th>
                                                    <th>Item Code</th>
                                                    <th style="display: none;">Item Desc</th>
                                                    <th>Item Desc</th>
                                                    <th>Category</th>
                                                    <th>UOM</th>
                                                    <th>Available Qty</th>
                                                    <th>Pack Style</th>
                                                    <th>Pack Req</th>
                                                    <th>Demand Qty</th>
                                                     <th>Production Floor</th>
                                                    <th>Production Status</th>
                                                     <th>WHTDOD</th>
                                                     <th>WH Status</th>
                                                </tr>
                                                <tr id="ItemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                       <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                </td>
                                                <td style="text-align: center;"><%# Container.DataItemIndex + 1%></td>
                                                <td>
                                                    <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                                </td>
                                                 <td style="display: none;">
                                                    <asp:Label ID="lblItemDesc1" runat="server" Text='<%# Eval("ItemDesc") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblItemDesc" runat="server" Text='<%# Eval("ItemDesc").ToString().Length > 40 ? 
                                                            Eval("ItemDesc").ToString().Substring(0,40) : Eval("ItemDesc") %>'></asp:Label>
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
                                                  <td>
                                                    <asp:Label ID="lblFloor" runat="server" Text='<%# Eval("ProductionFloor") %>'></asp:Label>
                                                </td>
                                                  <td>
                                                    <asp:Label ID="lblProductionStatus" runat="server" Text='<%# Eval("ProductionStatus") %>'></asp:Label>
                                                </td>
                                                  <td>
                                                    <asp:TextBox ID="txtWHDate"  runat="server" Text='<%# Eval("WHTDOD") %>' Width="120px"  AutoCompleteType="Disabled"></asp:TextBox>
                                                  </td>
                                                <td>
                                                    <asp:Label ID="lblWhStatus" runat="server" Text='<%# Eval("WHItemStatus") %>'></asp:Label>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <th style="width: 10px;">S.No.</th>
                                                    <th>Item Code</th>
                                                    <th>Item Desc</th>
                                                    <th>Category</th>
                                                    <th>UOM</th>
                                                    <th>Available Qty</th>
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
                 <div class="col-lg-12">
                      <div class="card" >   
                          <div class="card-body">
                               <div class ="center">
                                        <asp:Button ID ="btnLogistics" runat="server"   CausesValidation="false" Text="Update to Logistics" class="btn btn-primary" OnClick="btnLogistics_Click" Width="150px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnProduction" runat="server"  Text="Transfer to Production" class="btn btn-success" OnClick="btnProduction_Click"  Width="150px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnClose" runat="server"   CausesValidation="false" Text="Close" class="btn btn-danger" OnClick="btnClose_Click" Width="90px"  Height="31px" />
                                     
                                </div>
                            </div>
                      </div>
                  </div>
             </div>
         </div>
       </div>
</asp:Content>
