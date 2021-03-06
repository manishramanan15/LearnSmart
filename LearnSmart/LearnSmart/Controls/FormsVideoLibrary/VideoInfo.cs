﻿using LearnSmart.Controls.FormsVideoLibrary;

namespace LearnSmart.Controls.FormsVideoLibrary
{
    public class VideoInfo
    {
        public string DisplayName { set; get; }

        public VideoSource VideoSource { set; get; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
