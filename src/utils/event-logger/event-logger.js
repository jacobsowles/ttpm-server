const Event = require('../../components/event/event.model');
const EventLogger = {};

EventLogger.logEvent = (details, source, type, user) => {
    if (!['error', 'info', 'warning'].includes(type)) {
        EventLogger.logWarning('Event type ' + type + ' is not valid.', source, 'warning', user);
    }

    new Event({
        details,
        source,
        type,
        user
    }).save();
};

EventLogger.logError = (details, source, user) => {
    EventLogger.logEvent(details, source, 'error', user);
};

EventLogger.logInfo = (details, source, user) => {
    EventLogger.logEvent(details, source, 'info', user);
};

EventLogger.logWarning = (details, source, user) => {
    EventLogger.logEvent(details, source, 'warning', user);
};

module.exports = EventLogger;
