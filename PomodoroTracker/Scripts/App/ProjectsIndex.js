$(document).ready(function () {
    $('#NewProjectForm').on('submit', function (event) {
        event.preventDefault();
        //Get the value from #NewProjectDescriptionInput
        var newProjectDescription = $('#NewProjectDescriptionInput').val();
        //Post the new description to our API
        $.post('/api/projectsapi', { Description: newProjectDescription })
            .done(function (data) {
                var newProjectID = data.ProjectID;
                var newProjectEditLink = '<a href="/Projects/Edit/' + newProjectID + '">Edit</a>';
                var newProjectDetailsLink = '<a href="/Projects/Details/' + newProjectID + '">Details</a>';
                var newProjectDeleteLink = '<a href="/Projects/Edit/' + newProjectID + '">Delete</a>';

                $('table tbody').append('<tr><td>' + newProjectDescription + '</td><td>' + newProjectEditLink + ' | ' + newProjectDetailsLink + ' | ' + newProjectDeleteLink + '</td></tr>');
                $('#NewProjectDescriptionInput').val('');
                console.log(data);

            });
    });

});