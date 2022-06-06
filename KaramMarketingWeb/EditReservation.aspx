<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EditReservation.aspx.cs" Inherits="KaramMarketingWeb.EditReservation" %>

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
                    </div>
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
                                        <asp:TextBox ID="txtReservation" class="form-control" runat="server"  ReadOnly="true"></asp:TextBox>
                                       </div>

                                   <div class="form-group">
                                      <label for="Lastname">Customer:</label>
                                      <asp:TextBox ID="txtCustomer" class="form-control" runat="server"  ></asp:TextBox>
                                       </div>
                               
                                </div>
                           
                      </div>
                      
                  </div>
                 
                  <div class="col-lg-4">
                      <div class="card" >
                               <div class="card-body"  >

                                   <div class="form-group">
                                      <label for="Firstname">Req Date:</label>
                                          <asp:TextBox ID="txtDemandDate"  class="form-control" runat="server"></asp:TextBox>
                                            <ajaxtoolkit:calendarextender ID="CalendarExtender3" PopupPosition="BottomLeft" runat="server"  TargetControlID="txtDemandDate" Format="dd-MM-yyyy" />
                                             </div>

                                   <div class="form-group">
                                      <label for="Lastname">SO Date:</label>
                                     <asp:TextBox ID="txtStatus"  class="form-control" runat="server" ReadOnly="true" ></asp:TextBox>

                                   </div>
                               
                                </div>
                           </div>
                      
                      
                  </div>

                  <div class="col-lg-4">
                      <div class="card" >
                          
                               <div class="card-body"  >

                                   <div class="form-group">
                                      <label for="Firstname">SO:</label>
                                        <asp:TextBox ID="txtSalesOrder"  class="form-control"  runat="server" OnTextChanged="txtSalesOrder_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100" 
                                        CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" 
                                        ServiceMethod="GetSalesOrder" TargetControlID="txtSalesOrder">
                                         </ajaxToolkit:AutoCompleteExtender>
                 
                                   </div>

                                   <div class="form-group">
                                      <label for="label">SO Date:</label>
                                      <asp:TextBox ID="txtSODate" class="form-control"  runat="server"></asp:TextBox>
                                       <ajaxtoolkit:calendarextender ID="CalendarExtender4" PopupPosition="BottomLeft" runat="server"  TargetControlID="txtSODate" Format="dd-MM-yyyy" />
                                    </div>
                               
                                </div>
                           
                      </div>
                      
                  </div>

                   <div class="col-lg-12">
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
                                      <label for="Firstname">Reservation Cancellation  :</label> &nbsp;
                                        <asp:DropDownList class="form-control" ID="ddlReserveStatus" Width="160px"  runat="server">
                                            <asp:ListItem Text="Please Select" Value="Please Select" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Cancel" Value="Cancellation"></asp:ListItem>
                                        </asp:DropDownList>&nbsp;
                                                
                                       <asp:Button ID ="btnCancelReservation" runat="server"   CausesValidation="false" Text="Cancel ReservationID" class="btn btn-danger" OnClick="btnCancelReservation_Click" Width="160px"  Height="31px" />&nbsp;
                                   </div>

                                  
                               
                                </div>
                           
                      </div>
                      
                  </div>
                 <div class="col-lg-12">
                      <div class="card" >   
                                 <div class="table-responsive" style="overflow: scroll;">
                   
                                     <asp:ListView ID="lvProductdetails" runat="server" OnItemDataBound="lvProductdetails_ItemDataBound" >
                                        <LayoutTemplate>
                                              <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%; max-height:250px;"  id="inventory">
                                                <tr>
                                                    <th style="width: 10px;">S.No.</th>
                                                     <th>Item Code</th>
                                                    <th style="display: none;">Item Desc</th>
                                                    <th>Item Desc</th>
                                                    <th>Category</th>
                                                    <th>UOM</th>
                                                    <th>Available Qty</th>
                                                      <th>PackStyle</th>
                                                    <th>Pack Required</th>
                                                     <th>DemandQty</th>
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
                                                    <asp:Label ID="lblItemCode1" runat="server" Text='<%# Eval("ItemCode") %>'></asp:Label>
                                                </td>
                                                <td style="display: none;">
                                                    <asp:Label ID="lblItemDesc1" runat="server" Text='<%# Eval("ItemDesc") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblItemDescValue1" runat="server" Text='<%# Eval("ItemDesc").ToString().Length > 45 ? 
                                                            Eval("ItemDesc").ToString().Substring(0,45) : Eval("ItemDesc") %>'></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCategory1" runat="server" Text='<%# Eval("Category") %>'></asp:Label>
                                                </td>

                                                <td>
                                                    <asp:Label ID="lblUOM1" runat="server" Text='<%# Eval("UOM") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblAvailableQty1" runat="server" Text='<%# Eval("AvailableQty") %>'></asp:Label>
                                                </td>
                                                 <td>
                                                       <asp:Label ID="lblPackStyle" runat="server"  Text='<%# Eval("PackStyle") %>'  Visible="false"></asp:Label>
                                                       <asp:DropDownList ID="dllPackStyle" runat="server" Width="100px"></asp:DropDownList>

                                                 </td>
                                               <td>
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                       <ContentTemplate>
                                                        <asp:TextBox ID="txtDemandPack" runat="server" Text='<%# Eval("PackReq") %>'  Width="40px" AutoCompleteType="Disabled" AutoPostBack="true"
                                                            OnTextChanged="txtDemandPack_TextChanged" 
                                                                    onkeypress="return validateFloatKeyPress(this, event)"></asp:TextBox>
                                                     </ContentTemplate>
                                                 </asp:UpdatePanel>
                          
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
                                                    <th style="width: 10px;">S.No.</th>
                                                   <th>Item Code</th>
                                                    <th>Item Desc</th>
                                                    <th>Category</th>
                                                    <th>UOM</th>
                                                    <th>Available Qty</th>
                                                      <th>PackStyle</th>
                                                    <th>DemandQty</th>
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
                                      <asp:Button ID ="btnUpdate" runat="server"  Text="Update" class="btn btn-success" OnClick="btnUpdate_Click"  Width="120px"  Height="35px" />&nbsp;&nbsp;
                                      <asp:Button ID ="btnClose" runat="server"   CausesValidation="false" Text="Close" class="btn btn-danger" OnClick="btnClose_Click" Width="120px"  Height="35px" />&nbsp;
                                  
                                   </div>
                  </div>
                 
                 
             </div>
         </div>
       </div>
</asp:Content>


