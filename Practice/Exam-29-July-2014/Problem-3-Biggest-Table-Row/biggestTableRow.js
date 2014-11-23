function biggestTableRow(table) {
    var maxSum = Number.NEGATIVE_INFINITY;
    for (var lineIndex = 2; lineIndex < table.length - 1; lineIndex++) {
        var row = table[lineIndex];
        var cells = row.match(/<td>(.*?)<\/td>/g);
        var sum = 0, values = [];
        for (var c = 1; c < cells.length; c++) {
            var cellValue = cells[c];
            cellValue = cellValue.substring('<td>'.length);
            cellValue = cellValue.substring(0, cellValue.length - '</td>'.length);
            var num = Number(cellValue.trim());
            if (! isNaN(num)) {
                values.push(cellValue);
                sum += num;
            }
        }
        if (sum > maxSum && values.length > 0) {
            maxSum = sum;
            var maxSumDetails = values.join(' + ');
        }
    }
    if (maxSum != Number.NEGATIVE_INFINITY) {
        console.log(maxSum + ' = ' + maxSumDetails);
    } else {
        console.log("no data");
    }
}


// ------------------------------------------------------------
// Read the input from the console as array and process it
// Remove all below code before submitting to the judge system!
// ------------------------------------------------------------

biggestTableRow([
    "<table>",
    "<tr><th>Town</th><th>Store1</th><th>Store2</th><th>Store3</th></tr>",
    "<tr><td>Sofia</td><td>26.2</td><td>8.20</td><td>-</td></tr>",
    "<tr><td>Varna</td><td>11.2</td><td>18.00</td><td>36.10</td></tr>",
    "<tr><td>Plovdiv</td><td>17.2</td><td>12.3</td><td>6.4</td></tr>",
    "<tr><td>Bourgas</td><td>-</td><td>24.3</td><td>-</td></tr>",
    "</table>"
]);
