const mongoose = require('mongoose');
const Schema = mongoose.Schema;
mongoose.Promise = Promise;

module.exports = function(paths) {
    const schema = new Schema({}, { versionKey: false, timestamps: true });

    if (paths) {
        schema.add(paths);
    }

    return schema;
};
