const chai = require('chai');
const chaiHttp = require('chai-http');
const server = require('../../server');
const apiConfig = require('../../config/api.config');
const should = chai.should();

chai.use(chaiHttp);

const Request = class Request {
    constructor(baseRoute) {
        this.baseRoute = apiConfig.apiPrefix + '/' + baseRoute;
        this.request = chai.request(server);
    }

    get(route) {
        return this.makeRequest(this.request.get, route);
    }

    makeRequest(verb, route, body) {
        route = route || '';
        let request = verb(this.baseRoute + route);

        if (body) {
            request = request.send(body);
        }

        return request;
    }

    post(route, body) {
        return this.makeRequest(this.request.post, route, body);
    }
};

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

    shouldBeABusinessObject() {
        this
            .shouldBeAnObject()
            ._response.body.should.have.property('_id');

        return this;
    }

    shouldBeAnArray() {
        this._response.body.should.be.a('array');
        return this;
    }

    shouldBeAnEmptyArray() {
        this
            .shouldBeAnArray()
            ._response.body.length.should.be.eql(0);

        return this;
    }

    shouldBeAnObject() {
        this._response.body.should.be.a('object');
        return this;
    }

    shouldBeOk() {
        this._response.should.have.status(200);
        return this;
    }

    shouldHaveError(field, errorType) {
        this.shouldBeAnObject()
        this._response.body.should.have.property('errors')
        this._response.body.errors.should.have.property(field)
        this._response.body.errors[field].should.have.property('kind').eql(errorType);

        return this;
    }

    shouldReturnFieldRequiredError(field) {
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

    Request,
    Then
};
