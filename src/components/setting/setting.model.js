const mongoose = require('mongoose');
const extend = require('mongoose-schema-extend');
const Schema = mongoose.Schema;
const EntitySchema = require('../entity/entity.model');

const SettingSchema = EntitySchema.extend({
    defaultValue: {
        type: String,
        required: true
    },
    description: String,
    name: {
        type: String,
        required: true
    },
    userSettings: [{
        type: Schema.Types.ObjectId,
        ref: 'UserSetting'
    }]
});

module.exports = mongoose.model('Setting', SettingSchema);
