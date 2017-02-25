<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Sum of Digits</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <form method="post">
        <section>
            <label for="str">Input string:</label>
            <input type="text" name="str" id="str"/>
            <input type="submit" name="submit"/>
        </section>
    </form>
    <table>
    <?php
    if(isset($_POST['submit'])):
        $arr = preg_split('/(, )/', $_POST['str']);
        foreach($arr as $value):
            if (is_numeric($value)):
                $digits = str_split($value);
    ?>
            <tr>
                <td><?php echo $value; ?></td>
                <td><?php echo array_sum($digits); ?></td>
            </tr>
            <?php else: ?>
            <tr>
                <td><?php echo $value; ?></td>
                <td><?php echo 'I cannot sum that'; ?></td>
            </tr>
            <?php endif; ?>
        <?php endforeach;
    endif; ?>
    </table>
</main>
</body>
</html>