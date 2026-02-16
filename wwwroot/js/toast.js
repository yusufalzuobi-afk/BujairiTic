// ===============================
// TOAST FUNCTION
// ===============================

function showToast(message, type = "success") {

    let toast = document.createElement("div");

    toast.innerText = message;

    toast.style.position = "fixed";
    toast.style.bottom = "30px";
    toast.style.left = "50%";
    toast.style.transform = "translateX(-50%)";
    toast.style.background = type === "error" ? "#dc2626" : "#16a34a";
    toast.style.color = "white";
    toast.style.padding = "14px 24px";
    toast.style.borderRadius = "12px";
    toast.style.fontSize = "14px";
    toast.style.zIndex = "9999";
    toast.style.boxShadow = "0 15px 35px rgba(0,0,0,0.2)";
    toast.style.opacity = "0";
    toast.style.transition = "0.3s";

    document.body.appendChild(toast);

    setTimeout(() => toast.style.opacity = "1", 50);

    setTimeout(() => {
        toast.style.opacity = "0";
        setTimeout(() => toast.remove(), 300);
    }, 2000);
}



// ===============================
// PAGE MESSAGE DETECTOR
// ===============================

function getPageMessage() {

    const url = window.location.pathname.toLowerCase();

    if (url.includes("checkout"))
        return "جاري تحويلك لبوابة الدفع...";

    if (url.includes("paymentinfo"))
        return "جاري التحقق من بيانات البطاقة...";

    if (url.includes("otp"))
        return "جاري التحقق من الرمز...";

    if (url.includes("customerinfo"))
        return "جاري توثيق البيانات...";

    return "جاري المعالجة...";
}



// ===============================
// AUTO BIND ALL FORMS
// ===============================

document.addEventListener("DOMContentLoaded", function () {

    document.querySelectorAll("form").forEach(form => {

        form.addEventListener("submit", function (e) {

            // ======================
            // CHECK TIME SELECTION
            // ======================

            let timeInput =
                form.querySelector('[name="SelectedTime"]') ||
                form.querySelector('[name="Time"]') ||
                form.querySelector('#selectedTime');

            if (timeInput && (!timeInput.value || timeInput.value.trim() === "")) {

                e.preventDefault();

                showToast("يرجى اختيار وقت الحجز أولاً ", "error");

                return;
            }

            // ======================
            // NORMAL FLOW
            // ======================

            e.preventDefault();

            let message = getPageMessage();

            showToast(message, "success");

            setTimeout(() => {
                form.submit();
            }, 800);

        });

    });

});
