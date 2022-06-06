<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="KaramMarketingWeb.Login" %>

<!doctype html>
<html lang="en">

<head>
  <title>Login iWMS</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <link rel="stylesheet"  href="Login/Style.css"  />
    
<link href="Login/all.css" rel="stylesheet" />

  <style>
  .login{
    background: url('./Login/BlackScreen.png')
  }
      .auto-style1 {
          width: 286px;
      }
  </style>  
</head>

<body class="h-screen font-sans login bg-cover">
     <div class="logo-container">
                <a href="/en-us/">
                        <img class="auto-style1" alt="Signode" src="Login/SignodeLogo1.jpg" /> 
                </a>
              </div>
<div class="container mx-auto h-full flex flex-1 justify-center items-center">
  <div class="w-full max-w-lg">
    <div class="leading-loose">
      <form runat="server" class="max-w-xl m-4 p-10 bg-white rounded shadow-xl">
        <p class="text-gray-800 font-medium text-center text-lg font-bold">Login</p>

        <div class="">
          <label id="lblUser" runat="server" class="block text-sm text-gray-00" for="username">Username</label>
          <input class="w-full px-5 py-1 text-gray-700 bg-gray-200 rounded" runat="server" id="txtusername" name="username" autocomplete="off" type="text" required="" placeholder="User Name" aria-label="username">
        </div>

        <div class="mt-2">
          <label id="lblPassword" runat="server" class="block text-sm text-gray-600"  for="password">Password</label>
          <input class="w-full px-5  py-1 text-gray-700 bg-gray-200 rounded" runat="server" id="txtpassword" name="password" autocomplete="off" type="password" required="" placeholder="*******" aria-label="password">
        </div>

        <div class="mt-4 items-center justify-between">

          <asp:Button ID="btnLoginUser"  runat="server" Text="Submit" OnClick="btnLoginUser_Click" class="px-4 py-1 text-white font-light tracking-wider bg-gray-900 rounded" 
             />

         <%-- <a class="inline-block right-0 align-baseline  font-bold text-sm text-500 hover:text-blue-800" href="#">
            Forgot Password?
          </a>--%>
        </div>
          <div class="mt-2">
          <asp:Label id="lblError" runat="server" Text="" class="block text-sm text-gray-600" ForeColor="Red" ></asp:Label>
          </div>
        <a class="inline-block right-0 align-baseline font-bold text-sm text-500 hover:text-blue-800" href="#">
          
        </a>
      </form>

    </div>
  </div>
</div>
</body>

</html>

