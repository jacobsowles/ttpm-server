const apiConfig = require('../../config/api.config');
const Event = require('../event/event.model');

module.exports = function(app, passport) {
    const routePrefix = apiConfig.apiPrefix + '/events';

    app.get(routePrefix + '/', function(request, response, next) {
        Event
            .find()
            .lean()
            .then(events => response.send(events));
    });

    app.post(routePrefix + '/', function(request, response, next) {
        new Event(request.body)
            .save()
            .then(event => response.send(event));
    });
};
