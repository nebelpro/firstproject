
function JsLoad(url,sId,strEval){    
		var option={
		  method:"get",
		  parameters:"rnd="+Math.random(),
		  onSuccess:function(transport){ 
			   if ((transport.responseText != null)){ 	
             var oHead = document.getElementsByTagName("head").item(0); 
          // $(sId).text=transport.responseText; 
              if ($(sId).text!="") oHead.removeChild($(sId)); 
              var oScript = document.createElement( "script" );              
              oScript.language = "javascript"; 
              oScript.type = "text/javascript"; 
              oScript.id = sId; 
              oScript.defer = true;              
              oScript.text = transport.responseText;                          
              oHead.appendChild( oScript ); 
               alert(myApp);
              eval(strEval);
             
            } 
		  },
		  onFailure:function(transport){ 
			  alert("Js Request Error!");
		  }
		}
		var request= new Ajax.Request("Scripts/"+url,option);

}