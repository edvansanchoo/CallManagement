$(document).ready(function () {

    $('#btnAdd').on('click', function () {
        if (CheckBlankFieldsProperty()) {
        }

    });
});


function CheckBlankFieldsProperty() {
    var propertyCaller = $('#Caller').val();
    var propertyDescription = $('#Description').val();

    if (propertyCaller == "" || propertyDescription == "") {
        alert("Please fill all the information!");
        return false;
    }
    else {
        $("#btnAdd").attr("disabled", false);
        alert("Incident inserted!");
    }
}