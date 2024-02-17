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
    [ApiExplorerSettings(GroupName = "WherePlases")]
    public class WherePlaceController : ControllerBase
    {
        private readonly IWherePlaceService wherePlaceService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="WherePlaceController"/>
        /// </summary>
        public WherePlaceController(IWherePlaceService wherePayService,
            IMapper mapper, IApiValidatorService validatorService)
        {
            this.wherePlaceService = wherePayService;
            this.validatorService = validatorService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получает список всех "рабочих" мест
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(WherePlaceResp))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await wherePlaceService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<WherePlaceResp>>(result));
        }

        /// <summary>
        /// Получает описание "рабочего" места по Id
        /// </summary>
        [HttpGet("{id}")]
        [ApiOk(typeof(WherePlaceResp))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await wherePlaceService.GetByIdAsync(id, cancellationToken);
            if (item == null) return NotFound($"Не удалось найти ключ с идентификатором {id}");
            return Ok(mapper.Map<WherePlaceResp>(item));
        }

        /// <summary>
        /// Создаёт нового "рабочего" места
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(WherePlaceResp))]
        [ApiConflict]
        public async Task<IActionResult> Create(WherePlaceReqCreate request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var ClientReqModel = mapper.Map<WherePlaceModelReq>(request);
            var result = await wherePlaceService.AddAsync(ClientReqModel, cancellationToken);
            return Ok(mapper.Map<WherePlaceResp>(result));
        }
        /// <summary>
        /// Редактирует существующего "рабочего" места
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(WherePlaceResp))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(WherePlaceReqEdit request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<WherePlaceModelReq>(request);
            var result = await wherePlaceService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<WherePlaceResp>(result));
        }


        /// <summary>
        /// Удаляет существующего "рабочего" места
        /// </summary>
        [HttpDelete("{id}")]
        [ApiOk]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await wherePlaceService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
