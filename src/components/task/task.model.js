const mongoose = require('mongoose');
const BaseSchema = require('../base/base.model');
const Schema = mongoose.Schema;

const TaskSchema = new BaseSchema({
    displayOrder: {
        type: Number,
        default: 0
    },
    displayOrders: [{
        type: Schema.Types.ObjectId,
        ref: 'TaskGroupDisplayOrder'
    }],
    dueDate: Date,
    firstDateCompleted: Date,
    isArchived: {
        type: Boolean,
        default: false
    },
    isComplete: {
        type: Boolean,
        default: false
    },
    isDeleted: {
        type: Boolean,
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
        default: 0
    },
    user: {
        type: Schema.Types.ObjectId,
        required: true,
        ref: 'User'
    }
}, {
    versionKey: false
});

module.exports = mongoose.model('Task', TaskSchema);
