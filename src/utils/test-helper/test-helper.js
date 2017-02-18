const chai = require('chai');
const should = chai.should();

module.exports = {
    emptyCollection: (done, collection) => {
        collection.remove({}, (error) => {
           done();
        });
    },

    then: {
        shouldReturnFieldRequiredError: (response, field) => {
            response.should.have.status(200);
            response.body.should.be.a('object');
            response.body.should.have.property('errors');
            response.body.errors.should.have.property(field);
            response.body.errors[field].should.have.property('kind').eql('required');
        }
    }
};
