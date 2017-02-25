(function () {
    var sampleInput =
        '[{"model":"E92 320i","year":2011,"manufacturer":"BMW","price":50000,"class":"Family"},' +
        '{"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},' +
        '{"manufacturer":"Peugeot","year":1978,"model":"305","price":1000,"class":"Family"}]';

    $('<main>').prependTo('body');
    $('<section>').appendTo('main');
    $('<article>').appendTo('section');

    $('<textarea>', {id: 'input'}).css({'width': '400px', 'height': '200px'}).text(sampleInput).appendTo('article');
    $('<br>').appendTo('article');
    $('<button>', {id: 'output'}).css({'margin': '5px 0px 10px 0px'}).text('Generate Table').appendTo('article');

    $(document).ready(function () {
        $('#output').on('click', generateTable);
    });

    function generateTable() {
        // clears any existing tables preventing table stack up
        $('table').remove();

        sampleInput = document.getElementById('input').value;

        var cars = jQuery.parseJSON(sampleInput);

        $('<table>').css({'border': '1px solid black', 'border-spacing': '0'}).appendTo('article');
        $('<thead>').css({'background-color': 'rgb(160, 160, 80)'}).prependTo('table');
        $('<tr>').appendTo('thead');

        $('<th>').text('Manufacturer').appendTo('tr');
        $('<th>').text('Model').appendTo('tr');
        $('<th>').text('Year').appendTo('tr');
        $('<th>').text('Price').appendTo('tr');
        $('<th>').text('Class').appendTo('tr');
        $('th').css({'border': '1px solid black', 'padding': '5px 10px'});

        $('<tbody>').appendTo('table');

        var index,
            row_id;

        for (index = 0, row_id = 1; index < cars.length; index++, row_id++) {
            $('<tr>', {id: row_id}).appendTo('tbody');

            $('<td>').text(cars[index]['manufacturer']).appendTo('#' + row_id);
            $('<td>').text(cars[index]['model']).appendTo('#' + row_id);
            $('<td>').text(cars[index]['year']).appendTo('#' + row_id);
            $('<td>').text(cars[index]['price']).appendTo('#' + row_id);
            $('<td>').text(cars[index]['class']).appendTo('#' + row_id);
        }

        $('td').css({'border': '1px solid black', 'padding': '5px 10px'});
    }
}());
