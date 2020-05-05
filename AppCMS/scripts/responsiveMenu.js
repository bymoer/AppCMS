$(function () {
    $("#hamburger-menu-icon").click(function () {
        $("#responsive-menu-wrapper").addClass("show-fullscreen-menu");
    });
    $("#responsive-menu-close").click(function () {
        $("#responsive-menu-wrapper").removeClass("show-fullscreen-menu");
    });
});
                        