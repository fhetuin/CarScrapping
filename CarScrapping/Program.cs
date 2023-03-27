
using CarScrapping;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SixLabors.ImageSharp.Formats.Jpeg;
using System;
using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using Image = CarScrapping.Image;

class Program
{
    static async Task Main(string[] args)
    {
        await CheckDirectory("temp");
        await CheckDirectory("pdf");
        ResourceManager resMgr = new ResourceManager(typeof(CarInfo));
        while (true)
        {
   

            Console.Write("Entrez un identifiant de voiture : ");
            var carId = Console.ReadLine();
            var car = await GetCarFromApiAsync(carId);
            string token = await RefreshToken();
            Root root = await GetRoot(carId, token);


            await CreateDocument(root, car, resMgr);

        }
    }

    public static async Task CheckDirectory(string name)
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), name);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    public static async Task CreateDocument(Root root, Car car, ResourceManager resMgr)
    {


        string price = string.Empty;
        var p = root.Data.ParameterGroups.SelectMany(p=>p.Parameters);
        string dateMec = string.Empty;
        string gearBox = string.Empty;
        string motor = string.Empty;
        try
        {
            price = (root.Data.Price.Value * 0.090).ToString();
        }
        catch { }
        try
        {
            dateMec = p.Where(p => p.Label.Equals("Datum i trafik")).FirstOrDefault()?.Value;
            string dateString = dateMec.Replace("-", "/");
            DateTime date = DateTime.ParseExact(dateString, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            dateMec = date.ToString("dd/MM/yyyy");
        }
        catch { }
        string fileName = car != null ? $"{Directory.GetCurrentDirectory()}/pdf/{car.Brand}_{car.Model}_{car.GearBox}_{car.Miles}km_{price}.pdf" :

            $"{Directory.GetCurrentDirectory()}/pdf/{root.Data.Subject}.pdf";

            // Create a Document object and set its margins
            Document document = new Document(PageSize.A4, 50, 50, 50, 50);

            // Create a PdfWriter object to write to the stream
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

            // Open the document
            document.Open();

            // Create a table to hold the data
            PdfPTable table = new PdfPTable(1);
            table.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            // Add the image to the first cell of the first row
            PdfPCell cell = new PdfPCell();
            cell.Colspan = 2; 
            cell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            table.AddCell(new Phrase($"{root.Data.Subject}", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)));
        if (car != null) {
            table.AddCell($"Marque: {car?.Brand}");
            table.AddCell($"Modèle: {car?.Model}");
            motor = car?.Carburation;
            gearBox = car?.GearBox;       
            table.AddCell($"Kilométrage : {car?.Miles} km");
   
        }
        else
        {
            motor = p?.Where(p => p.Label.Equals("Bränsle")).FirstOrDefault()?.Value;
            gearBox = p?.Where(p => p.Label.Equals("Växellåda")).FirstOrDefault()?.Value;
            string miles = Regex.Replace(p?.Where(p => p.Label.Equals("Miltal")).FirstOrDefault()?.Value, @"\s+", "");
            table.AddCell($"Kilométrage : {(int.Parse(miles) * 10) } km");
        }

        table.AddCell($"Motorisation: {resMgr.GetString(motor) ?? motor}");
        table.AddCell($"Boite de vitesse : {resMgr.GetString(gearBox) ??gearBox}");
        table.AddCell($"Prix: {price} € varie selon le taux de change SEK/EURO, prix non négocié pour le moment +2500€ \n (Frais de rapatriement inclus + plaques WW valable 4 mois + forfait de courtage)");
        table.AddCell($"Date de mise en circulation :  {(string.IsNullOrEmpty(dateMec) ? p?.Where(p => p.Label.Equals("Modellår")).FirstOrDefault()?.Value : dateMec)}");

        int i = 1;
            foreach (Image img in root.Data.Images)
            {
                string imgUrl = img.Url + ".webp?type=original";
                using (WebClient client = new WebClient())
                {
                    byte[] data = client.DownloadData(imgUrl);
                    using (SixLabors.ImageSharp.Image image = SixLabors.ImageSharp.Image.Load(data))
                    {
                        JpegEncoder encoder = new JpegEncoder();
                        image.Save(Directory.GetCurrentDirectory() + "/temp/image_" + i + ".jpg", encoder);
                        // Create an Image object from the file containing the image
                        iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(Directory.GetCurrentDirectory() + "/temp/image_" + i + ".jpg");
                        table.AddCell(pdfImage);
                    }
                }
                i++;
            }
            // Add the table to the document
            document.Add(table);
        document.Close();
        Console.WriteLine($"le fichier {fileName} a été généré");
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
        return root;
    }
        
    
    public static async Task<Car> GetCarFromApiAsync(string id)
    {
        try
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

            car.Model = basfaktaObject["items"]
                .FirstOrDefault(p => p["label"].ToString() == "Modell")["value"].ToString();



            return car;
        }
        catch
        {
            return null;
        }
    }
    




}
