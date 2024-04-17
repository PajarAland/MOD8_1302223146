using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

public class Program
{
    public static void Main(string[] args)
    {

        CovidConfig Konfig = new CovidConfig();


        Console.WriteLine("Please insert the amount of money to transfer: " + Konfig.configuration.lang);
        String inputLang = Console.ReadLine();

        Konfig.UbahBahasa();
        Console.WriteLine();

        Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
        int inputJumlahTF = Convert.ToInt32(Console.ReadLine());

        if (inputLang == "en")
        {
            if (inputJumlahTF > Konfig.configuration.threshold)
            {
                Console.WriteLine("Transfer Fee: " + Konfig.configuration.high_fee);
                Console.WriteLine("Total Amount: " + (Konfig.configuration.high_fee + inputJumlahTF));
            }
            else
            {
                Console.WriteLine("Transfer Fee: " + Konfig.configuration.low_fee);
                Console.WriteLine("Total Amount: " + (Konfig.configuration.low_fee + inputJumlahTF));
            }
        }
        else if (inputLang == "id")
        {
            Console.WriteLine("Biaya Transfer: " + Konfig.configuration.high_fee);
            Console.WriteLine("Total Biaya: " + (Konfig.configuration.high_fee + inputJumlahTF));
        }
        else
        {
            Console.WriteLine("Biaya Transfer: " + Konfig.configuration.low_fee);
            Console.WriteLine("Total Biaya: " + (Konfig.configuration.low_fee + inputJumlahTF));
        }

        Console.WriteLine("Select transfer method: " + Konfig.configuration.methods);
        double inputTFMethod = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Pilih metode transfer: " + Konfig.configuration.methods);
        double inputMethodTF = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Please type " + Konfig.configuration.confirmation + "to confirm the transaction: ");
        double inputConfirmation = Convert.ToDouble(Console.ReadLine());


        if (Konfig.configuration.lang == "en")
        {
            if (Konfig.configuration.confirmation == "yes")
            {
                Console.WriteLine("The transfer is completed");
            }
            else
            {
                Console.WriteLine("The transfer is cancelled");
            }
        }
        else if (Konfig.configuration.lang == "id")
        {
            if (Konfig.configuration.confirmation == "ya")
            {
                Console.WriteLine("Proses transfer berhasil");
            }
            else
            {
                Console.WriteLine("Transfer dibatalkan");

            }
        }      
    }
    public class Config
    {

        public string lang { get; set; }
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }
        public string methods { get; set; }
        public string confirmation { get; set; }


        public Config() { }


        public Config(string lang, int threshold, int low_fee, int high_fee, string methods)
        {
            lang = bahasa;
            threshold = batasan;
            low_fee = feeRendah;
            methods = metoda;

            
        }
    }


    public class CovidConfig
    {

        public Config configuration;


        public const string filePath = "C:\\Users\\alienware\\source\\repos\\modul8_1302223146\\modul8_1302223146\\bin\\Debug\\net8.0\\bank_transfer_config.json";


        public CovidConfig()
        {
            try
            {
                ReadConfigFile();
            }
            catch (Exception)
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }


        public void SetDefault()
        {
            configuration = new Config("en", 25000000, 6500, 15000,[ "RTO(real - time)", "SKN", "RTGS", "BI FAST" ], "yes",
                "ya");
        }


        private Config ReadConfigFile()
        {
            String configJsonData = File.ReadAllText(filePath);
            configuration = JsonSerializer.Deserialize<Config>(configJsonData);
            return configuration;
        }


        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(configuration, options);
            File.WriteAllText(filePath, jsonString);
        }


        public void UbahBahasa()
        {
            if (configuration.lang == null)
            {
                configuration.lang = "en";
            }
            else if (configuration.lang == "en")
            {
                configuration.lang = "en";
            }
            else if (configuration.lang == "id")
            {
                configuration.lang = "id";
            }
        }
    }
}