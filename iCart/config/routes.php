<?php
// override default route
//$cnf['package']['namespace'] = 'Controllers\Admin';
//$cnf['package']['namespace'] = 'Controllers\Admin';
//
// override default controller index to newController
//$cnf['package']['controllers']['index']['to'] = 'newController';
//
// override default oldMethod old to newMethod
//$cnf['package']['controllers']['index']['methods']['oldMethod'] = 'newMethod';

$cnf['*']['namespace'] = 'Controllers';

return $cnf;