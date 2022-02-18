/*
    Controller For Bill For CRUD Operations
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RepoTest.API.Data;
using RepoTest.API.Dtos;
using RepoTest.API.Models;

namespace RepoTest.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class  BillController: ControllerBase {
        private readonly IBillRepository repo;
        private readonly IMapper mapper;

        public BillController(IBillRepository billRepository, IMapper mapper){
            this.repo = billRepository;
            this.mapper = mapper;
        }
        [HttpGet("{id}")]
        [ActionName("GetBillById")]
        public async Task<ActionResult<BillReturnDtos>> GetBillById(int id){
            var bill = await repo.GetByIdAsync(id);
            if(bill == null){
                return NotFound();
            }
            return mapper.Map<BillReturnDtos>(bill);
        }
        [HttpPost]
        public async Task<ActionResult<BillReturnDtos>> CreatAsync(BillFormDtos billForm){
            if(billForm == null)
                return BadRequest();
            
            var bill = mapper.Map<Bill>(billForm);
            await repo.AddAsync(bill);

            var b1 = mapper.Map<BillReturnDtos>(bill);
            return CreatedAtAction("GetBillById", new {id = b1.Id}, b1);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BillReturnDtos>> UpdateAsync(int id, BillFormDtos billForm){
            if(billForm == null)
                return BadRequest();
            var newBill = mapper.Map<Bill>(billForm);
            return mapper.Map<BillReturnDtos>(await repo.UpdateAsync(id,newBill));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(int id){
            await repo.RemoveAsync(id);
            return Ok();
        }
    }
}