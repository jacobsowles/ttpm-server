const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const taskSchema = new Schema({
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

module.exports = mongoose.model('Task', taskSchema);
