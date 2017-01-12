$if(ShowOn)$
<div id="UserBox">
    <h3><img src="Theme/default/Images/depend/t_login.gif" alt=""/></h3> 
	<ul>
    <li class="welcome">$RS.Welcome$,$mask$&nbsp;&nbsp;[<a href="javascript:Logout();">$RS.Exit$</a>]</li>
    $UserNav$
	</ul>
	<span class="clear" ></span>
</div>
$else$
<div id="LoginBox">
    <h3><img src="Theme/default/Images/depend/t_login.gif" alt=""/></h3>    
    <form  id="loginForm">
      <ul>
        <li><label>$RS.Username$: </label><input type="text" class="txt" id="txtName" name="txtName" /></li>
        <li><label>$RS.Password$: </label><input type="password" class="txt"  id="txtPwd" name="txtPwd"/>&nbsp;&nbsp;<input class="btn" type="image" onclick="user.Login();return false;" src="Theme/default/Images/depend/btnLogin.gif" alt="" /></li>
      </ul>
    </form>    
</div>
$endif$
