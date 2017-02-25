<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Square Root Sum</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<table>
    <thead>
        <tr>
            <th>Number</th>
            <th>Square</th>
        </tr>
    </thead>
    <tbody>
    <?php
    $sum = 0;
    $square = 0;
    for ($number = 0; $number <= 100; $number+=2):
        $square = round(sqrt($number), 2);
        $sum += $square;
    ?>
        <tr>
            <td><?php echo $number ?></td>
            <td><?php echo $square ?></td>
        </tr>
    <?php endfor;?>
    </tbody>
    <tfoot>
        <tr>
            <td>Total:</td>
            <td><?php echo $sum ?></td>
        </tr>
    </tfoot>
</table>
</body>
</html>