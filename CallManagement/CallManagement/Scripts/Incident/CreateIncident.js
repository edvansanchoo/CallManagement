$(document).ready(function () {

    $('#btnAdd').on('click', function () {
        alert("Incident inserted");
        if (CheckBlankFieldsProperty()) {
            
        }
        
    });
});






function CheckBlankFieldsProperty() {
    var propertyCaller = $('#Caller').val();
    var propertyDescription = $('#Description').val();

    if (propertyCaller == "" || propertyDescriprion == "") {
        alert("Please fill all the information!");
        return false;
    }
    else {
        return true;
    }
}