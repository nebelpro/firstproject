String.prototype.len=function(){
	var CN = this.match(/[^\x00-\xff]/ig);
    return this.length + (CN == null ? 0 : CN.length);
}

var Cookie= new Object();
Cookie.setCookie = function ( sName, sValue, nDays ) {
	var expires = "";
	if ( nDays ) {
		var d = new Date();
		d.setTime( d.getTime() + nDays * 24 * 60 * 60 * 1000 );
		expires = "; expires=" + d.toGMTString();
	}

	document.cookie = sName + "=" + sValue + expires + "; path=/";
};
Cookie.getCookie = function (sName) {
	var re = new RegExp( "(\;|^)[^;]*(" + sName + ")\=([^;]*)(;|$)" );
	var res = re.exec( document.cookie );
	return res != null ? res[3] : null;
};
Cookie.removeCookie = function ( name ) {
	setCookie( name, "", -1 );
};

/*Prototype.Browser.Support=function(){
    if (typeof hasSupport.support != "undefined") return hasSupport.support;
	
	var ie55 = /msie 5\.[56789]/i.test( navigator.userAgent );
	
	hasSupport.support = ( typeof document.implementation != "undefined" &&	document.implementation.hasFeature( "html", "1.0" ) || ie55 )
			
	// IE55 has a serious DOM1 bug... Patch it!
	if ( ie55 ) {
		document._getElementsByTagName = document.getElementsByTagName;
		document.getElementsByTagName = function ( sTagName ) {
			if ( sTagName == "*" )
				return document.all;
			else
				return document._getElementsByTagName( sTagName );
		};
	}

	return hasSupport.support;



}*/




var TabPane= Class.create();
TabPane.prototype={
    initialize:function(el,bUserCookie,styleName){
        this.classNameTag = styleName!=null ?styleName:"dynamic-tab-pane-control";
        this.element=$(el);
        if(this.element=="undefined"||this.element==null) return;
        this.element.tabPane=this;
        this.pages=[];
        this.selectedIndex = null;
        this.userCookie = bUseCookie != null ? bUseCookie : false;
        
        this.element.className = this.classNameTag + " " + this.element.className;
        
        // add tab row
	    this.tabRow = document.createElement( "div" );
	    this.tabRow.className = "tab-row";
        el.insertBefore( this.tabRow, el.firstChild );
        
        
        var tabIndex = 0;
	    if ( this.useCookie ) {
		    tabIndex = Number( Cookie.getCookie( "webfxtab_" + this.element.id ) );
		    if (isNaN(tabIndex))	tabIndex = 0;
	    }
	    this.selectedIndex = tabIndex;
    	
	    // loop through child nodes and add them
	    var cs = this.element.childNodes;
	    var n;
	    for (var i = 0; i < cs.length; i++) {
		    if (cs[i].nodeType == 1 && cs[i].className == "tab-page") {
			    this.addTabPage( cs[i] );
		    }
	    }
    },
    setSelectedIndex: function ( n ) {
	    if (this.selectedIndex != n) {
		    if (this.selectedIndex != null && this.pages[ this.selectedIndex ] != null )
			    this.pages[ this.selectedIndex ].hide();
		    this.selectedIndex = n;
		    this.pages[ this.selectedIndex ].show();
    		
		    if ( this.useCookie ) Cookie.setCookie( "webfxtab_" + this.element.id, n );	// session cookie
	    }
    },    	
    getSelectedIndex : function () {
	    return this.selectedIndex;
    },
    	
    addTabPage : function ( oElement ) {
        var oElement=$(oElement);
	    if ( oElement.tabPage == this )	// already added
		    return oElement.tabPage;
		    
	    var n = this.pages.length;
	    var tp = this.pages[n] = new WebFXTabPage( oElement, this, n );
	    tp.tabPane = this;    	
	    // move the tab out of the box
	    this.tabRow.appendChild( tp.tab );    			
	    if ( n == this.selectedIndex )
		    tp.show();
	    else
		    tp.hide();
    		
	    return tp;
    };    	
    dispose : function () {
	    this.element.tabPane = null;
	    this.element = null;		
	    this.tabRow = null;
    	
	    for (var i = 0; i < this.pages.length; i++) {
		    this.pages[i].dispose();
		    this.pages[i] = null;
	    }
	    this.pages = null;
    };




}