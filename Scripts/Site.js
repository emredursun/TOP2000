// Deze functie gaat elke cel langs en pakt daar de waarde van.
// En geeft deze een kleurtje mee en een icon mee.

$('#yearlist').find('tr').each(function (i, el) {
    var $tds = $(this).find('td'),
        number = $tds.eq(1).text()
    var cell = $tds.eq(1)



    if (number > 0) {
        var icon = '<span class="glyphicon glyphicon-triangle-top green"></span>'
        cell.prepend(icon + '<br>')
    }
    if ($.isNumeric(number) && number == 0) {
        var icon = '<span class="glyphicon glyphicon-minus"></span>'
        cell.addClass('black').html(icon)
    }
    if (number < 0) {
        var icon = '<span class= "glyphicon glyphicon-triangle-bottom red"></span>'
        cell.html(Math.abs(number)).prepend(icon + '<br>')
    }
    if (!$.isNumeric(number)) {
        var icon = '<span class="glyphicon glyphicon-star blue"></span>'
        cell.html('<span class="small">nieuw</small>').prepend(icon + '<br>')
    }


});


// Click on action button
$(document).on('click', '#action-button', function () {
    alert("test")
})

// Align text box infopage

var height = $('.text-block3').height()
$('.text-block1').height(height)
$('.text-block2').height(height)

// Background image infopage
var imgSource = '../Images/musicbackground2.jpg'
$(".background-img").css("background-image", "url(" + imgSource + ")");
