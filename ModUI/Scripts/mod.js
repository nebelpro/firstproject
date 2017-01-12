function $import(path){
 var i;
 var base="";
 var src = "common.js";
 var scripts = document.getElementsByTagName("script");
 for (i = 0; i < scripts.length; i++) {
      if (scripts[i].src.match(src)) {
          base = scripts[i].src.replace(src, "");
          break;
      }
  }
  //alert(base);
  document.write("<" + "script src=\"" + base + path + "\"></" + "script>"); 
}





var strPath="Scripts/_source/";
//$import(strPath+"prototype.js");
//$import(strPath+"tabpane.js");
$import(strPath+"Xml.js");
$import(strPath+"Lib.js");
$import(strPath+"Main.js");
//$import(strPath+"CastUI.js");
$import(strPath+"Weige.js");






