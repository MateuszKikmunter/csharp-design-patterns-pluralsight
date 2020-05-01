using MediatR;
using MediatRDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MediatRDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentException(nameof(mediator));
        }

        [HttpGet("{id}")]
        public async Task<Contact> GetContact([FromRoute] Query query) => await _mediator.Send(query);
    }

    #region Nested Classes

    public class Query : IRequest<Contact>
    {
        public int Id { get; set; }
    }

    public class ContactHandler : IRequestHandler<Query, Contact>
    {
        private readonly ContactsDbContext _contactsDbContext;

        public ContactHandler(ContactsDbContext contactsDbContext)
        {
            _contactsDbContext = contactsDbContext ?? throw new ArgumentException(nameof(contactsDbContext));
        }

        public Task<Contact> Handle(Query request, CancellationToken cancellationToken)
        {
            return _contactsDbContext.Contacts.Where(c => c.Id == request.Id).SingleOrDefaultAsync();
        }
    }

    #endregion
}