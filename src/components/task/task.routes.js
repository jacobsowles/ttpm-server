const apiConfig = require('../../config/api.config');
const EventLogger = require('../../utils/event-logger/event-logger');
const Task = require('../task/task.model');

module.exports = function(app, passport) {
    const routePrefix = apiConfig.apiPrefix + '/tasks';

    app.get(routePrefix + '/', (request, response) => {
        const where =
            request.query.user
                ? {user: request.query.user}
                : undefined;

        Task
            .find(where)
            .lean()
            .then(tasks => response.json(tasks))
            .catch(error => {
                response.json(error);
            });
    });

    app.get(routePrefix + '/:id', (request, response) => {
        Task
            .findById(request.params.id)
            .lean()
            .then(task => response.json(task))
            .catch(error => {
                response.json(error);
            });
    });

    app.post(routePrefix + '/', (request, response) => {
        new Task(request.body)
            .save()
            .then(task => response.json(task))
            .catch(error => {
                EventLogger.logError(error, 'POST ' + routePrefix + '/', request.body.user);
                response.json(error);
            });
    });
};


