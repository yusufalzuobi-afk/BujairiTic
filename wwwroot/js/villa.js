const MIN_PRICE = 50;
let guestCount = 1;
let selectedTime = null;

const guestInput = document.getElementById("guestInput");
const totalPrice = document.getElementById("totalPrice");
const dateSelect = document.getElementById("dateSelect");
const timeContainer = document.getElementById("timeSlotsContainer");
const selectedTimeInput = document.getElementById("selectedTimeInput");


// =======================
// توليد 10 أيام
// =======================

if (dateSelect) {

    const today = new Date();

    for (let i = 0; i < 10; i++) {

        let newDate = new Date();
        newDate.setDate(today.getDate() + i);

        let option = document.createElement("option");
        option.value = newDate.toISOString().split('T')[0];

        option.textContent = newDate.toLocaleDateString("ar-SA", {
            weekday: 'long',
            day: 'numeric',
            month: 'long',
            year: 'numeric'
        });

        dateSelect.appendChild(option);
    }
}


// =======================
// توليد الأوقات
// =======================

if (timeContainer) {

    for (let hour = 17; hour <= 23; hour++) {

        for (let min of [0, 30]) {

            let period = hour >= 12 ? 'م' : 'ص';
            let displayHour = hour % 12 === 0 ? 12 : hour % 12;

            let timeText = `${displayHour.toString().padStart(2, '0')}:${min.toString().padStart(2, '0')} ${period}`;

            let btn = document.createElement("button");
            btn.type = "button";
            btn.className = "border py-2 rounded-lg text-sm";
            btn.innerText = timeText;

            btn.onclick = function () {
                selectTime(this);
            };

            timeContainer.appendChild(btn);
        }
    }
}


// =======================
// تغيير عدد الضيوف
// =======================

function changeQty(val) {

    guestCount += val;

    if (guestCount < 1) guestCount = 1;
    if (guestCount > 8) guestCount = 8;

    guestInput.value = guestCount;
    updateTotal();
}


// =======================
// تحديث السعر
// =======================

function updateTotal() {
    totalPrice.innerText = guestCount * MIN_PRICE;
}


// =======================
// اختيار الوقت
// =======================

function selectTime(btn) {

    document.querySelectorAll("#timeSlotsContainer button")
        .forEach(b => b.classList.remove("bg-amber-600", "text-white"));

    btn.classList.add("bg-amber-600", "text-white");

    selectedTime = btn.innerText;

    if (selectedTimeInput) {
        selectedTimeInput.value = selectedTime;
    }
}


// =======================
// منع إرسال بدون وقت
// =======================

document.querySelector("form").addEventListener("submit", function (e) {

    if (!selectedTime) {
        e.preventDefault();
        alert("يرجى اختيار وقت الحجز أولاً");
    }
});

updateTotal();
