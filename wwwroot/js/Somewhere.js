document.addEventListener("DOMContentLoaded", function () {

    // =======================
    // إعدادات عامة
    // =======================

    const MIN_PRICE = 100;
    let selectedTime = null;

    const guestInput = document.getElementById("guestInput");
    const totalPrice = document.getElementById("totalPrice");
    const dateSelect = document.getElementById("datePicker");
    const timeContainer = document.getElementById("timeGrid");
    const selectedTimeInput = document.getElementById("selectedTimeInput");


    // =======================
    // تحديث السعر
    // =======================

    function updatePrice() {
        if (!guestInput || !totalPrice) return;

        const qty = parseInt(guestInput.value);
        const total = qty * MIN_PRICE;
        totalPrice.innerText = total + " ريال";
    }


    // =======================
    // التحكم بعدد الضيوف
    // =======================

    window.stepQty = function (direction) {

        if (!guestInput) return;

        let current = parseInt(guestInput.value);
        let newVal = current - direction;

        if (newVal < 1) newVal = 1;
        if (newVal > 10) newVal = 10;

        guestInput.value = newVal;
        updatePrice();
    };


    // =======================
    // توليد 10 أيام
    // =======================

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


    // =======================
    // توليد الأوقات
    // =======================

    if (timeContainer) {

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
                btn.className = "time-slot p-3 rounded-xl text-sm font-bold bg-white border";
                btn.innerText = timeText;

                btn.onclick = function () {
                    selectTime(this);
                };

                timeContainer.appendChild(btn);
            }
        }
    }


    // =======================
    // اختيار الوقت
    // =======================

    function selectTime(btn) {

        document.querySelectorAll(".time-slot")
            .forEach(t => t.classList.remove("active"));

        btn.classList.add("active");

        selectedTime = btn.innerText;

        if (selectedTimeInput) {
            selectedTimeInput.value = selectedTime;
        }
    }


    // =======================
    // منع إرسال الفورم
    // =======================

    const form = document.querySelector("form");

    if (form) {
        form.addEventListener("submit", function (e) {

            if (!selectedTime) {
                e.preventDefault();
                alert("يرجى اختيار وقت الحجز أولاً");
            }
        });
    }


    // =======================
    // تشغيل أولي
    // =======================

    updatePrice();

});
