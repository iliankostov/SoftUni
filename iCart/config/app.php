<?php
$cnf['debug'] = false;

$cnf['default_controller'] = 'Index';
$cnf['default_method'] = 'index';

$cnf['namespaces']['Areas\Admin\Controllers'] = '../areas/admin/controllers';
$cnf['namespaces']['Controllers'] = '../controllers';
$cnf['namespaces']['Models'] = '../models';

$cnf['viewsDirectory'] = '../views/';

$cnf['session']['autostart'] = true;
$cnf['session']['type'] = 'native';
$cnf['session']['name'] = '__sess';
$cnf['session']['lifetime'] = 3600;
$cnf['session']['path'] = '/';
$cnf['session']['domain'] = '';
$cnf['session']['secure'] = false;

return $cnf;