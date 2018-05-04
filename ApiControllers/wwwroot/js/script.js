$(document).ready(function () {
    $.ajaxSetup({ cache: false });
    $("form").submit(function (e) {
        e.preventDefault();
        $.ajax({
            url: "api/persons",
            contentType: "application/json",
            method: "POST",
            data: JSON.stringify({
                name: this.elements["Name"].value,
                post: this.elements["Post"].value,
                phone: this.elements["Phone"].value
            }),
            success: function (data) {
                addTableRow(data);
            }
        })
    });
});

var addTableRow = function (person) {
    $("table tbody").append(
        "<tr><td>" + person.personId + "</td><td>"
        + person.name + "</td><td>"
        + person.post + "</td><td>"
        + person.phone + "</td></tr>");
}
