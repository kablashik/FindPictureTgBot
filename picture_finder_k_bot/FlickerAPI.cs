namespace picture_finder_k_bot;
using FlickrNet;

public static class FlickrAPI
{
    private static readonly Flickr _flickr = new Flickr(Environment.GetEnvironmentVariable("FLICKER_TOKEN"));
    private static readonly Random _random = new Random();
    
    public static async Task<string> GetPhotoUrlAsync(string request)
    {
        var photoSearchOptions = new PhotoSearchOptions()
        {
            Text = request,
            SortOrder = PhotoSearchSortOrder.Relevance
        };

        PhotoCollection photoCollection = await _flickr.PhotosSearchAsync(photoSearchOptions);
        var photosList = photoCollection.ToList();

        if (photosList.Count() == 0)
        {
            return null;
        }

        var randomNumber = _random.Next(0, photosList.Count());
        return photosList[randomNumber].LargeUrl;
    }
}