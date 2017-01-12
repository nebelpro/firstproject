$if(ShowOn)$
<ul class="person_info"> 
    <li>$RS.Welcome$,$mask$ [<a href="javascript:Logout();">$RS.Exit$</a>]</li>            
    $UserNav$       
</ul>
$else$
<form  id="loginForm">
<ul class="person_info"> 
    <li>$RS.Username$:<input type="text" class="txt" id="txtName" name="txtName" /></li> 
    <li>$RS.Password$:<input type="password" class="txt"  id="txtPwd" name="txtPwd"/></li> 
    <li><input class="btn" type="image" onclick="user.Login();return false;" src="Theme/webtd/Images/depend/btn_login.gif" alt="" /></li>
</ul>
</form>
$endif$

