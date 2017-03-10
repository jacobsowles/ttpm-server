const apiPrefix = require('../../config/api.config.js').apiPrefix;

module.exports = function(app, passport) {
    app.post(`${apiPrefix}/register`, passport.authenticate('local-signup'), function(request, response) {
        response.json(request.user);
    });

    app.post(`${apiPrefix}/login`, passport.authenticate('local-login'), function(request, response) {
        response.json(request.user);
    });
};
