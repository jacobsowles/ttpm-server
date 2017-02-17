const mongoose = require('mongoose');
const Schema = mongoose.Schema;

module.exports = function(paths) {
    const schema = new Schema({}, { timestamps: true });
    schema.add(paths);

    return schema;
};
