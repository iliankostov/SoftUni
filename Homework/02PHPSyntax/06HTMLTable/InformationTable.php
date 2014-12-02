<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Information Table</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
    <main>
        <article>
            <?php generateTable(array('Gosho', '0882-321-423', '24', 'Hadji Dimitar')); ?>
        </article>
        <article>
            <?php generateTable(array('Pesho', '0884-888-888', '67', 'Suhata Reka')); ?>
        </article>
    </main>
</body>
</html>

<?php
function generateTable($data)
{
    $tableData = array('Name' => $data[0], 'Phone number' => $data[1], 'Age' => $data[2], 'Address' => $data[3]);
    echo "<table>";
    foreach ($tableData as $key => $value) {
        echo "<tr>";
        echo "<th>" . $key . "</th>";
        echo "<td>" . $value . "</td>";
        echo "</tr>";
    }
    echo "</table>";
}





























