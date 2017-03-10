const mongoose = require('mongoose');
const bcrypt = require('bcrypt-nodejs');
const BaseSchema = require('../base/base.model');
const Schema = mongoose.Schema;

const UserSchema = new BaseSchema({
    facebook : {
        id: String,
        token: String,
        email: String,
        name: String
    },
    google: {
        id: String,
        token: String,
        email: String,
        name: String
    },
    local: {
        email: String,
        password: String
    },
    tasks: [{
        type: Schema.Types.ObjectId,
        ref: 'Task'
    }],
    taskGroups: [{
        type: Schema.Types.ObjectId,
        ref: 'TaskGroup'
    }],
    userSettings: [{
        type: Schema.Types.ObjectId,
        ref: 'UserSetting'
    }]
});

UserSchema.methods.generateHash = function(password) {
    return bcrypt.hashSync(password, bcrypt.genSaltSync(8), null);
};

UserSchema.methods.validPassword = function(password) {
    return bcrypt.compareSync(password, this.local.password);
};

module.exports = mongoose.model('User', UserSchema);
