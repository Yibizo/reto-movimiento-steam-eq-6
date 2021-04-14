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