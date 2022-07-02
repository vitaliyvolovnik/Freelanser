$(document).ready(function () {
    
    $(":checkbox").change(function (e) {
        if (e.target.checked) {
            $("#reviewDiv").css("display", "flex");
            $("#Addreview").val(true)
        }
        else {
            $("#Addreview").val(false)
            $("#reviewDiv").css("display", "none");
        }
    })
    $("#star1").click(function () {
       
        var src = $("#star1").attr("src");
        src1 = src.replace("0", "1");
        src2 = src.replace("1", "0");
        var src = $("#star1").attr("src", src1);
        var src = $("#star2").attr("src",src2);
        var src = $("#star3").attr("src",src2);
        var src = $("#star4").attr("src",src2);
        var src = $("#star5").attr("src", src2);
        $("#Point").val("1");
    });
    $("#star2").click(function () {
       
        var src = $("#star1").attr("src");
        src1 = src.replace("0", "1");
        src2 = src.replace("1", "0");
        var src = $("#star1").attr("src", src1);
        var src = $("#star2").attr("src", src1);
        var src = $("#star3").attr("src", src2);
        var src = $("#star4").attr("src", src2);
        var src = $("#star5").attr("src", src2);

        $("#Point").val("2");
    });
    $("#star3").click(function () {
        
        var src = $("#star1").attr("src");
        src1 = src.replace("0", "1");
        src2 = src.replace("1", "0");
        var src = $("#star1").attr("src", src1);
        var src = $("#star2").attr("src", src1);
        var src = $("#star3").attr("src", src1);
        var src = $("#star4").attr("src", src2);
        var src = $("#star5").attr("src", src2);
        $("#Point").val("3");
    });
    $("#star4").click(function () {
        
        var src = $("#star1").attr("src");
        src1 = src.replace("0", "1");
        src2 = src.replace("1", "0");
        var src = $("#star1").attr("src", src1);
        var src = $("#star2").attr("src", src1);
        var src = $("#star3").attr("src", src1);
        var src = $("#star4").attr("src", src1);
        var src = $("#star5").attr("src", src2);
        $("#Point").val("4");
    });
    $("#star5").click(function () {
        
        var src = $("#star1").attr("src");
        src1 = src.replace("0", "1");
        src2 = src.replace("1", "0");
        var src = $("#star1").attr("src", src1);
        var src = $("#star2").attr("src", src1);
        var src = $("#star3").attr("src", src1);
        var src = $("#star4").attr("src", src1);
        var src = $("#star5").attr("src", src1);
        $("#Point").val("5");
    });
})
