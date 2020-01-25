//using HomeTheatre.Data.DbModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace HomeTheatre.Services.Utility
//{
//    public class SearchTheatreMapper
//    {
//        public SearchTheatre MapFrom(Theatre entity)
//        {
//            if (entity == null)
//            {
//                throw new Exception("The entity is null");
//            }

//            return new SearchTheatre
//            {
//                Id = entity.Id,
//                Name = entity.Name,
//                Location = entity.Location,
//                AverageRating = entity.AverageRating,
//                Phone=entity.Phone
//            };
//        }

//        public ICollection<SearchTheatre> MapFrom(ICollection<Theatre> entities)
//        {
//            return entities.Select(this.MapFrom).ToList();
//        }
//    }
//}
