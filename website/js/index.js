const slidesContainer = document.getElementById('slides');
const lenDivList = slidesContainer.getElementsByTagName('div').length;
const vid = document.querySelector('#slides div video');
vid.volume = 0.3;
let index = 1;

function prevNext(isNext) {
    let prev;
    if (isNext) {
        index++;
        if (index > lenDivList) {
            index = 1;
            prev = lenDivList;
        }
        else
            prev = index-1;
    }
    else {
        index--;
        if (index < 1) {
            index = lenDivList;
            prev = 1;
        }
        else
            prev = index+1;
    }
    let tempPrev = document.querySelector(`#slides div:nth-child(${prev})`);
    let tempIdx = document.querySelector(`#slides div:nth-child(${index})`);
    tempPrev.style.opacity = '0';
    tempIdx.style.opacity = '1';
    
    if (vid.parentElement.style.opacity == '0'){
        vid.volume = 0.3;
        vid.style.pointerEvents = 'none';
        vid.pause();
        vid.currentTime = 0;
    }
    else if (vid.parentElement.style.opacity == '1'){
        vid.style.pointerEvents = 'all';
    }
}

function getYPosition(){
    var top  = window.pageYOffset || document.documentElement.scrollTop
    console.log(top);
    return top;
}

async function printUsersLevel() {
    const responseFromServer = await fetch("http://localhost:5000/api/users");
    const userlist = await responseFromServer.json();
    const userListElement = document.getElementById("level-list");
    let temp = null
    if(userlist == temp){return 0}
    else{
        userListElement.innerHTML = "";
        for(let i = 0; i < userlist.length; i++){
            const userElement = document.createElement("li")
            userElement.className = "user"

            const idElement = document.createElement("span");
            idElement.innerText = "UserID: " + userlist[i].user_id + " |";
            const levelElement = document.createElement("span");
            levelElement.innerText = " Level: " + userlist[i].level + " |";
            /*const areaElement = document.createElement("span");
            areaElement.innerText = " Area_ID: " + userlist[i].area_id + " |";
            const PA1Element = document.createElement("span");
            PA1Element.innerText = " Problems_Area1: " + userlist[i].problems_a1 + " |";
            const PA2Element = document.createElement("span");
            PA2Element.innerText = " Problems_Area2: " + userlist[i].problems_a2 + " |";
            const PA3Element = document.createElement("span");
            PA3Element.innerText = " Problems_Area3: " + userlist[i].problems_a3 + " |";*/
    
            userElement.appendChild(idElement);
            userElement.appendChild(levelElement);
            /*userElement.appendChild(areaElement);
            userElement.appendChild(PA1Element);
            userElement.appendChild(PA2Element);
            userElement.appendChild(PA3Element);*/

            userListElement.appendChild(userElement);
        } }
        temp = userlist
}

async function printUsersArea() {
    const responseFromServer = await fetch("http://localhost:5000/api/users");
    const userlist = await responseFromServer.json();
    const userListElement = document.getElementById("area-list");
    let temp = null
    if(userlist == temp){return 0}
    else{
        userListElement.innerHTML = "";
        for(let i = 0; i < userlist.length; i++){
            const userElement = document.createElement("li")
            userElement.className = "user"

            const idElement = document.createElement("span");
            idElement.innerText = "UserID: " + userlist[i].user_id + " |";
            /*const levelElement = document.createElement("span");
            levelElement.innerText = " Level: " + userlist[i].level + " |";*/
            const areaElement = document.createElement("span");
            areaElement.innerText = " Area_ID: " + userlist[i].area_id + " |";
            /*const PA1Element = document.createElement("span");
            PA1Element.innerText = " Problems_Area1: " + userlist[i].problems_a1 + " |";
            const PA2Element = document.createElement("span");
            PA2Element.innerText = " Problems_Area2: " + userlist[i].problems_a2 + " |";
            const PA3Element = document.createElement("span");
            PA3Element.innerText = " Problems_Area3: " + userlist[i].problems_a3 + " |";*/
    
            userElement.appendChild(idElement);
            /*userElement.appendChild(levelElement);*/
            userElement.appendChild(areaElement);
            /*userElement.appendChild(PA1Element);
            userElement.appendChild(PA2Element);
            userElement.appendChild(PA3Element);*/

            userListElement.appendChild(userElement);
        } }
        temp = userlist
}

async function printUsersProblem() {
    const responseFromServer = await fetch("http://localhost:5000/api/users");
    const userlist = await responseFromServer.json();
    const userListElement = document.getElementById("problem-list");
    let temp = null
    if(userlist == temp){return 0}
    else{
        userListElement.innerHTML = "";
        for(let i = 0; i < userlist.length; i++){
            const userElement = document.createElement("li")
            userElement.className = "user"

            const idElement = document.createElement("span");
            idElement.innerText = "UserID: " + userlist[i].user_id + " |";
            /*const levelElement = document.createElement("span");
            levelElement.innerText = " Level: " + userlist[i].level + " |";
            const areaElement = document.createElement("span");
            areaElement.innerText = " Area_ID: " + userlist[i].area_id + " |";*/
            const PA1Element = document.createElement("span");
            PA1Element.innerText = " Problems_Area1: " + userlist[i].problems_a1 + " |";
            const PA2Element = document.createElement("span");
            PA2Element.innerText = " Problems_Area2: " + userlist[i].problems_a2 + " |";
            const PA3Element = document.createElement("span");
            PA3Element.innerText = " Problems_Area3: " + userlist[i].problems_a3 + " |";
    
            userElement.appendChild(idElement);
            /*userElement.appendChild(levelElement);
            userElement.appendChild(areaElement);*/
            userElement.appendChild(PA1Element);
            userElement.appendChild(PA2Element);
            userElement.appendChild(PA3Element);

            userListElement.appendChild(userElement);
        } }
        temp = userlist
}