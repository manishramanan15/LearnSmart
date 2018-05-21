using System;

namespace LearnSmart.Controls.FormsVideoLibrary
{ 
    public interface IVideoPlayerController
    {
        VideoStatus Status { set; get; }

        TimeSpan Duration { set; get; }
    }
}
