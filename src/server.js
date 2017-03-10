// Modules
const cookieParser = require('cookie-parser');
const bodyParser = require('body-parser');
const mongoose = require('mongoose');
const passport = require('passport');
const express = require('express');
const session = require('express-session');
const morgan = require('morgan');
const flash = require('connect-flash');
const path = require('path');

// Configurations
const dbConfig = require('./config/db.config');
const passportConfig = require('./config/passport.config')(passport);
const sessionConfig = require('./config/session.config');

// General setup
const app = express();

app.set('port', process.env.PORT || 3000);

app.use(morgan('dev'));
app.use(bodyParser.json());
app.use(cookieParser());

// Database
const db = mongoose.connection;
db.on('error', console.error.bind(console, 'connection error:'));

mongoose.Promise = global.Promise;
mongoose.connect(dbConfig.uri, dbConfig.options);

// Session and authentication
app.use(session(sessionConfig));
app.use(passport.initialize());
app.use(passport.session());

// Routes
require('./components/authentication/authentication.routes.js')(app, passport);
require('./components/event/event.routes.js')(app, passport);
require('./components/task/task.routes.js')(app, passport);

// Start server
db.once('open', function() {
    app.listen(app.get('port'), () => {
        console.log(`listening on ${app.get('port')}`);
    });
});

module.exports = app;
