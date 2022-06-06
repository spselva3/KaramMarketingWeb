<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CreateUser.aspx.cs" Inherits="KaramMarketingWeb.CreateUser" %>
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
    <div class="content-header">
                <div class="container-fluid">
                    <div class="row mb-2">
                        <div class="col-sm-3">
                             <asp:Label ID="lblHeading" runat="server" Text="Create User" Font-Size="Larger" Font-Bold="true" class="m-0 text-dark"></asp:Label>
                           
                        </div>
                        <!-- /.col -->
                        <div class="col-sm-6">
                            <ol class="breadcrumb float-sm-right">
                                <li class="breadcrumb-item"><a href="#">Home</a></li>
                                <li class="breadcrumb-item active">User Management</li>
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
                  <div class="col-lg-6">
                      <div class="card" >
                          <div class="card-header border-0">
                               <div class="card-body"  >

                                   <div class="form-group">
                                      <label for="Firstname">First Name:</label>
                                      <input type="text" class="form-control" id="txtFName" autocomplete="off" runat="server" placeholder="Enter First Name" name="Firstname" >
                                      <div class="valid-feedback">Valid.</div>
                                      <div class="invalid-feedback">Please fill out this field.</div>
                                      </div>

                                   <div class="form-group">
                                      <label for="Lastname">Last Name:</label>
                                      <input type="text" class="form-control" id="txtMName" autocomplete="off" runat="server" placeholder="Enter Last Name" name="Lastname" >
                                      <div class="valid-feedback">Valid.</div>
                                      <div class="invalid-feedback">Please fill out this field.</div>
                                    </div>
                               
                                    <div class="form-group">
                                      <label for="Mobilename">Mobile No:</label>
                                      <input type="text" class="form-control" id="txtMobile" autocomplete="off" runat="server" placeholder="Enter Mobile number" name="Mobilename" >
                                      <div class="valid-feedback">Valid.</div>
                                      <div class="invalid-feedback">Please fill out this field.</div>
                                    </div>

                                    <div class="form-group">
                                      <label for="uname">Role:</label>
                                        <asp:DropDownList class="form-control" ID="ddlRole" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged" ></asp:DropDownList>
                                      <div class="valid-feedback">Valid.</div>
                                      <div class="invalid-feedback">Please fill out this field.</div>
                                    </div>

                                   <div id ="pnlFloor" runat="server" class="form-group">
                                      <label for="uname">Floor :</label>
                                        <asp:DropDownList class="form-control" ID="ddlFloor" runat="server"></asp:DropDownList>
                                      <div class="valid-feedback">Valid.</div>
                                      <div class="invalid-feedback">Please fill out this field.</div>
                                    </div>

                                </div>
                           </div>
                      </div>
                      
                  </div>
                 
                  <div class="col-lg-6">
                           <div class="card">
                          <div class="card-header border-0">
                               <div class="card-body">
                                   
                                       
                                   <div class="form-group">
                                      <label for="uname">User Name:</label>
                                      <input type="text" class="form-control" id="txtUname" autocomplete="off" runat="server" placeholder="Enter User Name" name="uname" >
                                      <div class="valid-feedback">Valid.</div>
                                      <div class="invalid-feedback">Please fill out this field.</div>
                                    </div>

                                     <div class="form-group">
                                      <label for="Passwordname">Password :</label>
                                      <input type="text" class="form-control" id="txtPswd" autocomplete="off" runat="server" placeholder="Enter Password" name="Passwordname" >
                                      <div class="valid-feedback">Valid.</div>
                                      <div class="invalid-feedback">Please fill out this field.</div>
                                    </div>

                                    <div class="form-group">
                                      <label for="Emailname">Email :</label>
                                      <input type="text" class="form-control" id="txtEmail" autocomplete="off" runat="server" placeholder="Enter Email" name="Passwordname" >
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" Display="Dynamic" ControlToValidate="txtEmail"
                                ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                      <div class="valid-feedback">Valid.</div>
                                      <div class="invalid-feedback">Please fill out this field.</div>
                                    </div>

                                    <div class="form-group">
                                      <label for="Emailname">Status :</label>
                                        <asp:DropDownList class="form-control" ID="ddlStatus" runat="server">
                                            <asp:ListItem Text="Please Select" Value="Please Select" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Active" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="In-Active" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                      <div class="valid-feedback">Valid.</div>
                                      <div class="invalid-feedback">Please fill out this field.</div>
                                    </div>
                                </div>


                           </div>
                      </div>
                    </div>

                 <div class="col-lg-12">
                      <div class="card" >   
                          <div class="card-header border-0">
                               <div class="card-body">
                                  <div class ="center">
                                      <asp:Button ID ="btnCreate" runat="server"  Text="Create" class="btn btn-success" OnClick="btnCreate_Click" OnClientClick="return ValidateData();" Width="90px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnClear" runat="server"   CausesValidation="false" Text="Clear" class="btn btn-warning" OnClick="btnClear_Click" Width="90px"  Height="31px" />&nbsp;
                                      <asp:Button ID ="btnClose" runat="server"   CausesValidation="false" Text="Close" class="btn btn-danger" OnClick="btnClose_Click" Width="90px"  Height="31px" />
                                      <asp:HiddenField ID="hdnUSERID" runat="server" Value="" />
                                   </div>
                               </div>
                          </div>
                      </div>
                      
                  </div>
             </div>
         </div>
       </div>
</asp:Content>
