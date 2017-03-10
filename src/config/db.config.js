module.exports = {
    uri: process.env.NODE_ENV === 'production' ? 'mongodb://jrsowles:IAmN0rse@ds149049.mlab.com:49049/ttpm' : 'mongodb://jrsowles:IAmN0rse@ds153729.mlab.com:53729/ttpm-test',
    options: {
        server: {
            socketOptions: {
                keepAlive: 300000,
                connectTimeoutMS: 30000
            }
        },
        replset: {
            socketOptions: {
                keepAlive: 300000,
                connectTimeoutMS : 30000
            }
        }
    }
};
