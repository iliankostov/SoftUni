<table>
    <thead>
        <tr>
            <td>Name</td>
            <td>Job Title</td>
            <td>Website</td>
        </tr>
    </thead>
    <tbody>
        {{#data}}
        <tr>
            <td>{{name}}</td>
            <td>{{jobTitle}}</td>
            <td><a href="{{& website}}">{{website}}</a></td>
        </tr>
        {{/data}}
    </tbody>
</table>