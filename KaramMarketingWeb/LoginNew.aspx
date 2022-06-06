﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginNew.aspx.cs" Inherits="KaramMarketingWeb.LoginNew" %>


<!doctype html>
<html lang="en">

<head>
  <title>Login iWMS</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <link rel="stylesheet"  href="Login/Style.css"  />
    
<link href="Login/all.css" rel="stylesheet" />

  <style>

  
.topleft {
  position: absolute;
  top: 8px;
  left: 16px;
  font-size: 18px;
}
 /* .login{
    background: url('./Login/BlackScreen.png')
  }*/
      .auto-style1 {
          width: 286px;
      }
 @import url('https://fonts.googleapis.com/css2?family=Poppins:wght@400;900&display=swap');

body {
  margin: 0;
  width: 100vw;
  height: 100vh;
  background: #ecf0f3;
  display: flex;
  align-items: center;
  text-align: center;
  justify-content: center;
  place-items: center;
  overflow: hidden;
  font-family: poppins;
}

.container {
  position: relative;
  width: 350px;
  height: 500px;
  border-radius: 20px;
  padding: 40px;
  box-sizing: border-box;
  background: #ecf0f3;
  box-shadow: 14px 14px 20px #cbced1, -14px -14px 20px white;
}

.brand-logo {
  height: 100px;
  width: 100px;
  background: url("./Images/KaramHDWhite.png");
  margin: auto;
  border-radius: 50%;
  box-sizing: border-box;
  box-shadow: 7px 7px 10px #cbced1, -7px -7px 10px white;
}

.brand-title {
  margin-top: 10px;
  font-weight: 900;
  font-size: 1.8rem;
  color: orangered;
  letter-spacing: 1px;
}

.inputs {
  text-align: left;
  margin-top: 30px;
}

label, input, button {
  display: block;
  width: 100%;
  padding: 0;
  border: none;
  outline: none;
  box-sizing: border-box;
}

label {
  margin-bottom: 4px;
}

label:nth-of-type(2) {
  margin-top: 12px;
}

input::placeholder {
  color: gray;
}

input {
  background: #ecf0f3;
  padding: 10px;
  padding-left: 20px;
  height: 50px;
  font-size: 14px;
  border-radius: 50px;
  box-shadow: inset 6px 6px 6px #cbced1, inset -6px -6px 6px white;
}

button {
  color: white;
  margin-top: 20px;
  background: #1DA1F2;
  height: 40px;
  border-radius: 20px;
  cursor: pointer;
  font-weight: 900;
  box-shadow: 6px 6px 6px #cbced1, -6px -6px 6px white;
  transition: 0.5s;
}

button:hover {
  box-shadow: none;
}

a {
  position: absolute;
  font-size: 8px;
  bottom: 4px;
  right: 4px;
  text-decoration: none;
  color: black;
  background: yellow;
  border-radius: 10px;
  padding: 2px;
}

h1 {
  position: absolute;
  top: 0;
  left: 0;
}
  </style>  
</head>

<body class="h-screen font-sans login bg-cover">
     <div class="topleft">
                <a href="/en-us/">
                        <img class="auto-style1" alt="Signode" src="Login/SignodeLogo1.jpg" /> 
                </a>
     </div>
 <div class="container">
  <div class="brand-logo"></div>
  <div class="brand-title">Karam</div>
  <div class="inputs">
    <label>EMAIL</label>
    <input type="email" placeholder="example@test.com" />
    <label>PASSWORD</label>
    <input type="password" placeholder="Min 6 charaters long" />
    <button type="submit">LOGIN</button>
  </div>
 
</div>

</body>

</html>


