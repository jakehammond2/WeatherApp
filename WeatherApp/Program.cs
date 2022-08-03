using Newtonsoft.Json.Linq;

Console.WriteLine("Please enter in a zip code you would like to know the current tempterature of.");
int zipCode = int.Parse(Console.ReadLine()); 

var client = new HttpClient();

var apiResponse = File.ReadAllText("appsettings.json");

var apiKey = JObject.Parse(apiResponse).GetValue("weatherKey"); 

string weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode},US&appid={apiKey}&units=imperial";

var weatherJsonResponse = client.GetStringAsync(weatherURL).Result;    //Connects to Internet

var weatherObject = JObject.Parse(weatherJsonResponse);

double currentTemp = double.Parse(weatherObject["main"]["temp"].ToString());

string currentLocation = weatherObject.GetValue("name").ToString(); 

Console.WriteLine($"The current temperate at {currentLocation} with {zipCode} is {currentTemp}"); 


