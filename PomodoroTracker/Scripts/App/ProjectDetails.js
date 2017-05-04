$(document).ready(function () {
    $('#NewTaskForm').on('submit', function (event) {
        event.preventDefault();

        var newProjectTask = {
            Description: $('#NewProjectTaskDescriptionInput').val(),
            EstimatedPomodoroCount: $('#NewProjectTaskEstimatedPomodoroesInput').val(),
            ProjectID: $('#ProjectId').val()

        }
        

        $.post('/api/projecttasksapi', newProjectTask ).done(function (data) {
            console.log(data);
            var newTaskID = data.ProjectTaskID;
            var newTaskEditLink = '<a href="/ProjectTasks/Edit/' + newTaskID + '">Edit</a>';
            var newTaskDetailsLink = '<a href="/ProjectTasks/Details/' + newTaskID + '">Details</a>';
            var newTaskDeleteLink = '<a href="/ProjectTasks/Delete/' + newTaskID + '">Delete</a>';
            $('table tbody').append('<tr><td>' + newProjectTask.Description + '</td><td>' + newProjectTask.EstimatedPomodoroCount + '</td><td>' + newTaskEditLink + ' | ' + newTaskDetailsLink + ' | ' + newTaskDeleteLink + '</td></tr>');
            });

    });
});