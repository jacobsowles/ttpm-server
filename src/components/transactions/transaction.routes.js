const Transaction = require('./transaction.model.js');
const apiConfig = require('../../config/api.config.js');

module.exports = function(app) {
    app.get(`${apiConfig.apiPrefix}/transactions`, (request, response) => {
        Transaction.find({}, (error, transactions) => {
            if (error) {
                response.send(error);
            } else {
                response.send(transactions);
            }
        });
    });

    app.post(`${apiConfig.apiPrefix}/transactions`, (request, response) => {
        const transaction = new Transaction(request.body);

        transaction.save((error) => {
            if (error) {
                response.send(error);
            } else {
                response.send(transaction);
            }
        });
    });
};
