<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Annual Expenses</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <form method="post">
        <section>
            <label for="years">Enter number of years:</label>
            <input type="text" name="years" id="years"/>
            <input type="submit" name="submit" value="Show costs"/>
        </section>
    </form>
    <?php
    if (isset($_POST['submit'])):
    $years = $_POST['years'];
    ?>
        <table>
            <thead>
                <tr>
                    <th>Year</th>
                    <?php
                    $month = strtotime("2014.01.01");
                    for ($i = 1; $i <= 12; $i++):
                        $month_name = date('F', $month);
                        $months[] = $month_name;
                    ?>
                        <th><?php echo $month_name ?></th>
                    <?php
                        $month = strtotime('+1 month', $month);
                        endfor;
                    ?>
                    <th>Total:</th>
                </tr>
            </thead>
            <tbody>
                <?php
                for ($j = 2014; $j > 2014 - $years; $j--):
                    $total = 0;
                ?>
                <tr>
                    <td><?php echo $j ?></td>
                    <?php
                    foreach($months as $key => $value):
                        $value = rand(0, 999);
                        $total += $value;
                    ?>
                    <td><?php echo $value ?></td>
                    <?php endforeach; ?>
                    <td><?php echo $total ?></td>
                </tr>
                <?php endfor; ?>
            </tbody>
        </table>
    <?php endif; ?>
</main>
</body>
</html>