<!DOCTYPE html>
<html>
<head lang="en">
    <meta charset="UTF-8">
    <title>CV Generator</title>
    <link rel="stylesheet" href="styles/styles.css"/>
</head>
<body>
<section class="left">
    <form method="post" action="CVGenerator.php">
        <fieldset>
            <legend>Personal Information</legend>
            <input type="text" name="fName" placeholder="First Name" required="required"/><br />
            <input type="text" name="lName" placeholder="Last Name" required="required"/><br />
            <input type="email" name="email" placeholder="Email" required="required"/><br />
            <input type="tel" name="phone" placeholder="Phone Number" required="required"/><br />
            <label for="female">Female</label>
            <input type="radio" name="gender" id="female" value="Female"/>
            <label for="male">Male</label>
            <input type="radio" name="gender" id="male" value="Male"/><br />
            <label for="birthday">Birthday</label><br />
            <input type="date" name="birthday" id="birthday" required="required"/><br />
            <label for="nationality">Nationality</label><br />
            <select name="nationality" id="nationality">
                <option value="Bulgarian">Bulgarian</option>
                <option value="German">German</option>
                <option value="English">English</option>
            </select>
        </fieldset>
        <fieldset>
            <legend>Last Work Position</legend>
            <label for="company">Company Name</label>
            <input type="text" name="company" id="company" required="required"/><br />
            <label for="fromDate">From</label>
            <input type="date" name="fromDate" id="fromDate" required="required"/><br />
            <label for="toDate">To</label>
            <input type="date" name="toDate" id="toDate" required="required"/><br />
        </fieldset>
        <fieldset id="computerSkills">
            <legend>Computer Skills</legend>
            <label for="progLang">Programming Languages</label><br />
            <div id="progLang">
                <input type="text" name="progLang[]" required="required" title="Programming Language"/>
                <select name="progLangLevel[]" title="Level of Programming Language">
                    <option value="Beginner">Beginner</option>
                    <option value="Programmer">Programmer</option>
                    <option value="Ninja">Ninja</option>
                </select>
            </div>
            <input type="button" value="Remove Language" onclick="removeProgLang()" id="remProgLang" />
            <input type="button" value="Add Language" onclick="addProgLang()" />
        </fieldset>
        <fieldset id="otherSkills">
            <legend>Other Skills</legend>
            <label for="lang">Languages</label><br />
            <div id="lang">
                <input type="text" name="lang[]" required="required" title="Languages"/>
                <select name="comprehension[]" title="Comprehension" required="required">
                    <option value="" disabled selected>Comprehension</option>
                    <option value="beginner">Beginner</option>
                    <option value="intermediate">intermediate</option>
                    <option value="advanced">advanced</option>
                </select>
                <select name="reading[]" title="Reading" required="required">
                    <option value="" disabled selected>Reading</option>
                    <option value="beginner">Beginner</option>
                    <option value="intermediate">intermediate</option>
                    <option value="advanced">advanced</option>
                </select>
                <select name="writing[]" title="Writing" required="required">
                    <option value="" disabled selected>Writing</option>
                    <option value="beginner">Beginner</option>
                    <option value="intermediate">intermediate</option>
                    <option value="advanced">advanced</option>
                </select>
            </div>
            <input type="button" value="Remove Language" onclick="removeLang()" id="remLang" />
            <input type="button" value="Add Language" onclick="addLang()" /><br />
            <label for="driverLicense">Driver`s License</label><br />
            <label for="b">B</label>
            <input type="checkbox" name="b" value="B" id="b" />
            <label for="a">A</label>
            <input type="checkbox" name="a" value="A" id="a" />
            <label for="c">C</label>
            <input type="checkbox" name="c" value="C" id="c" />
        </fieldset>
        <input type="submit" value="Generate CV" />
    </form>
</section>
<section class="right">
<?php
if (isset($_POST['fName'], $_POST['lName'], $_POST['email'], $_POST['phone'], $_POST['gender'],
    $_POST['birthday'], $_POST['nationality'], $_POST['company'], $_POST['fromDate'],
    $_POST['toDate'], $_POST['progLang'], $_POST['progLangLevel'], $_POST['lang'],
    $_POST['comprehension'], $_POST['reading'], $_POST['writing'])):

    $fName = $_POST['fName'];
    $lName = $_POST['lName'];
    $email = $_POST['email'];
    $phone = $_POST['phone'];
    $gender = $_POST['gender'];
    $birthday = $_POST['birthday'];
    $nationality = $_POST['nationality'];
    $company = $_POST['company'];
    $fromDate = $_POST['fromDate'];
    $toDate = $_POST['toDate'];
    $progLangArray = $_POST['progLang'];
    $progLangLevelArray = $_POST['progLangLevel'];
    $langArray = $_POST['lang'];
    $comprehensionArray = $_POST['comprehension'];
    $readingArray = $_POST['reading'];
    $writingArray = $_POST['writing'];

    $driverLicenses = array();

    if (isset($_POST['a'])) {
        array_push($driverLicenses, 'A');
    }
    if (isset($_POST['b'])) {
        array_push($driverLicenses, 'B');
    }
    if (isset($_POST['c'])) {
        array_push($driverLicenses, 'C');
    }

    $driverLicenses = implode(', ', $driverLicenses);

    //Validate user input:
    $nameLangPattern = array("options"=>array("regexp"=>"/[^A-Za-z]/"));
    $companyPattern = array("options"=>array("regexp"=>"/[^A-Za-z0-9\s+]/"));
    $phonePattern = array("options"=>array("regexp"=>"/[^0-9-\+ ]+/"));
    $emailPattern = array("options"=>array("regexp"=>"/^[A-Za-z0-9_.]+@[A-Za-z0-9]+[.A-Za-z]+$/"));

    if (filter_var($fName, FILTER_VALIDATE_REGEXP, $nameLangPattern) ||
        filter_var($lName, FILTER_VALIDATE_REGEXP, $nameLangPattern) ||
        strlen($fName) < 2 || strlen($fName) > 20 || strlen($lName) < 2 ||
        strlen($lName > 20)) {
        die ('First Name and Last Name must contain only letters between 2 and 20 symbols!');
    }

    foreach ($langArray as $key => $value) {
        if (filter_var($value, FILTER_VALIDATE_REGEXP, $nameLangPattern)) {
            die ('Language must contain only letters between 2 and 20 symbols!');
        }
    }

    if (filter_var($company, FILTER_VALIDATE_REGEXP, $companyPattern) ||
        strlen($company) < 2 || strlen($company) > 20) {
        die ('Company Name must contain only letters and numbers between 2 and 20 symbols!');
    }

    if (filter_var($phone, FILTER_VALIDATE_REGEXP, $phonePattern)) {
        die ('Phone Number must contain only numbers, "+", "-" and " "!');
    }

    if (!filter_var($email, FILTER_VALIDATE_REGEXP, $emailPattern)) {
        die ('Email must contain numbers, letters, only one "@"!');
    }
    ?>
    <h1>CV</h1>

    <table>
        <thead>
        <tr>
            <th colspan="2">Personal Information</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>First Name</td>
            <td><?= htmlspecialchars($fName) ?></td>
        </tr>
        <tr>
            <td>Last Name</td>
            <td><?= htmlspecialchars($lName) ?></td>
        </tr>
        <tr>
            <td>Email</td>
            <td><?= htmlspecialchars($email) ?></td>
        </tr>
        <tr>
            <td>Phone Number</td>
            <td><?= htmlspecialchars($phone) ?></td>
        </tr>
        <tr>
            <td>Gender</td>
            <td><?= htmlspecialchars($gender) ?></td>
        </tr>
        <tr>
            <td>Birth Date</td>
            <td><?= htmlspecialchars($birthday) ?></td>
        </tr>
        <tr>
            <td>Nationality</td>
            <td><?= htmlspecialchars($nationality) ?></td>
        </tr>
        </tbody>
    </table>
    <br />

    <table>
        <thead>
        <tr>
            <th colspan="2">Last Work Position</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>Company Name</td>
            <td><?= htmlspecialchars($company) ?></td>
        </tr>
        <tr>
            <td>From</td>
            <td><?= htmlspecialchars($fromDate) ?></td>
        </tr>
        <tr>
            <td>To</td>
            <td><?= htmlspecialchars($toDate) ?></td>
        </tr>
        </tbody>
    </table>
    <br />

    <table>
        <thead>
        <tr>
            <th colspan="2">Computer Skills</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>Programming Languages</td>
            <td>
                <table>
                    <thead>
                    <tr>
                        <th>Language</th>
                        <th>Skill Level</th>
                    </tr>
                    </thead>
                    <tbody>
                    <?php for ($i=0; $i < count($progLangArray); $i++): ?>
                        <tr>
                            <td><?= htmlspecialchars($progLangArray[$i]) ?></td>
                            <td><?= htmlspecialchars($progLangLevelArray[$i]) ?></td>
                        </tr>
                    <?php endfor; ?>
                    </tbody>
                </table>
            </td>
        </tr>
        </tbody>
    </table>
    <br />

    <table>
        <thead>
        <tr>
            <th colspan="2">Other Skills</th>
        </tr>
        </thead>
        <tbody>
        <tr>
            <td>Languages</td>
            <td>
                <table>
                    <thead>
                    <tr>
                        <th>Language</th>
                        <th>Comprehension</th>
                        <th>Reading</th>
                        <th>Writing</th>
                    </tr>
                    </thead>
                    <tbody>
                    <?php for ($i=0; $i < count($langArray); $i++): ?>
                        <tr>
                            <td><?= htmlspecialchars($langArray[$i]) ?></td>
                            <td><?= htmlspecialchars($comprehensionArray[$i]) ?></td>
                            <td><?= htmlspecialchars($readingArray[$i]) ?></td>
                            <td><?= htmlspecialchars($writingArray[$i]) ?></td>
                        </tr>
                    <?php endfor; ?>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td>Driver`s License</td>
            <td><?= htmlspecialchars($driverLicenses) ?></td>
        </tr>
        </tbody>
    </table>
<?php endif; ?>
</section>
<script src="scripts/addRemoveLang.js"></script>
</body>
</html>