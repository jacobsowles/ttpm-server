const mongoose = require('mongoose');
const BaseSchema = require('../base/base.model');
const Schema = mongoose.Schema;

const TaskGroupDisplayOrderSchema = new BaseSchema({
    displayOrder: {
        type: Number,
        required: true
    },
    task: {
        type: Schema.Types.ObjectId,
        required: true,
        ref: 'Task'
    },
    taskGroup: {
        type: Schema.Types.ObjectId,
        required: true,
        ref: 'TaskGroup'
    }
});

module.exports = mongoose.model('TaskGroupDisplayOrder', TaskGroupDisplayOrderSchema);
