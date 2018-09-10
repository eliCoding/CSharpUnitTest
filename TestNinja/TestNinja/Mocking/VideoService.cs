using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TestNinja.Mocking;
using TestNinja.UnitTests.Mocking;


namespace TestNinja.Mocking
{
    public class VideoService
    {

        private IFileReader _fileReader;
        private IVideoRepository _repository;
        //DI via Constructor parameter
        public VideoService(IFileReader fileReader = null , IVideoRepository repository = null)
        {
            _fileReader = fileReader ?? new FileReader();
            // if we have s object reposotory we will use that otherwise we create new Object
            _repository = repository ?? new VideoRepository();
        }



        public string ReadVideoTitle()
        {
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            //var videos = new VideoRepository().GetUnprocessedVideos();
            var videos = _repository.GetUnprocessedVideos();
            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }

    
}