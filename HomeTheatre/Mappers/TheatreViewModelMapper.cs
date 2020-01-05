﻿using HomeTheatre.Data.DbModels;
using HomeTheatre.Mappers.Contract;
using HomeTheatre.Models.Theatre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Mappers
{
    public class TheatreViewModelMapper : IViewModelMapper<Theatre, TheatreViewModel>
    {
        public TheatreViewModel MapFrom(Theatre entity)
        {
            if (entity == null)
            {
                throw new Exception("There is no Theatre in the parameters given");
            }
            return new TheatreViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                AboutInfo = entity.AboutInfo,
                Location = entity.Location,
                Phone = entity.Phone,

            };
        }

        public ICollection<TheatreViewModel> MapFrom(ICollection<Theatre> Entities)
        {
            return Entities.Select(this.MapFrom).ToList();
        }

        public Theatre MapFrom(TheatreViewModel entityVM)
        {
            if (entityVM == null)
            {
                throw new Exception("There was no ViewModel found");
            }
            return new Theatre
            {
                Id = entityVM.Id,
                Name = entityVM.Name,
                AboutInfo = entityVM.AboutInfo,
                Location = entityVM.Location,
                Phone = entityVM.Phone,
            };
        }

        public ICollection<Theatre> MapFrom(ICollection<TheatreViewModel> entitiesVM)
        {
            return entitiesVM.Select(this.MapFrom).ToList();
        }
    }
}
