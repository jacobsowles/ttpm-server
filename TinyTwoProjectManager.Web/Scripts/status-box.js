$(function () {
    $('#progress-bar').circleProgress({
        value: 0.69,
        size: 150,
        thickness: 4,
        startAngle: -Math.PI / 2,
        animationStartValue: 0.0,
        fill: {
            color: '#5e804d'
        }
    });

    /*var canvas = $('canvas')[0];
    var context = canvas.getContext('2d');
    var image = $('<img>', { src: '/Content/Images/profile-picture.jpg' })[0];

    var drawImageOntoCanvas = function () {
        context.drawImage(this, 0, 0, 150, 150);
    }

    // check if image was already loaded by the browser
    if (image.complete) {
        drawImageOntoCanvas();
    }

    else {
        image.onload = function() {
            drawImageOntoCanvas;
        };
    }*/
})