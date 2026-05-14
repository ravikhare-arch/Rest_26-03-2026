            var xmlTrans;
            var panelin;
            var thetext;

            var offsetxpoint=-60 //Customize x offset of tooltip
            var offsetypoint=20 //Customize y offset of tooltip
            var ie=document.all
            var ns6=document.getElementById && !document.all
            var enabletip=false
            if (ie||ns6)
            var tipobj=document.all? document.all["dhtmltooltip"] : document.getElementById? document.getElementById("dhtmltooltip") : ""

            function ietruebody(){
            return (document.compatMode && document.compatMode!="BackCompat")? document.documentElement : document.body
            }

            function ddrivetip(thetext, thecolor, thewidth){
            var tipobj=document.all? document.all["dhtmltooltip"] : document.getElementById? document.getElementById("dhtmltooltip") : ""

            if (ns6||ie){
            var tipobj=document.all? document.all["dhtmltooltip"] : document.getElementById? document.getElementById("dhtmltooltip") : ""

            if (typeof thewidth!="undefined") tipobj.style.width=thewidth+"px"
            if (typeof thecolor!="undefined" && thecolor!="") tipobj.style.backgroundColor=thecolor
            //tipobj.innerHTML=thetext
            
                    mlTrans = null;
                    xmlTrans = undefined;
            
                    try { 
                    // Firefox, Opera 8.0+, Safari 
                    xmlTrans=new XMLHttpRequest(); 
                    } 
                    catch (e) { 
                    // internet Explorer 
                    try { 
                        xmlTrans=new ActiveXObject("Msxml2.XMLHTTP"); 
                    } 
                    catch (e) { 
                        try { 
                            xmlTrans=new ActiveXObject("Microsoft.XMLHTTP"); 
                        } 
                        catch (e) { 
                         alert("Your browser does not support ajax!"); 
                    return false; 
                    } 
                    } 
                    }
            
                    var url="../UserControls/GetAjaxData.aspx";
	                url=url+"?queryParameter=" + thetext;
                    xmlTrans.onreadystatechange = AjaxdataFromServer;
                    var dt = new Date().valueOf();
	                xmlTrans.open("GET",url+ "&dt=" + dt,true);
	                xmlTrans.send(null);
                    
                    enabletip=true;
                    //return false;
            }
            }

            function positiontip(e){
            var tipobj=document.all? document.all["dhtmltooltip"] : document.getElementById? document.getElementById("dhtmltooltip") : ""

            if (enabletip){
                var curX=(ns6)?e.pageX : event.clientX+ietruebody().scrollLeft;
                var curY=(ns6)?e.pageY : event.clientY+ietruebody().scrollTop;
                //Find out how close the mouse is to the corner of the window
                var rightedge=ie&&!window.opera? ietruebody().clientWidth-event.clientX-offsetxpoint : window.innerWidth-e.clientX-offsetxpoint-20
                var bottomedge=ie&&!window.opera? ietruebody().clientHeight-event.clientY-offsetypoint : window.innerHeight-e.clientY-offsetypoint-20

                var leftedge=(offsetxpoint<0)? offsetxpoint*(-1) : -1000

            //if the horizontal distance isn't enough to accomodate the width of the context menu
                if (rightedge<tipobj.offsetWidth)
                //move the horizontal position of the menu to the left by it's width
                tipobj.style.left=ie? ietruebody().scrollLeft+event.clientX-tipobj.offsetWidth+"px" : window.pageXOffset+e.clientX-tipobj.offsetWidth+"px"
                else if (curX<leftedge)
                tipobj.style.left="5px"
                else
                //position the horizontal position of the menu where the mouse is positioned
                tipobj.style.left=curX+offsetxpoint+"px"

            //same concept with the vertical position
            if (bottomedge<tipobj.offsetHeight)
                tipobj.style.top=ie? ietruebody().scrollTop+event.clientY-tipobj.offsetHeight-offsetypoint+"px" : window.pageYOffset+e.clientY-tipobj.offsetHeight-offsetypoint+"px"
                else
                tipobj.style.top=curY+offsetypoint+"px"
                tipobj.style.visibility="visible"
                }
            }

            function hideddrivetip(){
            var tipobj=document.all? document.all["dhtmltooltip"] : document.getElementById? document.getElementById("dhtmltooltip") : ""
            if (ns6||ie){
                enabletip=false
                tipobj.style.visibility="hidden"
                tipobj.style.left="-1000px"
                tipobj.style.backgroundColor=''
                tipobj.style.width=''
            }
            
            
           
            }

            function AjaxdataFromServer()
            {
                if (xmlTrans.readyState==4)
                { 
                    var strImport = xmlTrans.responseText;
                    var tipobj=document.all? document.all["dhtmltooltip"] : document.getElementById? document.getElementById("dhtmltooltip") : ""
                    tipobj.innerHTML=strImport;
                   
                }
            }
            
            document.onclick=positiontip

 function ChangeCheckBoxState(id, checkState,count)
        {
            var cb = document.getElementById(id);
            if (cb != null)
               cb.checked = checkState;
                var tr=cb.parentNode.parentNode; // this may change depending on the html used
           if (count != 0)
           {
           if  ((count % 2) == 0)
            {
            tr.className =(cb.checked)? 'bgselect' : '';
            }
            else
            {
            tr.className =(cb.checked)? 'bgselect' : 'bg';
            }
            ChangeHeaderAsNeeded();
            }

    }


    function ChangeCheckBoxStateAllFromHeader(id, checkState, count) {
        var cb = document.getElementById(id);
        if (cb != null)
            cb.checked = checkState;
        var tr = cb.parentNode.parentNode; // this may change depending on the html used
        if (count != 0) {
            if ((count % 2) == 0) {
                tr.className = (cb.checked) ? 'bgselect' : '';
            }
            else {
                tr.className = (cb.checked) ? 'bgselect' : 'bg';
            }
            $("#" + id).trigger("change");  
            ChangeHeaderAsNeeded();
        }

    }

        
         function ChangeRowColor(id,count)
        {
            var cb = document.getElementById(id);
            var tr=cb.parentNode.parentNode; // this may change depending on the html used
            if  ((count % 2) == 0)
            {
            tr.className =(cb.checked)? 'bgselect' : '';
            }
            else
            {
            tr.className =(cb.checked)? 'bgselect' : 'bg';
            }
            ChangeHeaderAsNeeded();
        }
        
        function ChangeAllCheckBoxStates(checkState)
        {
            // Toggles through all of the checkboxes defined in the CheckBoxIDs array
            // and updates their value to the checkState input parameter
            if (CheckBoxIDs != null)
            {
                for (var i = 0; i < CheckBoxIDs.length; i++)
                    ChangeCheckBoxStateAllFromHeader(CheckBoxIDs[i], checkState, i);
                    
            }
        }
        
        function ChangeHeaderAsNeeded()
        {
            // Whenever a checkbox in the table is toggled, we need to
            // check the Header checkbox if ALL of the GridView checkboxes are
            // checked, and uncheck it otherwise
            if (CheckBoxIDs != null)
            {
                // check to see if all other checkboxes are checked
                for (var i = 1; i < CheckBoxIDs.length; i++)
                {
                    var cb = document.getElementById(CheckBoxIDs[i]);
                    if (!cb.checked)
                    {
                        // Whoops, there is an unchecked checkbox, make sure
                        // that the header checkbox is unchecked
                        ChangeCheckBoxState(CheckBoxIDs[0], false,0);
                        return;
                    }
                }
                // If we reach here, ALL GridView checkboxes are checked
                ChangeCheckBoxState(CheckBoxIDs[0], true,0);
            }
        }
        
        
        function ChangeCheckBoxState1(id, checkState,count,variablename)
        {
         //alert(id);
            var cb = document.getElementById(id);
            
            if (cb != null)
               cb.checked = checkState;
                var tr=cb.parentNode.parentNode; // this may change depending on the html used
           if (count != 0)
           {
           if  ((count % 2) == 0)
            {
            tr.className =(cb.checked)? 'bgselect' : '';
            }
            else
            {
            tr.className =(cb.checked)? 'bgselect' : 'bg';
            }
           
             ChangeHeaderAsNeeded1(variablename);
            }

     }


     function ChangeCheckBoxStateAllFromHeader1(id, checkState, count, variablename) {
         //alert(id);
         var cb = document.getElementById(id);

         if (cb != null)
             cb.checked = checkState;
         var tr = cb.parentNode.parentNode; // this may change depending on the html used
         if (count != 0) {
             if ((count % 2) == 0) {
                 tr.className = (cb.checked) ? 'bgselect' : '';
             }
             else {
                 tr.className = (cb.checked) ? 'bgselect' : 'bg';
             }
             $("#" + id).trigger("change");  
             ChangeHeaderAsNeeded1(variablename);
         }

     }

        
         function ChangeRowColor1(id,count,variablename)
        {
            var cb = document.getElementById(id);
            var tr=cb.parentNode.parentNode; // this may change depending on the html used
            if  ((count % 2) == 0)
            {
            tr.className =(cb.checked)? 'bgselect' : '';
            }
            else
            {
            tr.className =(cb.checked)? 'bgselect' : 'bg';
            }
          ChangeHeaderAsNeeded1(variablename);
           
        }
        
        function ChangeAllCheckBoxStates1(checkState,variablename)
        {
            // Toggles through all of the checkboxes defined in the CheckBoxIDs array
            // and updates their value to the checkState input parameter
            var CheckBoxIDs = eval(variablename);
            //alert(eval(CheckBoxIDs));
            if (CheckBoxIDs != null)
            {
                for (var i = 0; i < CheckBoxIDs.length; i++)
                    ChangeCheckBoxStateAllFromHeader1(CheckBoxIDs[i], checkState, i, variablename);
                    
            }

        }
        
        function ChangeHeaderAsNeeded1(variablename)
        {
            // Whenever a checkbox in the table is toggled, we need to
            // check the Header checkbox if ALL of the GridView checkboxes are
            // checked, and uncheck it otherwise
            var CheckBoxIDs = eval(variablename);
            
            if (CheckBoxIDs != null)
            {
                // check to see if all other checkboxes are checked
                for (var i = 1; i < CheckBoxIDs.length; i++)
                {
                    var cb = document.getElementById(CheckBoxIDs[i]);
                    if (!cb.checked)
                    {
                        // Whoops, there is an unchecked checkbox, make sure
                        // that the header checkbox is unchecked
                        ChangeCheckBoxState1(CheckBoxIDs[0], false,0,variablename);
                        return;
                    }
                }
                // If we reach here, ALL GridView checkboxes are checked
                ChangeCheckBoxState1(CheckBoxIDs[0], true,0,variablename);
            }
        }


        function numbersonly(myfield, e, dec) 
        {
            var key;
            var keychar;
            if (window.event)
                key = window.event.keyCode;
            else if (e)
                key = e.which;
            else
                return true;
            keychar = String.fromCharCode(key);
            // control keys
            if ((key == null) || (key == 0) || (key == 8) ||
            (key == 9) || (key == 13) || (key == 27) || (key == 45))
                return true;
            // numbers
            else if ((("0123456789").indexOf(keychar) > -1))
                return true;
            // decimal point jump
            else if ((keychar == ".")) {
                return true;
            }
            else
                return false;

        }

function setvalidstring(vserch) {
    vserch = vserch.replace(new RegExp(" ", "g"), "innoviagtcspace");
    vserch = vserch.replace(new RegExp("%", "g"), "innoviagtcpercentage");
    vserch = vserch.replace(new RegExp("#", "g"), "innovagtchash");
    vserch = vserch.replace(new RegExp("&", "g"), "innovagtcandoperator");
    vserch = vserch.replace(new RegExp("'", "g"), "innovagtcsinglequote");
    vserch = vserch.replace(new RegExp(",", "g"), "innovagtcdoubleinvertcomma");
    return vserch;
}

function CheckBoxListCheckAll(state, chkBoxListID) {
    var chkBoxList = document.getElementById(chkBoxListID);
    var chkBoxCount = chkBoxList.getElementsByTagName("input");
    for (var i = 0; i < chkBoxCount.length; i++) {
        chkBoxCount[i].checked = state;
    }
    return false;
}       


function saveDefaultReportColumns(vModuleDetID, chkBoxListID, userID) {
    var chkBoxList = document.getElementById(chkBoxListID);
    var vSelectedColumns = "";
    var chkBoxCount = chkBoxList.getElementsByTagName("input");
    for (var i = 0; i < chkBoxCount.length; i++) {
        if (chkBoxCount[i].checked) {
            if (vSelectedColumns != "") {
                vSelectedColumns += ",";
            }
            var $label = $("label[for='" + chkBoxCount[i].id + "']")
            vSelectedColumns += $label.html();
        }
        
    }
        // Call Webservice to save Default Report Columns
    saveDefaultReportColumnswebservice(vModuleDetID, userID, vSelectedColumns);
   

    return false;
}   


function saveDefaultReportColumnswebservice(vModuleDetID, userID,vDefaultColumns) {
    $.ajax({
        type: "POST",
        url: "../mainmenu.aspx/saveDefaultReportColumnswebservice",
        data: "{'vModuleDetID': '" + vModuleDetID + "','vDefaultColumns':'" + vDefaultColumns + "','UserID':'" + userID + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // Handle the complete event
            alert("Selection of Columns saved for this Report");
            

        },
        error: function (response) {
            // Handle the Fail event
            //alert("Operation failed");
        }
    });
}

function setDefaultReportColumns(vModuleDetID, chkBoxListID, userID) {
    //Call Webservice to get the Selected Columns
    $.ajax({
        type: "POST",
        url: "../mainmenu.aspx/getDefaultReportColumnswebservice",
        data: "{'vModuleDetID': '" + vModuleDetID + "','UserID':'" + userID + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            // Handle the complete event
            var vSelectedColumns = response.d;
            if (vSelectedColumns != "") {
                vSelectedColumns = "," + vSelectedColumns + ",";
                var chkBoxList = document.getElementById(chkBoxListID);
                var chkBoxCount = chkBoxList.getElementsByTagName("input");
                for (var i = 0; i < chkBoxCount.length; i++) {
                    var $label = $("label[for='" + chkBoxCount[i].id + "']")
                    var vCurrColumnName = $label.html();
                    var incStr = vSelectedColumns.includes("," + vCurrColumnName + ",");
                    if (incStr == true) {
                        chkBoxCount[i].checked = true;
                    }
                    else {
                        chkBoxCount[i].checked = false;
                    }

                }
            }

        },
        error: function (response) {
            // Handle the Fail event
           // alert("Operation failed");
        }
    });
}   
