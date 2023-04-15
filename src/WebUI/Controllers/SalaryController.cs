using Application.IServices;
using Application.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUI.Extensions;
using WebUI.Models;

namespace WebUI.Controllers
{
    [Route("salaries")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryService _service;

        public SalaryController(ISalaryService service)
        {
            _service = service;
        }

        /// <summary>
        /// دریافت اطلاعات یک ماه فرد
        /// </summary>
        /// <param name="id">شناسه</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id) =>
           Ok(await _service.GetAsync(id));

        /// <summary>
        /// دریافت لیست اطلاعات یک فرد در محدوده زمانی پست شده
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("range")]
        public async Task<IActionResult> GetRangeAsync(RangeModel model) =>
           Ok(await _service.GetRangeAsync(model.FromDate,model.ToDate));

        /// <summary>
        /// افزودن اطلاعات یک ماه یک فرد
        /// </summary>
        /// <param name="datatype">0:Json, 1:Xml, 2:Cs, 3:Custom</param>
        /// <param name="model">مدل ورودی</param>
        /// <returns></returns>
        [HttpPost("/{datatype}/salaries")]
        public async Task<IActionResult> AddAsync(DataTypeEnum datatype,SalaryModel model)
        {
            var data = ConvertExtensions.ConvertToSalary(datatype, model.Data);
            await _service.AddAsync(data, model.OverTimeCalculator);
            return Ok();
        }

        /// <summary>
        /// ویرایش اطلاعات یک ماه یک فرد
        /// </summary>
        /// <param name="id">شناسه</param>
        /// <param name="datatype">0:Json, 1:Xml, 2:Cs, 3:Custom</param>
        /// <param name="model">مدل ورودی</param>
        /// <returns></returns>
        [HttpPut("/{datatype}/salaries/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, DataTypeEnum datatype, SalaryModel model)
        {
            var data = ConvertExtensions.ConvertToSalary(datatype, model.Data);
            await _service.UpdateAsync(id,data, model.OverTimeCalculator);
            return Ok();
        }

        /// <summary>
        /// حذف اطلاعات یک ماه یک فرد
        /// </summary>
        /// <param name="id">شناسه</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }

    }
}
