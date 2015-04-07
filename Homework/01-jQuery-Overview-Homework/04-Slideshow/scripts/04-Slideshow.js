(function () {
    const default_width = 500;
    const default_height = 500;

    $('<main>', {id: 'slides-container'})
        .css({
            'width': default_width,
            'height': default_height,
            'border': '1px solid black',
            'margin-left': 'auto',
            'margin-right': 'auto',
            'position': 'relative',
            'overflow': 'hidden'
        })
        .prependTo('body');

    $('<section>', {id: 'slides'})
        .css({
            'width': default_width,
            'height': default_height,
            'display': 'block',
            'margin': '0',
            'padding': '0'
        })
        .appendTo('#slides-container');

    // Slide 1
    $('<article>', {class: 'slide', id: 'slide-1'}).appendTo('#slides');
    $('<img src="images/goose-nature-water-bird.jpg">').appendTo('#slide-1');

    // Slide 2
    $('<article>', {class: 'slide', id: 'slide-2'}).appendTo('#slides');
    $('<img src="images/nature-rabbit-bunny.jpg">').appendTo('#slide-2');

    // Slide 3
    $('<article>', {class: 'slide', id: 'slide-3'}).appendTo('#slides');
    $('<img src="images/squirrel-animal-nature.jpg">').appendTo('#slide-3');

    // Slides common styling
    $('.slide').css({
        'width': default_width,
        'height': default_height,
        'padding': '5px',
        'position': 'absolute',
        'visibility': 'hidden'
    });

    $('img').css({
        'position': 'absolute',
        'top': '0',
        'left': '0',
        'z-index': '-1'
    });

    // Next and previous slide buttons
    $('<button>', {id: 'next'}).css({'right': '0'}).text('Next Slide').appendTo('#slides');
    $('<button>', {id: 'previous'}).css({'left': '0'}).text('Previous Slide').appendTo('#slides');

    $('#next, #previous').css({
        'margin': '5px',
        'padding': '5px',
        'position': 'absolute',
        'bottom': '0'
    });

    // Slide Show settings
    var slideWidth,
        numberOfButtons,
        slideShowLength,
        animationSpeed,
        animationInterval,

        slide_id,
        currentSlide,
        nextSlide,
        previousSlide,

        disableClick,

        interval;

    slideWidth = default_width;
    numberOfButtons = 2;
    slideShowLength = $('#slides').children().length - numberOfButtons;
    animationSpeed = 1000;
    animationInterval = 5000;

    slide_id = 1;
    currentSlide = $('#slide-' + slide_id).css('visibility', 'visible');

    function startSlideShow() {
        interval = setInterval(function () {
            // Disable clicking for the duration of animation to prevent slide stack up
            disableClick = true;
            slideLeft();

            // Enable clicking to toggle next and previous slides after animation has finished
            setTimeout(function () {
                disableClick = false;
            }, animationSpeed);

        }, animationInterval);
    }

    function stopSlideShow() {
        clearInterval(interval);
    }

    startSlideShow();

    $(document).ready(function () {

        $('#next').click(function (event) {
            if (!disableClick) {

                event.preventDefault();
                stopSlideShow();

                // Disable double clicking for the duration of animation to prevent slide stack up
                if (!$(this).data('isClicked')) {
                    var link = $(this);

                    slideLeft();

                    // Enable clicking to toggle next slide
                    link.data('isClicked', true);
                    setTimeout(function () {
                        link.removeData('isClicked')
                    }, animationSpeed);
                }

                startSlideShow();
            }
        });

        $('#previous').click(function (event) {
            if (!disableClick) {
                event.preventDefault();
                stopSlideShow();

                // Disable double clicking for the duration of animation to prevent slide stack up
                if (!$(this).data('isClicked')) {
                    var link = $(this);

                    slideRight();

                    // Enable clicking to toggle previous slide
                    link.data('isClicked', true);
                    setTimeout(function () {
                        link.removeData('isClicked')
                    }, animationSpeed);
                }

                startSlideShow();
            }
        });
    });

    function slideLeft() {

        currentSlide = $('#slide-' + slide_id);

        if (slide_id === slideShowLength) {
            slide_id = 0;
        }

        nextSlide = $('#slide-' + (slide_id + 1)).css({'left': slideWidth + 'px', 'visibility': 'visible'});
        slide_id++;

        currentSlide.animate(
            {'left': '-=' + slideWidth + 'px'},
            animationSpeed
        );

        nextSlide.animate(
            {'left': '-=' + slideWidth + 'px'},
            animationSpeed
        );
    }

    function slideRight() {

        currentSlide = $('#slide-' + slide_id);

        if (slide_id === 1) {
            slide_id = slideShowLength + 1;
        }

        previousSlide = $('#slide-' + (slide_id - 1)).css({'left': '-' + slideWidth + 'px', 'visibility': 'visible'});
        slide_id--;

        currentSlide.animate(
            {'left': '+=' + slideWidth + 'px'},
            animationSpeed
        );

        previousSlide.animate(
            {'left': '+=' + slideWidth + 'px'},
            animationSpeed
        );
    }
}());
