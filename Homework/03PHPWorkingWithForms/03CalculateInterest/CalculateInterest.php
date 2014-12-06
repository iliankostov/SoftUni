<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>Calculate Interest</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<main>
    <form method="post">
        <section>
            <label for="amount">Enter Amount</label>
            <input type="text" name="amount" id="amount"/>
            <div>
                <input type="radio" name="currency" id="usd" value="usd"/>
                <label for="usd">USD</label>
                <input type="radio" name="currency" id="eur" value="eur"/>
                <label for="eur">EUR</label>
                <input type="radio" name="currency" id="bgn" value="bgn"/>
                <label for="bgn">BGN</label>
            </div>
            <label for="cia">Compound Interest Amount</label>
            <input type="text" name="cia" id="cia"/>
            <div>
                <select name="period" id="period" title="Period of Time">
                    <option value="6">6 Months</option>
                    <option value="12">1 Year</option>
                    <option value="24">2 Years</option>
                    <option value="60">5 Years</option>
                </select>
                <input type="submit" name="submit" value="Calculate"/>
                <span>
                    <?php
                        if (isset($_POST['submit'])) {
                            if (is_numeric($_POST['amount']) && is_numeric($_POST['cia']) && isset($_POST['currency'])) {
                                $total = $_POST['amount'];
                                $ciaPerMonth = $_POST['cia'] / 12 / 100;
                                $currency = $_POST['currency'];
                                for ($i = 1; $i <= $_POST['period']; $i++) {
                                    $total += $total * $ciaPerMonth;
                                }
                                $total = number_format($total, 2, '.', '');
                                switch($currency) {
                                    case "usd":
                                        echo "$ " . $total;
                                        break;
                                    case "eur":
                                        echo "€ " . $total;
                                        break;
                                    case "bgn":
                                        echo $total . " лв.";
                                        break;
                                    default:
                                        break;
                                }
                            } else {
                                echo "Please fill all fields!";
                            }
                        }
                    ?>
                </span>
            </div>
        </section>
    </form>
</main>
</body>
</html>