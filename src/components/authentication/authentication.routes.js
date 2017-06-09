const apiPrefix = require('../../config/api.config.js').apiPrefix;
const HttpCode = require('../../utils/http-code');

module.exports = function(app, passport) {
    app.get(`${apiPrefix}/isLoggedIn`, function(request, response) {
        response.json(request.isAuthenticated());
    });

    app.get(`${apiPrefix}/logout`, function(request, response) {
        request.logout();
        response.status(HttpCode.ok);
    });

    app.post(`${apiPrefix}/register`, passport.authenticate('local-signup'), function(request, response) {
        response.json(request.user);
    });

    app.post(`${apiPrefix}/login`, passport.authenticate('local-login'), function(request, response) {
        response.json(request.user);
    });
};
