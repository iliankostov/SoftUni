<?php
$cnf['debug'] = false;

$cnf['default_controller'] = 'Index';
$cnf['default_method'] = 'index';

$cnf['namespaces']['Controllers'] = '../controllers';
$cnf['namespaces']['Models'] = '../models';
$cnf['namespaces']['Models\BindingModels'] = '../models/bindingmodels';

$cnf['namespaces']['Areas\Admin\Controllers'] = '../areas/admin/controllers';
$cnf['namespaces']['Areas\Admin\Models'] = '../areas/admin/models';

$cnf['viewsDirectory'] = '../views/';

$cnf['session']['autostart'] = true;
$cnf['session']['type'] = 'native';
$cnf['session']['name'] = '__sess';
$cnf['session']['lifetime'] = 3600;
$cnf['session']['path'] = '/';
$cnf['session']['domain'] = '';
$cnf['session']['secure'] = false;

$cnf['default_role'] = 3;
$cnf['default_cash'] = 10000;

return $cnf;