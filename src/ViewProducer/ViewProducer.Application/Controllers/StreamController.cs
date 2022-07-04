using Microsoft.AspNetCore.Mvc;
using ViewProducer.Application.Dto;
using ViewProducer.Infrastruce; 

namespace ViewProducer.Application
{
    [Route("api/stream")]
    [ApiController]
    public class StreamController : ControllerBase
    {
        IStreamProducer _streamProducer;

        public StreamController(IStreamProducer streamProducer)
        {
            _streamProducer = streamProducer;
        }


        [HttpPost("bulk")]
        public IActionResult PostBody([FromForm] UploadModel uploadModel)
        {
            var sr = new StreamReader(uploadModel.File.OpenReadStream());
            while (!sr.EndOfStream)
            {
                var text = sr.ReadLine(); 
                _streamProducer.WriteToStream("productview", text);
            } 
            return Ok();
        }
        [HttpPost]
        public IActionResult PostBody(string streamData)
        { 
            _streamProducer.WriteToStream("productview", streamData);
            return Ok();
        }
    }
}