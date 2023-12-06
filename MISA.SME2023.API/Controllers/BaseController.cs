using Microsoft.AspNetCore.Mvc;
using MISA.SME2023.BL;

namespace MISA.SME2023.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        #region Field

        private readonly IBaseBL<T> _baseBL;

        #endregion

        #region Contructor

        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Get Methods

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] string? keyword, [FromQuery] int? limit, [FromQuery] int? offset)
        {
            return StatusCode(StatusCodes.Status200OK, await _baseBL.GetAllAsync(keyword, limit, offset));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            return StatusCode(StatusCodes.Status200OK, await _baseBL.GetByIdAsync(id));
        }

        #endregion


        #region Post Methods

        [HttpPost]
        public virtual async Task<IActionResult> AddAsync([FromBody] T entity)
        {
            return StatusCode(StatusCodes.Status201Created, await _baseBL.AddAsync(entity));
        }

        [HttpPost("MultipleCreate")]
        public async Task<IActionResult> AddMultipleAsync([FromBody] IEnumerable<T> entities)
        {
            return StatusCode(StatusCodes.Status201Created, await _baseBL.AddMultipleAsync(entities));
        }

        #endregion

        #region Update Methods

        [HttpPut]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] T entity)
        {
            return StatusCode(StatusCodes.Status200OK, await _baseBL.UpdateAsync(entity));
        }

        [HttpPut("MultipleUpdate")]
        public async Task<IActionResult> UpdateMultipleAsync([FromBody] IEnumerable<T> entities)
        {
            return StatusCode(StatusCodes.Status200OK, await _baseBL.UpdateMultipleAsync(entities));
        }

        #endregion

        #region Delete Methods

        [HttpDelete]
        public virtual async Task<IActionResult> DeleteAsync([FromBody] T entity)
        {
            return StatusCode(StatusCodes.Status200OK, await _baseBL.DeleteAsync(entity));
        }

        [HttpDelete("MultipleDelete")]
        public async Task<IActionResult> DeleteMultipleAsync([FromBody] IEnumerable<T> entities)
        {
            return StatusCode(StatusCodes.Status200OK, await _baseBL.DeleteMultipleAsync(entities));
        }

        #endregion
    }
}
