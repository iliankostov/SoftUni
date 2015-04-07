(function () {

    $('<main>').prependTo('body');
    $('<aside>').css({'width': '210px'}).appendTo('main');
    $('<header>').appendTo('aside');
    $('<h3>').text('Animals').appendTo('header');

    $('<ul>').css({'list-style-type': 'none'}).appendTo('aside');

    $('<li>', {class: 'fish'}).text('Barracuda').appendTo('ul');
    $('<li>', {class: 'bird'}).text('Hummingbird').appendTo('ul');
    $('<li>', {class: 'bird'}).text('Nightingale').appendTo('ul');
    $('<li>', {class: 'reptile'}).text('Lizard').appendTo('ul');
    $('<li>', {class: 'fish'}).text('Bass').appendTo('ul');
    $('<li>', {class: 'reptile'}).text('Crocodile').appendTo('ul');
    $('<li>', {class: 'bird'}).text('Eagle').appendTo('ul');
    $('<li>', {class: 'fish'}).text('Cod').appendTo('ul');
    $('<li>', {class: 'fish'}).text('Trout').appendTo('ul');
    $('<li>', {class: 'bird'}).text('Sparrow').appendTo('ul');
    $('<li>', {class: 'reptile'}).text('Aligator').appendTo('ul');
    $('<li>', {class: 'reptile'}).text('Turtle').appendTo('ul');
    $('<li>', {class: 'bird'}).text('Hawk').appendTo('ul');
    $('<li>', {class: 'reptile'}).text('Snake').appendTo('ul');
    $('<li>', {class: 'fish'}).text('Salmon').appendTo('ul');

    $('<input>', {type: 'color'}).css({'margin': '5px'}).appendTo('aside');

    $('<select>').css({'margin': '5px'}).appendTo('aside');
    $('<option>', {value: 'bird'}).text('Birds').appendTo('select');
    $('<option>', {value: 'fish'}).text('Fish').appendTo('select');
    $('<option>', {value: 'reptile'}).text('Reptiles').appendTo('select');

    $('<button>', {id: 'paint'}).css({'margin': '5px'}).text('Paint').appendTo('aside');

    $(document).ready(function () {
        $('#paint').on('click', paintItems);
    });

    function paintItems() {
        $('li').css({'background-color': 'transparent', 'color': 'black'});

        var color,
            className,
            items;

        color = $('input[type=color]').val();
        className = $('option:selected').val();
        items = $('.' + className);

        if (color == '#000000') {
            items.css({'color': 'white'});
        }

        items.css({'background-color': color});

        console.log(color);
    }
}());