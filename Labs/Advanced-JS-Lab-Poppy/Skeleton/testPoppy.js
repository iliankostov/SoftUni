poppy.pop('success', 'Success', 'You are done!');
poppy.pop('info', 'Info', 'This is information.');
poppy.pop('error', 'Error', 'This is error!');
poppy.pop('warning', 'Attention!', 'You are our 100th visitor.', redirect);

function redirect() {
    window.location = 'http://www.google.com/';
}