const express = require('express');
const dataRouter = express.Router();
const mongoose = require('mongoose');
const Data = require('../js/store');
const uri = require('../js/URI');

module.exports = (upload) => {
    const url = uri.mongoURI;
    const connect = mongoose.createConnection(url, { useNewUrlParser: true, useUnifiedTopology: true });
    let gFS;
    connect.once('open', () => {
        gFS = new mongoose.mongo.GridFSBucket(connect.db, {
            bucketTitle: "uploads"
        });
    });

    dataRouter.route('/').post(upload.single('file'), (req, res, next) => {
        console.log(req.body);
        Data.findOne({ title: req.body.title }).then((file) => {
            console.log(file);
            if(file){
                return res.status(200).json({
                    success: false,
                    message: 'File already exists',
                });
            }
            let newFile = new Data({
                title: req.body.title,
                filename: req.file.filename,
                fileID: req.file.id,
            });
            newFile.save().then((file) => {
                res.status(200).json({
                    success: true,
                    file,
                });
            }).catch(err => res.status(500).json(err));
        }).catch(err => res.status(500).json(err));
    }).get((req, res, next) => {
        Data.find({}).then(files => {
            res.status(200).json({
                success: true,
                files,
            });
        }).catch(err => res.status(500).json(err));
    });

    dataRouter.route('/delete/:id').get((req, res, next) => {
        Data.findOne({ _id: req.params.id }).then((file) => {
            if(file){
                Data.deleteOne({ _id: req.params.id }).then(() => {
                    return res.status(200).json({
                        success: true,
                        message: `File with ID: ${req.params.id} deleted`,
                    });
                }).catch(err => { return res.status(500).json(err) });
            } else{
                res.status(200).json({
                    success: false,
                    message: `File with ID: ${req.params.id} not found`,
                });
            }
        }).catch(err => res.status(500).json(err));
    });

    dataRouter.route('/recent').get((req, res, next) => {
        Data.findOne({}, {}, { sort: { '_id': -1 } }).then((file) => {
            res.status(200).json({
                success: true,
                file,
            });
        }).catch(err => res.status(500).json(err));
    });

    dataRouter.route('/multiple').post(upload.array('file', 3), (req, res, next) => {
        res.status(200).json({
            success: true,
            message: `${req.files.length} files uploaded successfully`,
        });
    });

    dataRouter.route('/files').get((req, res, next) => {
        gFS.find().toArray((err, files) => {
            if(!files || files.length === 0){
                return res.status(200).json({
                    success: false,
                    message: 'No files available',
                });
            }
            files.map(file => {
                if(file.contentType === 'json'){
                    file.isDoc = true;
                } else{
                    file.isDoc = false;
                }
            });
            res.status(200).json({
                success: true,
                files,
            });
        });
    });

    dataRouter.route('/file/:filename').get((req, res, next) => {
        gFS.find({ filename: req.params.filename }).toArray((err, files) => {
            if(!files[0] || files.length === 0){
                return res.status(200).json({
                    success: false,
                    message: 'No files available',
                });
            }
            res.status(200).json({
                success: true,
                file: files[0],
            });
        });
    });

    dataRouter.route('/file/del/:id').post((req, res, next) => {
        console.log(req.params.id);
        gFS.delete(new mongoose.Types.ObjectId(req.params.id), (err, data) => {
            if(err){
                return res.status(404).json({ err: err });
            }
            res.status(200).json({
                success: true,
                message: `File with ID ${req.params.id} was deleted`
            });
        });
    });

    return dataRouter;
};