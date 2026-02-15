let guests = 1;
let selectedTime = null;

function changeGuests(val) {
    guests += val;
    if (guests < 1) guests = 1;
    if (guests > 10) guests = 10;

    document.getElementById("guestDisplay").innerText = guests;
    document.getElementById("guestInputHidden").value = guests;
    updateTotal();
}

function updateTotal() {
    document.getElementById("totalPrice").innerText = guests * MIN_PRICE;
}

/* =======================
   Generate 10 Days
======================= */

const dateSelect = document.getElementById("dateSelect");
const today = new Date();

for (let i = 0; i < 10; i++) {
    let d = new Date();
    d.setDate(today.getDate() + i);

    let option = document.createElement("option");
    option.value = d.toISOString().split('T')[0];
    option.textContent = d.toLocaleDateString("ar-SA", {
        weekday: 'long',
        day: 'numeric',
        month: 'long',
        year: 'numeric'
    });

    dateSelect.appendChild(option);
}

/* =======================
   Generate Time Slots
======================= */

const container = document.getElementById("timeContainer");

for (let hour = 9; hour < 24; hour++) {
    for (let min of [0, 30]) {

        let period = hour >= 12 ? "م" : "ص";
        let hour12 = hour % 12 === 0 ? 12 : hour % 12;

        let timeText = `${hour12.toString().padStart(2, '0')}:${min === 0 ? "00" : "30"} ${period}`;

        let btn = document.createElement("button");
        btn.type = "button";
        btn.className = "time-btn";
        btn.innerText = timeText;

        btn.onclick = function () {
            document.querySelectorAll(".time-btn").forEach(b => b.classList.remove("active"));
            btn.classList.add("active");
            selectedTime = timeText;
            document.getElementById("selectedTimeInput").value = selectedTime;
        };

        container.appendChild(btn);
    }
}

updateTotal();
