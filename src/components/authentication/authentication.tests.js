const User = require('../user/user.model');
const testHelper = require('../../utils/test-helper/test-helper');
const then = new testHelper.Then();
const request = new testHelper.Request();

let validUser;

describe('Authentication', () => {
    beforeEach((done) => {
        validUser = {
            email: 'jrsowles@gmail.com',
            password: 'password1'
        };

        User.remove({}, (error) => {
           done();
        });
    });

    /*
     * Registration
     */

    describe('/POST register', () => {
        it('should register a new user', (done) => {
            request
                .post('/register', validUser)
                .end((error, response) => {
                    then
                        .response(response)
                        .shouldBeOk()
                        .shouldBeABusinessObject()
                        .shouldHaveId()
                        .end(done);
                });
        });

        it('should not register a user if email already in use', (done) => {
            request
                .post('/register', validUser)
                .end((error, response) => {
                    request
                        .post('/register', validUser)
                        .end((error, response2) => {
                            then
                                .response(response2)
                                .shouldBeUnauthorized()
                                .end(done);
                        });
                });
        });

        it('should not register a user if email is blank', (done) => {
            validUser.email = '';
            request
                .post('/register', validUser)
                .end((error, response) => {
                    then
                        .response(response)
                        .shouldBeBadRequest()
                        .end(done);
                });
        });

        it('should not register a user if password is blank', (done) => {
            validUser.password = '';
            request
                .post('/register', validUser)
                .end((error, response) => {
                    then
                        .response(response)
                        .shouldBeBadRequest()
                        .end(done);
                });
        });
    });

    /*
     * Login
     */

    describe('/POST login', () => {
        it('should log in an existing user', (done) => {
            request
                .post('/register', validUser)
                .end((error, response) => {
                    request
                        .post('/login', validUser)
                        .end((error, response2) => {
                            then
                                .response(response2)
                                .shouldBeOk()
                                .shouldBeABusinessObject()
                                .shouldHaveId()
                                .end(done);
                        });
                });
        });

        it('should not log in a user with a blank email', (done) => {
            request
                .post('/register', validUser)
                .end((error, response) => {
                    validUser.email = '';
                    request
                        .post('/login', validUser)
                        .end((error, response2) => {
                            then
                                .response(response2)
                                .shouldBeBadRequest()
                                .end(done);
                        });
                });
        });

        it('should not log in a user with an unknown email', (done) => {
            request
                .post('/login', validUser)
                .end((error, response) => {
                    then
                        .response(response)
                        .shouldBeUnauthorized()
                        .end(done);
                });
        });

        it('should not log in a user with a blank password', (done) => {
            request
                .post('/register', validUser)
                .end((error, response) => {
                    validUser.password = '';
                    request
                        .post('/login', validUser)
                        .end((error, response2) => {
                            then
                                .response(response2)
                                .shouldBeBadRequest()
                                .end(done);
                        });
                });
        });

        it('should not log in a user with an invalid password', (done) => {
            request
                .post('/register', validUser)
                .end((error, response) => {
                    validUser.password = 'wrong password';
                    request
                        .post('/login', validUser)
                        .end((error, response2) => {
                            then
                                .response(response2)
                                .shouldBeUnauthorized()
                                .end(done);
                        });
                });
        });
    });
});
