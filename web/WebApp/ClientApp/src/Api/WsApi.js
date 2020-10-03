import { setting } from '../setting';
import store from '../store/store';
import axios from 'axios';
import _ from 'lodash';
//import {Notify} from './AreaMensajes';


let capitalizeFirstLetter = function (type) {
    return type.charAt(0).toUpperCase() + type.slice(1);
}

function WsApi() {
    this._defaultOptions = {

    };

};

WsApi.prototype._crypt = function (data) {
    // var doOaepPadding = true;
    // var rsa = new System.Security.Cryptography.RSACryptoServiceProvider();
    // rsa.FromXmlString(AppContext.PublicKey);
    // var rsaParamsPublic = rsa.ExportParameters(false);
    // var decryptedBytes = System.Text.Encoding.UTF8.GetBytes(data);
    // rsa.ImportParameters(rsaParamsPublic);
    // var encryptedBytes = rsa.Encrypt(decryptedBytes, doOaepPadding);
    // return System.Convert.ToBase64String(encryptedBytes);
    return "";
}
WsApi.prototype._parseResult = function (type, data) {
    var me = this;
    switch (type) {
        case 'Grid':
            return me._parseGridResult(data);
        case 'Combos':
            return me._parseCombosResult(data);
        case 'Data':
            return me._parseDataResult(data);
        case 'FullRecord':
            return me._parseFullRecordResult(data);
        default:
            // if (logSeguridad)
            //     Log.error('parsing QUERY result ({0}) INTERNAL ERROR'.format(type));
            throw 'INTERNAL ERROR';
    }
}
WsApi.prototype._parseGridResult = function (data) {
    var rGrid = { ...data };
    delete rGrid.MetaData;
    delete rGrid.Status;
    rGrid.data = rGrid.Data;
    delete rGrid.Data;
    return rGrid;
}
WsApi.prototype._parseDataResult = function (data) {
    return data.Data;
}
WsApi.prototype._parseCombosResult = function (dataset) {
    var me = this;
    var r = {};

    for (var i = 0; i < dataset.Data.length; i++) {
        r[i] = me._convertToKeyPair(dataset.Data[i]);
    }

    return r;
}
WsApi.prototype._parseFullRecordResult = function (dataset) {
    var me = this;
    var r = {};

    for (var i = 0; i < dataset.Data.length; i++) {
        r[i] = me._convertToKeyPair(dataset.Data[i]);
    }

    return r;
}
WsApi.prototype._convertToKeyPair = function (dataset) {
    var columns = dataset.Columns;

    var r = [];
    for (var i = 0; i < dataset.Data.length; i++) {
        var e = {};
        for (var j = 0; j < columns.length; j++) {
            e[columns[j]] = dataset.Data[i][j];
        }
        r.push(e);
    }
    return r;
}
WsApi.prototype._autoTrimStrings = function (dto) {
    for (var p in dto) {
        if (typeof dto[p] === 'string') {
            dto[p] = dto[p].trim();
        }
    }
}
WsApi.prototype.failure = function (err) {
    //AreaMensajes.popupMensajeErrorTecnico('Error en Servidor', err.message);
}

WsApi.prototype._convertToWCFDictionary = function (o) {
    var r = [];

    if (!o) return r;

    for (var e in o) {
        r.push({
            Key: e,
            Value: o[e]
        });
    }
    return r;
}

WsApi.prototype.selfApi = function (controllerName, travel) {
    let { hostClient } = setting.wsApi;
    let { token, Agencia } = store.getState();

    let url = `${hostClient}/api/${controllerName} `;
    let promise = new Promise((resolve, reject) => {

        axios({
            method: 'post',
            url: url,
            data: JSON.stringify(travel),
            headers: {
                "SecurityTokenId": token,
                "Agencia": Agencia,
                'Content-Type': 'application/json; charset=utf-8',
                'Accept': 'application/json; charset=utf-8',
            }
        }).then((response) => {
            let jsonData = JSON.parse(response.data);


            var typeOfStatus = jsonData.Status.substr(0, 2);

            switch (typeOfStatus) {
                case "TE":
                    //                  Log.error('{2} - command {0} ABENDED with issue identifier: {1}', commandName, r.data.MensajeError[0], r.status);
                    //AreaMensajes.popupMensajeErrorTecnico('Error Técnico', 'Número de identificación de incidente: {0} {1}'.format(jsonData.RequestId, r.data.MensajeError[0]));
                    resolve(jsonData.data);
                    break;
                case "FE":
                    //                   Log.debug('{1} - cannot run command {0} because of security privilegdes not granted!', commandName, r.status);
                    // AreaMensajes.popupMensajeErrorFuncional('Error de Validación', 'Código de Error: {0} {1}'.format(jsonData.RequestId, r.data.MensajeError[0]));
                    resolve(jsonData.data);
                    break;
                case "EX":
                    // Log.debug('{1} - command {0} dispatched/ran OK!', commandName, r.status);
                    resolve(jsonData.data);
                    break;
                case "SE": //Session expirada
                    resolve(jsonData.data);
                    // if (logSeguridad)
                    //     Log.debug('{1} - cannot run query {0} because your session has expired!', queryName, r.status);
                    // window.location.href = WebURL + "main";
                    break;
                default:
            }

        }
        ).catch(error => {
            reject(error);
        })
    })

    return promise;


}

WsApi.prototype.execQueryGridHelper = function (queryname, filtros, requiereIdentity) {
    let options = { returnColumnNames: true };
    if (requiereIdentity)
        options.requireIdentityFilter = true;

    let resultWithColumns = [];
    let promise = new Promise(async (resolve, reject) => {

        let result = await this.query(queryname, "Grid", filtros, options);
        for (var i = 0; i < result.Data.length; i++) {
            resultWithColumns.push(_.zipObject(result.ColumnNames, result.Data[i]));
        }


        resolve(resultWithColumns);
    });

    return promise;



}

WsApi.prototype.query = function (queryName, type, filters, options) {
    let me = this;
    let { queryService, hostClient } = setting.wsApi;
    let { token, Agencia } = store.getState();


    let SecurityTokenId = token;
    let url = queryService;
    let clientStartTime;

    options = options ? options : this._defaultOptions;
    filters = filters ? filters : {};

    if (options.includeClientMetrics) {
        clientStartTime = performance.now();
    }

    // if (logSeguridad)
    //     Log.debug('dispatching query {0} to run!', queryName);
    var querye = {};
    var query = {
        Name: queryName,
        Filters: me._convertToWCFDictionary(filters),
        Type: capitalizeFirstLetter(type),
        Options: me._convertToWCFDictionary(options)
    }
    query.$type = "M4Trader.ordenes.mvc." + queryName + ", M4Trader.ordenes.server";

    querye.d = JSON.stringify(query);

    me._autoTrimStrings(querye);

    let promise = new Promise((resolve, reject) => {

        axios({
            method: 'post',
            url: url,
            data: JSON.stringify(querye),
            headers: {
                "SecurityTokenId": token,
                "Agencia": Agencia,
                'Content-Type': 'application/json; charset=utf-8',
                'Accept': 'application/json; charset=utf-8'

            }
        }).then((response) => {
            var r = {};
            let jsonData = JSON.parse(response.data);
            r.data = jsonData.Data; // (*) 
            r.metaData = jsonData.MetaData; // (*) 
            r.status = jsonData.Status; // (*) 


            if (options.includeClientMetrics) {
                var clientEndTime = performance.now();
                r.metaData = r.metaData || {};
                r.metaData.clientMetrics = clientEndTime - clientStartTime;

                // if (logSeguridad)
                //     Log.debug('query round-trip was: {0}ms', r.metaData.clientMetrics);
            }

            var typeOfStatus = jsonData.Status.substr(0, 2);

            switch (typeOfStatus) {
                case "TE":
                    //                  Log.error('{2} - command {0} ABENDED with issue identifier: {1}', commandName, r.data.MensajeError[0], r.status);
                    //AreaMensajes.popupMensajeErrorTecnico('Error Técnico', 'Número de identificación de incidente: {0} {1}'.format(jsonData.RequestId, r.data.MensajeError[0]));
                    resolve(jsonData);
                    break;
                case "FE":
                    //                   Log.debug('{1} - cannot run command {0} because of security privilegdes not granted!', commandName, r.status);
                    // AreaMensajes.popupMensajeErrorFuncional('Error de Validación', 'Código de Error: {0} {1}'.format(jsonData.RequestId, r.data.MensajeError[0]));
                    resolve(jsonData);
                    break;
                case "EX":
                    // Log.debug('{1} - command {0} dispatched/ran OK!', commandName, r.status);
                    // Notify("info");
                    resolve(jsonData);
                    break;
                case "SE": //Session expirada
                    resolve(jsonData);
                    // if (logSeguridad)
                    //     Log.debug('{1} - cannot run query {0} because your session has expired!', queryName, r.status);
                    // window.location.href = WebURL + "main";
                    break;
                default:
            }

        }
        ).catch(error => {
            reject(error);
        })
    })

    return promise;

};


WsApi.prototype.command = function (commandName, args, options) {
    let me = this;
    let { commandService, hostClient } = setting.wsApi;
    let { token, Agencia } = store.getState();
    let command = {};
    let Commnade = {};
    let SecurityTokenId = token;
    let url = commandService;

    options = options ? options : this._defaultOptions;

    if (commandName === "AppContextCommand" || commandName === "LoginCommand" /*|| commandName === "MenuCommand"*/) {
        command.__type = commandName + ':#M4Trader.ordenes.server';
        command = {
            ...command,
            args
        }
    }
    else if (commandName === "AppLiteralesCommand") {
        command.$type = 'M4Trader.ordenes.server.' + commandName + ', M4Trader.ordenes.server';
        command.k = "AppLitCom";
        command.b = true;
        command = {
            ...command,
            ...args
        }
        Commnade.d = JSON.stringify(command);/*GetStringToServer(JSON.stringify(command));*/
        command = Commnade;
    }
    else {
        command.$type = 'M4Trader.ordenes.server.' + commandName + ', M4Trader.ordenes.server';
        //_.assign(command, args);

        command = {
            ...command,
            ...args
        }

        Commnade.d = JSON.stringify(command);/*GetStringToServer(JSON.stringify(command));*/
        command = Commnade;
    }



    let promise = new Promise((resolve, reject) => {

        axios({
            method: 'post',
            url: url,
            data: JSON.stringify(command),
            headers: {
                "SecurityTokenId": token,
                "Agencia": Agencia,
                'Content-Type': 'application/json; charset=utf-8',
                'Accept': 'application/json; charset=utf-8'

            }
        }).then((response) => {
            let jsonData = JSON.parse(response.data);


            var typeOfStatus = jsonData.Status.substr(0, 2);

            switch (typeOfStatus) {
                case "TE":
                    //                  Log.error('{2} - command {0} ABENDED with issue identifier: {1}', commandName, r.data.MensajeError[0], r.status);
                    //AreaMensajes.popupMensajeErrorTecnico('Error Técnico', 'Número de identificación de incidente: {0} {1}'.format(jsonData.RequestId, r.data.MensajeError[0]));
                    resolve(jsonData);
                    break;
                case "FE":
                    //                   Log.debug('{1} - cannot run command {0} because of security privilegdes not granted!', commandName, r.status);
                    // AreaMensajes.popupMensajeErrorFuncional('Error de Validación', 'Código de Error: {0} {1}'.format(jsonData.RequestId, r.data.MensajeError[0]));
                    break;
                case "EX":
                    
                    // Log.debug('{1} - command {0} dispatched/ran OK!', commandName, r.status);
                    resolve(jsonData);
                    break;
                case "SE": //Session expirada
                    resolve(jsonData);
                    // if (logSeguridad)
                    //     Log.debug('{1} - cannot run query {0} because your session has expired!', queryName, r.status);
                    // window.location.href = WebURL + "main";
                    break;
                default:
            }

        }
        ).catch(error => {
            reject(error);
        })
    })

    return promise;

};





let WSApiServer = new WsApi();
export {
    WSApiServer
};
