// ===========================
// إعدادات عامة
// ===========================

const pricePerGuest = 100;
let currentGuests = 2;
let selectedTime = null;

// Elements
const dateSelect = document.getElementById("dateSelect");
const timeContainer = document.getElementById("timeSlotsContainer");
const guestDisplay = document.getElementById("guestDisplay");
const guestInput = document.getElementById("guestCountInput");
const totalPriceEl = document.getElementById("totalPrice");
const selectedTimeInput = document.getElementById("selectedTimeInput");
const bookingForm = document.getElementById("bookingForm");


// ===========================
// توليد 10 أيام تلقائي
// ===========================

if (dateSelect) {

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
        option.textContent = formattedText;

        dateSelect.appendChild(option);
    }
}


// ===========================
// توليد الأوقات 9 صباحاً → 1 صباحاً
// ===========================

if (timeContainer) {

    let startHour = 9;
    let endHour = 25; // 1AM

    for (let hour = startHour; hour < endHour; hour++) {

        for (let min of [0, 30]) {

            let displayHour24 = hour % 24;
            let period = displayHour24 >= 12 ? 'م' : 'ص';

            let displayHour12 =
                displayHour24 % 12 === 0 ? 12 : displayHour24 % 12;

            let hh = displayHour12.toString().padStart(2, '0');
            let mm = min.toString().padStart(2, '0');

            let timeText = `${hh}:${mm} ${period}`;

            let btn = document.createElement("button");
            btn.type = "button";
            btn.className =
                "time-slot border rounded-lg py-2 text-sm hover:border-primary hover:text-primary transition font-medium";

            btn.innerText = timeText;

            btn.onclick = function () {
                selectTime(this);
            };

            timeContainer.appendChild(btn);
        }
    }
}


// ===========================
// اختيار الوقت
// ===========================

function selectTime(button) {

    document.querySelectorAll(".time-slot")
        .forEach(b =>
            b.classList.remove("bg-primary", "text-white", "border-primary")
        );

    button.classList.add("bg-primary", "text-white", "border-primary");

    selectedTime = button.innerText;

    if (selectedTimeInput) {
        selectedTimeInput.value = selectedTime;
    }
}


// ===========================
// التحكم بعدد الضيوف
// ===========================

function updatePrice() {
    guestDisplay.innerText = currentGuests;
    guestInput.value = currentGuests;
    totalPriceEl.innerText = currentGuests * pricePerGuest;
}

window.incrementGuest = function () {
    if (currentGuests < 10) {
        currentGuests++;
        updatePrice();
    }
};

window.decrementGuest = function () {
    if (currentGuests > 2) {
        currentGuests--;
        updatePrice();
    }
};


// ===========================
// منع الإرسال بدون وقت
// ===========================

if (bookingForm) {

    bookingForm.addEventListener("submit", function (e) {

        if (!selectedTimeInput.value) {
            e.preventDefault();
            alert("يرجى اختيار وقت الحجز أولاً");
        }
    });
}


// ===========================
// تشغيل أولي
// ===========================

updatePrice();
