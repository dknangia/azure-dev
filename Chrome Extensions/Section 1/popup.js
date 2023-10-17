const timeElement = document.getElementById("time");
const currentTime = new Date().toLocaleTimeString();
timeElement.textContent = `The current time is ${currentTime}`;
const nameElement = document.getElementById("name");

chrome.action.setBadgeText({ text: "TIME" }, () => {
  console.log("Badge text set");
});


chrome.storage.sync.get("name", (data) => {
  if (data.name !== undefined) {
    nameElement.textContent = `Your name is ${data.name}`;
  }
});
