using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ScreenToGif.Interfaces;
using ScreenToGif.Util;

namespace ScreenToGif.Model.ExportPresets.AnimatedImage.Apng
{
    /// <summary>
    /// Apng FFmpeg encoder preset.
    /// ffmpeg -h muxer=apng
    /// ffmpeg -h encoder=apng
    /// </summary>
    public class FfmpegApngPreset : ApngPreset, IFfmpegPreset
    {
        private VideoSettingsMode _settingsMode = VideoSettingsMode.Normal;
        private string _parameters = "-vsync passthrough \n{I} \n-pred mixed \n-plays 0 \n-f apng \n{O}";
        private PredictionMethods _predictionMethods = PredictionMethods.Mixed;
        private VideoPixelFormats _pixelFormat = VideoPixelFormats.RgbA;
        private Framerates _framerate = Framerates.Auto;
        private double _customFramerate = 25d;
        private Vsyncs _vsync = Vsyncs.Passthrough;


        public VideoSettingsMode SettingsMode
        {
            get => _settingsMode;
            set => SetProperty(ref _settingsMode, value);
        }

        [DataMember(EmitDefaultValue = false)]
        public string Parameters
        {
            get => _parameters;
            set => SetProperty(ref _parameters, value);
        }

        public PredictionMethods PredictionMethod
        {
            get => _predictionMethods;
            set => SetProperty(ref _predictionMethods, value);
        }

        public VideoPixelFormats PixelFormat
        {
            get => _pixelFormat;
            set => SetProperty(ref _pixelFormat, value);
        }

        public Framerates Framerate
        {
            get => _framerate;
            set => SetProperty(ref _framerate, value);
        }

        public double CustomFramerate
        {
            get => _customFramerate;
            set => SetProperty(ref _customFramerate, value);
        }

        public Vsyncs Vsync
        {
            get => _vsync;
            set => SetProperty(ref _vsync, value);
        }


        public FfmpegApngPreset()
        {
            Encoder = EncoderType.FFmpeg;
            ImageId = "Vector.Ffmpeg";
            RequiresFfmpeg = true;
        }

        public static List<FfmpegApngPreset> Defaults => new List<FfmpegApngPreset>
        {
            new FfmpegApngPreset
            {
                TitleKey = "S.Preset.Apng.Ffmpeg.High.Title",
                DescriptionKey = "S.Preset.Apng.Ffmpeg.High.Description",
                HasAutoSave = true,
                IsSelectedForEncoder = false,
                IsDefault = true,
                CreationDate = new DateTime(2021, 02, 20)
            },

            new FfmpegApngPreset
            {
                TitleKey = "S.Preset.Apng.Ffmpeg.Low.Title",
                DescriptionKey = "S.Preset.Apng.Ffmpeg.Low.Description",
                HasAutoSave = true,
                IsDefault = true,
                CreationDate = new DateTime(2021, 02, 20),

                PixelFormat = VideoPixelFormats.Rgb8,
                Parameters = "-vsync passthrough \n{I} \n-pred mixed \n-plays 0 \n-pix_fmt rgb8 \n-f apng \n{O}"
            }
        };
    }
}