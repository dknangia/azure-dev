const PROXY_CONFIG = [
  {
    context: [
      "/GetWeather",
    
    ],
    target: "https://localhost:40443",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
