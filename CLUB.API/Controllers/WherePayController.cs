using AutoMapper;
using CLUB.API.Attribute;
using CLUB.API.Infrastructures.Validator;
using CLUB.API.Models;
using CLUB.API.ModelsRequest;
using CLUB.SERVICES.CONTRACTS.Interface;
using CLUB.SERVICES.CONTRACTS.ModelRequest;
using Microsoft.AspNetCore.Mvc;

namespace CLUB.API.Controllers
{

    /// <summary>
    /// CRUD контроллер по работы с ключами доступа
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "WherePays")]
    public class WherePayController : ControllerBase
    {
        private readonly IWherePayService wherePayService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="WherePayController"/>
        /// </summary>
        public WherePayController(IWherePayService wherePayService,
            IMapper mapper, IApiValidatorService validatorService)
        {
            this.wherePayService = wherePayService;
            this.validatorService = validatorService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получает список всех мест оплаты
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(WherePayResp))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await wherePayService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<WherePayResp>>(result));
        }

        /// <summary>
        /// Получает описание места оплаты по Id
        /// </summary>
        [HttpGet("{id}")]
        [ApiOk(typeof(WherePayResp))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await wherePayService.GetByIdAsync(id, cancellationToken);
            if (item == null) return NotFound($"Не удалось найти ключ с идентификатором {id}");
            return Ok(mapper.Map<WherePayResp>(item));
        }

        /// <summary>
        /// Создаёт новое место оплаты
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(WherePayResp))]
        [ApiConflict]
        public async Task<IActionResult> Create(WherePayReqCreate request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var ClientReqModel = mapper.Map<WherePayModelReq>(request);
            var result = await wherePayService.AddAsync(ClientReqModel, cancellationToken);
            return Ok(mapper.Map<WherePayResp>(result));
        }
        /// <summary>
        /// Редактирует существующего место оплаты
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(WherePayResp))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(WherePayReqEdit request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<WherePayModelReq>(request);
            var result = await wherePayService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<WherePayResp>(result));
        }


        /// <summary>
        /// Удаляет существующего место оплаты
        /// </summary>
        [HttpDelete("{id}")]
        [ApiOk]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await wherePayService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
