process.env.NODE_ENV = 'test';

const mongoose = require('mongoose');
const BaseSchema = require('./base.model');
const Base = mongoose.model('Base', new BaseSchema());
const chai = require('chai');
const assert = chai.assert;

describe('Base', () => {
    beforeEach((done) => {
        Base.remove({}, (error) => {
           done();
        });
    });

    it('should have a createdAt timestamp', (done) => {
        new Base().save((error, base) => {
            assert(!!base['createdAt']);
        });
        done();
    });

    it('should have a updatedAt timestamp', (done) => {
        new Base().save((error, base) => {
            assert(!!base['updatedAt']);
        });
        done();
    });

    it('should not have a version number', (done) => {
        new Base().save((error, base) => {
            assert(!base['__v']);
        });
        done();
    });

    it('should record new updateAt on item update', (done) => {
        new Base().save((error, base) => {
            base.update(() => {
                Base.findById(base, (error, updatedBase) => {
                    assert(updatedBase.updatedAt > updatedBase.createdAt);
                });
            });
        });
        done();
    });
});
