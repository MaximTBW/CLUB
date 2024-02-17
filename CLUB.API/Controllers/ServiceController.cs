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
    [ApiExplorerSettings(GroupName = "Services")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService serviceService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ServiceController"/>
        /// </summary>
        public ServiceController(IServiceService clientsService,
            IMapper mapper, IApiValidatorService validatorService)
        {
            this.serviceService = clientsService;
            this.validatorService = validatorService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Получает список всех услуг
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(ServiceResp))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await serviceService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<ServiceResp>>(result));
        }

        /// <summary>
        /// Получает услугу по Id
        /// </summary>
        [HttpGet("{id}")]
        [ApiOk(typeof(ServiceResp))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await serviceService.GetByIdAsync(id, cancellationToken);
            if (item == null) return NotFound($"Не удалось найти ключ с идентификатором {id}");
            return Ok(mapper.Map<ServiceResp>(item));
        }

        /// <summary>
        /// Создаёт новую услугу
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(ServiceResp))]
        [ApiConflict]
        public async Task<IActionResult> Create(ServiceReqCreate request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var ClientReqModel = mapper.Map<ServiceModelReq>(request);
            var result = await serviceService.AddAsync(ClientReqModel, cancellationToken);
            return Ok(mapper.Map<ServiceResp>(result));
        }
        /// <summary>
        /// Редактирует существующую услугу
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(ServiceResp))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(ServiceReqEdit request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<ServiceModelReq>(request);
            var result = await serviceService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<ServiceResp>(result));
        }


        /// <summary>
        /// Удаляет существующую услугу
        /// </summary>
        [HttpDelete("{id}")]
        [ApiOk]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await serviceService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
