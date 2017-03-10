const LocalStrategy = require('passport-local').Strategy;
const User = require('../components/user/user.model.js');
const ErrorGenerator = require('../utils/error-generator/error-generator');

module.exports = function(passport) {
    passport.serializeUser(function(user, done) {
        done(null, user.id);
    });

    passport.deserializeUser(function(id, done) {
        User.findById(id, function(error, user) {
            done(error, user);
        });
    });

    passport.use(
        'local-signup',
        new LocalStrategy(
            {
                usernameField: 'email',
                passwordField: 'password',
                passReqToCallback: true
            },

            function(request, email, password, done) {
                process.nextTick(function() {
                    User.findOne({ 'local.email': email }, function(error, user) {
                        if (error) {
                            return done(error);
                        }

                        if (user) {
                            return done(null, false, ErrorGenerator.createError('email', 'invalid', 'Email already taken.'));
                        }

                        if (!password) {
                            return done(null, false, ErrorGenerator.createError('password', 'invalid', 'Password cannot be blank.'));
                        }

                        else {
                            const newUser = new User();

                            newUser.local.email = email;
                            newUser.local.password = newUser.generateHash(password);

                            newUser.save(function(error) {
                                if (error) {
                                    throw error;
                                }

                                return done(null, newUser);
                            });
                        }
                    });
                });
            }
        )
    );

    passport.use(
        'local-login',
        new LocalStrategy(
            {
                usernameField: 'email',
                passwordField: 'password',
                passReqToCallback: true
            },

            function(request, email, password, done) {
                User.findOne({ 'local.email': email }, function(error, user) {
                    if (error) {
                        return done(error);
                    }

                    if (!user) {
                        return done(null, false, ErrorGenerator.createError('email', 'invalid', 'Email not found.'));
                    }

                    if (!user.validPassword(password)) {
                        return done(null, false, ErrorGenerator.createError('password', 'invalid', 'Invalid password.'));
                    }

                    return done(null, user);
                });
            }
        )
    );
};
