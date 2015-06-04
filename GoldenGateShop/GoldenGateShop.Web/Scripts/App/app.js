var app = app || {}

app.activateMenu = function activateMenu(element) {
    $('#admin-menu').children().each(function (index, element) {
        $(element).removeClass('active');
    })

    var el = 'li#' + element;

    $(el).addClass('active');
}

//loading element
$(window).ajaxStart(function () { $('#loading').show(); });
$(window).ajaxComplete(function () { $('#loading').hide(); });

app.uploadImage = function uploadImage(element) {
    var file = element[0].files[0];
    if (file.type.match(/image\/.*/)) {
        var reader = new FileReader();
        reader.onload = function () {
            $('#image').attr('src', reader.result);
            document.getElementById('picture').value = reader.result.toString();
        };
        reader.readAsDataURL(file);
    } else {
        Noty.error("File your are trying to upload isn't a picture!");
    }
}