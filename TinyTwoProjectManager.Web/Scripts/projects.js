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

    $('.task-lists h4').on('click', function (evt) {
        evt.preventDefault();
        var taskListId = $(this).attr('id');

        $.get('/Task/GetTasksForTaskList/', { id: taskListId }, function (data) {
            $('#center-column').html(data);
        });
    });
});