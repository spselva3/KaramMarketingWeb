<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateReservation.aspx.cs" Inherits="KaramMarketingWeb.CreateReservation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


       <%--<link href="FormDesign/form.css" rel="stylesheet" />--%>
   
    <style>

         table.lamp th {
                color: white;
                background-color: navy;
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
      .form-inline1 {  
          display: flex;
          flex-flow: row wrap;
          align-items: center;
        }

        .form-inline1 label {
          margin: 5px 10px 5px 0;
        }

        .form-inline1 input {
          vertical-align: middle;
          margin: 5px 10px 5px 0;
          padding: 5px;
          border: 1px solid #ddd;
        }

        .form-inline1 button {
          padding: 10px 10px;
          background-color: dodgerblue;
          border: 1px solid #ddd;
          cursor: pointer;
        }

        .form-inline1 button:hover {
        }

        @media (max-width: 500px) {
            .form-inline1 input {
                margin: 10px 0;
            }

            .form-inline1 {
                flex-direction: column;
                align-items: stretch;
            }
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
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

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
                             <asp:Label ID="lblHeading" runat="server" Text="Create Reservation" Font-Size="Larger" Font-Bold="true" class="m-0 text-dark"></asp:Label>
                        </div>
                         <div class="col-sm-9">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item active">Note: You can reserve the required items in Standard Packing only</li>
                            </ol>
                        </div>
                    </div>
                </div>
      </div>
    <div class="content">
        <div class="container-fluid">
             <div class="row">
                 <div class="col-lg-12">
                      <div class="card" >   
                               <%--<div class="card-body">--%>
                                  <div class="form-inline1">
                                       <label  for="email">Item Category:</label>
                                                <asp:TextBox ID="txtCategory"  runat="server" ClientIdMode="Static"></asp:TextBox>
                                        <div id="listPlacementCategory" style="height:200px; overflow-y:scroll;" ></div>
                                      <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="100" 
                                                        CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" 
                                                        ServiceMethod="GetCategory" TargetControlID="txtCategory" CompletionListElementID="listPlacementCategory"
                                                   ShowOnlyCurrentWordInCompletionListItem="true">
                                                </ajaxToolkit:AutoCompleteExtender>


                                       <label style="padding-left:10px" for="email">Item Code:</label>
                                                <asp:TextBox ID="txtItemCode"  runat="server" ClientIdMode="Static"></asp:TextBox>
                                     <div id="listPlacement" style="height:200px; overflow-y:scroll;" ></div>
                                      <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100" 
                                                        CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" 
                                                        ServiceMethod="GetItemCode" TargetControlID="txtItemCode"  CompletionListElementID="listPlacement"
                                                   ShowOnlyCurrentWordInCompletionListItem="true">
                                                    </ajaxToolkit:AutoCompleteExtender>

                                        <label for="email">Item Description:</label>
                                                <asp:TextBox ID="txtItemDesc"  runat="server" ClientIdMode="Static"></asp:TextBox>
                                        <div id="listPlacementDesc" style="height:200px; overflow-y:scroll;" ></div>
                                               <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="100" 
                                                        CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" 
                                                        ServiceMethod="GetItemDesc" TargetControlID="txtItemDesc"  CompletionListElementID="listPlacementDesc"
                                                   ShowOnlyCurrentWordInCompletionListItem="true">
                                               </ajaxToolkit:AutoCompleteExtender>

                                      
                                        <asp:Button ID ="btnCreate" runat="server"  Text="Search" class="btn btn-success" OnClick="btnCreate_Click"  Width="90px"  />&nbsp;
                                       <asp:Button ID ="btnClear" runat="server"   CausesValidation="false" Text="Clear" class="btn btn-warning" OnClick="btnClear_Click" Width="90px"   />&nbsp;
                                  </div>
                               <%--</div>--%>
                          </div>
                      
                  </div>
                 <div class="col-lg-12">
                      <div class="card" >   
                                 <div class="table-responsive" style="overflow: scroll; height:200px;">
                   
                                    <asp:ListView ID="lvMatdetails" runat="server" >
                                        <LayoutTemplate>
                                            <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%; max-height:300px;"  id="inventory">
                                                <tr>
                                                    <th>
                                                        <asp:CheckBox ID="chkHeader" runat="server" OnCheckedChanged="chkHeader_CheckedChanged" AutoPostBack="true" />
                                                    </th>
                                                    <th style="width: 10px;">Sr.No</th>
                                                    <th style="width:100px;">Item Code</th>
                                                      <th>Item Description</th>
                                                    <th style="display: none;">Item Description</th>
                                                    <th>Category</th>
                                                    <th>UOM</th>
                                                   
                                                    <th style="width:100px;">Available Qty</th>
                                                    <%-- <th>Demand Qty</th>--%>
                                                </tr>
                                                <tr id="ItemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:CheckBox ID="chkSelect" runat="server"   />
                                                </td>
                                                <td style="text-align: center;"><%# Container.DataItemIndex + 1%></td>
                                                <td>
                                                    <asp:Label ID="lblItemCode" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:Label ID="lblItemDesc" runat="server"  Text='<%# Eval("ItemDesc") %>'></asp:Label>
                                                </td>
                                                 <td style="display: none;">
                                                    <asp:Label ID="lblItemDescValue" runat="server" Visible="false" Text='<%# Eval("ItemDesc").ToString().Length > 45 ? 
                                                            Eval("ItemDesc").ToString().Substring(0,45) : Eval("ItemDesc") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCategory" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                                </td>
                                                <td>

                                                    <asp:Label ID="lblUOM" runat="server" Text='<%# Eval("UOM") %>'></asp:Label>
                                                </td>
                                                 
                                                <td>
                                                    <asp:Label ID="lblAvailableQty" runat="server" Text='<%# Eval("AvailableQty") %>'></asp:Label>
                                                </td>
                                                <%-- <td>
                                                    <asp:TextBox ID="txtDemand" runat="server" Text="0" Width="40px" AutoCompleteType="Disabled"
                                                                onkeypress="return validateFloatKeyPress(this, event)"></asp:TextBox>
                                                </td>--%>
                                               
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
                                                    <%--<th>Demand Qty</th>--%>
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
                 <div class="col-lg-12">
                               <div class ="center">
                                      <asp:Button ID ="btnAdd" runat="server"  Text="Add to Cart" class="btn btn-success" OnClick="btnAdd_Click"  Width="120px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnCancel" runat="server"   CausesValidation="false" Text="Close" class="btn btn-danger" OnClick="btnCancel_Click" Width="90px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnLoadCart" runat="server"   CausesValidation="false" Text="Load Cart" class="btn btn-primary" OnClick="btnLoadCart_Click" Width="120px"  Height="31px" />
                                      <asp:HiddenField ID="hdnUSERID" runat="server" Value="" />
                                   </div>
                  </div>
                 <br /> <br />
                 <div class="col-lg-12">
                      <div class="card" >   
                                 <div class="table-responsive" style="overflow: scroll; height:200px;">
                   
                                    <asp:ListView ID="lvProductdetails" runat="server" OnItemDataBound="lvProductdetails_ItemDataBound" >
                                        <LayoutTemplate>
                                              <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%; max-height:300px;"  id="inventory">
                                                <tr>
                                                    <th style="width: 10px;">Sr.No</th>
                                                     <th>Item Category</th>
                                                     <th>Item Code</th>
                                                     <th >Item Description</th>
                                                    <th style="display: none;">Item Description</th>
                                                    <th>UOM</th>
                                                    <th>Available Qty</th>
                                                    <th>Standard Packing</th>
                                                     <th>Required Packings(Nos.)</th>
                                                    <th>Required Qty</th>
                                                     <th>Delete</th>
                                                </tr>
                                                <tr id="ItemPlaceholder" runat="server">
                                                </tr>
                                            </table>
                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td style="text-align: center;"><%# Container.DataItemIndex + 1%></td>
                                                  <td>
                                                    <asp:Label ID="lblCategory1" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                                </td>
                                               <td>
                                                    <asp:Label ID="lblItemCode1" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                                </td>
                                                <td >
                                                    <asp:Label ID="lblItemDesc1" runat="server" Text='<%# Eval("ItemDesc") %>'></asp:Label>
                                                </td>
                                                <td style="display: none;">
                                                    <asp:Label ID="lblItemDescValue1" Visible="false" runat="server" Text='<%# Eval("ItemDesc").ToString().Length > 45 ? 
                                                            Eval("ItemDesc").ToString().Substring(0,45) : Eval("ItemDesc") %>'></asp:Label>
                                                </td>
                                              

                                                <td>
                                                    <asp:Label ID="lblUOM1" runat="server" Text='<%# Eval("UOM") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblAvailableQty1" runat="server" Text='<%# Eval("AvailableQty") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                       <asp:Label ID="lblPackStyle" runat="server" Text='<%# Eval("PackStyle") %>' Visible="false"></asp:Label>
                                                       <asp:DropDownList ID="dllPackStyle" runat="server" Width="100px"></asp:DropDownList>

                                                 </td>
                                               <td>
                                                   
                                                        <asp:TextBox ID="txtDemandPack" runat="server" Text='<%# Eval("PackReq") %>' Width="40px" AutoCompleteType="Disabled" AutoPostBack="true"
                                                            OnTextChanged="txtDemandPack_TextChanged" 
                                                                    onkeypress="return validateFloatKeyPress(this, event)"></asp:TextBox>
                                                    
                                             </td>
                                                 <td>
                                                    <asp:Label ID="lblDemand" runat="server" Text='<%# Eval("DemandQty") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                <asp:LinkButton ID="lnkclose" runat="server" ToolTip="Delete" CausesValidation="false" OnClick="lnkclose_Click"
                                                                OnClientClick="return DeleteConfirmation();">
                                                 <asp:Image ID="imgclose" runat="server" ImageUrl="~/images/DeleteIcon.png" Width="20" Height="20" alt="" />
                                                            </asp:LinkButton>
                                                     </td>
                                            </tr>
                                        </ItemTemplate>
                                        <EmptyDataTemplate>
                                            <table class="lamp" cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                     <th style="width: 10px;">Sr.No</th>
                                                     <th>Item Code</th>
                                                    <th style="display: none;">Item Description</th>
                                                    <th>Item Description</th>
                                                    <th>Item Category</th>
                                                    <th>UOM</th>
                                                    <th>Available Qty</th>
                                                      <th>Standard Packing</th>
                                                    <th>Required Packings(Nos.)</th>
                                                     <th>Required Qty</th>
                                                     <th>Delete</th>
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
                     <div class="col-lg-12">
                                 <div class="card" >   
                                      <div class="form-inline1">

                                           <label style="padding-left:10px" for="email">Req. Date:</label>
                                                    <asp:TextBox ID="txtDemandDate"  runat="server" ClientIdMode="Static" AutoCompleteType="Disabled" ></asp:TextBox>
                                                   <ajaxtoolkit:calendarextender ID="CalendarExtender1" PopupPosition="BottomLeft" runat="server"  TargetControlID="txtDemandDate" Format="dd-MM-yyyy" />

                                           <label for="email">Customer Name:</label>
                                                    <asp:TextBox ID="txtCustomer" runat="server"  AutoCompleteType="Disabled" ReadOnly="false"></asp:TextBox>
                            

                                           <label  for="email">Sales Order No:</label>
                                                    <asp:TextBox ID="txtSalesOrder" runat="server" AutoPostBack="true" OnTextChanged="txtSalesOrder_TextChanged" AutoCompleteType="Disabled" ReadOnly="false"></asp:TextBox>
                                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" CompletionInterval="100" 
                                                            CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" 
                                                            ServiceMethod="GetSalesOrder" TargetControlID="txtSalesOrder">
                                                        </ajaxToolkit:AutoCompleteExtender>

                                           <label  for="email">SO Date:</label>
                                                   <asp:TextBox ID="txtSODate" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                                                  <ajaxtoolkit:calendarextender ID="CalendarExtender2" PopupPosition="BottomLeft" runat="server"  TargetControlID="txtSODate" Format="dd-MM-yyyy" />
    
                                      </div>
                              </div>
                      </div>


                  <div class="col-lg-12">
                               <div class ="center">
                                      <asp:Button ID ="btnGenerate" runat="server"  Text="Generate Reservation ID" class="btn btn-success" OnClick="btnGenerate_Click"  Width="180px"  Height="35px" />&nbsp;
                                     
                                   </div>
                      <br />
                  </div>
             </div>
         </div>
       </div>
</asp:Content>

