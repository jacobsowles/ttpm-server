const mongoose = require('mongoose');
const BaseSchema = require('../base/base.model');
const Schema = mongoose.Schema;

const EventSchema = new BaseSchema({
    details: {
        type: String,
        require: true
    },
    source: {
        type: String,
        required: true
    },
    type: {
        type: String,
        required: true
    },
    user: {
        type: Schema.Types.ObjectId,
        ref: 'User'
    }
});

module.exports = mongoose.model('Event', EventSchema);
