using System;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

namespace Serialization 
{

    public class ImageSerializer
    {
        public static void SerializeImage(string imagePath, string outputFilePath)
        {
            // Read the image file as byte array
            byte[] imageBytes = File.ReadAllBytes(imagePath);

            // create a stream to write the serialized data.
            using (FileStream stream = new FileStream(outputFilePath, FileMode.Open))
            {
                // Create a BinaryFormatter to perform the serialization
                BinaryFormatter formatter = new BinaryFormatter();

                // Serialize the image byte array and write it to the file.
                formatter.Serialize(stream, imageBytes);

            }
            Console.WriteLine("Image serialized and stored in file: " + outputFilePath);

        }
    }


    public class ImageDeserialize
    {
        public static void DeserializeImage(string filePath, string outputImagePath)
        {
            // Create a FileStream to read the serialized data
            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                // Create a BinaryFormatter to perform the deserialization
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the image byte array from the file
                byte[] imageBytes = (byte[])formatter.Deserialize(stream);

                // Write the deserialized image data to the output file
                File.WriteAllBytes(outputImagePath, imageBytes);
            }

            Console.WriteLine("Deserialization is completed Successfully image is Stored in path: " + outputImagePath);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string imagePath = "C:\\DdriveData\\Personal_Data\\New folder\\Image\\pm.jpg";
            string filePath = "C:\\General\\test.txt";

            string serializeImagePath = "C:\\General\\test.txt";
            string outputImagePath = "C:\\DdriveData\\Personal_Data\\New folder\\Image\\deserialized.jpg";


            ImageSerializer.SerializeImage(imagePath, filePath);

            ImageDeserialize.DeserializeImage(serializeImagePath, outputImagePath);

            string jsonString = @"[
            {
                ""name"": ""John"",
                ""age"": 30,
                ""city"": ""New York""
            },
            {
                ""name"": ""Jane"",
                ""age"": 25,
                ""city"": ""London""
            },
            {
                ""name"": ""Tom"",
                ""age"": 35,
                ""city"": ""Paris""
            }
            ]";

            // Deserialize the JSON array
            var jsonArray = JsonConvert.DeserializeObject<dynamic[]>(jsonString);

            foreach (var obj in jsonArray)
            {
                Console.WriteLine($"Name: {obj.name}");
                Console.WriteLine($"Age: {obj.age}");
                Console.WriteLine($"City: {obj.city}");
                Console.WriteLine();
            }




            Console.WriteLine("Hello World!");
            Console.ReadKey();

        }
    }
}