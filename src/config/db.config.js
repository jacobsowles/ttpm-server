module.exports = {
    uri: 'mongodb://jrsowles:IAmN0rse@ds133398.mlab.com:33398/flipper',
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
