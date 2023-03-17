
using CarScrapping;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Enter car ID: ");
        var carId = Console.ReadLine();
        var car = await GetCarFromApiAsync(carId);

        Console.WriteLine($"Title: {car.Title}");
        Console.WriteLine($"Brand: {car.Brand}");
        Console.WriteLine($"Carburation: {car.Carburation}");
        Console.WriteLine($"GearBox: {car.GearBox}");
        Console.WriteLine($"Miles: {car.Miles}");
        Console.WriteLine($"Model: {car.Model}");
        string token = await RefreshToken();
        Root root = await GetRoot(carId, token);
        Thread.Sleep(5000000);
    }

    public static async Task<string> RefreshToken()
    {
        string url = $"https://www.blocket.se/api/adout-api-route/refresh-token-and-validate-session";
        string jsonString = await Request.GetResultRequest(url);
        JObject jsonData = JObject.Parse(jsonString);
        return jsonData["bearerToken"].ToString();
    }
    
    public static async Task<Root> GetRoot(string id, string token)
    {
        string url = $"https://api.blocket.se/search_bff/v2/content/{id}?include=store";
        string jsonString = await Request.GetResultRequest(url, token);
        Root root = JsonConvert.DeserializeObject<Root>(jsonString);
        List<Image> images = root.Data.Images;
        foreach(Image img in images)
        {
            Console.WriteLine(img.Url);
        }
        Console.WriteLine(root.Data.Subject);
        return root;
    }
        
    
    public static async Task<Car> GetCarFromApiAsync(string id)
    {
        using HttpClient client = new HttpClient();
        string url = $"https://api.blocket.se/motor-query-service/v1/view/legacy/{id}";
        string jsonString = await Request.GetResultRequest(url);
        JObject jsonData = JObject.Parse(jsonString);

        JArray tsDataArray = (JArray)jsonData["tsData"];

        JObject basfaktaObject = tsDataArray.Children<JObject>()
            .FirstOrDefault(o => o["label"].ToString() == "Basfakta");

        Car car = new Car();
        car.Title = basfaktaObject["items"]
            .FirstOrDefault(p => p["label"].ToString() == "Märke")["value"].ToString();

        car.Brand = basfaktaObject["items"]
            .FirstOrDefault(p => p["label"].ToString() == "Märke")["value"].ToString();

        car.Carburation = basfaktaObject["items"]
            .FirstOrDefault(p => p["label"].ToString() == "Drivmedel")["value"].ToString();

        car.GearBox = basfaktaObject["items"]
            .FirstOrDefault(p => p["label"].ToString() == "Växellåda")["value"].ToString();

        car.Miles = basfaktaObject["items"]
            .FirstOrDefault(p => p["label"].ToString() == "Mätarställning")["value"].ToString();

        car.Model = basfaktaObject["items"]
            .FirstOrDefault(p => p["label"].ToString() == "Modell")["value"].ToString();

        return car;
    }
    




}
