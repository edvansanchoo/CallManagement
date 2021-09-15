/$(document).ready(function () {

$('#btnAdd').on('click', function () {

    alert("Incident inserted");

    /*if (CheckBlankFieldsProperty()) {
        $("#btnAdd").attr("disabled", true);
    }*/
});
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


const label =
    document.querySelector("#labelSelect");
const select =
    document.querySelector("#txtLabelName");

select.addEventListener("change", (ev) => {
    label.innerHTML = `meu ${ev.target.value}
legal`
})
