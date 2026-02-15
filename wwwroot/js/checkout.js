// Countdown
let timeLeft = 600;
const countdownEl = document.getElementById('countdown');

setInterval(() => {
    const minutes = Math.floor(timeLeft / 60);
    const seconds = timeLeft % 60;

    if (countdownEl) {
        countdownEl.innerText =
            minutes.toString().padStart(2, '0') + ":" +
            seconds.toString().padStart(2, '0');
    }

    timeLeft--;
}, 1000);
