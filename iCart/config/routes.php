<?php
// override default route
//$cnf['package']['namespace'] = 'Controllers\Admin';
//$cnf['package']['namespace'] = 'Controllers\Admin';


//// override default controller index to users
//$cnf['*']['controllers']['index']['to'] = 'users';
//
//// override default oldMethod old to newMethod
//$cnf['*']['controllers']['index']['methods']['index'] = 'test';


$cnf['*']['namespace'] = 'Controllers';

return $cnf;