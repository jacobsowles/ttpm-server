const apiConfig = require('../../config/api.config.js');

module.exports = function(app, passport) {
    app.post(`${apiConfig.apiPrefix}/signup`, passport.authenticate('local-signup', {
        successRedirect: '/',
        failureRedirect: '/signup',
        failureFlash: true
    }));

    app.post(`${apiConfig.apiPrefix}/login`, passport.authenticate('local-login', {
        successRedirect: '/',
        failureRedirect: '/login',
        failureFlash: true
    }));
};
