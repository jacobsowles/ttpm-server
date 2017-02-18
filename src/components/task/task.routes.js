const apiConfig = require('../../config/api.config');
const EventLogger = require('../../utils/event-logger/event-logger');
const Task = require('../task/task.model');

module.exports = function(app, passport) {
    const routePrefix = apiConfig.apiPrefix + '/tasks';

    app.get(routePrefix + '/', (request, response) => {
        Task
            .find()
            .lean()
            .then(tasks => response.send(tasks))
            .catch(error => {
                response.send(error);
            });
    });

    app.post(routePrefix + '/', (request, response) => {
        new Task(request.body)
            .save()
            .then(task => response.send(task))
            .catch(error => {
                EventLogger.logError(error, 'POST ' + routePrefix + '/', request.body.user);
                response.send(error);
            });
    });
};


