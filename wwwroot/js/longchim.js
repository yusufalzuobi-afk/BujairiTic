const MIN_PRICE = 50;
let selectedTime = null;

/* =========================
   عدد الضيوف
========================= */
function stepQty(direction) {
    const input = document.getElementById('guestInput');
    let newVal = parseInt(input.value) - direction;

    if (newVal < 2) newVal = 2;
    if (newVal > 6) newVal = 6;

    input.value = newVal;
    updatePrice(newVal);
}

function updatePrice(qty) {
    document.getElementById('totalPrice')
        .innerText = `${qty * MIN_PRICE} ريال`;
}

/* =========================
   توليد 10 أيام
========================= */
const dateSelect = document.getElementById("dateSelect");
const today = new Date();

for (let i = 0; i < 10; i++) {

    let newDate = new Date();
    newDate.setDate(today.getDate() + i);

    let formattedValue = newDate.toISOString().split('T')[0];

    let formattedText = newDate.toLocaleDateString("ar-SA", {
        weekday: 'long',
        day: 'numeric',
        month: 'long',
        year: 'numeric'
    });

    let option = document.createElement("option");
    option.value = formattedValue;
    option.text = formattedText;

    dateSelect.appendChild(option);
}

/* =========================
   توليد الأوقات
========================= */
const container = document.getElementById('timeSlotsContainer');

let startHour = 9;
let endHour = 25;

for (let hour = startHour; hour < endHour; hour++) {

    for (let min of [0, 30]) {

        let displayHour24 = hour % 24;
        let period = displayHour24 >= 12 ? 'م' : 'ص';

        let displayHour12 = displayHour24 % 12 === 0
            ? 12
            : displayHour24 % 12;

        let hh = displayHour12.toString().padStart(2, '0');
        let mm = min.toString().padStart(2, '0');

        let timeText = `${hh}:${mm} ${period}`;

        let btn = document.createElement("button");
        btn.type = "button";
        btn.className = "time-slot text-sm font-medium";
        btn.innerText = timeText;

        btn.onclick = function () {
            selectTime(this);
        };

        container.appendChild(btn);
    }
}

/* =========================
   اختيار الوقت
========================= */
function selectTime(btn) {

    document.querySelectorAll('.time-slot')
        .forEach(b => b.classList.remove('active'));

    btn.classList.add('active');
    selectedTime = btn.innerText;
}

/* =========================
   زر الحجز
========================= */
document.getElementById("bookingForm").addEventListener("submit", function (e) {

    if (!selectedTime) {
        e.preventDefault();
       // alert("يرجى اختيار وقت الحجز");
        return;
    }

    document.getElementById("hiddenGuests").value =
        document.getElementById("guestInput").value;

    document.getElementById("hiddenDate").value =
        document.getElementById("dateSelect").value;

    document.getElementById("hiddenTime").value =
        selectedTime;
});

