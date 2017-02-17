const apiConfig = require('../../config/api.config');
const EventLogger = require('../../utils/event-logger/event-logger');
const Task = require('../task/task.model');

module.exports = function(app, passport) {
    const routePrefix = apiConfig.apiPrefix + '/tasks';

    app.get(routePrefix + '/', (request, response, next) => {
        Task
            .find()
            .lean()
            .then(tasks => response.send(tasks))
            .catch(error => {
                next(error);
            });
    });

    app.post(routePrefix + '/', (request, response, next) => {
        new Task(request.body)
            .save()
            .then(task => response.send(task))
            .catch(error => {
                EventLogger.logError(error, 'POST ' + routePrefix + '/', request.body.user);
                next(error);
            });
    });
};


