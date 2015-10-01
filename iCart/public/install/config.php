<?php
// TODO parse all annotation and set rules in config folder

$testFile = fopen("../../config/test.php", "w") or die("Unable to open file!");
$startTag = "<?php\n";
fwrite($testFile, $startTag);


$files = scandir('../../controllers');
var_dump($files);

$defaultRoute = "\$cnf['*']['namespace'] = 'Controllers';\n";
fwrite($testFile, $defaultRoute);

$returnCnf = "return \$cnf;";
fwrite($testFile, $returnCnf);

fclose($testFile);

echo "Config installed";
