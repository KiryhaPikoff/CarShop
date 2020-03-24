using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarShopBuisnessLogic
{
    public class StorageService
    {

        private readonly ICarLogic carLogic;

        private readonly IStorageLogic storageLogic;

        public StorageService(ICarLogic carLogic, IStorageLogic storageLogic)
        {
            this.carLogic = carLogic;
            this.storageLogic = storageLogic;
        }

        public void WriteOffComponentsFromStorage(OrderViewModel order)
        {
            // Получаем компоненты из этого заказа
            Dictionary<int, (string, int)> components = this.getNeededCarComponentsFromOrder(order);
            // Если они все есть на складах
            if (checkComponentsExistenceOnStorages(components) == true)
            {
                // То списваем их
                foreach (KeyValuePair<int, (string, int)> component in components)
                {
                    this.writeOffComponentFromStorages(component);
                }
            }
            else
            {
                throw new Exception("На складе отсутствуют необходимые компоненты. Попробуйте позже.");
            }
        }

        /// <summary>
        /// Метод осуществляющий проверку необходимых компонентов на складах
        /// </summary>
        /// <param name="components"></param>
        /// <returns></returns>
        private bool checkComponentsExistenceOnStorages(Dictionary<int, (string, int)> components)
        {
            bool existAllComponents = true;
            List<StorageViewModel> storages = storageLogic.Read(null);
            // Проход по каждому компоненту, который необходим для заказа
            foreach (KeyValuePair<int, (string, int)> component in components)
            {
                // Если такого компонента меньше чем требуется то выходим из цикла и метода с false
                if (this.getComponentCountOnStorages(component) < component.Value.Item2)
                {
                    existAllComponents = false;
                    break;
                }
            }
            return existAllComponents;
        }

        /// <summary>
        /// Метод вытаскивающий компоненты из заказа, которые необходимо списать
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private Dictionary<int, (string, int)> getNeededCarComponentsFromOrder(OrderViewModel order)
        {
            Dictionary<int, (string, int)> dictComponents = carLogic.Read(new CarBindingModel
            {
                Id = order.CarId
            }
            )[0].CarComponents;
            return dictComponents;
        }

        /// <summary>
        /// Метод возвращающий общее количество компонента на всех складах
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        private int getComponentCountOnStorages(KeyValuePair<int, (string, int)> component)
        {
            int componentCount = 0;
            List<StorageViewModel> storages = storageLogic.Read(null);
            foreach (StorageViewModel storage in storages)
            {
                int tempCount = storage.StorageComponents
                    .Where(stc => stc.Key == component.Key)
                    .Select(stc => stc.Value.Item2)
                    .FirstOrDefault();

                componentCount += tempCount;
            }
            return componentCount;
        }

        /// <summary>
        /// Метод который списывает компонент со склада(ов)
        /// </summary>
        /// <param name="component"></param>
        private void writeOffComponentFromStorages(KeyValuePair<int, (string, int)> component)
        {
            List<StorageViewModel> storages = storageLogic.Read(null);
            int toWriteOff = component.Value.Item2;
            for (int i = 0; i < storages.Count; i++)
            {
                StorageViewModel storage = storages.ElementAt(i);
                Dictionary<int, (string, int)> storageComponents = storage.StorageComponents;
                KeyValuePair<int, (string, int)> storageComponent = storageComponents
                    .Where(stc => stc.Key == component.Key)
                    .FirstOrDefault();
                Dictionary<int, (string, int)> storageComponentsDict = new Dictionary<int, (string, int)>();
                if (storageComponent.Key == component.Key)
                {
                    if (storageComponent.Value.Item2 <= toWriteOff)
                    {
                        toWriteOff -= storageComponent.Value.Item2;
                        storageComponent = new KeyValuePair<int, (string, int)>(storageComponent.Key, (storageComponent.Value.Item1, 0));
                    }
                    else
                    {
                        storageComponent = new KeyValuePair<int, (string, int)>(storageComponent.Key, (storageComponent.Value.Item1, storageComponent.Value.Item2 - toWriteOff));
                    }
                    storageComponents.Remove(storageComponent.Key);
                    storageComponents.Add(storageComponent.Key, (storageComponent.Value.Item1, storageComponent.Value.Item2));
                }
                storageLogic.CreateOrUpdate(new StorageBindingModel
                {
                    Id = storage.Id,
                    StorageName = storage.StorageName,
                    StorageComponents = storageComponents
                });
            }
        }
    }
}