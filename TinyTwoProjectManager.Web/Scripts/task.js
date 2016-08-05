$(function () {
    $(document).on('click', '#task-table .view-mode input[type=text]', function () {
        var row = $(this).closest('tr');
        row.addClass('edit-mode');
        row.removeClass('view-mode');
    });

    $(document).on('click', '#task-table .edit-mode input[type=text]', function () {
        var row = $(this).closest('tr');
        row.addClass('view-mode');
        row.removeClass('edit-mode');
    });

    $(document).on('blur', '#task-table .edit-mode input[type=text]', function () {
        var row = $(this).closest('tr');
        row.addClass('view-mode');
        row.removeClass('edit-mode');

        // TODO: save data
    });

    $(document).on('change', '#task-table input[type=checkbox]', function () {
        var row = $(this).closest('tr');
        this.checked ? row.addClass('task-complete') : row.removeClass('task-complete');
    });
});