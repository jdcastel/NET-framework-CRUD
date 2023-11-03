using AutoMapper;
using JDRC2237A3.Data;
using JDRC2237A3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

// ************************************************************************************
// WEB524 Project Template V1 == 2237-022d12bf-21fa-4d5e-95e2-07787686bdf7
//
// By submitting this assignment you agree to the following statement.
// I declare that this assignment is my own work in accordance with the Seneca Academic
// Policy. No part of this assignment has been copied manually or electronically from
// any other source (including web sites) or distributed to other students.
// ************************************************************************************

namespace JDRC2237A3.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Product, ProductBaseViewModel>();
                cfg.CreateMap<Album, AlbumBaseViewModel>();
                cfg.CreateMap<Artist, ArtistBaseViewModel>();
                cfg.CreateMap<MediaType, MediaTypeBaseViewModel>();

                cfg.CreateMap<Track, TrackBaseViewModel>();
                cfg.CreateMap<Track, TrackWithDetailViewModel>();
                cfg.CreateMap<TrackAddViewModel, Track>();

                cfg.CreateMap<Playlist, PlaylistBaseViewModel>();
                cfg.CreateMap<PlaylistBaseViewModel, PlaylistEditTracksFormViewModel>();
                cfg.CreateMap<PlaylistEditTracksViewModel, PlaylistEditTracksFormViewModel>();
            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }


        // Add your methods below and call them from controllers. Ensure that your methods accept
        // and deliver ONLY view model objects and collections. When working with collections, the
        // return type is almost always IEnumerable<T>.
        //
        // Remember to use the suggested naming convention, for example:
        // ProductGetAll(), ProductGetById(), ProductAdd(), ProductEdit(), and ProductDelete().


        public IEnumerable<AlbumBaseViewModel> AlbumGetAll()
        {
            var query = ds.Albums
                          .OrderBy(x => x.Title);

            return mapper.Map<IEnumerable<Album>, IEnumerable<AlbumBaseViewModel>>(query);
        }

        public IEnumerable<ArtistBaseViewModel> ArtistGetAll()
        {
            var query = ds.Artists
                          .OrderBy(x => x.Name);

            return mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistBaseViewModel>>(query);
        }

        public IEnumerable<MediaTypeBaseViewModel> MediaTypeGetAll()
        {
            var query = ds.MediaTypes
                          .OrderBy(x => x.Name);

            return mapper.Map<IEnumerable<MediaType>, IEnumerable<MediaTypeBaseViewModel>>(query);
        }

        public IEnumerable<TrackWithDetailViewModel> TrackGetAllWithDetail()
        {
            var query = ds.Tracks
                          .OrderBy(x => x.Name)
                          .Include("Album.Artist")
                          .Include("MediaType");

            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetailViewModel>>(query);
        }

        public TrackWithDetailViewModel TrackGetById(int id)
        {
            var track = ds.Tracks.Include("Album.Artist")
                                 .Include("MediaType")
                                 .SingleOrDefault(i => i.TrackId == id);

            return track == null ? null : mapper.Map<Track, TrackWithDetailViewModel>(track);
        }

        public TrackWithDetailViewModel TrackAdd(TrackAddViewModel newTrack)
        {

            //if (newTrack != null)
            //{
            //    var newTrack = mapper.Map<Track, TrackWithDetailViewModel>(track);

            //    ds.Tracks.Add(newTrack);
            //    ds.SaveChanges();
            //}

            var album = ds.Albums.Find(newTrack.AlbumId);
            var mediaType = ds.MediaTypes.Find(newTrack.MediaTypeId);

            if (album == null && mediaType == null)
            {
                return null;
            }
            else
            {
                var addedItem = ds.Tracks.Add(mapper.Map<TrackAddViewModel, Track>(newTrack));

                addedItem.Album = album;
                addedItem.MediaType = mediaType;

                ds.SaveChanges();

                return (addedItem == null) ? null : mapper.Map<Track, TrackWithDetailViewModel>(addedItem);
            }
        }

        public IEnumerable<PlaylistBaseViewModel> PlaylistGetAll()
        {
            var query = ds.Playlists
                          .OrderBy(x => x.Name)
                          .Include("Tracks");

            return mapper.Map<IEnumerable<Playlist>, IEnumerable<PlaylistBaseViewModel>>(query);
        }

        public PlaylistBaseViewModel PlaylistGetById(int id)
        {
            var playlist = ds.Playlists.Include("Tracks")
                                       .FirstOrDefault(x => x.PlaylistId == id);
            return playlist != null ? mapper.Map<Playlist, PlaylistBaseViewModel>(playlist) : null;
        }

    //    public PlaylistEditTracksFormViewModel PlaylistEditTracks(PlaylistEditTracksViewModel newItem)
    //    {
    //        var playlist = ds.Playlists
    //                         .Include("Tracks")
    //                         .SingleOrDefault(x => x.PlaylistId == newItem.PlaylistId);

    //        if (playlist == null)
    //        {
    //            return null;
    //        }

    //        ds.Entry(playlist).Collection(p => p.Tracks).Load();

    //        playlist.Tracks.Clear();

    //        if (newItem.SelectedTrackIds != null && newItem.SelectedTrackIds.Any())
    //        {
    //            var selectedTracks = ds.Tracks.Where(x => newItem.SelectedTrackIds.Contains(x.TrackId)).ToList();
    //            foreach (var track in selectedTracks)
    //            {
    //                playlist.Tracks.Add(track); 
    //            }
    //        }

    //        ds.SaveChanges();

    //        return mapper.Map<Playlist, PlaylistEditTracksFormViewModel>(playlist);
    //    }

    }
}