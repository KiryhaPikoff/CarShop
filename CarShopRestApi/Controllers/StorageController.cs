using CarShopBuisnessLogic.BindingModels;
using CarShopBuisnessLogic.Interfaces;
using CarShopBuisnessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CarShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StorageController : ControllerBase
    {
        private readonly IStorageLogic _storageLogic;

        public StorageController(IStorageLogic storageLogic)
        {
            _storageLogic = storageLogic;
        }

        [HttpGet]
        public List<StorageViewModel> GetStorages() => _storageLogic.Read(null);

        [HttpGet]
        public StorageViewModel GetStorage(int StorageId) => _storageLogic.Read(new StorageBindingModel
        {
            Id = StorageId
        }).FirstOrDefault();

        [HttpPost]
        public void CreateOrUpdateStorage(StorageBindingModel model) => _storageLogic.CreateOrUpdate(model);

        [HttpPost]
        public void DeleteStorage(StorageBindingModel model) => _storageLogic.Delete(model);

        [HttpPost]
        public void AddComponentOnStorage(AddComponentBindingModel model) => _storageLogic.AddComponent(model);
    }
}