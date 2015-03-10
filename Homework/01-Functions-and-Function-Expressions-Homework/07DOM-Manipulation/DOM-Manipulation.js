var domModule = function domModule() {

    function appendChild(child, parent) {
        this.parent = retrieveElements(parent);
        this.child = setElement(child);

        if (this.parent !== null) {
            for (var a = 0; a < this.parent.length; a++) {
                this.parent[a].appendChild(this.child.cloneNode(true));
            }
        }
    }

    function removeChild(parent, child) {
        this.parent = retrieveElements(parent);

        if (this.parent !== null) {
            for (var a = 0; a < this.parent.length; a++) {
                this.children = this.parent[a].querySelectorAll(":scope > " + child);

                for (var b = 0; b < this.children.length; b++) {
                    this.parent[a].removeChild(this.children[b]);
                }
            }
        }
    }

    function addHandler(element, eventType, eventHandler) {
        this.parent = retrieveElements(element);
        if (this.parent !== null) {
            for (var a = 0; a < this.parent.length; a++) {
                this.parent[a].addEventListener(eventType, eventHandler);
            }
        }
    }

    function retrieveElements(selector) {
        if (selector.nodeType !== document.ELEMENT_NODE) {
            return document.querySelectorAll(selector);
        }

        return selector;
    }

    function setElement(element) {
        if (element.nodeType !== document.ELEMENT_NODE) {
            var newElement = document.createElement(element);

            return newElement;
        }

        return element;
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        retrieveElements: retrieveElements
    };
}();

var liElement = document.createElement("li");
liElement.innerHTML = "Phoenix";

// Appends a list item to ul.birds-list
domModule.appendChild(liElement, ".birds-list");

// Removes the first li child from the bird list
domModule.removeChild("ul.birds-list", "li:first-child");

// Adds a click event to all bird list items
domModule.addHandler("li.bird", 'click', function () {
    alert("I'm a bird!")
});

// Retrives all elements of class "bird"
var elements = domModule.retrieveElements(".bird");
