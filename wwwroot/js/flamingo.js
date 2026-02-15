let selectedTime = null;

const guestInput = document.getElementById("guestInput");
const totalPrice = document.getElementById("totalPrice");
const dateSelector = document.getElementById("dateSelector");
const timeContainer = document.getElementById("timeContainer");
const selectedTimeInput = document.getElementById("selectedTimeInput");

// Generate Dates
if (dateSelector) {
    const today = new Date();
    for (let i = 0; i < 10; i++) {
        let d = new Date();
        d.setDate(today.getDate() + i);

        let option = document.createElement("option");
        option.value = d.toISOString().split("T")[0];
        option.textContent = d.toLocaleDateString("ar-SA", {
            weekday: "long",
            day: "numeric",
            month: "long",
            year: "numeric"
        });
        dateSelector.appendChild(option);
    }
}

// Generate Time Slots
const slots = ['07:00 م', '07:30 م', '08:00 م', '08:30 م', '09:00 م', '09:30 م', '10:00 م', '10:30 م', '11:00 م', '11:30 م'];

slots.forEach(slot => {
    const btn = document.createElement("button");
    btn.type = "button";
    btn.className = "border bg-gray-50 py-4 rounded-2xl font-bold";
    btn.innerText = slot;

    btn.onclick = () => {
        document.querySelectorAll("#timeContainer button")
            .forEach(b => b.classList.remove("bg-amber-600", "text-white"));

        btn.classList.add("bg-amber-600", "text-white");
        selectedTime = slot;
        selectedTimeInput.value = slot;
    };

    timeContainer.appendChild(btn);
});

// Change Guests
function changeGuests(val) {
    let current = parseInt(guestInput.value);
    let newVal = current + val;

    if (newVal < 2) newVal = 2;
    if (newVal > 10) newVal = 10;

    guestInput.value = newVal;
    updateTotal();
}

// Update Price
function updateTotal() {
    totalPrice.innerText = guestInput.value * MIN_PRICE;
}

// Prevent Submit Without Time
document.querySelector("form").addEventListener("submit", function (e) {
    if (!selectedTime) {
        e.preventDefault();
        alert("يرجى اختيار وقت الحجز أولاً");
    }
});

// Terms Toggle
document.getElementById("toggleTerms").addEventListener("click", function () {
    document.getElementById("termsContent").classList.toggle("hidden");
});

// Init
updateTotal();
