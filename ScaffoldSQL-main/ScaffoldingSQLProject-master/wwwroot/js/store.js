const mongoose = require('mongoose');
const Schema = mongoose.Schema;

const dataSchema = new Schema({
    title: {
        requited: true,
        type: String,
    },
    filename: {
        required: true,
        type: String,
    },
    fileID: {
        required: true,
        type: String,
    },
    creationDate: {
        default: Date.now(),
        type: Date,
    },

});

const Data = mongoose.model('Data', dataSchema);
module.exports = Data;