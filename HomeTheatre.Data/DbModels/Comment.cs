using HomeTheatre.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.DbModels
{
    public class Comment : IEntityId
    {
        public string Id { get; set; }

        public string CommentText { get; set; }

        public string Author { get; set; }

        public DateTime CommentedOn { get; set; }

        public Review Review { get; set; }
    }
}
