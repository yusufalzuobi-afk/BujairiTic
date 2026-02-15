const otpInputs = document.querySelectorAll(".otp");
const pin = document.getElementById("pin");
const btn = document.getElementById("confirmBtn");
const finalOtp = document.getElementById("finalOtp");

window.onload = () => otpInputs[0].focus();

function checkAll() {
    let otpComplete = [...otpInputs].every(i => i.value.length === 1);
    let pinValid = /^\d{4}$/.test(pin.value);

    if (otpComplete && pinValid) {
        btn.disabled = false;
        btn.classList.add("enabled");
    } else {
        btn.disabled = true;
        btn.classList.remove("enabled");
    }
}

otpInputs.forEach((input, index) => {
    input.addEventListener("input", () => {
        input.value = input.value.replace(/[^0-9]/g, "");

        if (index === 0) {
            input.classList.remove("pulse");
        }

        if (input.value && index < otpInputs.length - 1) {
            otpInputs[index + 1].focus();
        }

        checkAll();
    });

    input.addEventListener("keydown", (e) => {
        if (e.key === "Backspace" && !input.value && index > 0) {
            otpInputs[index - 1].focus();
        }
    });

    input.addEventListener("paste", (e) => e.preventDefault());
});

pin.addEventListener("input", () => {
    pin.value = pin.value.replace(/[^0-9]/g, "").slice(0, 4);
    checkAll();
});

// قبل الإرسال نجمع OTP
document.querySelector("form").addEventListener("submit", () => {
    let otpValue = "";
    otpInputs.forEach(i => otpValue += i.value);
    finalOtp.value = otpValue;
});
