<?php
function isPrime($number)
{
    if ($number < 2) {
        return false;
    }
    for ($i = 2; $i <= sqrt($number); $i++) {
        if ($number % $i == 0) {
            return false;
        }
    }
    return true;
}
?>
<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Find Primes in Range</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <section>
        <form method="post">
                <label for="start">Starting index:</label>
                <input type="text" name="start" id="start"/>
                <label for="end">End:</label>
                <input type="text" name="end" id="end"/>
                <input type="submit" name="submit" />
        </form>
    </section>
    <section>
        <?php
        if (isset($_POST['submit'])):
            $start = $_POST['start'];
            $end = $_POST['end'];
            for ($i = $start; $i <= $end; $i++):
                if (isPrime($i)):
        ?>
                    <b>
                        <?php
                        if ($i < $end) {
                            echo $i . ', ';
                        } else {
                            echo $i;
                        }
                        ?>
                    </b>
                <?php
                else:
                    if ($i < $end) {
                        echo $i . ', ';
                    } else {
                        echo $i;
                    }
                endif;
            endfor;
        endif; ?>
    </section>
</main>
</body>
</html>