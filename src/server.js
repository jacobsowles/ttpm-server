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
const dbConfig = require('./config/db.config.js');
const sessionConfig = require('./config/session.config.js');

// General setup
const root = path.resolve(__dirname + '/../..');
const app = express();

app.use(express.static(root + '/public'));

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
app.use(flash());

// Routes
app.get('/', (request, response) => {
    response.sendFile(root + '/public/index.html');
});

require('./components/authentication/authentication.routes.js')(app, passport);
require('./components/transactions/transaction.routes.js')(app);

// Start server
db.once('open', function() {
    app.listen(3000, () => {
        console.log('listening on 3000');
    });
});
