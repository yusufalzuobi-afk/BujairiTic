let currentQty = 0;

const qtyInput = document.getElementById("qtyInput");

function updateQty(delta) {

    const newQty = currentQty + delta;

    if (newQty >= 0 && newQty <= 8) {

        currentQty = newQty;

        document.getElementById("ticketQty").innerText = currentQty;

        qtyInput.value = currentQty;
    }
}


// ================= DATES =================

const dateGrid = document.getElementById("dateGrid");

const today = new Date();

for (let i = 0; i < 7; i++) {

    const d = new Date();

    d.setDate(today.getDate() + i);

    const card = document.createElement("div");

    card.className = "date-card";

    card.innerText = d.toLocaleDateString();

    card.onclick = () => {

        document.getElementById("bookingDateInput").value =
            d.toISOString();

        document.querySelectorAll(".date-card")
            .forEach(x => x.classList.remove("active"));

        card.classList.add("active");
    };

    dateGrid.appendChild(card);
}



// ================= TIMES =================

const timeGrid = document.getElementById("timeGrid");

const times = ["09:00 ص", "05:00 م"];

times.forEach(t => {

    const pill = document.createElement("div");

    pill.className = "time-pill";

    pill.innerText = t;

    pill.onclick = () => {

        document.getElementById("selectedTimeInput").value = t;

        document.querySelectorAll(".time-pill")
            .forEach(x => x.classList.remove("active"));

        pill.classList.add("active");
    };

    timeGrid.appendChild(pill);
});
