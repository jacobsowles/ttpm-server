const chai = require('chai');
const should = chai.should();

const Then = class Then {
    end(done) {
        if (done) {
            done();
        }
    }

    response(response) {
        this._response = response;
        return this;
    }

    shouldBeAnArray() {
        this._response.body.should.be.a('array');
        return this;
    }

    shouldBeAnObject() {
        this._response.body.should.be.a('object');
        this._response.body.should.have.property('_id');

        return this;
    }

    shouldBeOk() {
        this._response.should.have.status(200);
        return this;
    }

    shouldHaveError(field, errorType) {
        this._response.body.should.have.property('errors');
        this._response.body.errors.should.have.property(field);
        this._response.body.errors[field].should.have.property('kind').eql(errorType);

        return this;
    }

    shouldReturnFieldRequiredError(field) {
        this.shouldBeOk();
        this.shouldHaveError(field, 'required');

        return this;
    }
};

module.exports = {
    emptyCollection: (done, collection) => {
        collection.remove({}, (error) => {
           done();
        });
    },

    Then
};
