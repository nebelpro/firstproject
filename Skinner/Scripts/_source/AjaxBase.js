var AjaxBase = Class.create();
AjaxBase.prototype = {
    initialize:function(){        
        this.oper   = "";
        this.url    = "ajax.aspx"; 
        this.param  = "";
        this.async  = true;     
        this.option = {
            method:"post",
            asynchronous:true,
			parameters:"" ,
			onSuccess: null,
			onFailure:function(transport){ 
				//alert(transport.responseText);
				document.write(transport.responseText);
			}
        };
    },
    rqst:function(){     
        this.option.parameters = "rnd=" + Math.random() + "&oper="+ this.oper + this.param;  
        this.option.asynchronous = this.async; 
        //alert(this.option.parameters);    
        var request= new Ajax.Request(this.url,this.option);    
    }
}