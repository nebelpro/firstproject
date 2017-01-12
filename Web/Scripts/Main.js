//具体页面处理函数放在此文件中
//具体页面处理函数放在此文件中

// for play
function IsPlay(point){
	if(point == 0)return true;
	var sMsg = Res.GetValue("INFO_CONFIRMPLAY");
	sMsg.replace("{0}",point)
	return confirm(sMsg);
}

function CheckMedia(){
	var objSetup; 
	try	{
		objSetup = new ActiveXObject("LibSetupCheck.SetupPlayer"); 
	}catch (e)	{
	    var sMsg = Res.GetValue("WARN_NOPLAYER");
		alert(sMsg);
		return false;
	}
	return true;
}



function ChkAddPoint(){
    var nonull = Res.GetValue("WARN_NOCARD");
    var errcardno = Res.GetValue("WARN_ERRCARD");
    var errcardpwd = Res.GetValue("WARN_ERRPWD");
	var no = $("tbCardNum").value;
	if(no.length == 0){
		alert(nonull);
		return false;
	}else if (no.length != 10){
		alert(errcardno);
		return false;
	}else{
		if(/\W/.test(no)){
			alert(errcardno);
			return false;
		}
	}
	var pwd = $("tbCardPwd").value;
	if(pwd.length != 10){
		alert(errcardpwd);
		return false;
	}
}

function CallPlay(url){
    location.href=url;
    setTimeout("window.close()",2000);
}