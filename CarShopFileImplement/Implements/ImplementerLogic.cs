using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopFileImplement.Implements
{
    public class ImplementerLogic : IImplementerLogic
    {
        private readonly FileDataListSingleton source;

        public ImplementerLogic()
        {
            source = FileDataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            Implementer implementer;
            if (model.Id.HasValue)
            {
                implementer = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
                if (implementer == null)
                {
                    throw new Exception("Элемент не найден");
                }
            }
            else
            {
                int maxId = source.Implementers.Count > 0 ? source.Implementers.Max(rec => rec.Id) : 0;
                implementer = new Implementer { Id = maxId + 1 };
                source.Implementers.Add(implementer);
            }
            implementer.ImplementerFIO = model.ImplementerFIO;
            implementer.PauseTime = model.PauseTime;
            implementer.WorkingTime = model.WorkingTime;
        }

        public void Delete(ImplementerBindingModel model)
        {
            Implementer implementer = source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (implementer != null)
            {
                source.Implementers.Remove(implementer);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            return source.Implementers
            .Where(rec => model == null || rec.Id == model.Id)
            .Select(rec => new ImplementerViewModel
            {
                Id = rec.Id,
                ImplementerFIO = rec.ImplementerFIO,
                PauseTime = rec.PauseTime,
                WorkingTime = rec.WorkingTime
            })
            .ToList();
        }
    }
}
