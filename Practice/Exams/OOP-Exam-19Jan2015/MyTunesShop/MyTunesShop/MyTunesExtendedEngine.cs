namespace MyTunesShop
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MyTunesExtendedEngine : MyTunesEngine
    {
        protected override void ExecuteRateCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song":
                    var song = this.media.FirstOrDefault(s => s is Song && s.Title == commandWords[2]) as Song;
                    if (song != null)
                    {
                        int rating = int.Parse(commandWords[3]);

                        if (song.Ratings == null)
                        {
                            song.Ratings = new List<int>();
                        }

                        song.PlaceRating(rating);
                        this.Printer.PrintLine("The rating has been placed successfully.");
                    }
                    else
                    {
                        throw new ArgumentException("The song must be rateable.");
                    }
                    break;
                default:
                    base.ExecuteRateCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song_to_album":
                    var album = this.media.FirstOrDefault(m => m is IAlbum && m.Title == commandWords[2]) as IAlbum;
                    var song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[3]) as ISong;

                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                    }

                    if (song == null)
                    {
                        this.Printer.PrintLine("The song does not exist in the database.");
                    }

                    album.AddSong(song);
                    this.Printer.PrintLine(string.Format("The song {0} has been added to the album {1}.", song.Title, album.Title));

                    break;
                case "member_to_band":
                    var band = this.performers.FirstOrDefault(b => b is IBand && b.Name == commandWords[2]) as IBand;

                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                    }
                    string memeberName = commandWords[3];
                    band.AddMember(memeberName);
                    this.Printer.PrintLine(string.Format("The member {0} has been added to the band {1}.", memeberName, band.Name));
                    break;

                default:
                    base.ExecuteInsertCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = new Band(commandWords[3]);
                    this.InsertPerformer(band);
                    break;
                default:
                    base.ExecuteInsertPerformerCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    var performer = this.performers.FirstOrDefault(p => p.Name == commandWords[5]);
                    if (performer == null)
                    {
                        this.Printer.PrintLine("The performer does not exist in the database.");
                        return;
                    }

                    string title = commandWords[3];
                    decimal price = decimal.Parse(commandWords[4]);
                    string genre = commandWords[6];
                    int year = int.Parse(commandWords[7]);

                    Album album = new Album(title, price, performer, genre, year);
                    this.InsertAlbum(album);
                    break;
                default:
                    base.ExecuteInsertMediaCommand(commandWords);
                    break;

            }
        }

        protected override void ExecuteSupplyCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Supply(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully supplied.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSupplyCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSellCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Sell(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully sold.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSellCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    var album = this.media.FirstOrDefault(s => s is IAlbum && s.Title == commandWords[3]) as IAlbum;
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetAlbumReport(album));
                    break;

                default:
                    base.ExecuteReportMediaCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteReportPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    var band = this.performers.FirstOrDefault(b => b is IBand && b.Name == commandWords[3]) as IBand;
                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                        return;
                    }

                    this.Printer.PrintLine(this.GetBandReport(band));
                    break;

                default:
                    base.ExecuteReportPerformerCommand(commandWords);
                    break;
            }
        }

        protected override string GetSongReport(ISong song)
        {
            var songSalesInfo = this.mediaSupplies[song];
            StringBuilder songInfo = new StringBuilder();
            songInfo.AppendFormat("{0} ({1}) by {2}", song.Title, song.Year, song.Performer.Name).AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", song.Genre, song.Price).AppendLine()
                .AppendFormat("Rating: {0}", this.AverageRatingCalculator(song as Song)).AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", songSalesInfo.Supplies, songSalesInfo.QuantitySold);
            return songInfo.ToString();
        }

        protected string GetAlbumReport(IAlbum album)
        {
            var albumSalesInfo = this.mediaSupplies[album];
            StringBuilder albumInfo = new StringBuilder();

            albumInfo.AppendFormat("{0} ({1}) by {2}", album.Title, album.Year, album.Performer.Name).AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", album.Genre, album.Price).AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", albumSalesInfo.Supplies, albumSalesInfo.QuantitySold).AppendLine();

            StringBuilder songInfo = new StringBuilder();

            if (album.Songs.Any())
            {
                songInfo.AppendFormat("Songs:").AppendLine();
                for (int i = 0; i < album.Songs.Count(); i++)
                {
                    songInfo.AppendFormat("{0} ({1:F2})", album.Songs[i].Title, album.Songs[i].Duration);

                    if (i != album.Songs.Count() - 1)
                    {
                        songInfo.AppendLine();
                    }
                }
            }
            else
            {
                songInfo.Append("No songs");
            }

            albumInfo.Append(songInfo);

            return albumInfo.ToString();
        }

        protected string GetBandReport(IBand band)
        {
            StringBuilder bandInfo = new StringBuilder();

            bandInfo.Append(band.Name).Append(":");

            StringBuilder bandMembersInfo = new StringBuilder();
            if (band.Members.Any())
            {
                bandMembersInfo.AppendFormat(" {0}", string.Join(", ", band.Members));
            }

            bandInfo.AppendLine(bandMembersInfo.ToString());

            StringBuilder bandSongsInfo = new StringBuilder();
            if (band.Songs.Any())
            {
                var sortedBandSongs = band.Songs.OrderBy(s => s.Title);

                for (int i = 0; i < sortedBandSongs.Count(); i++)
                {
                    bandSongsInfo.Append(sortedBandSongs.ElementAt(i).Title);

                    if (i != sortedBandSongs.Count() - 1)
                    {
                        bandSongsInfo.Append("; ");
                    }
                }
            }
            else
            {
                bandSongsInfo.Append("no songs");
            }

            bandInfo.Append(bandSongsInfo);
            return bandInfo.ToString();
        }

        private double AverageRatingCalculator(Song song)
        {
            if (song.Ratings == null)
            {
                return 0;
            }

            return Math.Round(song.Ratings.Average(), MidpointRounding.AwayFromZero);
        }

        private void InsertAlbum(Album album)
        {
            this.media.Add(album);
            this.mediaSupplies.Add(album, new SalesInfo());
            this.Printer.PrintLine("Album {0} by {1} added successfully", album.Title, album.Performer.Name);
        }
    }
}