﻿using AutoMapper;
using CoreTest.Data;
using CoreTest.Data.Entities;
using CoreTest.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTest.Controllers
{
    [Route("/api/orders/{orderid}/items")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderItemsController : Controller
    {
        private readonly ICoreRepository _repository;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(
            ICoreRepository repository,
            ILogger<OrderItemsController> logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }  
        
        public IActionResult Get(int orderId)
        {
            var order = _repository.GetOrderById(User.Identity.Name, orderId);
            if(order != null)
            {
                return Ok(_mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            var order = _repository.GetOrderById(User.Identity.Name, orderId);
            if (order != null)
            {
                var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
                if(item != null)
                {
                    return Ok(_mapper.Map<OrderItem,OrderItemViewModel>(item));
                }
               
            }
            return NotFound();
        }
    }
}
