const mongoose = require('mongoose');
const extend = require('mongoose-schema-extend');
const EntitySchema = require('../extend/extend.model');
const Schema = mongoose.Schema;

const TaskGroupDisplayOrderSchema = EntitySchema.exptend({
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
