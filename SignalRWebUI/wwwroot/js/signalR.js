// API Hub adresin—gerekirse portu kendine göre değiştir
const hubUrl = "http://localhost:5247/signalrhub";

const connection = new signalR.HubConnectionBuilder()
  .withUrl(hubUrl)               // CORS için API'de AllowCredentials açık olmalı
  .withAutomaticReconnect()
  .configureLogging(signalR.LogLevel.Information)
  .build();

// Sunucudan gelecek event (örnek)
connection.on("ReceiveMessage", (user, message) => {
  console.log("MSG:", user, message);
  // Örn: sayfaya yazdırmak istersen:
  // const ul = document.getElementById("messages");
  // if (ul) ul.insertAdjacentHTML("beforeend", `<li><b>${user}</b>: ${message}</li>`);
});

// Bağlantıyı başlat
async function start() {
  try {
    await connection.start();
    console.log("SignalR connected.");
  } catch (err) {
    console.error("Connect error:", err);
    setTimeout(start, 3000); // 3 sn sonra tekrar dene
  }
}
start();

// (Opsiyonel) Sunucu metodunu tetiklemek için
// connection.invoke("SendMessage", "irem", "hello world").catch(console.error);
