var globalBill=0;
var globalpayment=0;
var globalitem=0;
var globalgen=0;
function __DoChangeFontStyle(objTextArea)
{
    objTextArea.style.fontStyle = 'normal';
    objTextArea.value = '';
    objTextArea.style.color = 'black';
}


function __DoChangeRowColor(objRow,objChk,v)
{
    if(document.getElementById(objChk).checked==true)
    {
        objRow.style.backgroundColor = '#EBFFCA';  //#CFFF88
         globalBill=v ;
    }
    else
    { 
         objRow.style.backgroundColor = 'white';
    }
}


function __DoChangeRowColorforpayment(objRow,objChk,v)
{
   
    if(document.getElementById(objChk).checked==true)
    {
    

        objRow.style.backgroundColor = '#EBFFCA';  //#CFFF88
       globalpayment=v ;
       }
    else
    { 
         objRow.style.backgroundColor = 'white';
    }
}





function __DoChangeRowColorforITEM(objRow,objChk,v)
{
    if(document.getElementById(objChk).checked==true)
    {
        objRow.style.backgroundColor = '#EBFFCA';  //#CFFF88
         globalitem=v ;
       }
    else
    { 
         objRow.style.backgroundColor = 'white';
    }
}









function Additem()
{


var w;
w=window.open ("Additem.aspx","mywindow","status=0,scrollbars=0,width=300,height=200"); 
return false;
}




function EDITItem()
{



if(globalitem==0)
{
alert('Please Select The record to Edit');
}
else
{
var w;
w=window.open ("EditItem.aspx?itemcode="+globalitem,"mywindow","status=0,scrollbars=0,width=300,height=200"); 
}
return false;
}



function Addgen()
{


var w;
w=window.open ("AddGeneralMaster.aspx","mywindow","status=0,scrollbars=0,width=300,height=200"); 
return false;
}




function EDITgen()
{



if(globalitem==0)
{
alert('Please Select The record to Edit');
}
else
{
var w;
w=window.open ("EditItem.aspx?genid="+globalgen,"mywindow","status=0,scrollbars=0,width=300,height=200"); 
}
return false;
}










function AddBills()
{

var w;
w=window.open ("AddBillingdetails.aspx","mywindow","status=0,scrollbars=1,width=500,height=650"); 
w.moveTo(0,20);
return false;
}



function EDITBills()
{



if(globalBill==0)
{
alert('Please Select The record to Edit');
}
else
{
var w;
w=window.open ("EditBill.aspx?SNO="+globalBill,"mywindow","status=0,scrollbars=1,width=500,height=650"); 
w.moveTo(0,20);
}
return false;
}




function AddReceipt()
{

if(globalpayment==0)
{
alert('Please Select The record to Make Payment ');
}

else
{
var w;
w=window.open ("Addpayment.aspx?pid="+globalpayment,"mywindow","status=0,scrollbars=0,width=500,height=400"); 
w.moveTo(0,20);
}

return false;
}


function EditPayment()
{

if(globalpayment==0)
{
alert('Please Select The record to Edit');
}

else
{
var w;
w=window.open ("EditPayment.aspx?pid="+globalpayment,"mywindow","status=0,scrollbars=0,width=500,height=400"); 
w.moveTo(0,20);
}

return false;
}



			
			
	
             function calendarPicker(strField)
			{
			alert(strField);
							window.open('DatePicker.aspx?field=' + strField,'calendarPopup','width=250,height=190,resizable=yes,status=1');
			}
			
			
			
			
	