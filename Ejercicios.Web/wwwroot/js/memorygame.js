document.addEventListener("DOMContentLoaded", () => {
    const container = document.getElementById("game");
    if (!container) return;

    const level = parseInt(container.dataset.level);
    const totalPairs = level === 1 ? 4 : level === 2 ? 6 : 8;

    let selectedCards = cards.slice(0, totalPairs);

    let deck = [];
    selectedCards.forEach(c => {
        deck.push({ ...c });
        deck.push({ ...c });
    });

    deck.sort(() => Math.random() - 0.5);

    let firstCard = null;
    let lock = false;
    let moves = 0;
    let matched = 0;

    container.classList.add("memory-grid");
    container.setAttribute("data-level", level);

    deck.forEach((card, index) => {
        let div = document.createElement("div");
        div.className = "memory-card";
        div.dataset.id = index;

        div.innerHTML = `
            <img src="${card.ImagePath}" class="front" />
            <div class="back"></div>
        `;

        container.appendChild(div);
    });

    const cardsDOM = document.querySelectorAll(".memory-card");

    cardsDOM.forEach(cardEl => {
        cardEl.addEventListener("click", () => {
            if (lock || cardEl.classList.contains("matched") || cardEl.classList.contains("flip"))
                return;

            cardEl.classList.add("flip");

            if (!firstCard) {
                firstCard = cardEl;
            } else {
                moves++;
                const secondCard = cardEl;
                lock = true;

                const id1 = firstCard.dataset.id;
                const id2 = secondCard.dataset.id;

                // 🔥 CORRECCIÓN IMPORTANTE
                if (deck[id1].Id === deck[id2].Id) {
                    firstCard.classList.add("matched");
                    secondCard.classList.add("matched");

                    matched++;
                    lock = false;
                    firstCard = null;

                    if (matched === totalPairs) {
                        setTimeout(() => finishGame(moves), 800);
                    }

                } else {
                    setTimeout(() => {
                        firstCard.classList.remove("flip");
                        secondCard.classList.remove("flip");
                        firstCard = null;
                        lock = false;
                    }, 800);
                }
            }
        });
    });

    function finishGame(moves) {
        const timeSeconds = Math.floor(performance.now() / 1000);

        fetch('/MemoryGame/SaveScore', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({
                level: level,
                moves: moves,
                timeSeconds: timeSeconds
            })
        });

        alert("¡Juego completado! Movimientos: " + moves);

        window.location.href = "/MemoryGame/TopScores?level=" + level;
    }
});
