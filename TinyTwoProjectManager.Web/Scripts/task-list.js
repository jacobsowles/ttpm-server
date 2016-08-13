$(function () {
    $('.task-lists h4').on('click', function (e) {
        e.preventDefault();
        var taskListId = $(this).attr('id');

        $('.task-lists').children('h4').each(function () {
            $(this).removeClass('active-task-list');
        });

        $(this).addClass('active-task-list');

        $.get('/Task/GetTasksForTaskList/', { id: taskListId }, function (data) {
            $('#center-column').html(data);
        });
    });
});