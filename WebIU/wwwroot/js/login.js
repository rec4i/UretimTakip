$(".toggle-password").click(function () {
    $(this).toggleClass("fas fa-lock");
    var input = $("#Password");

    if (input.attr("type") === "password") {
        input.attr("type", "text");
        $(this).removeClass("fas fa-lock").addClass("fas fa-unlock");
    } else {
        input.attr("type", "password");
        $(this).removeClass("fas fa-unlock").addClass("fas fa-lock");
    }
});
