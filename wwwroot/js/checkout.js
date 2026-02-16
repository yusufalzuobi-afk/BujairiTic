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
// ==========================
// PAYMENT CARD SELECTION
// ==========================

document.addEventListener("DOMContentLoaded", function () {

    const cards = document.querySelectorAll(".payment-card");

    cards.forEach(card => {

        const radio = card.querySelector('input[type="radio"]');

        card.addEventListener("click", function () {

            // remove selected from all
            cards.forEach(c => c.classList.remove("selected"));

            // add to clicked
            card.classList.add("selected");

            // check radio
            if (radio) radio.checked = true;

        });

    });

});
