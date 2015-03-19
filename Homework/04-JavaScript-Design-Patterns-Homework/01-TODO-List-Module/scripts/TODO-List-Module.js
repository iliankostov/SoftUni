var Todo = Todo || {};
Todo.Container = (function () {
    var Container = function(sections) {
        this._sections = sections;
    };

    Container.prototype.addToDOM = function(){
        var container = document.createElement('div');
        container.id = 'container';
        document.getElementsByTagName('body')[0].appendChild(container);
        var h1 = document.createElement('h1');
        h1.innerHTML += 'Tuesday ';
        var todo = document.createElement('em');
        todo.innerHTML = 'TODO';
        h1.appendChild(todo);
        h1.innerHTML += ' list';
        container.appendChild(h1);
        var innerContainer = document.createElement('div');
        innerContainer.id = 'inner-container';

        // try to add sections into container
        //innerContainer.appendChild(this._sections);

        container.appendChild(innerContainer);
        var form = document.createElement('form');
        var input = document.createElement('input');
        var button = document.createElement('button');
        button.innerHTML = 'New Section';
        container.appendChild(form);
        form.appendChild(input);
        form.appendChild(button);
    };

    return Container;
})();

Todo.Section = (function () {
    var Section = function(title, items) {
        this._title = title;
        this._items = items;
    };
    
    Section.prototype.addToDOM = function() {
        var section = document.createElement('div');
        document.getElementById('container').appendChild(section);
        var sectionBox = document.createElement('div');
        section.appendChild(sectionBox);
        var h2 = document.createElement('h2');
        h2.innerHTML = this._title;
        sectionBox.appendChild(h2);

    };

    return Section;
})();

var section = new Todo.Section('Shopping List');
var container = new Todo.Container(section);
container.addToDOM();
