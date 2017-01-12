var XmlRes = Class.create();
XmlRes.prototype ={
   initialize:function(strPath){		
      this.XmlDoc=this.GetXmlDoc(strPath);
   },
   GetXmlDoc:function(strPath){
       if(window.ActiveXObject){
           var xmlObj = new ActiveXObject("MSXML2.DOMDocument");
           xmlObj.async = false;
           var bRet = xmlObj.load(strPath);      
           return xmlObj;
       }
       else{
          var myDoc = document.implementation.createDocument("","",null);
          myDoc.async = false;     
          myDoc.load(strPath);  
          return myDoc;
       }
   },
   GetValue:function(strKey){  
       if(window.ActiveXObject){     
          if(this.XmlDoc != null){    
              var doc = this.XmlDoc.documentElement;
              if(doc){
                  var node = doc.selectSingleNode("//Client/key[@name='"+strKey+"']");
                  if(node != null){
                     return node.text;
                  }else{
                     return "?"+strKey+"?";
                  }
              }                     
         }
         return "?"+strKey+"?";
      }else{
         if(this.XmlDoc!=null){
             var myRes = this.XmlDoc.getElementsByTagName("Resources");
            var myClient = myRes[0].getElementsByTagName("Client");
            var keys = myClient[0].getElementsByTagName("key");             
            for(var i=0; i<keys.length;i++){	
               if(keys[i].getAttribute("name")==strKey){	              
                 return keys[i].firstChild.data;	//nodeValue	
               }
            }      
         }  
      }
   },
   GetTheme:function(){
        if(window.ActiveXObject){     
          if(this.XmlDoc != null){    
              var doc = this.XmlDoc.documentElement;
              if(doc){
                  var node = doc.selectSingleNode("//theme");
                  if(node != null){
                     return node.text;
                  }else{
                     return "?"+strKey+"?";
                  }
              }                     
         }
         return "?"+strKey+"?";
      }else{
         if(this.XmlDoc!=null){
             var myRes = this.XmlDoc.getElementsByTagName("Resources");
            var myClient = myRes[0].getElementsByTagName("theme");  
            return myClient[0].firstChild.data; 
         }  
      }
   
   
   }

}

var Res = new XmlRes("Resource/ModRes.xml");

function RS(strKey){
   if(Res!=undefined){
      return Res.GetValue(strKey);
   }else{
      Res = new XmlRes();
      return Res.GetValue(strKey);
   }
   
}