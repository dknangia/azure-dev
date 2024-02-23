chrome.alarms.create("timer", { periodInMinutes: 1 / 60 });

// chrome.alarms.onAlarm.addListener(function (alarm) {
//   if (alarm.name === "timer") {
//     chrome.storage.local.get(["timer"], function (result) {
//       const time = result.timer ?? 0;
//       chrome.storage.local.set({ timer: time + 1 });
//       chrome.action.setBadgeText({ text: `${time + 1}` });
//     });
//   }
});
