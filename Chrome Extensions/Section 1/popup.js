const timeElement = document.getElementById("time");
const timerElement = document.getElementById("timer");
const currentTime = new Date().toLocaleTimeString();
timeElement.textContent = `The current time is ${currentTime}`;
const nameElement = document.getElementById("name");

function updateTimer(){
  chrome.storage.local.get(["timer"], function (result) { 

    const time = result.timer ?? 0; 

    timerElement.textContent = `You have been on this page for ${time} seconds`;

  }) 

}
updateTimer();
setInterval(updateTimer, 1000);


chrome.storage.sync.get("name", (data) => {
  if (data.name !== undefined) {
    nameElement.textContent = `Your name is ${data.name}`;
  }
});
