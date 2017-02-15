const moment = require('moment');
const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const EntitySchema = new Schema({
    dateCreated: {
        type: Date,
        required: true
    },
    lastUpdated: Date
});

EntitySchema.methods.create = () => {
    this.dateCreated = moment();
};

EntitySchema.methods.update = () => {
    this.lastUpdated = moment();
};

module.exports = mongoose.model('Entity', EntitySchema);
