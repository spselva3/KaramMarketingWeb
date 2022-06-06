<%@ Page Title="" Language="C#" MasterPageFile="~/MasterForm.Master" AutoEventWireup="true" CodeBehind="TestFom.aspx.cs" Inherits="KaramMarketingWeb.TestFom" %>
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
            min-height:300px;
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


    <script type="text/javascript" src="NewTable/DataTables/datatables.min.js"></script>

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
   <div class="title">Create Reservation ID</div>
    <div class="content">
        <div class="user-details">
          <div class="input-box">
            <span class="details">Item Code</span>
            <asp:TextBox ID="txtItemCode" runat="server"></asp:TextBox>
               <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" CompletionInterval="100" 
                                    CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" 
                                    ServiceMethod="GetItemCode" TargetControlID="txtItemCode" ShowOnlyCurrentWordInCompletionListItem="true">
                                </ajaxToolkit:AutoCompleteExtender>
          </div>
          <div class="input-box">
            <span class="details">Item Desc</span>
            <asp:TextBox ID="txtItemDesc" runat="server"></asp:TextBox>
               <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" CompletionInterval="100" 
                                    CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" 
                                    ServiceMethod="GetItemDesc" TargetControlID="txtItemDesc" ShowOnlyCurrentWordInCompletionListItem="true">
                                </ajaxToolkit:AutoCompleteExtender>
          </div>
          <div class="input-box">
            <span class="details">Category</span>
              <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
               <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender3" runat="server" CompletionInterval="100" 
                                    CompletionSetCount="10" EnableCaching="false" FirstRowSelected="false" MinimumPrefixLength="1" 
                                    ServiceMethod="GetCategory" TargetControlID="txtCategory" ShowOnlyCurrentWordInCompletionListItem="true">
                                </ajaxToolkit:AutoCompleteExtender>
            
          </div>
            <div class="input-box">
                  <span class="details1">A</span>
            <div class="button1">
                 <asp:Button ID="btnSearchItem" runat="server" Text="Search" OnClick="btnSearchItem_Click" />
                            
            </div>
          </div>
        </div>
         
        <div class="title">Available Items</div>
          <div class="card">
              <div class="table-responsive" style="overflow: scroll; height:300px;">
                            <asp:ListView ID="lvMatdetails" runat="server" >
                                <LayoutTemplate>
                                    <table class="lamp table-striped table-bordered table-hover table-bordered dataTable" style="width:100%; max-height:300px;"  id="inventory">
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
                                        <td style="display: none;">
                                            <asp:Label ID="lblItemDesc" runat="server" Visible="false" Text='<%# Eval("ItemDesc") %>'></asp:Label>
                                        </td>
                                            <td>
                                            <asp:Label ID="lblItemDescValue" runat="server" Text='<%# Eval("ItemDesc").ToString().Length > 45 ? 
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
                         <div class="user-details">
                              <div class="input-box">
                                  <asp:Button ID="btnAdd" CssClass="buttonAdd"  runat="server" Text="Add" OnClick="btnAdd_Click" />
                                   
                              </div>
                              <div class="input-box">
                                  <asp:Button ID="btnCancel" CssClass="buttonCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                              </div>
                              <div class="input-box">
                                    <asp:Button ID="btnLoadCart" CssClass="buttonAdd" runat="server" Text="Load Cart" OnClick="btnLoadCart_Click" />
                              </div>
                         </div> 
        
    </div>

         <div class="title">Added Items</div>
          <div class="card">
              <div class="table-responsive" style="overflow: scroll; height:300px;">
                              <asp:ListView ID="lvProductdetails" runat="server" OnItemDataBound="lvProductdetails_ItemDataBound" >
                                        <LayoutTemplate>
                                            <table class="lamp" cellpadding="2" cellspacing="2" width="100%">
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
                                                       <asp:Label ID="lblPackStyle" runat="server" Text='' Visible="false"></asp:Label>
                                                       <asp:DropDownList ID="dllPackStyle" runat="server" Width="100px"></asp:DropDownList>

                                                 </td>
                                               <td>
                                                    <asp:TextBox ID="txtDemandPack" runat="server" Text='0' Width="40px" AutoCompleteType="Disabled" AutoPostBack="true"
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
                         <div class="user-details">
                              <div class="input-box">
                                  
                              </div>
                              <div class="input-box">
                                  
                              </div>
                              <div class="input-box">
                                   
                              </div>
                         </div> 
        
       
        <div class="button">
          <input type="submit" value="Create Reservation">
        </div>
    </div>
  </div>
</asp:Content>
