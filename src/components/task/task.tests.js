process.env.NODE_ENV = 'test';

const Task = require('./task.model');
const mongoose = require('mongoose');
const chai = require('chai');
const chaiHttp = require('chai-http');
const server = require('../../server');
const routeBase = require('../../config/api.config').apiPrefix + '/tasks';
const should = chai.should();
const testHelper = require('../../utils/test-helper/test-helper');
const then = testHelper.then;

const validTask = {
    name: 'Test Task',
    user: '58a73fab07404f65cf1ba0f5'
};

chai.use(chaiHttp);

describe('Tasks', () => {
    beforeEach((done) => {
        Task.remove({}, (error) => {
           done();
        });
    });

    describe('/GET tasks', () => {
      it('should GET all the tasks', (done) => {
        chai
            .request(server)
            .get(routeBase + '/')
            .end((error, response) => {
                response.should.have.status(200);
                response.body.should.be.a('array');
                response.body.length.should.be.eql(0);
                done();
            });
        });
    });

    describe('/POST tasks', () => {
        it('should POST a task ', (done) => {
            chai
                .request(server)
                .post(routeBase + '/')
                .send(validTask)
                .end((error, response) => {
                    response.should.have.status(200);
                    response.body.should.be.a('object');
                    response.body.should.have.property('_id');
                    done();
                });
        });

        it('should not POST a task without name field', (done) => {
            const task = validTask;
            task.name = undefined;

            chai
                .request(server)
                .post(routeBase + '/')
                .send(task)
                .end((error, response) => {
                    then.shouldReturnFieldRequiredError(response, 'name');
                    done();
                });
        });
    });
});
