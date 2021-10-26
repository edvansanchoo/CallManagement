$(document).ready(function () {

    $('#btnSave').on('click', function () {
        if (CheckBlankFieldsProperty()) {
        }

    });
});


function CheckBlankFieldsProperty() {
    var propertyCaller = $('#RequestBy').val();
    var propertyDescription = $('#SortDescription').val();

    if (propertyCaller == "" || propertyDescription == "") {
        alert("Please fill all the information!");
        return false;
    }
    else {
        $("#btnAdd").attr("disabled", false);
        alert("Request inserted!");
    }
}
