const mongoose = require('mongoose');
const extend = require('mongoose-schema-extend');
const EntitySchema = require('../extend/extend.model');
const Schema = mongoose.Schema;

const UserSettingSchema = EntitySchema.extend({
    setting : {
        type: Schema.Types.ObjectId,
        required: true,
        ref: 'Setting'
    },
    user: {
        type: Schema.Types.ObjectId,
        required: true,
        ref: 'User'
    },
    value: {
        type: String,
        required: true
    }
});

module.exports = mongoose.model('UserSetting', UserSettingSchema);
