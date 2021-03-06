﻿using System;
using System.Linq;
using FotM.Domain;

namespace FotM.ArmoryScanner
{
    public class ArmoryPuller: IArmoryPuller
    {
        private readonly Uri _baseAddress;

        public ArmoryPuller(Uri apiRoot, string locale = Locale.EnUs)
        {
            _baseAddress = new Uri(apiRoot, "api/wow");
        }

        public Leaderboard DownloadLeaderboard(Bracket bracket, string locale = Locale.EnUs)
        {
            string bracketString = null;

            switch (bracket)
            {
                case Bracket.Twos:
                    bracketString = "2v2";
                    break;
                case Bracket.Threes:
                    bracketString = "3v3";
                    break;
                case Bracket.Fives:
                    bracketString = "5v5";
                    break;
                case Bracket.Rbg:
                    bracketString = "rbg";
                    break;
            }

            if (string.IsNullOrEmpty(bracketString))
            {
                throw new ArgumentException("Bracket not found");
            }

            var uriBuilder = new UriBuilder(_baseAddress);
            uriBuilder.Path += "/leaderboard/" + bracketString;
            uriBuilder.Query = "locale=" + locale;
            var rawJsonPuller = new RawJsonPuller(uriBuilder.Uri);

            // making results consistent as Blizzard randomly tosses around players with same rating
            var leaderboard = rawJsonPuller.DownloadJson<Leaderboard>();
            leaderboard.Bracket = bracket;
            leaderboard.Time = DateTime.Now;
            leaderboard.Order();

            return leaderboard;
        }
    }
}