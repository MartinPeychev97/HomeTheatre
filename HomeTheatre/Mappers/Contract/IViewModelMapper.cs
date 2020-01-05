using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTheatre.Mappers.Contract
{
    public interface IViewModelMapper<Model, ViewModel>
    {
        ViewModel MapFrom(Model Entity);
        ICollection<ViewModel> MapFrom(ICollection<Model> Entities);
        Model MapFrom(ViewModel entityVM);
        ICollection<Model> MapFrom(ICollection<ViewModel> entitiesVM);
    }
}
