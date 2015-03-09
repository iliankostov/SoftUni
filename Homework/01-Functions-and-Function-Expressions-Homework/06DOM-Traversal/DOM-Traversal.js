function traverse(node) {
    traverseNode(node, '');

    function traverseNode(node, spacing) {
        this.htmlElement = node;
        spacing = spacing || '  ';
        var tagName = this.htmlElement.tagName.toLowerCase();
        var elementId = this.htmlElement.id;
        var elementClass = this.htmlElement.className;
        var output = spacing + tagName + ": ";
        output += elementId != '' ? 'id="' + elementId + '"' : '';
        output += elementClass != '' ? 'class="' + elementClass +'"' : '';
        console.log(output);

        for (var i = 0, len = node.childNodes.length; i < len; i += 1) {
            var child = node.childNodes[i];
            if (child.nodeType === document.ELEMENT_NODE) {
                traverseNode(child, spacing + '  ');
            }
        }
    }
}

console.log("The correct answer is in the console of the browser!");
var selector = ".birds";
traverse(document.querySelector(selector));