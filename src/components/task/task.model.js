const mongoose = require('mongoose');
const extend = require('mongoose-schema-extend');
const EntitySchema = require('../extend/extend.model');
const Schema = mongoose.Schema;

const TaskSchema = EntitySchema.extend({
    displayOrder: {
        type: Number,
        required: true,
        default: 0
    },
    displayOrders: [{
        type: Schema.Types.ObjectId,
        required: true,
        ref: 'TaskGroupDisplayOrder'
    }],
    dueDate: Date,
    firstDateCompleted: Date,
    isComplete: {
        type: Boolean,
        required: true,
        default: false
    },
    lastDateCompleted: Date,
    name: {
        type: String,
        required: true
    },
    notes: String,
    plannedDate: Date,
    taskGroup: {
        type: Schema.Types.ObjectId,
        ref: 'TaskGroup'
    },
    timesCompleted: {
        type: Number,
        required: true,
        default: 0
    },
    user: {
        type: Schema.Types.ObjectId,
        required: true,
        ref: 'User'
    }
});

module.exports = mongoose.model('Task', TaskSchema);
