pop('success', 'Success', 'You are done!');
pop('info', 'Info', 'This is information.');
pop('error', 'Error', 'This is error!');
pop('warning', 'Attention!', 'You are our 100th visitor.', redirect);

function redirect() {
    window.location = 'http://www.google.com/';
}