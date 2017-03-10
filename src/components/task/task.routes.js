const apiConfig = require('../../config/api.config');
const ErrorGenerator = require('../../utils/error-generator/error-generator');
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
                EventLogger.logError(error, 'GET ' + routePrefix + '/', request.body.user);
                response.json(error);
            });
    });

    app.get(routePrefix + '/:id', (request, response) => {
        Task
            .findById(request.params.id)
            .lean()
            .then(task => response.json(task))
            .catch(error => {
                EventLogger.logError(error, 'GET ' + routePrefix + '/', request.body.user);
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

    app.put(routePrefix + '/:id', (request, response) => {
        if (!request.body.name) {
            response
                .status(400)
                .json(ErrorGenerator.createError('name', 'invalid', 'Name cannot be blank.'));
        }

        Task
            .findByIdAndUpdate(request.params.id, request.body, { new: true })
            .then(task => {
                response.json(task);
            })
            .catch(error => {
                EventLogger.logError(error, 'PUT ' + routePrefix + '/', request.body.user);
                response.json(error);
            });
    });

    app.delete(routePrefix + '/:id', (request, response) => {
        const updatedTask = request.body;
        updatedTask.isDeleted = true;

        Task
            .findByIdAndUpdate(request.params.id, updatedTask, { new: true })
            .then(task => {
                response.json(task);
            })
            .catch(error => {
                EventLogger.logError(error, 'DELETE ' + routePrefix + '/', request.body.user);
                response.json(error);
            });
    });
};


