
////Initialize SignalR
//var connection = new signalR.HubConnectionBuilder().withUrl('/onlineclienthub').build();
//connection.on('ReciveMessage', renderMessage);

//async function ready() {

//    try {
//        connection.start();

//        await SendUserInformation();

//    } catch (error) {
//        console.error(error);
//    }
//}
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/onlineclienthub")
    .configureLogging(signalR.LogLevel.Information)
    .build();


async function start() {
    try {
        //await connection.start();
        connection.start()
            .then(function () {
                SendUserInformation();
            })
        console.log(id);
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

connection.onclose(async () => {
    await start();
});

// Start the connection.

async function SendUserInformation() {
    try {

        const userinformation = await createjson();

        await connection.invoke('AddOnlineUserAsync',
            ipAddress = userinformation.ipAddress,
            browser = userinformation.browser,
            country = userinformation.country,
            entrydate = userinformation.entrydate,
            os = userinformation.os,
            url = userinformation.url);


    } catch (error) {
        //SendUserInformation();
    }
}
function renderMessage(name, time, message) {
    var nameSpan = document.createElement('span');
    nameSpan.className = 'name';
    nameSpan.textContent = name;

    var timeSpan = document.createElement('span');
    timeSpan.className = 'time';
    var timeFriendly = moment(time).format('H:mm');
    timeSpan.textContent = timeFriendly;

    var headerDiv = document.createElement('div');
    headerDiv.appendChild(nameSpan);
    headerDiv.appendChild(timeSpan);

    var messageDiv = document.createElement('div');
    messageDiv.className = 'message';
    messageDiv.textContent = message;

    var newItem = document.createElement('li');
    newItem.appendChild(headerDiv);
    newItem.appendChild(messageDiv);

    var chatHistory = document.getElementById('chatHistory');
    chatHistory.appendChild(newItem);
    chatHistory.scrollTop = chatHistory.scrollHeight - chatHistory.clientHeight;
}
async function createjson() {
    try {
        const date = new Date().toLocaleString();

        var userinfo = await getCountryInfornationUser();
        const browser = getBrowserName();
        const os = getOSName();
        const obj = { ipAddress: userinfo.data.ipAddress.toString(), browser: browser, country: userinfo.data.countryName + '_' + userinfo.data.city, entrydate: date, os: os, url: window.location.href };
        return obj;
    } catch (error) {
        console.error(error);
    }
}
async function getCountryInfornationUser() {
    try {
        const response = await axios.get('https://api.db-ip.com/v2/free/self');
        //const response = await axios.get('https://ipinfo.io/json');
        //return await JSON.stringify(response.data.ip);
        //return JSON.stringify(response.data.ipAddress, response.data.countryName, response.data.city);
        return response;
    } catch (error) {
        console.error(error);
    }
}
function getBrowserName() {
    if ((navigator.userAgent.indexOf("Opera") || navigator.userAgent.indexOf('OPR')) != -1) {
        return 'Opera';
    } else if (navigator.userAgent.indexOf("Chrome") != -1) {
        return 'Chrome';
    } else if (navigator.userAgent.indexOf("Safari") != -1) {
        return 'Safari';
    } else if (navigator.userAgent.indexOf("Firefox") != -1) {
        return 'Firefox';
    } else if ((navigator.userAgent.indexOf("MSIE") != -1) || (!!document.documentMode == true)) {
        return 'IE';//crap
    } else {
        return 'Unknown';
    }
}
function getOSName() {
    if (navigator.appVersion.indexOf("Win") != -1)
        return "Windows OS";
    if (navigator.appVersion.indexOf("Mac") != -1)
        return "MacOS";
    if (navigator.appVersion.indexOf("X11") != -1)
        return "UNIX OS";
    if (navigator.appVersion.indexOf("Linux") != -1)
        return "Linux OS";
}
function disconnectionhub() {
    connection.stop();
}

start();
//SendUserInformation();
//document.addEventListener('DOMContentLoaded', ready);
