 


$(document).ready(function () {
    $(".datepicker").datepicker({
        dateFormat: "yy-mm-dd",
        changemonth: true,
        changeyear: true//,
        //beforeShow: function (input, inst) {
        //    $(inst.dpDiv).addClass('bg-warning');
        //}
    });
});

$(function () {  
    
    $("#btnSave").click(function () {  
        //alert("");  
        var customerData = {};  
        customerData.customerName = $("#CustomerName").val();
        customerData.customerTypeId = $("#CustomerTypeId").val();
        customerData.dateOfBirth = $("#CustomerDateOfBirth").val();
        var stringCustomerData = JSON.stringify(customerData);
        $.ajax({  
            type: "POST",  
            url: applicationURL+"AddCustomerAjax",
            data: stringCustomerData,
            dataType: "json",  
            contentType: "application/json; charset=utf-8",  
            success: function (data) {  
                alert("Data has been added successfully: " + data.message);
                
            },  
            error: function (err) {  
                alert("Error while inserting data: " + err);
            }  
        });  
        return false;  
    });  

    
});  