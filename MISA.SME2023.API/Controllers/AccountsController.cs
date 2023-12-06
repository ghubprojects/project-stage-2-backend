using Microsoft.AspNetCore.Mvc;
using MISA.SME2023.BL;
using MISA.SME2023.Common;

namespace MISA.SME2023.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController<Account>
    {
        private readonly IAccountBL _accountBL;

        public AccountsController(IBaseBL<Account> baseBL, IAccountBL accountBL) : base(baseBL)
        {
            _accountBL = accountBL;
        }

        [HttpPost]
        public override async Task<IActionResult> AddAsync([FromBody] Account entity)
        {
            return StatusCode(StatusCodes.Status201Created, await _accountBL.AddAsync(entity));
        }

        [HttpPut]
        public override async Task<IActionResult> UpdateAsync([FromBody] Account entity)
        {
            return StatusCode(StatusCodes.Status200OK, await _accountBL.UpdateAsync(entity));
        }

        [HttpDelete]
        public override async Task<IActionResult> DeleteAsync([FromBody] Account entity)
        {
            return StatusCode(StatusCodes.Status200OK, await _accountBL.DeleteAsync(entity));
        }

        [HttpPut("UpdateInactive")]
        public async Task<IActionResult> UpdateInactiveAsync([FromBody] AccountUpdateInactiveDTO data)
        {
            return StatusCode(StatusCodes.Status200OK, await _accountBL.UpdateInactiveAsync(data.id, data.inactive, data.force_child));
        }
    }
}
