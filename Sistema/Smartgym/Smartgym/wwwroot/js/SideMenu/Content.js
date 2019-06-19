$(document).ready(function () {
    $("#Sidebar").mCustomScrollbar({
        theme: "minimal"
    });

    $('#Dismiss, .overlay').on('click', function () {
        $('#Sidebar').removeClass('active');
        $('.overlay').removeClass('active');
    });

    $('#SidebarCollapse').on('click', function () {
        $('#Sidebar').addClass('active');
        $('.overlay').addClass('active');
        $('.collapse.in').toggleClass('in');
        $('a[aria-expanded=true]').attr('aria-expanded', 'false');
    });
});