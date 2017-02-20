const mongoose = require('mongoose');
const Schema = mongoose.Schema;

module.exports = function(paths) {
    const schema = new Schema({}, { versionKey: false, timestamps: true });
    schema.add(paths);

    return schema;
};
