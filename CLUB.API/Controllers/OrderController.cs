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
    [ApiExplorerSettings(GroupName = "Orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IApiValidatorService validatorService;
        private readonly IMapper mapper;

        /// <summary>
        /// �������������� ����� ��������� <see cref="OrderController"/>
        /// </summary>
        public OrderController(IOrderService OrderService,
            IMapper mapper, IApiValidatorService validatorService)
        {
            this.orderService = OrderService;
            this.validatorService = validatorService;
            this.mapper = mapper;
        }

        /// <summary>
        /// �������� ������ ���� �������
        /// </summary>
        [HttpGet]
        [ApiOk(typeof(OrderResp))]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var result = await orderService.GetAllAsync(cancellationToken);
            return Ok(mapper.Map<IEnumerable<OrderResp>>(result));
        }

        /// <summary>
        /// �������� ����� �� Id
        /// </summary>
        [HttpGet("{id}")]
        [ApiOk(typeof(OrderResp))]
        [ApiNotFound]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var item = await orderService.GetByIdAsync(id, cancellationToken);
            if (item == null) return NotFound($"�� ������� ����� ���� � ��������������� {id}");
            return Ok(mapper.Map<OrderResp>(item));
        }

        /// <summary>
        /// ������ ����� �����
        /// </summary>
        [HttpPost]
        [ApiOk(typeof(OrderResp))]
        [ApiConflict]
        public async Task<IActionResult> Create(OrderReqCreate request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var OrderReqModel = mapper.Map<OrderReq>(request);
            var result = await orderService.AddAsync(OrderReqModel, cancellationToken);
            return Ok(mapper.Map<OrderResp>(result));
        }
        /// <summary>
        /// ����������� ������������ �����
        /// </summary>
        [HttpPut]
        [ApiOk(typeof(OrderResp))]
        [ApiNotFound]
        [ApiConflict]
        public async Task<IActionResult> Edit(OrderReqEdit request, CancellationToken cancellationToken)
        {
            await validatorService.ValidateAsync(request, cancellationToken);

            var model = mapper.Map<OrderReq>(request);
            var result = await orderService.EditAsync(model, cancellationToken);
            return Ok(mapper.Map<OrderResp>(result));
        }


        /// <summary>
        /// ������� ������������ �����
        /// </summary>
        [HttpDelete("{id}")]
        [ApiOk]
        [ApiNotFound]
        [ApiNotAcceptable]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await orderService.DeleteAsync(id, cancellationToken);
            return Ok();
        }
    }
}
