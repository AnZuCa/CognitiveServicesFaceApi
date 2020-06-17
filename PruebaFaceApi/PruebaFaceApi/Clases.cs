using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PruebaFaceApi
{
    public class FaceDetectResponse
    {
        public string FaceId { get; set; }
        public FaceAttributes FaceAttributes { get; set; }
        public FaceLandmarks FaceLandmarks { get; set; }
        public FaceRectangle FaceRectangle { get; set; }


    }
    public class FaceRectangle
    {
        public int Height { get; set; }
        public int Left { get; set; }
        public int Top { get; set; }
        public int Width { get; set; }

    }

    public class FaceLandmarks
    {
        public FeatureCoordinate EyebrowLeftInner { get; set; }
        public FeatureCoordinate EyebrowLeftOuter { get; set; }
        public FeatureCoordinate EyebrowRightInner { get; set; }
        public FeatureCoordinate EyebrowRightOuter { get; set; }
        public FeatureCoordinate EyeLeftBottom { get; set; }

        public FeatureCoordinate EyeLeftInner { get; set; }

        public FeatureCoordinate EyeLeftOuter { get; set; }

        public FeatureCoordinate EyeLeftTop { get; set; }
        public FeatureCoordinate EyeRightBottom { get; set; }

        public FeatureCoordinate EyeRightInner { get; set; }
        public FeatureCoordinate EyeRightOuter { get; set; }

        public FeatureCoordinate EyeRightTop { get; set; }
        public FeatureCoordinate MouthLeft { get; set; }
        public FeatureCoordinate MouthRight { get; set; }
        public FeatureCoordinate NoseLeftAlarOutTip { get; set; }
        public FeatureCoordinate NoseLeftAlarTop { get; set; }
        public FeatureCoordinate NoseRightAlarOutTip { get; set; }
        public FeatureCoordinate NoseRightAlarTop { get; set; }
        public FeatureCoordinate NoseRootLeft { get; set; }
        public FeatureCoordinate NoseRootRight { get; set; }
        public FeatureCoordinate NoseTip { get; set; }

        public FeatureCoordinate PupilLeft { get; set; }
        public FeatureCoordinate PupilRight { get; set; }

        public FeatureCoordinate UnderLipBottom { get; set; }

        public FeatureCoordinate UnderLipTop { get; set; }
        public FeatureCoordinate UpperLipBottom { get; set; }
        public FeatureCoordinate UpperLipTop { get; set; }
    }
    public class FeatureCoordinate
    {
        public double X { get; set; }
        public double Y { get; set; }

    }
    public class FaceAttributes
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public Glasses Glasses { get; set; }
        public double Age { get; set; }
        public FacialHair FacialHair { get; set; }
        public string Gender { get; set; }
        public HeadPose HeadPose { get; set; }
        public double Smile { get; set; }

    }
    public enum Glasses
    {
        NoGlasses = 0,
        Sunglasses = 1,
        ReadingGlasses = 2,
        SwimmingGoggles = 3
    }
    public class HeadPose
    {
        public double Pitch { get; set; }
        public double Roll { get; set; }
        public double Yaw { get; set; }

    }
    public class FacialHair
    {
        public double Beard { get; set; }
        public double Moustache { get; set; }
        public double Sideburns { get; set; } //patillas

    }

    public class FaceVerifyResponse
    { 
     public double Confidence { get; set; }
      public bool IsIdentical { get; set; }
    }

}
