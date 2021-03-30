const slidesContainer = document.getElementById('slides');
const lenImgList = slidesContainer.getElementsByTagName('img').length;
let index = 1;

function prevNextImg(boolCond) {
    let prev;
    if (boolCond) {
        index++;
        if (index > lenImgList) {
            index = 1;
            prev = lenImgList;
        }
        else {
            prev = index-1;
        }
    }
    else {
        index--;
        if (index < 1) {
            index = lenImgList;
            prev = 1;
        }
        else {
            prev = index+1;
        }
    }
    let tempIdx = document.querySelector(`slides img:nth-child(${index})`);
    let tempPrev = document.querySelector(`slides img:nth-child(${prev})`);
    tempPrev.style.opacity = '0';
    tempIdx.style.opacity = '1';
}

function waitNextImg() {
    setInterval(function(){prevNextImg(true);},10000);
}

function test() {
    alert('test');
}