$(function () {
    $('#project-list-accordion').accordion({
        animate: {
            duration: 150
        },
        collapsible: true
    });

    $('#create-project-cancel').on('click', function () {
        $('#create-project-pane input').val('');
    });

    $('#task-lists h4').on('click', function () {
        var taskListId = $(this).attr('id');

        $('#center-column').load('/TaskList/Index/' + taskListId, function (responseText, statusText, xhr) {
            if (statusText == 'success') {

            } else if (statusText == 'error') {
                alert('Error: ' + xhr.status + ': ' + xhr.statusText); // TODO: do better
            }
        });
    });
});