$(document).ready(function () {

    alert("fjdslkfldsk")
    $("#CategoryName").change(function (e) {
        Display($("#myselect option:selected").text())
    })
    $(".opt").css("display:block;");
})

function Display(name) {
    $(".opt").css("display:block;");
    $(".".concat(name)).css("display:block;");
}