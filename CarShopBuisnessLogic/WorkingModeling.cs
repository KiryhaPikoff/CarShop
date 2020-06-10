using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Enums;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarShopBuisnessLogic
{
    public class WorkModeling
    {
        private readonly IImplementerLogic implementerLogic;
        private readonly IOrderLogic orderLogic;
        private readonly MainLogic mainLogic;
        private readonly Random rnd;

        public WorkModeling(IImplementerLogic implementerLogic, IOrderLogic orderLogic, MainLogic mainLogic)
        {
            this.implementerLogic = implementerLogic;
            this.orderLogic = orderLogic;
            this.mainLogic = mainLogic;
            rnd = new Random(1000);
        }
        /// <summary>
        /// Запуск работ
        /// </summary>
        public void DoWork()
        {
            var implementers = implementerLogic.Read(null);
            var orders = orderLogic.Read(new OrderBindingModel { FreeOrders = true });
            foreach (var implementer in implementers)
            {
                WorkerWorkAsync(implementer, orders);
            }
        }
        /// <summary>
        /// Иммитация работы исполнителя
        /// </summary>
        /// <param name="implementer"></param>
        /// <param name="orders"></param>
        private async void WorkerWorkAsync(ImplementerViewModel implementer, List<OrderViewModel> orders)
        {
            //сперва отрабатываются заказы со статусом «Выполняются»
            // ищем заказы, которые уже в работе (вдруг исполнителя прервали)
            var runOrders = await Task.Run(() => orderLogic.Read(new OrderBindingModel
            {
                ImplementerId = implementer.Id
            }));
            foreach (var order in runOrders)
            {
                // делаем работу заново
                Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                mainLogic.FinishOrder(new ChangeStatusBindingModel
                {
                    OrderId = order.Id
                });
                // отдыхаем
                Thread.Sleep(implementer.PauseTime);
            }

            // потом заказы со статусом «Требуются материалы» (вдруг материалы подвезли)
            var notEnoughMaterialsOrders = orderLogic.Read(new OrderBindingModel { 
                NotEnoughMaterialsOrders = true
            }); 
            orders.RemoveAll(x => notEnoughMaterialsOrders.Contains(x));
            this.DoWork(implementer, notEnoughMaterialsOrders);

            // и только потом новые заказы.
            await Task.Run(() =>
            {
                this.DoWork(implementer, orders);
            });
        }

        private void DoWork(ImplementerViewModel implementer, List<OrderViewModel> orders)
        {
       
            foreach (var order in orders)
            {
            // пытаемся назначить заказ на исполнителя
            try
                {
                    mainLogic.TakeOrderInWork(new ChangeStatusBindingModel
                    {
                        OrderId = order.Id,
                        ImplementerId = implementer.Id
                    });
                    Boolean isNotEnoughMaterials = orderLogic.Read(new OrderBindingModel
                    {
                        Id = order.Id
                    }).FirstOrDefault().Status == OrderStatus.Треубются_материалы;
                    if (isNotEnoughMaterials)
                    {
                        continue;
                    }
                    // делаем работу
                    Thread.Sleep(implementer.WorkingTime * rnd.Next(1, 5) * order.Count);
                        mainLogic.FinishOrder(new ChangeStatusBindingModel
                        {
                            OrderId = order.Id,
                            ImplementerId = implementer.Id
                        });
                    // отдыхаем
                    Thread.Sleep(implementer.PauseTime);
                    }
                    catch (Exception) { }
            }
        }
    }
}