$(function () {
    $('.task-lists h4').on('click', function (evt) {
        evt.preventDefault();
        var taskListId = $(this).attr('id');

        $.get('/Task/GetTasksForTaskList/', { id: taskListId }, function (data) {
            $('#center-column').html(data);
        });
    });
});