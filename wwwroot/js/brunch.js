document.addEventListener("DOMContentLoaded", function () {

    const MIN_CHARGE = 50;
    let selectedTimeBtn = null;

    // =======================
    // توليد 10 أيام
    // =======================

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
        option.textContent = formattedText;
        dateSelect.appendChild(option);
    }

    // =======================
    // توليد الأوقات
    // =======================

    const container = document.getElementById('timeSlotsContainer');

    let startHour = 9;
    let endHour = 25;

    for (let hour = startHour; hour < endHour; hour++) {
        for (let min of [0, 30]) {

            let displayHour24 = hour % 24;
            let period = displayHour24 >= 12 ? 'م' : 'ص';

            let displayHour12 = displayHour24 % 12 === 0 ? 12 : displayHour24 % 12;

            let hh = displayHour12.toString().padStart(2, '0');
            let mm = min.toString().padStart(2, '0');

            let timeText = `${hh}:${mm} ${period}`;

            let btn = document.createElement("button");
            btn.type = "button";
            btn.className = "time-slot border rounded-lg py-2 text-sm transition font-medium";
            btn.innerText = timeText;

            btn.onclick = function () {
                selectTime(this);
            };

            container.appendChild(btn);
        }
    }

    // =======================
    // الضيوف
    // =======================

    window.updateQty = function (val) {
        const input = document.getElementById('guestCount');
        let newVal = parseInt(input.value) - val;

        if (newVal < 1) newVal = 1;
        if (newVal > 10) newVal = 10;

        input.value = newVal;
        updateTotal(newVal);
    };

    function updateTotal(qty) {
        const total = qty * MIN_CHARGE;
        document.getElementById('totalPrice').innerText = total + " ريال";
    }

    window.selectTime = function (btn) {
        if (selectedTimeBtn) {
            selectedTimeBtn.classList.remove('selected');
        }
        btn.classList.add('selected');
        selectedTimeBtn = btn;
        document.getElementById("selectedTimeInput").value = btn.innerText;
    };

    document.getElementById('bookingForm').addEventListener('submit', function (e) {
        if (!selectedTimeBtn) {
            e.preventDefault();
            //alert("يرجى اختيار الوقت أولاً");
        }
    });

});
