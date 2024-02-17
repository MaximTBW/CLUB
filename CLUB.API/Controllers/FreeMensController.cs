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
    /// CRUD ���������� �� ������ � ������� �������
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = "FreeMens")]
    public class FreeMensController : ControllerBase
    {
        private readonly IFreeMenService freeMensService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// �������������� ����� ��������� <see cref="FreeMensController"/>
        /// </summary>
        public FreeMensController(IFreeMenService FreeMenService,
            IMapper mapper, IApiValidatorService validatorService)
        {
            this.freeMensService = FreeMenService;
            this.validatorService = validatorService;
            this.mapper = mapper;
        }

        /// <summary>
        /// �������� ������ ���� ���������
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(FreeMenResp))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await freeMensService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<FreeMenResp>>(result));
        }

        /// <summary>
        /// �������� �������� �������� �� Id
        /// </summary>
        [HttpGet("{id}")]
        [ApiOk(typeof(FreeMenResp))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await freeMensService.GetByIdAsync(id, cancellationToken);
            if (item == null) return NotFound($"�� ������� ����� ���� � ��������������� {id}");
            return Ok(mapper.Map<FreeMenResp>(item));
        }

        /// <summary>
        /// ������ ������ ��������
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(FreeMenResp))]
        [ApiConflict]
        public async Task<IActionResult> Create(FreeMenReqCreate request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var FreeMensReqModel = mapper.Map<FreeMenReq>(request);
            var result = await freeMensService.AddAsync(FreeMensReqModel, cancellationToken);
            return Ok(mapper.Map<FreeMenResp>(result));
        }
        /// <summary>
        /// ����������� ������������� ��������
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(FreeMenResp))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(FreeMenReqEdit request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<FreeMenReq>(request);
            var result = await freeMensService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<FreeMenResp>(result));
        }


        /// <summary>
        /// ������� ������������� ��������
        /// </summary>
        [HttpDelete("{id}")]
        [ApiOk]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await freeMensService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
