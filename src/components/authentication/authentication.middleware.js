const HttpCode = require('../../utils/http-code');

function authenticationMiddleware() {
    return function (request, response, next) {
        if (request.isAuthenticated()) {
            return next();
        }

        response.status(HttpCode.unauthorized).json(response);
    };
}
