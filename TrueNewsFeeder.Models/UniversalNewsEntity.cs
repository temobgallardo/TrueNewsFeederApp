using Google.Cloud.Firestore;
using System;

namespace TrueNewsFeeder.Models
{
    [FirestoreData]
    public class UniversalNewsEntity
    {
        [FirestoreProperty]
        public string Title { get; set; }
        [FirestoreProperty]
        public string Description { get; set; }
        [FirestoreProperty]
        public string UrlToImage { get; set; }
        [FirestoreProperty]
        public string Content { get; set; }
        [FirestoreProperty]
        public string Source { get; set; }
        [FirestoreProperty]
        public string Url { get; set; }
        [FirestoreProperty]
        public DateTime PublishedAt { get; set; }
        [FirestoreProperty]
        public DateTime PublishedAtEnd { get; set; }
    }
}