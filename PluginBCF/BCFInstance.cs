﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Xbim.BCF
{
    public class BCFInstance
    {
        public BCFInstance()
        {
            Markup = new Markup();
            Markup.Topic.Guid = guid;
        }

        public BCFInstance(string guid)
        {
            Markup = new Markup();
            Markup.Topic.Guid = guid;
        }

        public BitmapImage Img
        {
            get
            {
                return SnapShot;
            }
        }

        public string guid
        {
            get {
                return Markup.Topic.Guid;
            }
        }

        public Markup Markup { get; set; }
        public BitmapImage SnapShot { get; set; }
        public VisualizationInfo VisualizationInfo { get; set; }

        internal void SnapShotSaveToFile(string photolocation)
        {
            if (SnapShot == null)
                return;
            PngBitmapEncoder encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(SnapShot));

            using (var filestream = new FileStream(photolocation, FileMode.Create))
                encoder.Save(filestream);
        }
    }
}
