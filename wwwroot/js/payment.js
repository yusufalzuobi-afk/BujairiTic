const cardNumber = document.getElementById("cardNumber");
const expiry = document.getElementById("expiry");
const cvv = document.getElementById("cvv");
const cardName = document.getElementById("cardName");
const payBtn = document.getElementById("payBtn");

function luhnCheck(val) {
    let sum = 0, shouldDouble = false;
    for (let i = val.length - 1; i >= 0; i--) {
        let digit = parseInt(val.charAt(i));
        if (shouldDouble) { digit *= 2; if (digit > 9) digit -= 9; }
        sum += digit;
        shouldDouble = !shouldDouble;
    }
    return sum % 10 === 0;
}

function validateCard() {
    let value = cardNumber.value.replace(/\s/g, '');
    if (value.length !== 16 || !luhnCheck(value)) {
        cardNumber.classList.add("invalid");
        cardNumber.classList.remove("valid");
        return false;
    }
    cardNumber.classList.remove("invalid");
    cardNumber.classList.add("valid");
    return true;
}

function validateExpiry() {
    let val = expiry.value;
    if (!/^\d{2}\/\d{2}$/.test(val)) return false;
    expiry.classList.add("valid");
    expiry.classList.remove("invalid");
    return true;
}

function validateCVV() {
    if (!/^\d{3}$/.test(cvv.value)) {
        cvv.classList.add("invalid");
        cvv.classList.remove("valid");
        return false;
    }
    cvv.classList.remove("invalid");
    cvv.classList.add("valid");
    return true;
}

function validateName() {
    if (!/^[A-Za-z\s]{3,}$/.test(cardName.value)) {
        cardName.classList.add("invalid");
        cardName.classList.remove("valid");
        return false;
    }
    cardName.classList.remove("invalid");
    cardName.classList.add("valid");
    return true;
}

function checkAll() {
    if (validateCard() && validateExpiry() && validateCVV() && validateName()) {
        payBtn.disabled = false;
        payBtn.classList.add("enabled");
    } else {
        payBtn.disabled = true;
        payBtn.classList.remove("enabled");
    }
}

cardNumber.addEventListener("input", e => {
    let v = e.target.value.replace(/\D/g, '').substring(0, 16);
    v = v.replace(/(.{4})/g, "$1 ").trim();
    e.target.value = v;
    checkAll();
});

expiry.addEventListener("input", e => {
    let v = e.target.value.replace(/\D/g, '').substring(0, 4);
    if (v.length >= 3) v = v.substring(0, 2) + "/" + v.substring(2);
    e.target.value = v;
    checkAll();
});

cvv.addEventListener("input", checkAll);
cardName.addEventListener("input", checkAll);
