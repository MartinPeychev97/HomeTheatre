using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Models.Comment
{
    public class CommentIndexViewModel
    {
        public int? PrevPage { get; set; }

        public int CurrPage { get; set; }

        public int? NextPage { get; set; }

        public int TotalPages { get; set; }

        public ICollection<CommentViewModel> CommentModels { get; set; }
    }
}
