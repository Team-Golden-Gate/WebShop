var app = app || {}

app.activateMenu = function activateMenu(element) {
    $('#admin-menu').children().each(function (index, element) {
        $(element).removeClass('active');
    })

    var el = 'li#' + element;

    $(el).addClass('active');
}

