#include <WiFi.h>    
#define SERVER_PORT 8000    

const int relayPins[4] = {5, 18, 19, 0}; // Adjust as needed. These are the GPIO pins on the ESP32 which connect to the relay board.
const int led = 2;
const char* ssid = "Mark's Wi-Fi Network";       
const char* password = "Princess2010"; 

WiFiServer server(SERVER_PORT);   

void setup() 
{ 
  int i;             
  pinMode(led, OUTPUT);
  for (int i = 0; i < 4; i++) 
  {
    pinMode(relayPins[i], OUTPUT);
    digitalWrite(relayPins[i], LOW); // all off
  }

  Serial.begin(115200);   
  Serial.println("\n\r");
  WiFi.begin(ssid, password); 
  while (WiFi.status() != WL_CONNECTED)  
  { 
    Serial.print("->");
    delay(200);
  }
  Serial.println("");
  Serial.println("WiFi Successfully Connected");   
  Serial.print("NodeMCU IP address: "); 
  Serial.println(WiFi.localIP());     
  server.begin();             
  Serial.println("NodeMCU as a Server Role Started");
  for(i=0;i<5;i++)    
  { 
    Serial.printf("Pass %d\n\r",i);
    digitalWrite(led,HIGH);
    delay(50);
    digitalWrite(led,LOW);
    delay(50);
  }
}

int SetAntenna(int ant)
{
  int i;
  for (i=0;i<4;i++)
     digitalWrite(relayPins[i], LOW); 
  digitalWrite(relayPins[ant],HIGH); 
  return 0;
}  
int GetAntenna()
{
  int i,rv = 0;
  for (i=0;i<4;i++) 
  {
    if (digitalRead(relayPins[i])!=0)
       rv += (1<<i);
  }
  return rv;
}
                    
void loop()
{
  int v;
  WiFiClient client = server.available();   // listen for incoming clients
  if (client) 
  {                                                // if you get a client,
    while (client.connected()) 
    {                  // loop while the client's connected
      if (client.available()) 
      {                           // if there's bytes to read from the client,
        uint8_t data = client.read();  
        Serial.printf("Char Received: %c\r\n",data);
        switch(data) 
        {
          case '1': 
            SetAntenna(0);
            client.println("Antenna 1"); 
            break;
          case '2': 
            SetAntenna(1);
            client.println("Antenna 2"); 
            break;
          case '3':                  
            SetAntenna(2);
            client.println("Antenna 3"); 
            break;
          case '4':                
            SetAntenna(3);
            client.println("Antenna 4"); 
            break;
          case 's':                
            v = GetAntenna();
            client.printf("%x\n\r",v); 
            break;
        }
      }
    }  
    client.stop();
    Serial.println("Client Disconnected.");
  } 
}