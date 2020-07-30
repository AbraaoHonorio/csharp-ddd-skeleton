using FluentValidation;
using XPTO.Core.Bus;
using XPTO.Core.Domain;
using XPTO.Core.DomainNotification;

namespace XPTO.Product.Application.Command.Handler
{
    public class BaseHandler
    {

        public BaseHandler(IDomainNotification domainNotification, IMediatrHandler mediatorHandler)
        {
            _domainNotification = domainNotification;
            _mediatorHandler = mediatorHandler;
        }

        private readonly IDomainNotification _domainNotification;
        private readonly IMediatrHandler _mediatorHandler;

        protected void Notify(FluentValidation.Results.ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                var notifier = new DomainNotifier(error.ErrorMessage);

                _domainNotification.Handle(notifier);
                _mediatorHandler.PublishNotification(notifier);
            }
        }

        protected void Notify(string mensagem)
        {
            _domainNotification.Handle(new DomainNotifier(mensagem));
        }

        protected bool ValidateObject<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : class
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}
