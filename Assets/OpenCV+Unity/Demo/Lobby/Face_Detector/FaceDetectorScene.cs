﻿namespace OpenCvSharp.Demo
{
    using System;
    using UnityEngine;
    using System.Collections.Generic;
    using UnityEngine.UI;
    using OpenCvSharp;
    using System.Diagnostics;

    public class FaceDetectorScene : WebCamera
    {
        public TextAsset faces;
        public TextAsset eyes;
        public TextAsset shapes;
        public int text_x;
        public int text_y;


        private FaceProcessorLive<WebCamTexture> processor;

        /// <summary>
        /// Default initializer for MonoBehavior sub-classes
        /// </summary>
        protected override void Awake()
        {
            base.Awake();
            base.forceFrontalCamera = true; // we work with frontal cams here, let's force it for macOS s MacBook doesn't state frontal cam correctly

            byte[] shapeDat = shapes.bytes;
            if (shapeDat.Length == 0)
            {
                string errorMessage =
                    "In order to have Face Landmarks working you must download special pre-trained shape predictor " +
                    "available for free via DLib library website and replace a placeholder file located at " +
                    "\"OpenCV+Unity/Assets/Resources/shape_predictor_68_face_landmarks.bytes\"\n\n" +
                    "Without shape predictor demo will only detect face rects.";

#if UNITY_EDITOR
                // query user to download the proper shape predictor
                if (UnityEditor.EditorUtility.DisplayDialog("Shape predictor data missing", errorMessage, "Download", "OK, process with face rects only"))
                    Application.OpenURL("http://dlib.net/files/shape_predictor_68_face_landmarks.dat.bz2");
#else
             UnityEngine.Debug.Log(errorMessage);
#endif
            }

            processor = new FaceProcessorLive<WebCamTexture>();
            processor.Initialize(faces.text, eyes.text, shapes.bytes);

            // data stabilizer - affects face rects, face landmarks etc.
            processor.DataStabilizer.Enabled = true;        // enable stabilizer
            processor.DataStabilizer.Threshold = 2.0;       // threshold value in pixels
            processor.DataStabilizer.SamplesCount = 2;      // how many samples do we need to compute stable data

            // performance data - some tricks to make it work faster
            processor.Performance.Downscale = 256;          // processed image is pre-scaled down to N px by long side
            processor.Performance.SkipRate = 0;             // we actually process only each Nth frame (and every frame for skipRate = 0)
        }

        /// <summary>
        /// Per-frame video capture processor
        /// </summary>
        protected override bool ProcessTexture(WebCamTexture input, ref Texture2D output)
        {
            // detect everything we're interested inマークを付ける
            processor.ProcessTexture(input, TextureParameters);

            // mark detected objects線や枠の追加
            //processor.MarkDetected();

            // processor.Image now holds data we'd like to visualize画面に映像を表示
            output = Unity.MatToTexture(processor.Image, output);   // if output is valid texture it's buffer will be re-used, otherwise it will be re-created

            //追加点↓

            if (processor.Faces.Count > 0)
            {
                var TR = processor.Faces[0].Region.TopRight;
                var TL = processor.Faces[0].Region.TopLeft;
                var BR = processor.Faces[0].Region.BottomRight;
                var BL = processor.Faces[0].Region.BottomLeft;
                var Ce = processor.Faces[0].Region.Center;
                text_x = TR.X;
                text_y = TR.Y;
                //UnityEngine.Debug.Log(text_x);
                //UnityEngine.Debug.Log(text_y);
            }

            //var de = Center.GetType();

            //Ce.Y = processor.Height - Ce.Y;

            //Debug.Log(Ce);

            //↑

            return true;
        }

    }
}
