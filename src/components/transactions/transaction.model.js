const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const transactionSchema = new Schema({
    item: {
        type: String,
        required: true
    },
    acquisitionDate: {
        type: Date,
        required: true,
        default: Date.now
    },
    acquisitionPrice: {
        type: Number,
        required: true,
        default: 0
    },
    saleDate: Date,
    salePrice: Number
});

module.exports = mongoose.model('Transaction', transactionSchema);
