<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForm.Master" AutoEventWireup="true" CodeBehind="EditSO.aspx.cs" Inherits="KaramMarketingWeb.EditSO" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="FormDesign/form.css" rel="stylesheet" />
        <style>
          table.lamp {
              font-family: Arial, sans-serif;
            font-size: 12px;
            padding: 0px;
            border: 1px solid #d4d4d4;
            overflow: hidden;
            white-space: nowrap;
            /*min-height:200px;*/
        }

         table.lamp th {
             font-family: Arial, sans-serif;
            font-size: 12px;
                color: white;
                background-color: #007B72;
                padding: 10px;
                padding-left: 10px;
                text-align: left;
                cursor: pointer;
                *cursor: hand;
            }
          table.lamp td {
              font-family: Arial, sans-serif;
            font-size: 12px;
                padding: 4px;
                padding-left: 10px;
                background-color: #ffffff;
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
             function ClosePupup() {
                 debugger;
                 //alert('Sucessfully Created');
                 window.close();
                 if (window.opener && !window.opener.closed) {
                     window.opener.location.reload();
                 }
             }

         function validatenumerics(key) {
             var keycode = (key.which) ? key.which : key.keyCode;
             if (keycode > 31 && (keycode < 48 || keycode > 57)) {
                 return false;
             }
             else return true;
         }

         function validateFloatKeyPress(el, evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode;
             if (charCode != 46 && charCode > 31
                 && (charCode < 48 || charCode > 57)) {
                 return false;
             }
             if (charCode == 46 && el.value.indexOf(".") !== -1) {
                 return false;
             }
             return true;
         }


         function PicklistConfirmation() {
             if (confirm("Do you want to create  Reservation ID ?"))
                 return true;
             else
                 return false;
         }

         function DeleteConfirmation() {
             if (confirm("Do you want to remove the material ?"))
                 return true;
             else
                 return false;
         }

     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <div class="title">Edit Reservation ID</div>
     <asp:Label ID="lblErrorMsg" runat="server" Text="" Font-Bold="false" Font-Size="8" ForeColor="Red"></asp:Label>
      <div class="content">
        <div class="user-details">
          <div class="input-box">
               <span class="details">Reserve ID</span>
                  <%--<asp:Label ID="lblReservation"  runat="server" ></asp:Label>--%>
                <asp:TextBox ID="txtReservation" runat="server"  ReadOnly="true"></asp:TextBox>
              
          </div>
            <div class="input-box">
               <span class="details">Customer</span>
                  <asp:TextBox ID="txtCustomer" runat="server"></asp:TextBox>
              
          </div>
            <div class="input-box">
               <span class="details">Req Date</span>
                  <asp:TextBox ID="txtDemandDate" runat="server"></asp:TextBox>
                <ajaxtoolkit:calendarextender ID="CalendarExtender2" PopupPosition="BottomLeft" runat="server"  TargetControlID="txtDemandDate" Format="dd-MM-yyyy" />
                
              
          </div>
            <div class="input-box">
               <span class="details">Status</span>
                 <asp:TextBox ID="txtStatus" runat="server" ReadOnly="true" ></asp:TextBox>
              
          </div>
        </div>

          <div class="user-details">
          <div class="input-box">
               <span class="details">SO</span>
                   <asp:TextBox ID="txtSalesOrder" runat="server"></asp:TextBox>
               <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender4" runat="server" CompletionInterval="100" 
                                    CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" 
                                    ServiceMethod="GetSalesOrder" TargetControlID="txtSalesOrder">
                                </ajaxToolkit:AutoCompleteExtender>
              
          </div>
            <div class="input-box">
               <span class="details">SO Date</span>
                  <asp:TextBox ID="txtSODate" runat="server"></asp:TextBox>
               <ajaxtoolkit:calendarextender ID="CalendarExtender1" PopupPosition="BottomLeft" runat="server"  TargetControlID="txtSODate" Format="dd-MM-yyyy" />
                
          </div>
              <div class="input-box">
               <span class="details1">S</span>
                
          </div>
              <div class="input-box">
               <span class="details1">S</span>
                
          </div>
        </div>
      </div>
    <div class="title">Reserved Items</div>
      <div class="card">
           <div class="table-responsive" style="overflow: scroll; height:400px;">
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
           <div class="buttonUpdate">
               <asp:Button ID="btnUpdate" CssClass="buttonUpdate" BackColor="#1fcf39"  runat="server" Text="Update" OnClick="btnUpdate_Click" />&nbsp;&nbsp;
               <asp:Button ID="btnClose" BackColor="Red" runat="server" Text="Close"  OnClientClick="ClosePupup()" /> 
        </div>
      </div>
</asp:Content>
