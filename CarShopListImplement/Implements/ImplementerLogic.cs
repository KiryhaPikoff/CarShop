using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using CarShopListImplement.Models;
using System;
using System.Collections.Generic;

namespace CarShopListImplement.Implements
{
    public class ImplementerLogic : IImplementerLogic
    {
        private readonly DataListSingleton source;
        public ImplementerLogic()
        {
            source = DataListSingleton.GetInstance();
        }

        public void CreateOrUpdate(ImplementerBindingModel model)
        {
            Implementer tempImplementer = model.Id.HasValue ? null : new Implementer
            {
                Id = 1
            };
            foreach (var implementer in source.Implementers)
            {
                if (implementer.ImplementerFIO == model.ImplementerFIO && implementer.Id != model.Id)
                {
                    throw new Exception("Уже есть испольнитель с таким ФИО");
                }
                if (!model.Id.HasValue && implementer.Id >= tempImplementer.Id)
                {
                    tempImplementer.Id = implementer.Id + 1;
                }
                else if (model.Id.HasValue && implementer.Id == model.Id)
                {
                    tempImplementer = implementer;
                }
            }

            if (model.Id.HasValue)
            {
                if (tempImplementer == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, tempImplementer);
            }
            else
            {
                source.Implementers.Add(CreateModel(model, tempImplementer));
            }
        }

        public void Delete(ImplementerBindingModel model)
        {
            for (int i = 0; i < source.Implementers.Count; ++i)
            {
                if (source.Implementers[i].Id == model.Id.Value)
                {
                    source.Implementers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        public List<ImplementerViewModel> Read(ImplementerBindingModel model)
        {
            List<ImplementerViewModel> result = new List<ImplementerViewModel>();
            foreach (var implementer in source.Implementers)
            {
                if (model != null)
                {
                    if (model.Id.HasValue && implementer.Id == model.Id)
                    {
                        result.Add(CreateViewModel(implementer));
                        break;
                    }
                    continue;
                }
                result.Add(CreateViewModel(implementer));
            }
            return result;
        }

        private Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.ImplementerFIO = model.ImplementerFIO;
            implementer.PauseTime = model.PauseTime;
            implementer.WorkingTime = model.WorkingTime;
            return implementer;
        }

        private ImplementerViewModel CreateViewModel(Implementer implementer)
        {
            return new ImplementerViewModel
            {
                Id = implementer.Id,
                ImplementerFIO = implementer.ImplementerFIO,
                PauseTime = implementer.PauseTime,
                WorkingTime = implementer.WorkingTime
            };
        }
    }
}
