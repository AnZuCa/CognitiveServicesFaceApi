using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
namespace PruebaFaceApi
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] data1, data2, resp1, resp2;
            String url = "https://eastus2.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=true&returnFaceAttributes=age,gender";
            FaceDetectResponse fd1, fd2;
            using (var q = new WebClient())
            {


                q.Headers.Add(HttpRequestHeader.ContentType, "application/octet-stream");
                q.Headers.Add("Ocp-Apim-Subscription-Key", "42995da1c53e42288c2fcda472fc272a");
                data1 = File.ReadAllBytes("C:\\Users\\hp\\Desktop\\Rostro1.jpg");

                resp1 = q.UploadData(url, data1);
                string str1 = Encoding.UTF8.GetString(resp1);
                fd1 = JsonConvert.DeserializeObject<FaceDetectResponse[]>(str1)[0];

            }
            using (var q = new WebClient())
            {
                //Se especifica si se envia un url con Json o un conjunto de bytes, en este caso conjunto de bytes
                q.Headers.Add(HttpRequestHeader.ContentType, "application/octet-stream");
                //Key de Face Api en azure Cognitive services
                q.Headers.Add("Ocp-Apim-Subscription-Key", "42995da1c53e42288c2fcda472fc272a");
                //Localización de la imagen
                data2 = File.ReadAllBytes("C:\\Users\\hp\\Desktop\\Rostro2.jpg");
                //Se envian los datos y se recive la respuesta
                resp2 = q.UploadData(url, data2);
                //Decodificamos los datos en formato UTF8
                String str2 = Encoding.UTF8.GetString(resp2);
                fd2 = JsonConvert.DeserializeObject<FaceDetectResponse[]>(str2)[0];
            }
            using (var q = new WebClient())//verifico si las dos imagenes son la misma persona
            {
                q.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                q.Headers.Add("Ocp-Apim-Subscription-Key", "42995da1c53e42288c2fcda472fc272a");
                url = "https://eastus2.api.cognitive.microsoft.com/face/v1.0/verify";
                string json = "{\"faceId1\":\"" + fd1.FaceId + "\", \"faceId2\":\"" + fd2.FaceId + "\" }";
                String str=q.UploadString(url, json);
                FaceVerifyResponse resp3 = JsonConvert.DeserializeObject<FaceVerifyResponse>(str);

                if (resp3.IsIdentical)
                {
                    Console.WriteLine("Las dos fotos son de la misma persona");
                    Console.WriteLine("Coincidencia en las dos fotos:"+resp3.Confidence);
                }
                else {
                    Console.WriteLine("Las dos fotos son de diferente persona");
                    Console.WriteLine("Coincidencia en las dos fotos:" + resp3.Confidence);
                }

            }
            Console.ReadLine();
            }
    }
}
