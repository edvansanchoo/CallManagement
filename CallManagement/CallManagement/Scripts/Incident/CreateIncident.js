﻿$(document).ready(function () {

    $('#btnAdd').on('click', function () {

        if (CheckBlankFieldsProperty()) {
            $("#btnAdd").attr("disabled", true);
        }
    }
});

function CheckBlankFieldsProperty() {
    var propertyCaller = $('#txtCaller').val();
    var propertyLabelName = $('#txtLabelName').val();
    var propertyLabelType = $('#txtLabelType').val();
    var propertyWorkNotes = $('#txtWorkNotes').val();
    var emptyFields = "";

    if (propertyCaller == "") {
        emptyFields += "Caller\n";
    }
    if (propertyLabelName == "") {
        emptyFields += "Description\n";
    }
    if (propertyLabelType == "") {
        emptyFields += "Type\n";
    }
    if (propertyWorkNotes == "") {
        emptyFields += "Work Notes\n";
    }

    if (emptyFields != "") {
        alert("Empty Fields: \n\n" + emptyFields);
        return false;
    } else {
        $("#btnAdd").attr("disabled", false);
        return true;
    }
}