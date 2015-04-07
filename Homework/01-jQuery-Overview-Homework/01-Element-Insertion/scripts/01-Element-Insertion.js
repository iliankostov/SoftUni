(function () {
    var appendedElement_id,
        prependedElement_id;

    appendedElement_id = prependedElement_id = 10;

    $('<main>').prependTo('body');
    $('<aside>').appendTo('main');
    $('<ul>').appendTo('aside');
    $('<li>').text('Item 10').appendTo('ul');

    $('<button>', {id: 'append'}).css({'margin': '5px'}).text('Append').appendTo('aside');
    $('<button>', {id: 'prepend'}).css({'margin': '5px'}).text('Prepend').appendTo('aside');

    $(document).ready(function () {
        $('#append').on('click', appendItem);
        $('#prepend').on('click', prependItem);
    });

    function appendItem() {
        appendedElement_id++;
        $('<li>').text('Item ' + (appendedElement_id)).appendTo('ul');
    }

    function prependItem() {
        prependedElement_id--;
        $('<li>').text('Item ' + (prependedElement_id)).prependTo('ul');
    }
}());