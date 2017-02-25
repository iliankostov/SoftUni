<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Car Randomizer</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <form method="post">
        <section>
            <label for="cars">Enter cars</label>
            <input type="text" name="cars" id="cars"/>
            <input type="submit" name="submit" value="Show result"/>
        </section>
    </form>
    <?php
    if (isset($_POST['submit'])):
            $cars = preg_split('/, /', $_POST['cars']);
            $colors = array("yellow", "green", "black", "orange", "purple");
            $counts = array("1", "2", "3", "4", "5");
    ?>
    <table>
        <thead>
        <tr>
            <th>Car</th>
            <th>Color</th>
            <th>Count</th>
        </tr>
        </thead>
        <tbody>
        <?php
            foreach ($cars as $car):
                $color = $colors[array_rand($colors)];
                $count = $counts[array_rand($counts)];
        ?>
        <tr>
            <td><?php echo $car;?></td>
            <td><?php echo $color;?></td>
            <td><?php echo $count;?></td>
        </tr>
        <?php endforeach;?>
        </tbody>
    </table>
    <?php endif;?>
</main>
</body>
</html>