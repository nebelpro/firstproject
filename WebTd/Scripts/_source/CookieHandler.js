var Cookie=new Object();
Cookie.setCookie=function(name,value,option){
	var str=name+"="+escape(value);		//用于存储赋值给document.cookie的cookie格式字符串
	if(option){
		//如果设置了过期时间
		if(option.expireDays){
			var date=new Date();
			var ms=option.expireDays*24*3600*1000;
			date.setTime(date.getTime()+ms);
			str+="; expires="+date.toGMTString();
		}	
		if(option.path)str+="; path="+path;			//设置访问路径
		if(option.domain)str+="; domain"+domain;	//设置访问主机
		if(option.secure)str+="; true";				//设置安全性
	}
	document.cookie=str;
}

Cookie.getCookie=function(name){
	var cookieArray=document.cookie.split("; ");	//得到分割的cookie名值对
	var cookie=new Object();
	for(var i=0;i<cookieArray.length;i++){
		var arr=cookieArray[i].split("=");				//将名和值分开
		if(arr[0]==name)return unescape(arr[1]);	//如果是指定的cookie，则返回它的值
	}
	return "";
}

Cookie.deleteCookie=function(name){
	this.setCookie(name,"",{expireDays:-1});	//将过期时间设置为过去来删除一个cookie
}
