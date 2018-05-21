using System;
using System.Threading.Tasks;

namespace LearnSmart.Controls.FormsVideoLibrary
{
    public interface IVideoPicker
    {
        Task<string> GetVideoFileAsync();
    }
}
