const MIN_PRICE = 100;
let selectedTime = null;

const guestInput = document.getElementById("guestInput");
const totalPrice = document.getElementById("totalPrice");
const dateSelect = document.getElementById("dateSelect");
const timeContainer = document.getElementById("timeSlotsContainer");
const selectedTimeInput = document.getElementById("selectedTimeInput");

function toggleTerms() {
    const content = document.getElementById("termsContent");
    const chevron = document.getElementById("termsChevron");

    content.classList.toggle("hidden");

    chevron.classList.toggle("rotate-180");
}

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

    const slots = [
        '08:00 م', '08:30 م', '09:00 م', '09:30 م',
        '10:00 م', '10:30 م', '11:00 م', '11:30 م',
        '12:00 ص', '12:30 ص'
    ];

    slots.forEach(slot => {

        let btn = document.createElement("button");
        btn.type = "button";
        btn.innerText = slot;
        btn.className = "border py-3 rounded-lg text-sm font-bold";

        btn.onclick = function () {
            selectTime(this);
        };

        timeContainer.appendChild(btn);
    });
}


// =======================
// تغيير عدد الضيوف
// =======================

function changeQty(val) {

    let current = parseInt(guestInput.value);
    let newVal = current + val;

    if (newVal < 2) newVal = 2;
    if (newVal > 10) newVal = 10;

    guestInput.value = newVal;
    updateTotal();
}


// =======================
// تحديث السعر
// =======================

function updateTotal() {
    totalPrice.innerText = guestInput.value * MIN_PRICE;
}


// =======================
// اختيار الوقت
// =======================

function selectTime(btn) {

    document.querySelectorAll("#timeSlotsContainer button")
        .forEach(b => b.classList.remove("bg-amber-600", "text-white"));

    btn.classList.add("bg-amber-600", "text-white");

    selectedTime = btn.innerText;
    selectedTimeInput.value = selectedTime;
}


// =======================
// منع الإرسال بدون وقت
// =======================

document.querySelector("form").addEventListener("submit", function (e) {

    if (!selectedTime) {
        e.preventDefault();
        alert("يرجى اختيار وقت الحجز أولاً");
    }
});


updateTotal();
