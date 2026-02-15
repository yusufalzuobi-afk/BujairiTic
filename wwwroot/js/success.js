let duration = 180;
let timeDisplay = document.getElementById("time");
let progressBar = document.getElementById("progressBar");
let instructionText = document.getElementById("instructionText");

let timer = setInterval(() => {

    duration--;

    let minutes = Math.floor(duration / 60);
    let seconds = duration % 60;

    timeDisplay.textContent =
        (minutes < 10 ? "0" : "") + minutes + ":" +
        (seconds < 10 ? "0" : "") + seconds;

    let progressPercent = (duration / 180) * 100;
    progressBar.style.width = progressPercent + "%";

    if (duration <= 0) {
        clearInterval(timer);
        timeDisplay.textContent = "00:00";
        instructionText.innerHTML =
            "انتهت صلاحية الطلب.<br>يرجى إعادة المحاولة.";
        progressBar.style.background = "#dc2626";
    }

}, 1000);

function cancel() {
    window.history.back();
}
