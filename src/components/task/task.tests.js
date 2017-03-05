process.env.NODE_ENV = 'test';

const Task = require('./task.model');
const testHelper = require('../../utils/test-helper/test-helper');
const then = new testHelper.Then();
const request = new testHelper.Request('tasks');

let validTask;

describe('Tasks', () => {
    beforeEach((done) => {
        validTask = {
            name: 'Test Task',
            user: '58a73fab07404f65cf1ba0f5'
        };

        Task.remove({}, (error) => {
           done();
        });
    });

    /*
     * Test item retrieval
     */

    describe('/GET tasks', () => {
        it('should GET all the tasks', (done) => {
            request
                .get('/')
                .end((error, response) => {
                    then
                        .response(response)
                        .shouldBeOk()
                        .shouldBeAnEmptyArray()
                        .end(done);
                });
        });

        it('should GET all tasks for the given user', (done) => {
            new Task(validTask).save((error, task1) => {
                validTask.user = '111111111111';
                new Task(validTask).save((error, task2) => {
                    request
                        .get('?user=' + task1.user)
                        .end((error, response) => {
                            then
                                .response(response)
                                .shouldBeOk()
                                .shouldBeAnArray()
                                .shouldHaveCount(1)
                                .end(done);
                        });
                });
            });
        });
    });

    describe('/GET/:id tasks', () => {
        it('should GET a task with the given id', (done) => {
            new Task(validTask).save((error, task) => {
                request
                    .get('/' + task._id)
                    .end((error, response) => {
                        then
                            .response(response)
                            .shouldBeOk()
                            .shouldBeABusinessObject()
                            .shouldHaveIdOf(task._id)
                            .end(done);
                    });
            });
        });
    });

    /*
     * Test item creation
     */

    describe('/POST tasks', () => {
        it('should POST a task ', (done) => {
            request
                .post('/', validTask)
                .end((error, response) => {
                    then
                        .response(response)
                        .shouldBeOk()
                        .shouldBeABusinessObject()
                        .end(done);
                });
        });

        /*
         * Test default values
         */

        it('should create an incomplete task', (done) => {
            request
                .post('/', validTask)
                .end((error, response) => {
                    then
                        .response(response)
                        .shouldBeOk()
                        .shouldHaveFieldWithValue('isComplete', false)
                        .end(done);
                });
        });

        it('should create an unarchived task', (done) => {
            request
                .post('/', validTask)
                .end((error, response) => {
                    then
                        .response(response)
                        .shouldBeOk()
                        .shouldHaveFieldWithValue('isArchived', false)
                        .end(done);
                });
        });

        it('should create a non-deleted task', (done) => {
            request
                .post('/', validTask)
                .end((error, response) => {
                    then
                        .response(response)
                        .shouldBeOk()
                        .shouldHaveFieldWithValue('isDeleted', false)
                        .end(done);
                });
        });

        it('should create a task with displayOrder 0', (done) => {
            request
                .post('/', validTask)
                .end((error, response) => {
                    then
                        .response(response)
                        .shouldBeOk()
                        .shouldHaveFieldWithValue('displayOrder', 0)
                        .end(done);
                });
        });

        it('should create a task that has never been completed', (done) => {
            request
                .post('/', validTask)
                .end((error, response) => {
                    then
                        .response(response)
                        .shouldBeOk()
                        .shouldHaveFieldWithValue('timesCompleted', 0)
                        .end(done);
                });
        });

        /*
         * Test presence of required fields
         */

        it('should not POST a task without name', (done) => {
            const task = validTask;
            task.name = undefined;

            request
                .post('/', task)
                .end((error, response) => {
                    then
                        .response(response)
                        .shouldBeOk()
                        .shouldReturnFieldRequiredError('name')
                        .end(done);
                });
        });

        it('should not POST a task without user', (done) => {
            const task = validTask;
            task.user = undefined;

            request
                .post('/', task)
                .end((error, response) => {
                    then
                        .response(response)
                        .shouldBeOk()
                        .shouldReturnFieldRequiredError('user')
                        .end(done);
                });
        });
    });

    /*
     * Test item deletion
     */

    describe('/DELETE/:id tasks', () => {
        it('should logically DELETE a task with the given id', (done) => {
            new Task(validTask).save((error, task) => {
                request
                    .delete('/' + task._id, task)
                    .end((error, response) => {
                        then
                            .response(response)
                            .shouldBeOk()
                            .shouldBeABusinessObject()
                            .shouldHaveIdOf(task._id)
                            .shouldHaveFieldWithValue('isDeleted', true)
                            .end(done);
                    });
            });
        });
    });
});
