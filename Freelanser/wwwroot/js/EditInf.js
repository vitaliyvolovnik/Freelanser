﻿$(document).ready(function () {
    $(".opt").hide();
    $("#CategoryName").change(function (e) {
        Display($(this).children("option:selected").val())
    })
    $("input.opt1").click(function (e) {
        var str = "";
        $("input.opt1").filter(':checked').each(function (i) {
            str = str.concat($(this).val());
            str = str.concat(",");
        })
        str = str.substring(0, str.length - 1);
        $("#SkillsStr").val(str);
    })
    

})
function Display(name) {
    
    var str = ".".concat(name.replaceAll(" ", "_").replaceAll("&", "_"));
    $(".opt").hide();
    $(str).show();
}