// Abstraction - Managing Different Media 
// You're part of a small team developing "TuneIn," a new personalized media streaming platform. TuneIn aims to provide users with a seamless experience for listening to songs, watching movies, and catching up on their favorite podcasts, all in one place. The platform needs to be flexible and easily extensible to support new media types in the future. 
// Design an abstract class called Media.  
// This class will serve as the blueprint for all types of media in the TuneIn platform.  
// Create three classes that inherit from the Media class: Song, Movie, and Podcast.  
// Each of these classes needs to provide a concrete implementation for the PlaySong. 

class TuneIn{
    public static void Main(){
        Song song= new Song();
        Movie movie= new Movie();
        Podcast podcast= new Podcast();


        song.PlayMedia();
        song.PauseMedia();
        song.StopMedia();

        movie.PlayMedia();
        movie.PauseMedia();
        movie.StopMedia();

        podcast.PlayMedia();
        podcast.PauseMedia();
        podcast.StopMedia();

        Media media= new Song();

        media.IncreaseVolume();
        media.DecreaseVolume();

        Console.WriteLine("\nAll methods ave been called.");
    }
}