<?php
$cnf['Admin']['namespace'] = 'Controllers\Admin';

$cnf['administration']['namespace'] = 'Controllers\Admin';
$cnf['administration']['controllers']['index']['to'] = 'Test';
$cnf['administration']['controllers']['index']['methods']['new'] = '_new';
$cnf['administration']['controllers']['new']['to'] = 'create';

$cnf['Test']['namespace'] = 'Controllers\Test';

$cnf['*']['namespace'] = 'Controllers';

return $cnf;
