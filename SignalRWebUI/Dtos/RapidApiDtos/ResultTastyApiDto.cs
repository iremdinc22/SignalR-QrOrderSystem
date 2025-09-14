namespace SignalRWebUI.Dtos.RapidApiDtos;

// Root DTO
//API’den gelen JSON verisinin en tepesinde (root seviyesinde) seni ilgilendiren liste tek başına dönmez, onun yanında başka alanlar da olur.
public class TastyListResponse
{
    public List<ResultTastyApiDto> Results { get; set; } 
}

public class ResultTastyApiDto
{
    public string Name { get; set; }
    public string original_video_url { get; set; }
    public int total_time_minutes { get; set; }
    public string thumbnail_url { get; set; }
}