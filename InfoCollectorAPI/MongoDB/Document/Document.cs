﻿using MongoDB.Bson;

namespace InfoCollectorAPI.MongoDB.Document
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt => Id.CreationTime;

    }
}
