using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Models;
using OrderManagement.ViewModels;

namespace OrderManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public HomeController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            var model = _orderRepository.GetAllOrders();
            return View(model);
        }

        public IActionResult Cook()
        {
            var model = _orderRepository.GetAllOrders();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(OrderCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Order newOrder = new Order
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Status = Status.Pending,
                    Table = model.Table,
                    FoodName = model.FoodName,
                    CreateDate = DateTime.Now
                };

                _orderRepository.Add(newOrder);
                return RedirectToAction("index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Order order = _orderRepository.GetOrder(id);
            OrderEditViewModel orderEditViewModel = new OrderEditViewModel
            {
                Id = order.Id,
                Name = order.Name,
                Surname = order.Surname,
                Table = order.Table,
                FoodName = order.FoodName
            };

            return View(orderEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(OrderEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Order order = _orderRepository.GetOrder(model.Id);
                order.Name = model.Name;
                order.Surname = model.Surname;
                order.Table = model.Table;
                order.FoodName = model.FoodName;

                _orderRepository.Update(order);
                return RedirectToAction("index");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            _orderRepository.Delete(id);
            return RedirectToAction("index");
        }

        public IActionResult Approve(int id)
        {
            Order order = _orderRepository.GetOrder(id);
            order.Status = Status.Approved;
            order.ApproveDate = DateTime.Now;

            _orderRepository.Update(order);
            return RedirectToAction("cook");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
