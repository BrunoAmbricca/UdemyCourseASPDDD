
using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();

//await AddNewRecords();

QueryStreaming();

async Task TrackingAndNoTracking()
{
    var streamer = await dbContext.Streamers.FirstOrDefaultAsync(x => x.Id == 1);
    var streamer2 = await dbContext.Streamers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);
}

void QueryStreaming()
{
    var streamers = dbContext.Streamers.ToList();

    foreach(var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "disney",
        Url = "https://www.disney.com"
    };

    dbContext!.Streamers!.Add(streamer);

    await dbContext.SaveChangesAsync();

    var movies = new List<Video>
    {
        new Video
        {
            Nombre = "La Cenicienta",
            StreamerId = streamer.Id
        },
        new Video
        {
            Nombre = "1001 Dalmatas",
            StreamerId = streamer.Id
        },
        new Video
        {
            Nombre = "El jorobado de Notredame",
            StreamerId = streamer.Id
        },
        new Video
        {
            Nombre = "Star Wars",
            StreamerId = streamer.Id
        }
    };

    await dbContext!.Videos!.AddRangeAsync(movies);

    await dbContext!.SaveChangesAsync();
}