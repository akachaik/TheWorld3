(function () {
    "use strict";

    var $sidebarAndWrapper = $("#sidebar, #wrapper");

    $("#sidebarToggle").on("click", function() {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        var $icon = $("#sidebarToggle i.fa");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.addClass("fa-angle-right");
            $icon.removeClass("fa-angle-left");
        } else {
            $icon.removeClass("fa-angle-right");
            $icon.addClass("fa-angle-left");
        }
    });
    
})();