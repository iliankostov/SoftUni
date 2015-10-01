<?php
$cnf['admin']['controllers']['test']['to'] = 'index';
$cnf['admin']['controllers']['test']['methods']['opa'] = 'index';
$cnf['admin']['controllers']['index']['methods']['index'] = 'notFound';
$cnf['admin']['namespace'] = 'Areas\Admin\Controllers';
$cnf['*']['namespace'] = 'Controllers';
return $cnf;